using Models.DTO;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class AirPortsAirlines
    {
        static AirPortsAirlines()
        {

        }

        public static List<Airports> GetAirports(List<Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            List<Airports> lstAirport = new List<Airports>();
            using (DataSet ds = er.CallStoredProcedure("usp_GetAirports", _parameters, "Conn_CommonDB"))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstAirport.Add(new Airports
                        {
                            CityName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["Name"].ToString().Trim().ToLower() + "-" + row["City"].ToString().Trim().ToLower()) + ", " + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToUpper(row["State"].ToString().ToLower()) + ", " + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["countryname"].ToString().ToLower()) + " - [" + System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToUpper(row["IATACode"].ToString()) + "]",
                            CountryName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["CountryName"].ToString().ToLower()),
                            StateName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToUpper(row["country"].ToString().ToLower()),
                            City = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["City"].ToString().Trim().ToLower()),
                            IATACode = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["citycode"].ToString().Trim().ToLower()),
                            Name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["Name"].ToString().Trim().ToLower()),
                            Id = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(row["IATACode"].ToString().Trim().ToLower())
                        });
                    }
                }
            }
            return lstAirport;
        }
        public static List<Airlines> GetAirlines(List<Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            List<Airlines> lstAirport = new List<Airlines>();
            using (DataSet ds = er.CallStoredProcedure("usp_GetAllAirlines", _parameters, "Conn_AirDB"))
            {
                lstAirport.Add(new Airlines
                {
                    IATACode = "All",
                    AirlineName = "All"
                });
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstAirport.Add(new Airlines
                        {
                            IATACode = row[0].ToString(),
                            AirlineName = row[1].ToString() 
                        });
                    }
                }

            }
            return lstAirport;
        }
    }
}
