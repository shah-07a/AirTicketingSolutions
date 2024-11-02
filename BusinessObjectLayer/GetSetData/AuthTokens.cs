using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL = DataAccessLayer;

namespace BusinessObjectLayer.GetSetData
{
    public class AuthTokens
    {
        public List<Parameter>  Parameters { get; set; }
        public string GetAuthTokens()
        {
            return DAL.DataModel.DbModels.GetSetData.AuthTokens.GetAuthTokens(Parameters);
        }
    }
}
