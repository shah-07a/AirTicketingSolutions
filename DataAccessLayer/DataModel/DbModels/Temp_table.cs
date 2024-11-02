using Models.DTO;
using System;
using System.Collections.Generic;

namespace DataAccessLayer.DataModel.DbModels
{
    public static class Temp_table
    {
        public static string PostData(List<Models.DTO.Parameter> _parameters)
        {
            string status = string.Empty;
          try
            {
                SqlHelpers.ExecuteNonQuery enq = new SqlHelpers.ExecuteNonQuery();
                status = enq.CallStoredProcedure("usp_InsertTempTable", _parameters, "Conn_CommonDB").ToString();

            }
            catch (Exception ex)
            {
                try
                {
                    DbErrorLogs objDbErr = new DbErrorLogs();
                    objDbErr.AddErrorLogs(ex, Types.ProjectNames.DataAccessLayer.ToString(), "AirSolutions");
                }
                catch (Exception ex1)
                {
                    Base.AppLogs.ErrorsLogInstance.ManageException(ex1, Types.ProjectNames.DataAccessLayer.ToString());
                }
            }

            return status;
        }
    }
}
