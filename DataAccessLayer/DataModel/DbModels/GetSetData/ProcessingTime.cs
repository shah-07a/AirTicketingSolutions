using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public class ProcessingTime
    {
        public static string Add(List<Models.DTO.ProcessingTime> _processingTimes)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6]
            {new DataColumn("PTId", typeof(int)),
                    new DataColumn("RequestId", typeof(string)),
                    new DataColumn("StartTime", typeof(string)),
                    new DataColumn("EndTime", typeof(string)),
                    new DataColumn("ProcessName", typeof(string)),
                    new DataColumn("Remarks", typeof(string))
                });
            foreach (var item in _processingTimes)
            {
                dt.Rows.Add(item.PTId, item.RequestId, item.StartTime, item.EndTime, item.ProcessName, item.Remarks);
            }
            List<Models.DTO.Parameter> lstParamtr = new List<Models.DTO.Parameter>();
            lstParamtr.Add(new Models.DTO.Parameter
            {
                Name = "udt_ProcessingTimes",
                Value = dt,
                TypeOfData = Models.DTO.Types.DataTypes.String.ToString()
            });
            
            SqlHelpers.ExecuteNonQuery enq = new SqlHelpers.ExecuteNonQuery();
            return enq.CallStoredProcedure("[dbo].[usp_AddProcessingTimes]", lstParamtr, "Conn_AirDb");
        }
    }
}
