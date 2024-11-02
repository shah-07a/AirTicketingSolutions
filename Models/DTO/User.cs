using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CompanyId { get; set; }
        public int UserRoleId { get; set; }
        public string EmailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAffiliate { get; set; }
    }
}
