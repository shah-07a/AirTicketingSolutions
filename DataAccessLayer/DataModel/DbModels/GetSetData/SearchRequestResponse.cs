using Models.DTO;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class SearchRequestResponse
    {
        public static string Add(List<Parameter> _parameters)
        {
            SqlHelpers.ExecuteNonQuery enq = new SqlHelpers.ExecuteNonQuery();
            return enq.CallStoredProcedure("[dbo].[usp_InsertRequestAir]", _parameters, "Conn_AirDb");
        }
        public static string GetRequestResponse(List<Parameter> _parameters, string _type)
        {
            string result = string.Empty;
            SqlHelpers.ExecuteReader exReader = new SqlHelpers.ExecuteReader();
            using (DataSet ds = exReader.CallStoredProcedure("usp_GetSavedSearchResponse", _parameters, "Conn_AirDb"))
            {
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            if (_type == "res")
                            {
                                result = row["ResponseJson"].ToString();
                            }
                            else
                            {
                                result = row["ResponseJson"].ToString();
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
