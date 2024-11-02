using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MDL = Models.DTO;

namespace HttpServices.Controllers
{
    
    public class AccountController : ApiController
    {
        [HttpGet]
        public string Index()
        {
            return "Hello, I am Ok.";
        }
        
        [HttpPost]
        public MDL.CompanyDetails GetCompanyValidate(MDL.Parameter parameters)
        {
            Helpers.ReadData readdata = new Helpers.ReadData();
            MDL.CompanyDetails cd = new MDL.CompanyDetails();
            cd = readdata.GetCompanyValidate(parameters);
            return cd;
        }

    }
}
