using GlobalDistributionSystem;
using HttpServices.Helpers;
using Models.Common;
using Models.DTO;
using Models.Sabre.JsonModels.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BOL = BusinessObjectLayer;
using EF = Models.Sabre.JsonModels.Response;

namespace HttpServices.Controllers
{
    public class BargainFinderMaxRQController : ApiController
    {
        [HttpGet]
        [Route("test")]
        public string test()
        {
            string a = "rafiq";
            string b = a;
            return b;
        }
        
        [HttpPost]
        [Route("SearchRequest")]
        public CommonUtility BfmxRequest(Models.Common.SearchRequestModel _searchRequest)
        {
            CommonUtility appResponse;
            string st = _searchRequest.SearchType;
            string currenturl = _searchRequest.ReferrerUrl;
            string requestidtype = "P";
            if (currenturl.Contains("qa.nanojot.com"))
            {
                requestidtype = "Q";
            }
            else if (currenturl.Contains("test.nanojot.com"))
            {
                requestidtype = "U";
            }
            else if (currenturl.Contains("localhost"))
            {
                requestidtype = "L";
            }
            else
            {
                requestidtype = "P";
            }
            List<ProcessingTime> lstprocstime = new List<ProcessingTime>();
            ProcessingTime procstime = new ProcessingTime();
            
            procstime.ProcessName = "Generate Request Id";
            procstime.StartTime = DateTime.Now.ToString();
            
            string requestId = requestidtype + "-" + Base.AppLogs.RandomString();
            Base.AppLogs.ErrorsLogInstance.RequestID = requestId;

            procstime.RequestId = requestId;
            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);
                       
            Helpers.ReadData readdata = new ReadData();

            procstime = new ProcessingTime();
            procstime.ProcessName = "Get Company Details";
            procstime.RequestId = requestId;
            procstime.StartTime = DateTime.Now.ToString();
            CompanyDetails companyDetails = readdata.GetCompanyDetails(_searchRequest.DomainName, Convert.ToInt32(_searchRequest.CompanyTypeId), _searchRequest.ClientRequestId, _searchRequest.AuthToken);
            if(companyDetails == null)
            {
                appResponse = new CommonUtility
                {
                    Message = "Search failed.",
                    Status = false
                };
                return appResponse;
            }

            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);
            Helpers.CreateData cd = new CreateData();
            EF.SearchResponseBaseModelJson searchResponse = new EF.SearchResponseBaseModelJson();
            
            string iatacode = GetAirportCode(_searchRequest.Departure).ToUpper();
            #region Search Request Generate
            procstime = new ProcessingTime();
            procstime.ProcessName = "Creat BFMX Request Object";
            procstime.RequestId = requestId;
            procstime.StartTime = DateTime.Now.ToString();
            Models.Sabre.RequestResourceModels bfmxRequest = null;
            string priceditincount = "100ITINS";
            if (_searchRequest.CompanyTypeId == "1")
            {
                priceditincount = "50ITINS";
            }
            
            if(companyDetails.LoggedInUser.UserRoleId == 0 || companyDetails.LoggedInUser.UserRoleId == 8)
            {
                companyDetails.IsNetInclude = false;
                companyDetails.IsTourNetInclude = false;
            }
            if(string.IsNullOrEmpty(_searchRequest.Airline))
            {
                _searchRequest.Airline = "All";
            }
            bfmxRequest = new Models.Sabre.RequestResourceModels
            {
                CompanyTypeId = Convert.ToInt32(_searchRequest.CompanyTypeId),
                CompanyId = Convert.ToInt32(_searchRequest.DefaultCompanyId),
                IsAuthenticated = true,
                ClientIP = _searchRequest.ClientRequestId,
                UserRoleId = _searchRequest.LoggedInUser.UserRoleId.ToString(),
                SelectionName = _searchRequest.SearchType,
                CurrentUrl = _searchRequest.ReferrerUrl,
                Limit = "50",
                ValidInterlineTicket = true,
                ReqTypeName = priceditincount,
                PseudoCityCode = companyDetails.PseudoCityCode,
                CurrencyCode = companyDetails.CurrencyCode,
                PublicFareInd = true,
                PrivateFareInd = true,
                DirectFlightsOnly = Convert.ToBoolean(_searchRequest.DirectOnly == "OFF" ? false : true),
                IsDirectFlight = Convert.ToBoolean(_searchRequest.DirectOnly == "OFF" ? false : true),
                OriginDestinationInformation = GetOriginDestinationInformation(_searchRequest),
                Sources = new List<Source> { new Source
                    {
                        RequestorID = new RequestorID
                        {
                            ID = "REQ.ID",
                            Type = "0.AAA.X",
                            CompanyName = new CompanyName
                            {
                                Code = "TN"
                            }
                        },
                        PseudoCityCode = companyDetails.PseudoCityCode
                    }
                    },
                TravelPreferences = GetTravelPreferences(companyDetails.IsNetInclude, companyDetails.IsTourNetInclude, Convert.ToInt32(_searchRequest.Adults), Convert.ToInt32(_searchRequest.Children), Convert.ToInt32(_searchRequest.Infants), _searchRequest.FareType, _searchRequest.Airline),
                PassengerTypeQuantity = GetPassengerTypeQuantity(Convert.ToInt32(_searchRequest.Adults), Convert.ToInt32(_searchRequest.Children), Convert.ToInt32(_searchRequest.Infants))

            };
            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);
            #endregion

            
            try
            {

                if ((bfmxRequest.CompanyTypeId == 1) && (bfmxRequest.IsAuthenticated == false))
                {
                    appResponse = new CommonUtility
                    {
                        Message = "Authentication Required",
                        Status = false
                    };
                   return appResponse;
                }
                /*=== Validate Search Hits ===*/
                Helpers.ReadData dr = new Helpers.ReadData();
                procstime = new ProcessingTime();
                procstime.ProcessName = "Get Search Hits";
                procstime.RequestId = requestId;
                procstime.StartTime = DateTime.Now.ToString();
                string searchhits = dr.GetSearchHits(bfmxRequest);
                procstime.EndTime = DateTime.Now.ToString();
                lstprocstime.Add(procstime);
                if (searchhits.ToLower() == "searchblocked")
                {
                    appResponse = new CommonUtility
                    {
                        Message = "search denied",
                        Status = false
                    };
                    
                    return appResponse;
                }
                
                /*=== End of Validate Search Hits ===*/

                string jsonData = string.Empty, ServiceURL = string.Empty;
                

                /*=== Check saved response if any available ====*/
                procstime = new ProcessingTime();
                procstime.ProcessName = "Get Saved Response From Db";
                procstime.RequestId = requestId;
                procstime.StartTime = DateTime.Now.ToString();
                
                ReadData readData = new ReadData();
                jsonData = readData.GetRequestResponse(bfmxRequest, "res");

                procstime.EndTime = DateTime.Now.ToString();
                lstprocstime.Add(procstime);
                /*=== End of check saved response if any available ====*/

                
                
               
                if (bfmxRequest != null & string.IsNullOrEmpty(jsonData))
                {
                    cd = new CreateData();
                    procstime = new ProcessingTime();
                    procstime.ProcessName = "Create Request In Json Format";
                    procstime.StartTime = DateTime.Now.ToString();
                    procstime.RequestId = requestId;

                    string RequestContent = cd.CreateRequestInJsonFormat(bfmxRequest);
                    Task.Run(() =>
                    {
                        Base.AppLogs.RequestLogMessage(RequestContent, "Quote" + "RQ", requestId);
                    });
                    procstime.EndTime = DateTime.Now.ToString();
                    lstprocstime.Add(procstime);

                    ServiceURL = System.Configuration.ConfigurationManager.AppSettings["SabreServiceURL"].ToString();
                    procstime = new ProcessingTime();
                    procstime.ProcessName = "Get Auth Token";
                    procstime.StartTime = DateTime.Now.ToString();
                    procstime.RequestId = requestId;

                    string securitytoken = dr.GetAuthToken(bfmxRequest);

                    procstime.EndTime = DateTime.Now.ToString();
                    lstprocstime.Add(procstime);

                    Task.Run(() =>
                    {
                        Base.AppLogs.RequestLogMessage(securitytoken, "GetTokenFromDb" + "RS", requestId);
                    });
                    
                    if (string.IsNullOrEmpty(securitytoken))
                    {
                        appResponse = new CommonUtility
                        {
                            Message = "search denied",
                            Status = false
                        };
                        return appResponse;
                    }
                    procstime = new ProcessingTime();
                    procstime.ProcessName = "Get Response From Sabre";
                    procstime.StartTime = DateTime.Now.ToString();
                    procstime.RequestId = requestId;

                    appResponse = new GDSHttpClient().PostAsync(ServiceURL + "?mode=live&limit="+ bfmxRequest.Limit +"&offset=1", RequestContent, requestId, securitytoken);
                   
                    procstime.EndTime = DateTime.Now.ToString();
                    lstprocstime.Add(procstime);

                    Helpers.SaveData sd = null;
                    if (appResponse != null)
                    {
                        jsonData = appResponse.Data.Result;
                        string request = JsonConvert.SerializeObject(bfmxRequest);
                        bfmxRequest.RequestJson = request;
                        bfmxRequest.ResponseJson = jsonData;
                        sd = new SaveData();
                        Task.Run(() =>
                        {
                            Task.Run(() =>
                            {
                                Base.AppLogs.RequestLogMessage(jsonData, "Quotes" + "RS", requestId);
                            });
                            sd.AddSearchRequest(bfmxRequest, requestId);
                        });
                     }
                    /*=== Apply fare rules ===*/
                    FareRulesNew fr = new FareRulesNew();
                    int userId = 0;
                    if(_searchRequest.LoggedInUser.Id > 0)
                    {
                        userId = Convert.ToInt32(_searchRequest.LoggedInUser.Id);
                    }
                    int defaultCompanyId = 0;
                    int userRoleId = 0;
                    if(string.IsNullOrEmpty(_searchRequest.DefaultCompanyId) == false)
                    {
                        defaultCompanyId = Convert.ToInt32(_searchRequest.DefaultCompanyId);
                    }

                     userRoleId = Convert.ToInt32(_searchRequest.LoggedInUser.UserRoleId);

                    procstime = new ProcessingTime();
                    procstime.ProcessName = "Set Fare Rules";
                    procstime.RequestId = requestId;
                    procstime.StartTime = DateTime.Now.ToString();

                    Models.DTO.SearchResponseBaseModel filteredResponse = fr.SetFareRules(jsonData, requestId, _searchRequest.DomainName, userId, defaultCompanyId, userRoleId, companyDetails.DefaultInfantFare, Convert.ToBoolean(_searchRequest.DirectOnly == "OFF" ? false : true));
                    
                    procstime.EndTime = DateTime.Now.ToString();
                    lstprocstime.Add(procstime);
                    Task.Run(() =>
                    {
                        sd = new SaveData();
                        sd.AddProcessingTimes(lstprocstime);
                    });
                    /*=== End Apply fare rules ===*/
                    appResponse.Data = filteredResponse;
                    appResponse.IsCancellationDisplay = companyDetails.IsChangeCancelDisplay;
                    return appResponse;
                }
                else
                {
                    appResponse = new CommonUtility
                    {
                        Information = jsonData,
                        Message = "Response fetched from database",
                        Status = true
                    };
                    return appResponse;
                }
            }
            catch (Exception ex)
            {
                    BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                    {
                        Exception = ex,
                        ProjectName = Types.ProjectNames.HttpServices.ToString(),
                        SolutionName = "AirSolutions"
                    };
                    objDbErr.AddErrorLog();
            }
            appResponse = new CommonUtility
            {
                Message = "Not found",
                Status = false
            };
            return appResponse;
        }
        #region Private Methods
        private string GetAirportCode(string airportfullname_)
        {
            string iatacode = string.Empty;
            if(string.IsNullOrEmpty(airportfullname_) == false)
            {
                if(airportfullname_.IndexOf("[") > -1)
                {
                    iatacode = airportfullname_.Substring(airportfullname_.IndexOf("[")+1, 3);
                }
                else
                {
                    iatacode = airportfullname_;
                }
            }

            return iatacode;
        }

        private List<Models.Sabre.JsonModels.Request.CabinPref> GetCabinPref()
        {
           List<Models.Sabre.JsonModels.Request.CabinPref> lstCabinPref = new List<Models.Sabre.JsonModels.Request.CabinPref>();
            lstCabinPref.Add(new CabinPref
            {
                Cabin = "Y",
                PreferLevel = "Only"

            });
            return lstCabinPref;
        }
        private List<OriginDestinationInformation> GetOriginDestinationInformation(Models.Common.SearchRequestModel _searchRequest)
        {
            List<OriginDestinationInformation> lstOriginDestinationInformation = new List<OriginDestinationInformation>();
            Helpers.CreateData cd = new CreateData();
            if (_searchRequest.SearchType == "O")
            {
                lstOriginDestinationInformation.Add(new OriginDestinationInformation
                {
                    RPH = "1",
                    DepartureDateTime = _searchRequest.DepartureDate + "T" + cd.GetCurrentTime(),
                    OriginLocation = new OriginLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                    },
                    DestinationLocation = new DestinationLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                    }
                });

            }
            else if (_searchRequest.SearchType == "R")
            {
                lstOriginDestinationInformation.Add(new OriginDestinationInformation
                {
                    RPH = "1",
                    DepartureDateTime = _searchRequest.DepartureDate + "T" + cd.GetCurrentTime(),
                    OriginLocation = new OriginLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                    },
                    DestinationLocation = new DestinationLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                    }
                });
                lstOriginDestinationInformation.Add(new OriginDestinationInformation
                {
                    RPH = "2",
                    DepartureDateTime = _searchRequest.ReturnDate + "T" + cd.GetCurrentTime(),
                    OriginLocation = new OriginLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                    },
                    DestinationLocation = new DestinationLocation
                    {
                        LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                    }
                });
            }
            else if (_searchRequest.SearchType == "M")
            {
                if(_searchRequest.Departure1 != null && _searchRequest.Departure1.ToLower() == "xxx")
                {
                    _searchRequest.Departure1 = null;
                }
                if (_searchRequest.Departure2 != null && _searchRequest.Departure2.ToLower() == "xxx")
                {
                    _searchRequest.Departure2 = null;
                }
                if(_searchRequest.Destination1 != null && _searchRequest.Destination1.ToLower() == "xxx")
                {
                    _searchRequest.Destination1 = null;
                }
                if (_searchRequest.Destination2 != null && _searchRequest.Destination2.ToLower() == "xxx")
                {
                    _searchRequest.Destination2 = null;
                }
                if (_searchRequest.Departure != null && _searchRequest.Departure1 == null && _searchRequest.Departure2 == null)
                {
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "1",
                        DepartureDateTime = _searchRequest.DepartureDate + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                        }
                    });
                }
                else if (_searchRequest.Departure != null && _searchRequest.Departure1 != null && _searchRequest.Departure2 == null)
                {
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "1",
                        DepartureDateTime = _searchRequest.DepartureDate + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                        }
                    });
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "2",
                        DepartureDateTime = _searchRequest.DepartureDate1 + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure1).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination1).ToUpper()
                        }
                    });

                }
                else if (_searchRequest.Departure != null && _searchRequest.Departure1 != null && _searchRequest.Departure2 != null)
                {
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "1",
                        DepartureDateTime = _searchRequest.DepartureDate + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination).ToUpper()
                        }
                    });
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "2",
                        DepartureDateTime = _searchRequest.DepartureDate1 + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure1).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination1).ToUpper()
                        }
                    });
                    lstOriginDestinationInformation.Add(new OriginDestinationInformation
                    {
                        RPH = "3",
                        DepartureDateTime = _searchRequest.DepartureDate2 + "T" + cd.GetCurrentTime(),
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Departure2).ToUpper()
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = GetAirportCode(_searchRequest.Destination2).ToUpper()
                        }
                    });
                }
            }
            return lstOriginDestinationInformation;
        }
        private TravelPreferences GetTravelPreferences(bool isJCB, bool isITX, int adult, int child, int infant, string faretype, string airlineCode)
        {
            TravelPreferences travelPreferences = new TravelPreferences();
            travelPreferences.ValidInterlineTicket = true;
            TravelPreferencesTPA_Extensions travelPreferencesTPA_Extensions = new TravelPreferencesTPA_Extensions();
            travelPreferencesTPA_Extensions.LongConnectTime = new LongConnectTime
            {
                Enable = true,
                Min = 120,
                Max = 1439
            };
            travelPreferencesTPA_Extensions.LongConnectPoints = new LongConnectPoints
            {
                Min = 1,
                Max = 3
            };
            travelPreferencesTPA_Extensions.ExcludeCallDirectCarriers = new ExcludeCallDirectCarriers
            {
                Enabled = true
            };
            if (isJCB || isITX)
            {
                FlexibleFares flexibleFares = new FlexibleFares();
                List<FareParameters> lstFareParameters = new List<FareParameters>();
                if (isITX)
                {
                    lstFareParameters.Add(new FareParameters
                    {
                        PassengerTypeQuantity = GetFlexifareParameterPassengerTypeQuantity("ITX", adult, child, infant)
                    });
                }
                if (isJCB)
                {
                    lstFareParameters.Add(new FareParameters
                    {
                        PassengerTypeQuantity = GetFlexifareParameterPassengerTypeQuantity("JCB", adult, child, infant)
                    });
                }
                flexibleFares.FareParameters = lstFareParameters;
                travelPreferencesTPA_Extensions.FlexibleFares = flexibleFares;
            }
            List<CabinPref> lstCabinPref = new List<CabinPref>();
            lstCabinPref.Add(new CabinPref
            {
                Cabin = faretype.ToUpper(),
                PreferLevel = "Preferred"
            });

            travelPreferences.TPA_Extensions = travelPreferencesTPA_Extensions;
            travelPreferences.CabinPref = lstCabinPref;

            if(airlineCode != "All")
            {
                List<VendorPref> lstVendorPrefs = new List<VendorPref>();
                lstVendorPrefs.Add(new VendorPref
                {
                   Code = airlineCode,
                   PreferLevel = "Preferred"
                });
                travelPreferences.VendorPref = lstVendorPrefs;
            }
           
            return travelPreferences;
        }
           

     private List<FlexifareParameterPassengerTypeQuantity> GetFlexifareParameterPassengerTypeQuantity(string code, int adult, int child, int infant)
        {
            List<FlexifareParameterPassengerTypeQuantity> lstFlexifareParameterPassengerTypeQuantity = new List<FlexifareParameterPassengerTypeQuantity>();

            lstFlexifareParameterPassengerTypeQuantity.Add(new FlexifareParameterPassengerTypeQuantity
            {
                Code = code,
                Quantity = adult
            });
            if(child > 0)
            {
                if(code == "ITX")
                {
                    lstFlexifareParameterPassengerTypeQuantity.Add(new FlexifareParameterPassengerTypeQuantity
                    {
                        Code = "106",
                        Quantity = child
                    });
                }
                else if (code == "JCB")
                {
                    lstFlexifareParameterPassengerTypeQuantity.Add(new FlexifareParameterPassengerTypeQuantity
                    {
                        Code = "JNN",
                        Quantity = child
                     });
                }
            }
            if (infant > 0)
            {
                if (code == "ITX")
                {
                    lstFlexifareParameterPassengerTypeQuantity.Add(new FlexifareParameterPassengerTypeQuantity
                    {
                        Code = "101",
                        Quantity = infant
                    });
                }
                else if (code == "JCB")
                {
                    lstFlexifareParameterPassengerTypeQuantity.Add(new FlexifareParameterPassengerTypeQuantity
                    {
                        Code = "JNF",
                        Quantity = infant
                    });
                }
            }
            return lstFlexifareParameterPassengerTypeQuantity;
        }

        private List<PassengerTypeQuantity> GetPassengerTypeQuantity(int adult, int child, int infant)
        {
            List<PassengerTypeQuantity> lstPassengerTypeQuantities = new List<PassengerTypeQuantity>();
            lstPassengerTypeQuantities.Add(new PassengerTypeQuantity
            {
                Code = "ADT",
                Quantity = adult,
                TPA_Extensions = new PTQ_TPA_Extensions
                {
                    VoluntaryChanges = new VoluntaryChanges
                    {
                        Match = "Info"
                    }
                }
            });
            if(child > 0)
            {
                lstPassengerTypeQuantities.Add(new PassengerTypeQuantity
                {
                    Code = "C07",
                    Quantity = child,
                    TPA_Extensions = new PTQ_TPA_Extensions
                    {
                        VoluntaryChanges = new VoluntaryChanges
                        {
                            Match = "Info"
                        }
                    }
                });
            }
            if(infant > 0)
            {
                lstPassengerTypeQuantities.Add(new PassengerTypeQuantity
                {
                    Code = "INF",
                    Quantity = infant,
                    TPA_Extensions = new PTQ_TPA_Extensions
                    {
                        VoluntaryChanges = new VoluntaryChanges
                        {
                            Match = "Info"
                        }
                    }
                });
            }
            return lstPassengerTypeQuantities;
        }
        #endregion
    }
}
