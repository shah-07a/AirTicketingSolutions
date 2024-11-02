using Models.Common;
using System;
using System.Net.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using PresentationLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                using (var client = new HttpClient())
                {
                   //=== client.BaseAddress = new Uri("http://localhost:49063/");
                    client.BaseAddress = new Uri("http://qa.nanojot.com/services/AirWebApi/api/");
                    CommonUtility appResponse = new CommonUtility();
                    dynamic responseTask = client.GetAsync("SearchRequest");
                    responseTask.Wait();
                    var RespanceResult = responseTask.Result.Content.ReadAsStringAsync();
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    jss.MaxJsonLength = Int32.MaxValue;
                    string jsonData = jss.Serialize(RespanceResult);        
                    var result = responseTask.Result;
                    ViewBag.SearchResponse= result;
                }
                
            }
            catch (Exception ex)
            {
                string errMsg = ex.Message;
                ViewBag.SearchResponse = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public ActionResult DisplayQuotes()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetQuotes(SearchRequestModel model)
        {
            ViewBag.Response = "This is a test";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
