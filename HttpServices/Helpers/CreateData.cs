using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using Models.Sabre;
using Models.Sabre.JsonModels.Request;
using Models.DTO;
using BOL = BusinessObjectLayer;
using Newtonsoft.Json;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace HttpServices.Helpers
{
    public class CreateData
    {
        public CreateData()
        {
            ///====
        }
        public string CreateRequestInJsonFormat(RequestResourceModels _bfmxRequest)
        {
            try
            {

                var objJson = new Models.Sabre.JsonModels.Request.OTA_AirLowFareSearchParent
                {
                    OTA_AirLowFareSearchRQ = new OTA_AirLowFareSearchRQ
                    {
                        POS = new POS
                        {
                            Source = _bfmxRequest.Sources
                        },
                        OriginDestinationInformation = _bfmxRequest.OriginDestinationInformation,
                        TravelPreferences = _bfmxRequest.TravelPreferences,
                        TravelerInfoSummary = new TravelerInfoSummary
                        {
                            AirTravelerAvail = new List<AirTravelerAvail> { new AirTravelerAvail
                            {
                                 PassengerTypeQuantity =  _bfmxRequest.PassengerTypeQuantity
                            }
                              }
                        },
                        TPA_Extensions = new TPA_Extensions
                        {
                            IntelliSellTransaction = new IntelliSellTransaction
                            {
                                RequestType = new RequestType
                                {
                                    Name = _bfmxRequest.ReqTypeName
                                }
                            }
                        }
                    },
                    AlternatePCC = new AlternatePCC
                    {
                        PseudoCityCode = _bfmxRequest.PseudoCityCode
                    },
                    PriceRequestInformation = new PriceRequestInformation
                    {
                        CurrencyCode = _bfmxRequest.CurrencyCode,
                        TPA_Extensions = new TPA_Extensions_1
                        {
                            Indicators = new Indicators
                            {
                                PublicFare = new PublicFare
                                {
                                    Ind = _bfmxRequest.PublicFareInd
                                }
                            },
                            PrivateFare = new PrivateFare
                            {
                                Ind = _bfmxRequest.PrivateFareInd
                            }
                        }
                    },
                    DirectFlightsOnly = _bfmxRequest.DirectFlightsOnly,
                    IsAuthenticated = _bfmxRequest.IsAuthenticated,
                    IsDirectFlight = _bfmxRequest.IsDirectFlight,
                    CompanyId = _bfmxRequest.CompanyId

                };
                var json = JsonConvert.SerializeObject(objJson, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
                return json.ToString();
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
            return "";
        }

        public string GetCurrentTime()
        {
            DateTime dt = DateTime.Now;
            string h = CheckTime(dt.Hour);
            string m = CheckTime(dt.Minute);
            string s = CheckTime(dt.Second);
            return h +":"+ m +":" + s;
        }
        #region Private Methods
        private string CheckTime(int time)
        {
            return (time < 10) ? "0" + time.ToString() : time.ToString();
        }
        private IList<OriginDestinationInformation> LstOriginDestinationInformation(IList<OriginDestinationInformation> _lstDepDesInfo)
        {
            List<OriginDestinationInformation> lstDOInfo = new List<OriginDestinationInformation>();
            try
            {
                foreach (var item in _lstDepDesInfo)
                {
                    lstDOInfo.Add(new OriginDestinationInformation
                    {
                        RPH = item.RPH,
                        DepartureDateTime = item.DepartureDateTime,
                        OriginLocation = new OriginLocation
                        {
                            LocationCode = item.OriginLocation.LocationCode
                        },
                        DestinationLocation = new DestinationLocation
                        {
                            LocationCode = item.DestinationLocation.LocationCode
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }

            
            return lstDOInfo;
        }
        private List<PassengerTypeQuantity> LstPassengerTypeQuantities(IList<PassengerTypeQuantity> _lstPassengerTypeQuantities)
        {
            List<PassengerTypeQuantity> lstPTQ = new List<PassengerTypeQuantity>();
            try
            {
                foreach (var item in _lstPassengerTypeQuantities)
                {
                    lstPTQ.Add(new PassengerTypeQuantity
                    {
                        Code = item.Code,
                        Quantity = item.Quantity,
                        TPA_Extensions = new PTQ_TPA_Extensions
                        {
                            VoluntaryChanges = new VoluntaryChanges
                            {
                                Match = item.TPA_Extensions.VoluntaryChanges.Match
                            }
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
            
            return lstPTQ;
        }
        private List<Source> LstSources(IList<Source> _lstSources)
        {
            List<Source> lstSource = new List<Source>();
            try
            {
                foreach (var item in _lstSources)
                {
                    lstSource.Add(new Source
                    {
                         RequestorID = new RequestorID
                         {
                             Type = item.RequestorID.Type,
                             ID = item.RequestorID.ID,
                             CompanyName = new CompanyName
                             {
                                  Code = "TN"
                             }
                         }
                    });
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }
            return lstSource;
        }

        private TravelPreferences TravelPreferences(TravelPreferences _travelPreferences)
        {
            TravelPreferences objTPf = new TravelPreferences();
            try
            {
                objTPf.ValidInterlineTicket = _travelPreferences.ValidInterlineTicket;
                objTPf.TPA_Extensions = new TravelPreferencesTPA_Extensions
                {
                    LongConnectTime = new LongConnectTime
                    {
                        Enable = _travelPreferences.TPA_Extensions.LongConnectTime.Enable,
                        Min = _travelPreferences.TPA_Extensions.LongConnectTime.Min,
                        Max = _travelPreferences.TPA_Extensions.LongConnectTime.Max
                    },
                    LongConnectPoints = new LongConnectPoints
                    {
                        Min = _travelPreferences.TPA_Extensions.LongConnectPoints.Min,
                        Max = _travelPreferences.TPA_Extensions.LongConnectPoints.Max
                    },
                    ExcludeCallDirectCarriers = new ExcludeCallDirectCarriers
                    {
                        Enabled = _travelPreferences.TPA_Extensions.ExcludeCallDirectCarriers.Enabled
                    },
                    FlexibleFares = new FlexibleFares
                    {
                        FareParameters = LstParameters(_travelPreferences.TPA_Extensions.FlexibleFares.FareParameters)
                    }
                    
                };
                
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
            }

            return objTPf;
        }

       private IList<FareParameters> LstParameters(IList<FareParameters> _parameters)
        {
            List<FareParameters> LstPM = new List<FareParameters>();
            foreach (var item in _parameters)
            {
                LstPM.Add(new FareParameters
                {
                  //===   PassengerTypeQuantity = LstFlexiFaresPassengerTypeQuantities(item.PassengerTypeQuantity.ToList())
                });
            }
            return LstPM;
        }
        private IList<PassengerTypeQuantity> LstFlexiFaresPassengerTypeQuantities(List<PassengerTypeQuantity> _passengerTypeQuantities)
        {
            List<PassengerTypeQuantity> lstPTQ = new List<PassengerTypeQuantity>();
            foreach (var item in _passengerTypeQuantities)
            {
                lstPTQ.Add(new PassengerTypeQuantity
                {
                     Code = item.Code,
                      Quantity = item.Quantity
                });
            }
            return lstPTQ;
        }
        private void ErrorLogging(Exception _excep)
        {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = _excep,
                    ProjectName = Types.ProjectNames.HttpServices.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
        }
        #endregion

    }
}