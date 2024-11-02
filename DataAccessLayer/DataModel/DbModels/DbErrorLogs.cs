using Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.DataModel.DbModels
{
    public class DbErrorLogs 
    {
        public DbErrorLogs()
        {

        }

        public  void AddErrorLogs(Exception _exception, string _projectName, string _solutionName)
        {
            try
            {
                string ErrorMessage = "|| ExceptionMessage ||:- " + _exception.Message + "  || ExceptionSource ||:- " + _exception.StackTrace + " || ExceptionTargetSite ||:- " + _exception.TargetSite + "  ||  ExceptionData ||:- " + _exception.Data + Environment.NewLine + Environment.NewLine + Environment.NewLine + "||ExceptionInnerException||:-  " + Environment.NewLine + _exception.InnerException;
                SqlHelpers.ExecuteNonQuery enq = new SqlHelpers.ExecuteNonQuery();
                List<Parameter> lstParms = new List<Parameter>();

                lstParms.Add(new Parameter
                {
                    Name = "ErrorMessage",
                    Value = ErrorMessage,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "ProjectName",
                    Value = _projectName,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Parameter
                {
                    Name = "SolutionName",
                    Value = _solutionName,
                    TypeOfData = Types.DataTypes.String.ToString()
                });
                string status = enq.CallStoredProcedure("usp_InsertErrors", lstParms, "Conn_CommonDB").ToString();
            }
            catch (Exception ex1)
            {
                Base.AppLogs.ErrorsLogInstance.ManageException(ex1, Types.ProjectNames.HttpServices.ToString());
            }
            
        }

    }
}
