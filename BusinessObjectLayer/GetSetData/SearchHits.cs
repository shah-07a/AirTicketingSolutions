using Models.DTO;
using System.Collections.Generic;
using DAL = DataAccessLayer;

namespace BusinessObjectLayer.GetSetData
{
    public class SearchHits
    {
        public List<Parameter> Parameters { get; set; }
        public string GetSearchHits()
        {
            return DAL.DataModel.DbModels.GetSetData.SearchHits.GetSearchHits(Parameters);
        }
    }
}
