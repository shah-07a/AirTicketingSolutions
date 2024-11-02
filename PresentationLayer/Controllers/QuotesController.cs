
using Models.Common;
using Models.Sabre.JsonModels.FilteredResponse;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using BOL = BusinessObjectLayer;
using ModelDTO = Models.DTO;
using System.Linq;
using PresentationLayer.Models.ViewModels;

namespace PresentationLayer.Controllers
{
    public class QuotesController : Controller
    {
        // GET: Quotes
        public ActionResult Index()
        {
            return View();
        }
              
        public ActionResult RedirectAndPost(string _authtoken)
        {
            SearchRequestModel model = new SearchRequestModel();
            try
            {
                model.RequestingClientInfo = _authtoken;
             
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.PresentationLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            return GetQuotes(model);
        }
        
        [HttpPost]
        public ActionResult GetQuotes(SearchRequestModel _model)
        {
            //===SearchRequestModel _model = new SearchRequestModel();
            List<ModelDTO.Airports> lstAirports = new List<ModelDTO.Airports>();
            List<ModelDTO.Airlines> lstAirlines = new List<ModelDTO.Airlines>();
            var model = new FilteredSearchResponse();
            int UserRoleId = _model.RequestingClientInfo.Split('|')[16] == "zero" ? 0 : Convert.ToInt32(_model.RequestingClientInfo.Split('|')[16]);
            try
            {
                if (_model.CompanyTypeId == "1" && _model.AuthToken == "invalidauthtoken")
                {
                    TempData["Model"] = _model;
                    TempData.Keep();
                    string returnurl = _model.RequestingClientInfo + "|" + Request.Url;
                    string urllogin = ConfigurationManager.AppSettings["UrlLogin"].ToString();
                    return Redirect(urllogin + "?returnUrl=" + returnurl);
                }

                string authtokenstring = string.Empty;
                if (_model.RequestingClientInfo.ToLower().IndexOf("validated") > -1)
                {
                    /*=== Note: authtokenstring index:-  0- AuthToken 1- Status 2- CompanyType ===*/
                    authtokenstring = _model.RequestingClientInfo;
                    _model = (SearchRequestModel)TempData["Model"];
                    _model.RequestingClientInfo.Replace(_model.RequestingClientInfo.Split('|')[4], authtokenstring.Split('|')[0]);
                    _model.AuthToken = authtokenstring.Split('|')[0];
                    UserRoleId = _model.LoggedInUser.UserRoleId;
                }
                if (string.IsNullOrEmpty(_model.ClientRequestId))
                {
                    return Redirect(_model.ReferrerUrl);
                }
                
               Task.Run(() =>
               {
                    BOL.GetSetData.AirPortsAirlines objAirports = new BOL.GetSetData.AirPortsAirlines();
                    List<ModelDTO.Parameter> lstParms = new List<ModelDTO.Parameter>();

                    lstParms.Add(new ModelDTO.Parameter
                    {
                        Name = "SearchText",
                        Value = "",
                        TypeOfData = ModelDTO.Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new ModelDTO.Parameter
                    {
                        Name = "DefaultCompanyId",
                        Value = _model.DefaultCompanyId,
                        TypeOfData = ModelDTO.Types.DataTypes.Int.ToString()
                    });
                    lstParms.Add(new ModelDTO.Parameter
                    {
                        Name = "UserRoleId",
                        Value = _model.LoggedInUser.UserRoleId,
                        TypeOfData = ModelDTO.Types.DataTypes.Int.ToString()
                    });
                    objAirports.Parameters = lstParms;
                    if (Session["Airports"] == null)
                    {
                        lstAirports = objAirports.GetAirports();
                    }

                    lstParms = new List<ModelDTO.Parameter>();

                    lstParms.Add(new ModelDTO.Parameter
                    {
                        Name = "DefaultCompanyId",
                        Value = _model.DefaultCompanyId,
                        TypeOfData = ModelDTO.Types.DataTypes.String.ToString()
                    });
                    lstParms.Add(new ModelDTO.Parameter
                    {
                        Name = "UserRoleId",
                        Value = _model.LoggedInUser.UserRoleId,
                        TypeOfData = ModelDTO.Types.DataTypes.Int.ToString()
                    });
                    objAirports.Parameters = lstParms;
                    if (Session["Airlines"] == null)
                    {
                        lstAirlines = objAirports.GetAirlines();
                    }
               });
                using (var client = new HttpClient())
                {
                    ModelDTO.ProcessingTime processingTime = new ModelDTO.ProcessingTime();
                    processingTime.StartTime = DateTime.Now.ToString();
                    processingTime.ProcessName = "Send Request and Get Response";
                    JavaScriptSerializer jss;
                    //===  client.BaseAddress = new Uri("http://localhost:49063/");
                    client.BaseAddress = new Uri("http://qa.nanojot.com/services/AirWebApi/api/");
                    jss = new JavaScriptSerializer();
                    string requestResource = jss.Serialize(_model);
                    dynamic responseTask = client.PostAsJsonAsync<SearchRequestModel>("SearchRequest", _model);
                    responseTask.Wait();

                    var ResponseResult = responseTask.Result.Content.ReadAsStringAsync();
                    jss = new JavaScriptSerializer();
                    jss.MaxJsonLength = Int32.MaxValue;
                    var jsonSettings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    QuoteViewModel qvm = new QuoteViewModel();
                    var searchResponse = JsonConvert.DeserializeObject<FilteredSearchResponse>(ResponseResult.Result, jsonSettings);
                    
                    var filteredResponse = qvm.GetFilteredQuotes((FilteredSearchResponse)searchResponse, _model.SearchType, lstAirlines, _model.FareType);
                    
                    List<ModelDTO.Airlines> lstDistinctAirlines = new List<ModelDTO.Airlines>();
                    lstDistinctAirlines = qvm.GetDistinctAirlines(lstAirlines, filteredResponse);
                    ViewBag.ResponseResult = qvm.CreateQuoteDisplay(filteredResponse, lstDistinctAirlines, UserRoleId, searchResponse.IsCancellationDisplay);
                    ViewBag.StopFilters = qvm.CreateStopFilter(filteredResponse);
                    ViewBag.PreferredAirlines = qvm.CreatePreferredAirlines(filteredResponse, lstDistinctAirlines);
                    ViewBag.DistinctAirlines = qvm.CreateGridOfDistinctAirlines(lstDistinctAirlines);
                    processingTime.EndTime = DateTime.Now.ToString();
                    ViewData["ProcessingTime"] = processingTime;
                    Session["FilteredResponse"] = null;
                    Session["FilteredResponse"] = filteredResponse;
                    ViewData["SearchType"] = _model.SearchType;
                 }

            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.PresentationLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            Session["LoginParameters"] = _model.RequestingClientInfo;
            if(Session["Airports"] == null)
            {
                Session["Airports"] = lstAirports;
            }
            if (Session["Airlines"] == null)
            {
                Session["Airlines"] = lstAirlines;
            }
            
            ViewData["DirectOnly"] = _model.DirectOnly.ToUpper();
            ViewBag.Airlines = Session["Airlines"];
            ViewData["FareType"] = _model.FareType;
            if(_model.SearchType == "R")
            {
                ViewData["AirlineText"] = _model.AirlineText;
                ViewData["AirlineVal"] = _model.Airline;
            }
            else if(_model.SearchType == "O")
            {
                ViewData["AirlineText"] = _model.OAirlineText;
                ViewData["AirlineVal"] = _model.Airline;
            }
            else
            {
                ViewData["AirlineText"] = _model.MAirlineText;
                ViewData["AirlineVal"] = _model.Airline;
            }
            return View("DisplayQuotes", model);
            
        }

        public JsonResult GetAirlines(string prefix)
        {
            List<ModelDTO.Airlines> lstAirlines = new List<ModelDTO.Airlines>();
            prefix = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(prefix);
            if (Session["Airports"] == null)
            {
                return null;
            }
            lstAirlines = (List<ModelDTO.Airlines>) Session["Airlines"];

            if (string.IsNullOrEmpty(prefix) == false)
            {
                if (prefix.Length > 2)
                {
                    var AirlinesList = (from al in lstAirlines
                                    where al.AirlineName.StartsWith(prefix)
                                    select new
                                    {
                                        label = al.AirlineName,
                                        val = al.IATACode
                                    }).ToList();
                    return Json(AirlinesList);
                }

                prefix = prefix.ToUpper();
                var AirlinesList1 = (from al in lstAirlines
                                 where al.IATACode.StartsWith(prefix)
                                 select new
                                 {
                                     label = al.AirlineName,
                                     val = al.IATACode
                                 }).ToList();
                return Json(AirlinesList1);
            }
            return null;
        }
        public JsonResult GetAirport(string prefix)
        {
            List<ModelDTO.Airports> lstAirport = new List<ModelDTO.Airports>();
            prefix = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(prefix);
            if (Session["Airports"] == null)
            {
                return null;
            }
            lstAirport = (List<ModelDTO.Airports>)Session["Airports"];



            if (string.IsNullOrEmpty(prefix) == false)
            {
                if (prefix.Length > 3)
                {
                    var CityList = (from ap in lstAirport
                                    where ap.CityName.StartsWith(prefix)
                                    select new
                                    {
                                        label = ap.CityName,
                                        val = ap.Id
                                    }).ToList();
                    return Json(CityList);
                }


                var CityList1 = (from ap in lstAirport
                                 where ap.Id.StartsWith(prefix)
                                 select new
                                 {
                                     label = ap.CityName,
                                     val = ap.Id
                                 }).ToList();
                return Json(CityList1);
            }
            return null;
        }
        [HttpGet]
        public ActionResult GetOutboundFlightDetails(string _sequencenumber, double _totalfare, string _validatingairline )
        {
            string id = _sequencenumber;
            if(Session["ResponseResult"] != null)
            {
                ViewBag.ResponseResult = Session["ResponseResult"];
                ViewData["SequenceNumber"] = _sequencenumber;
                ViewData["TotalFare"] = _totalfare;
                ViewData["ValidatingAirline"] = _validatingairline;

                return View("_FlightDetails", ViewBag.ResponseResult);
            }
            return View("_FlightDetails");
        }
        [HttpGet]
        public ActionResult GetInboundFlightDetails(string ItineraryId)
        {
            string id = ItineraryId;
            return View();
        }
        public string GetTest(string DisAirlies)
        {
            string response = string.Empty;
           if(DisAirlies != null )
            {
                List<ModelDTO.Airlines> lstAL = new List<ModelDTO.Airlines>();
                foreach (var al in DisAirlies.Split(','))
                {
                    lstAL.Add(new ModelDTO.Airlines
                    {
                        IATACode = al,
                        AirlineName = ""
                    });
                }
                if(lstAL.Count > 0)
                {
                    QuoteViewModel qvm = new QuoteViewModel();
                    if(Session["FilteredResponse"] != null)
                    {
                        var fr = (List<Models.FilteredQuotes>)Session["FilteredResponse"];
                        response = qvm.CreateQuoteDisplay(fr, lstAL,0,false);
                    }
                }
            }
            return response;
        }
    }
}
