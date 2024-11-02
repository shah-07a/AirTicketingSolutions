using Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataModel.DbModels.SqlHelpers
{
    public class ExecuteDataSet
    {
        public DataSet CallStoredProcedure(string _storeProcedureName, List<Models.DTO.Parameter> _parameters, string _connectionName)
        {
            DataSet dataSet = new DataSet();
            try
            {

                string connString = ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand(_storeProcedureName, conn))
                    {
                        foreach (var item in _parameters)
                        {
                            if (item.TypeOfData == "Int")
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, Convert.ToInt32(item.Value));
                            }
                            else if (item.TypeOfData == "Double")
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, Convert.ToDouble(item.Value));
                            }
                            else if (item.TypeOfData == "DateTime")
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, Convert.ToDateTime(item.Value));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, item.Value);
                            }

                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dataSet);
                    }
                }
                return dataSet;

            }
            catch (Exception ex)
            {
                DbErrorLogs objDbErr = new DbErrorLogs();
                objDbErr.AddErrorLogs(ex, Types.ProjectNames.DataAccessLayer.ToString(), "AirSolutions");

            }
            return dataSet;
        }
       
    }
}
