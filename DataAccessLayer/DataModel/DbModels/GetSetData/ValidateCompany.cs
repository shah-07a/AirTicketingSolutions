using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using MDL = Models.DTO;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class ValidateCompany
    {
        static ValidateCompany()
        {

        }

        public static MDL.CompanyDetails GetValidateCompany(List<MDL.Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            MDL.CompanyDetails cd = new MDL.CompanyDetails();
            using (DataSet ds = er.CallStoredProcedure("usp_CompanyInfo", _parameters, "Conn_CommonDB"))
            {
                if(ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        cd.Id = Convert.ToInt32(row["Id"]);
                        cd.AdvancePurchaseDays = Convert.ToInt32(row["AdvancePurchase"]);
                        cd.NumberOfMonths = Convert.ToInt32(row["NumberOfMonths"]);
                        cd.IsAir = Convert.ToBoolean(row["Air"]);
                        cd.IsHotel = Convert.ToBoolean(row["Hotel"]);
                        cd.IsCarRental = Convert.ToBoolean(row["CarRental"]);
                        cd.CompanyTypeId = Convert.ToInt32(row["CompanyTypeId"]);
                        cd.Name = row["Name"].ToString();
                        cd.FromEmail = row["FromEmail"].ToString();
                        cd.EmailBCC = row["EmailBCC"].ToString();
                        cd.EmailCC = row["EmailCC"].ToString();
                    }
                }
                else
                {
                    cd.Id = 0;
                    cd.AdvancePurchaseDays = 0;
                    cd.NumberOfMonths = 0;
                    cd.IsAir = false;
                    cd.IsHotel = false;
                    cd.IsCarRental = false;
                    cd.CompanyTypeId = 0;
                }
            }
            return cd;
        }
    }
}
