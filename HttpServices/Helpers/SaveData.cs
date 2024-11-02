using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.Sabre;
using Models.DTO;
using BOL = BusinessObjectLayer;
using System.Threading.Tasks;

namespace HttpServices.Helpers
{
    public class SaveData
    {
        public string AddSearchRequest(RequestResourceModels _bfmxRequest, string RequestID)
        {            
            try
            {
                List<Parameter> lstParms = new List<Parameter>();
                BOL.GetSetData.SearchRequestResponse objSR = new BOL.GetSetData.SearchRequestResponse();

                lstParms.Add(new Parameter
                {
                    Name = "RequestID",
                    Value = RequestID,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "Destination",
                    Value = _bfmxRequest.OriginDestinationInformation[0].DestinationLocation.LocationCode,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "Departure",
                    Value = _bfmxRequest.OriginDestinationInformation[0].OriginLocation.LocationCode,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "DepartureDate",
                    Value = _bfmxRequest.OriginDestinationInformation[0].DepartureDateTime,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "ReturnDate",
                    Value = _bfmxRequest.OriginDestinationInformation.Count > 1 ? _bfmxRequest.OriginDestinationInformation[1].DepartureDateTime  : _bfmxRequest.OriginDestinationInformation[0].DepartureDateTime,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "Airline",
                    Value = _bfmxRequest.Airline == null ? "All" : _bfmxRequest.Airline,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "Class",
                    Value = _bfmxRequest.AirClass,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                foreach (var item in _bfmxRequest.PassengerTypeQuantity)
                {
                    lstParms.Add(new Parameter
                    {
                        Name = item.Code == "C07" ? "Children" : item.Code == "INF" ? "Infants" : "Adults",
                        Value = item.Quantity,
                        TypeOfData = Types.DataTypes.Int.ToString()
                    });
                }
                                
                lstParms.Add(new Parameter
                {
                    Name = "DirectFlights",
                    Value = _bfmxRequest.IsDirectFlight,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "TripType",
                    Value = _bfmxRequest.SelectionName == "R" ? "2" : _bfmxRequest.SelectionName == "O" ? "1" : _bfmxRequest.SelectionName == "M" ? "3" : _bfmxRequest.SelectionName,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "CompanyId",
                    Value = _bfmxRequest.CompanyId,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "IPAddress",
                    Value = _bfmxRequest.ClientIP,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "RequestJson",
                    Value = _bfmxRequest.RequestJson,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "ResponseJson",
                    Value = _bfmxRequest.ResponseJson,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
               
                objSR.Parameters = lstParms;
                return objSR.Add();
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
                return "An Error Occoured";
            }
        }

        public string AddProcessingTimes(List<ProcessingTime> _processingTime)
        {
            try
            {
                BOL.GetSetData.ProcessingTime objPt = new BOL.GetSetData.ProcessingTime();
                objPt.ProcessingTimes = _processingTime;
                objPt.Add();
                return "Successfully Saved";
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
                return "An Error Occoured";
            }
        }
    }
}