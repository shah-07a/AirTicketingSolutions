using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Parameter
    {
        public string Name { get; set; }
        public dynamic Value { get; set; }
        public string TypeOfData { get; set; }
        public string DomainName { get; set; }
        public string Token { get; set; }

    }
}
