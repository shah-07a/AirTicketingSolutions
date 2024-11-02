using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public  class AuthenticationTokens
    {
        public AuthenticationTokens()
        {

        }
        public  int Id { get; set; }
        public  string Token { get; set; }
        public  string ExpiryTime { get; set; }
        public  string Status { get; set; }
        public  int CompanyId { get; set; }
        public  string Remarks { get; set; }
        public  int EngineType { get; set; }
    }
}
