using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccessLayer;
using MDL = Models.DTO;

namespace BusinessObjectLayer.GetSetData
{
    public class ValidateCompany
    {
        public List<MDL.Parameter> Parameters;

        public MDL.CompanyDetails GetCompanyValidate()
        {
            return DAL.DataModel.DbModels.GetSetData.ValidateCompany.GetValidateCompany(Parameters);
        }
    }
}
