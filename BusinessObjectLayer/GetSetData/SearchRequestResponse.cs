using Models.DTO;
using System.Collections.Generic;
using DAL = DataAccessLayer;

namespace BusinessObjectLayer.GetSetData
{
    public class SearchRequestResponse
    {
        public List<Parameter>  Parameters { get; set; }
        public string ReqResType { get; set; }
        public string Add()
        {
            return DAL.DataModel.DbModels.GetSetData.SearchRequestResponse.Add(Parameters);
        }

        public string  GetRequestResponse()
        {
            return DAL.DataModel.DbModels.GetSetData.SearchRequestResponse.GetRequestResponse(Parameters, ReqResType);
        }
    }
}
