using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MDL = Models.DTO;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class FareRules
    {
        public static  List<MDL.Markups> GetMarkups(List<MDL.Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            List<MDL.Markups> lstMarkups = new List<MDL.Markups>();
            using (DataSet ds = er.CallStoredProcedure("usp_GetMarkups", _parameters, "Conn_CommonDB"))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstMarkups.Add(new MDL.Markups
                        {
                             CompanyId = Convert.ToInt32(row["CompanyId"]),
                             CompanyTypeId = Convert.ToInt32(row["CompanyTypeId"]),
                             NetFareMarkup = Convert.ToDouble(row["NetFareMarkup"]),
                             PublishedFareMarkup = Convert.ToDouble(row["PublishedFareMarkup"]),
                             TourNetFareMarkup = Convert.ToDouble(row["TourNets"]),
                             IATACode = row["IATACode"].ToString(),
                             WebSiteUrl = row["WebsiteURL"].ToString(),
                              MarkupType = row["PublishedMarkupType"].ToString()
                        });
                    }
                }

            }
            return lstMarkups;
        }

        public static List<MDL.BlockedAirlines> GetBlockedAirlines(List<MDL.Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            List<MDL.BlockedAirlines> lstBlockedairlines = new List<MDL.BlockedAirlines>();
            using (DataSet ds = er.CallStoredProcedure("usp_GetAllBlockedAirlines", _parameters, "Conn_CommonDB"))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        lstBlockedairlines.Add(new MDL.BlockedAirlines
                        {
                            IATACode = row["IATACode"].ToString()
                        });
                    }
                }

            }
            return lstBlockedairlines;
        }

        public static DataSet GetDbDataCollections(List<MDL.Parameter> _parameters)
        {
            SqlHelpers.ExecuteDataSet ds = new SqlHelpers.ExecuteDataSet();
            DataSet dt = ds.CallStoredProcedure("usp_GetDbDataCollections", _parameters, "Conn_CommonDB");
            return dt;
        }
    }
}
