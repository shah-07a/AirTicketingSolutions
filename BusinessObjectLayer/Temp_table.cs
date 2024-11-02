using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO = Models.DTO;
using DAL = DataAccessLayer.DataModel;
using Models.DTO;

namespace BusinessObjectLayer
{
    public class Temp_table
    {
        public async Task<string> PostData(List<DTO.Parameter> tempTable)
        {
            string status = string.Empty;
            try
            {
                await Task.Run(() =>
                {
                    status = DAL.DbModels.Temp_table.PostData(tempTable);
                });
                
      
            }
            catch (Exception ex)
            {
                    DbErrorLogs objDbErr = new DbErrorLogs
                    {
                        Exception = ex,
                        ProjectName = Types.ProjectNames.DataAccessLayer.ToString(),
                        SolutionName = "AirSolutions"
                    };
                    objDbErr.AddErrorLog();
            }
            return status;
        }
    }
}
