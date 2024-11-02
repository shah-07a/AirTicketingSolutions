using System.Collections.Generic;
using DAL = DataAccessLayer;

namespace BusinessObjectLayer.GetSetData
{
    public class ProcessingTime
    {
        public List<Models.DTO.ProcessingTime> ProcessingTimes { get; set; }
        public string Add()
        {
            return DAL.DataModel.DbModels.GetSetData.ProcessingTime.Add(ProcessingTimes);
        }
    }
}
