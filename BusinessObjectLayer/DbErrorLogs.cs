using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccessLayer.DataModel.DbModels;

namespace BusinessObjectLayer
{
    public class DbErrorLogs
    {
        public Exception Exception { get; set; }
        public string ProjectName { get; set; }

        public string SolutionName { get; set; }

        public void AddErrorLog()
        {
            DAL.DbErrorLogs objDbErr = new DAL.DbErrorLogs();
            objDbErr.AddErrorLogs(Exception, ProjectName, SolutionName);
        }

    }
}
