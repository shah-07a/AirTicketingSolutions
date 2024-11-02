using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class DataTraveler
    {
        public dynamic Information { get; set; }
        public string ActionType { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}
