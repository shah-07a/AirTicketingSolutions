using Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataModel.DbModels.SqlHelpers
{
    public class ExecuteReader
    {
        public DataSet CallStoredProcedure(string _storeProcedureName, List<Models.DTO.Parameter> _parameters, string _connectionName)
        {
            // DataTable datatable = null;
            DataSet dataset = null; 
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
                            else if (item.TypeOfData == "Bool")
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, Convert.ToBoolean(item.Value));
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@" + item.Name, item.Value);
                            }

                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        string timeout = conn.ConnectionTimeout.ToString();
                        conn.Open();
                        dataset = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(dataset);

                        //SqlDataReader reader = cmd.ExecuteReader();
                       // datatable = new DataTable();
                        //datatable.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                    DbErrorLogs objDbErr = new DbErrorLogs();
                    objDbErr.AddErrorLogs(ex, Types.ProjectNames.DataAccessLayer.ToString(), "AirSolutions");
            }
            return dataset;
        }

        public string CallStoredProcedure(string _storeProcedureName, List<Models.DTO.Parameter> _parameters, string _result, string _connectionName)
        {
            SqlDataReader reader = null;
            _result = "searchblocked";
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
                        using (reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    _result = reader["Result"].ToString();
                                }
                            }
                        }
                    }

                }
                return _result;

                
            }
            catch (Exception ex)
            {
                    DbErrorLogs objDbErr = new DbErrorLogs();
                    objDbErr.AddErrorLogs(ex, Types.ProjectNames.DataAccessLayer.ToString(), "AirSolutions");

            }
            return _result;
        }
    }
}
