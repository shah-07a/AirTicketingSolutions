using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDL = Models.DTO;
using DAL = DataAccessLayer;
using System.Data;

namespace BusinessObjectLayer.GetSetData
{
    public class FareRules
    {
        public List<MDL.Parameter> Parameters { get; set; }
        public List<MDL.Markups> GetMarkups()
        {
            return DAL.DataModel.DbModels.GetSetData.FareRules.GetMarkups(Parameters);
        }

        public List<MDL.BlockedAirlines> GetBlockedAirlines()
        {
            return DAL.DataModel.DbModels.GetSetData.FareRules.GetBlockedAirlines(Parameters);
        }

        public DataSet GetDbDataCollections()
        {
            return DAL.DataModel.DbModels.GetSetData.FareRules.GetDbDataCollections(Parameters);
        }


    }
}
