using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.Common
{
    public class SearchRequestModel
    {
        public string BookingType { get; set; }
        public string SearchType { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string Departure1 { get; set; }
        public string Destination1 { get; set; }
        public string DepartureDate1 { get; set; }
        public string Departure2 { get; set; }
        public string Destination2 { get; set; }
        public string DepartureDate2 { get; set; }
        public string Departure3 { get; set; }
        public string Destination3 { get; set; }
        public string DepartureDate3 { get; set; }
        public string Departure4 { get; set; }
        public string Destination4 { get; set; }
        public string DepartureDate4 { get; set; }
        public string ReturnDate { get; set; }
        public string Airline { get; set; }
        public string AirlineText { get; set; }
        public string OAirlineText { get; set; }
        public string MAirlineText { get; set; }
        public string FareType { get; set; }
        public string Class { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
        public string Infants { get; set; }
        public string DirectOnly { get; set; }
        public string DomainName { get; set; }
        public string DefaultCompanyId { get; set; }
        public string CompanyTypeId { get; set; }
        public string ClientRequestId { get; set; }
        public string AuthToken { get; set; }
        public string ReferrerUrl { get; set; }
        public string RequestingClientInfo { get; set; }
        public DTO.User LoggedInUser { get; set; } = new DTO.User();

    }
}