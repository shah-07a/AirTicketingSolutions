using Models.DTO;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class SearchHits
    {
        static SearchHits()
        {

        }
        public static string GetSearchHits(List<Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            string result = "searchblocked";
            using (DataSet ds = er.CallStoredProcedure("usp_BlockSearchRequest", _parameters, "Conn_AirDb"))
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        result = row["Result"].ToString();
                    }
                }
                
            }
            return result;
        }
    }
}
