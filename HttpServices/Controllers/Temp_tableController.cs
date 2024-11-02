using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BO = BusinessObjectLayer;
using Models.DTO;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace HttpServices.Controllers
{
    public class Temp_tableController : ApiController
    {
        public Temp_tableController()
        {

        }
        [HttpGet]
        [Route("api/Temp_table/data")]
        public IHttpActionResult AddData()
        {
            BO.Temp_table tempTable = new BO.Temp_table();
            string retVal;
            try
            {
                List<Models.DTO.Parameter> tt = new List<Models.DTO.Parameter>();
                tt.Add(new Models.DTO.Parameter
                {
                    Name = "AgencyName",
                    Value = "Qifar Infotech Solutions",
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                tt.Add(new Models.DTO.Parameter
                {
                    Name = "FirstName",
                    Value = "Rafiq Mohammad",
                    TypeOfData = Types.DataTypes.DateTime.ToString()
                });
                tt.Add(new Models.DTO.Parameter
                {
                    Name = "LastName",
                    Value = "Shah",
                    TypeOfData = Types.DataTypes.Double.ToString()
                });
                tt.Add(new Models.DTO.Parameter
                {
                    Name = "EmailId",
                    Value = "jindeshahmandar@gmail.com",
                    TypeOfData = Types.DataTypes.Int.ToString()
                });
                tt.Add(new Models.DTO.Parameter
                {
                    Name = "Phone",
                    Value = "9915617315",
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                retVal = tempTable.PostData(tt).ToString();
            }
            catch (Exception ex)
            {
                BO.DbErrorLogs el = new BO.DbErrorLogs
                {
                    ProjectName = Types.ProjectNames.HttpServices.ToString(),
                    Exception = ex,
                    SolutionName = "AirSolution"
                };
                el.AddErrorLog();
            }
            return Ok();
        }

        public IHttpActionResult CreateJson()
        {
            return Ok();
        }
    }
}
