using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Models.Sabre;
using Models.DTO;
using BOL = BusinessObjectLayer;

namespace HttpServices.Helpers
{
    public class ReadData
    {
        public string GetSearchHits(RequestResourceModels _bfmxRequest)
        {
            string result = "";
            try
            {
                /*=== Check Hits  ===*/
                BOL.GetSetData.SearchHits objSearchHits = new BOL.GetSetData.SearchHits();
                string currentip = _bfmxRequest.ClientIP.ToString();
                if (_bfmxRequest.UserRoleId == "8" || _bfmxRequest.UserRoleId == "0")
                {
                    string searchhits = string.Empty;
                    string selectionname = _bfmxRequest.SelectionName;
                    List<Parameter> lstParms = new List<Parameter>();
                    lstParms.Add(new Parameter
                    {
                        Name = "IP",
                        Value = currentip,
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new Parameter
                    {
                        Name = "Des",
                        Value = _bfmxRequest.OriginDestinationInformation[0].DestinationLocation.LocationCode,
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new Parameter
                    {
                        Name = "Dep",
                        Value = _bfmxRequest.OriginDestinationInformation[0].OriginLocation.LocationCode,
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new Parameter
                    {
                        Name = "DepDate",
                        Value = Convert.ToDateTime(_bfmxRequest.OriginDestinationInformation[0].DepartureDateTime),
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new Parameter
                    {
                        Name = "ArrDate",
                        Value = selectionname == "2" ? Convert.ToDateTime(_bfmxRequest.OriginDestinationInformation[1].DepartureDateTime) : Convert.ToDateTime(_bfmxRequest.OriginDestinationInformation[0].DepartureDateTime),
                        TypeOfData = Types.DataTypes.String.ToString()
                    });

                    objSearchHits.Parameters = lstParms;
                    if (selectionname == "2")
                    {
                        searchhits = objSearchHits.GetSearchHits();
                    }
                    else if (selectionname == "1")
                    {
                        searchhits = objSearchHits.GetSearchHits();
                    }
                    if (searchhits.ToLower() == "searchblocked")
                    {
                        result = "searchblocked";
                    }
                }
                /*=== End Check Hits  ===*/

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
            return result;
        }
        public string GetAuthToken(RequestResourceModels _bfmxRequest)
        {
            string token = string.Empty;
            try
            {
                BOL.GetSetData.AuthTokens objAT = new BOL.GetSetData.AuthTokens();
                List<Parameter> lstParms = new List<Parameter>();

                lstParms.Add(new Parameter
                {
                    Name = "CompanyId",
                    Value = _bfmxRequest.CompanyId,
                    TypeOfData = Types.DataTypes.Int.ToString()
                });

                lstParms.Add(new Parameter
                {
                    Name = "CompanyTypeId",
                    Value = _bfmxRequest.CompanyTypeId,
                    TypeOfData = Types.DataTypes.Int.ToString()
                });
                objAT.Parameters = lstParms;
                token = objAT.GetAuthTokens();

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
            return token;

        }

        public string GetRequestResponse(RequestResourceModels _bfmxRequest, string _reqResType)
        {
            string result = string.Empty;
            try
            {
                BOL.GetSetData.SearchRequestResponse objSRR = new BOL.GetSetData.SearchRequestResponse();
                List<Parameter> lstParams = new List<Parameter>();
                lstParams.Add(new Parameter
                {
                     Name= "Departure",
                     Value= _bfmxRequest.OriginDestinationInformation[0].OriginLocation.LocationCode,
                     TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParams.Add(new Parameter
                {
                    Name = "Destination",
                    Value = _bfmxRequest.OriginDestinationInformation[0].DestinationLocation.LocationCode,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParams.Add(new Parameter
                {
                    Name = "DepartureDate",
                    Value = _bfmxRequest.OriginDestinationInformation[0].DepartureDateTime,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                if (_bfmxRequest.OriginDestinationInformation.Count > 0)
                {
                    lstParams.Add(new Parameter
                    {
                        Name = "ReturnDate",
                        Value = _bfmxRequest.OriginDestinationInformation[1].DepartureDateTime,
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                }
                    lstParams.Add(new Parameter
                    {
                        Name = "Airline",
                        Value = _bfmxRequest.Airline != null ? _bfmxRequest.Airline : "",
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                lstParams.Add(new Parameter
                {
                    Name = "Class",
                    Value = _bfmxRequest.TravelPreferences.CabinPref[0].Cabin,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                foreach (var item in _bfmxRequest.PassengerTypeQuantity)
                {
                    lstParams.Add(new Parameter
                    {
                        Name = item.Code == "C07" ? "Children" : item.Code == "INF" ? "Infants" : "Adults",
                        Value = item.Quantity,
                        TypeOfData = Types.DataTypes.Int.ToString()
                    });
                }
                
                lstParams.Add(new Parameter
                {
                    Name = "DirectFlights",
                    Value = _bfmxRequest.DirectFlightsOnly,
                    TypeOfData = Types.DataTypes.Bool.ToString()
                });
                lstParams.Add(new Parameter
                {
                    Name = "TripType",
                    Value = _bfmxRequest.SelectionName == "R" ? 2 : _bfmxRequest.SelectionName == "O" ? 1 : _bfmxRequest.SelectionName == "M" ? 3 : 2,
                    TypeOfData = Types.DataTypes.Int.ToString()
                });
                objSRR.Parameters = lstParams;
                objSRR.ReqResType = _reqResType;
               result =  objSRR.GetRequestResponse();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Types.ProjectNames.HttpServices.ToString(),
                    SolutionName = "HttpServices"
                };
                objDbErr.AddErrorLog();
            }
            return result;
        }

        public CompanyDetails GetCompanyDetails(string _domainname, int _companytypeid, string _clientrequestid, string _authtoken)
        {
            CompanyDetails cd = new CompanyDetails();
            try
            {
                BOL.GetSetData.CompanyDetails objCompanyDetails = new BOL.GetSetData.CompanyDetails();
                    List<Parameter> lstParms = new List<Parameter>();
                    lstParms.Add(new Parameter
                    {
                        Name = "DomainName",
                        Value = _domainname,
                        TypeOfData = Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new Parameter
                    {
                        Name = "CompanyTypeId",
                        Value = _companytypeid,
                        TypeOfData = Types.DataTypes.Int.ToString()
                    });
                lstParms.Add(new Parameter
                {
                    Name = "ClientRequestId",
                    Value = _clientrequestid,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "AuthToken",
                    Value = _authtoken,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                objCompanyDetails.Parameters = lstParms;

                cd = objCompanyDetails.GetCompanyDetails();

            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }

            return cd;
        }
        public CompanyDetails GetCompanyValidate(Parameter _parameters)
        {
            BOL.GetSetData.ValidateCompany objVC = new BOL.GetSetData.ValidateCompany();
            List<Parameter> lstParms = new List<Parameter>();
            CompanyDetails cd = new CompanyDetails();
            try
            {
                lstParms.Add(new Parameter
                {
                    Name = "DomainName",
                    Value = _parameters.DomainName,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "Token",
                    Value = _parameters.Token,
                    TypeOfData = Types.DataTypes.String.ToString()
                });

                objVC.Parameters = lstParms;
                cd = objVC.GetCompanyValidate();
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
            return cd;
        }
    }
}