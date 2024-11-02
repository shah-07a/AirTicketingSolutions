using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models.DTO;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class AuthTokens
    {
        public static string GetAuthTokens(List<Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            string token = string.Empty;
            using (DataSet ds = er.CallStoredProcedure("usp_GetToken", _parameters, "Conn_CommonDB"))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        token = row["Token"].ToString();
                    }
                }
            }
            return token;
        }
    }
}
