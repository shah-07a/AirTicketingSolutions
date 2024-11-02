using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class CompanyDetails
    {
        public int Id { get; set; }
        public int CompanyTypeId { get; set; }
        public string CompanyType { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string StreetAddress { get; set; }
        public string HeaderUrl { get; set; }
        public string FooterUrl { get; set; }
        public string WebsiteUrl { get; set; }
        public string PrivacyUrl { get; set; }
        public string TermsUrl { get; set; }
        public string SmtpEmailID { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string QueueNo { get; set; }
        public string PseudoCityCode { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Domain { get; set; }
        public string CurrencyCode { get; set; }
        public string FaviconUrl { get; set; }
        public bool IsAir { get; set; }
        public bool IsHotel { get; set; }
        public bool IsCarRental { get; set; }
        public bool IsInsurance { get; set; }
        public string EmailName { get; set; }
        public string CityStateCountry { get; set; }
        public bool IsPublishedInclude { get; set; }
        public bool IsNetInclude { get; set; }
        public bool IsTourNetInclude { get; set; }
        public string EmailCC { get; set; }
        public string EmailBCC { get; set; }
        public string QueuePlacePcc { get; set; }
        public string QueuePlaceQueueNo { get; set; }
        public string DKNumber { get; set; }
        public float DefaultInfantFare { get; set; }
        public int AdvancePurchaseDays { get; set; }
        public string AutoCancelledTime { get; set; }
        public bool IsAverageFare { get; set; }
        public bool IsChangeCancelDisplay { get; set; }
        public int NumberOfMonths { get; set; }
        public bool IsDisCouponDisplay { get; set; }
        public string StandardMarkupPerRoom { get; set; }
        public bool IsEnable { get; set; }
        public User LoggedInUser { get; set; } = new User();
    }
}
