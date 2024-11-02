using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Sabre
{
    public class RequestRules
    {
        public bool IsPublishedInclude { get; set; }
        public bool IsNetInclude { get; set; }
        public bool IsTourNetInclude { get; set; }
        public bool IsNet { get; set; } = false;
       public string PricedItinCount { get; set; }
       

    }
}
