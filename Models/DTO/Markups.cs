using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class Markups
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }
        public double NetFareMarkup { get; set; }
        public double PublishedFareMarkup { get; set; }
        public double TourNetFareMarkup { get; set; }
        public string IATACode { get; set; }
        public string WebSiteUrl { get; set; }
        public string MarkupType { get; set; }
    }
    public class FareDetails
    {
        public double PerPassengerMarkup { get; set; }
        public double PerPassengerFare { get; set; }
        public double BaseFare { get; set; }
        public double Taxes { get; set; }
        public double TotalPrice { get; set; }
        public int NumberOfPassenger { get; set; }
        public string PassengerType { get; set; }
        public string FareType { get; set; }
        public string MarkupType { get; set; }
    }
    public class MarkupParameters
    {
        public double PassengerFare { get; set; }
        public double PassengerEquivFare { get; set; }
        public double PassengerTotalTax { get; set; }
        public string PassengerType { get; set; }
        public int PassengerQnty { get; set; }
        public string AirlineCode { get; set; }
        public List<Markups> Markups { get; set; }
        public List<FareDetails> FareDetails { get; set; } = new List<FareDetails>();
        public double ServiceFee { get; set; }
        public double Commission { get; set; }
        public string FareType { get; set; }
        public bool IsInfant { get; set; }

    }
}
