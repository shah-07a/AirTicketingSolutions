using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
   public class CommonUtility : DataTraveler
    {
        public CommonUtility() { }
        public dynamic Data { get; set; }
        public string Data1 { get; set; }
        public string AgencyDetails { get; set; }
        public string CCFEE { get; set; }
        public string PolicyNumber { get; set; }
        public string PurchaseDate { get; set; }
        public string Price { get; set; }
        public string CancellationDate { get; set; }
        public string RequestPostTime { get; set; }
        public string ResponseGetTime { get; set; }
        public bool IsCancellationDisplay { get; set; }
        //=== public Models.DTO.SearchResponseBaseModel SearchResponseBaseModel { get; set; }

    }
}
