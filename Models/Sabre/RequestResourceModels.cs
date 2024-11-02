using Models.Sabre.JsonModels.Request;
using System.Collections.Generic;

namespace Models.Sabre
{
    public class RequestResourceModels : RequestRules
    {
        public RequestResourceModels()
        {

        }
        public IList<Source> Sources { get; set; }
        public IList<OriginDestinationInformation> OriginDestinationInformation { get; set; }
        public IList<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }
        public TravelPreferences TravelPreferences { get; set; }
        public IList<CabinPref> CabinPref { get; set; }
        public string SelectionName { get; set; }
        public string Airline { get; set; }
        public string AirClass { get; set; }
        
        public string ReturnDate { get; set; }
        public string OnlineItinerariesOnly { get; set; }
        public string Limit { get; set; }
        public string OffSet { get; set; }
        public string EticketsOnly { get; set; }
        public string SortBy { get; set; }
        public string Order { get; set; }
        public string SortBy2 { get; set; }
        public string Order2 { get; set; }
        public string PointofSaleCountry { get; set; }
        public string PassengerCount { get; set; }
        public string LengthofStay { get; set; }
        public string MinFare { get; set; }
        public string MaxFare { get; set; }
        public string PCC { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public int CompanyTypeId { get; set; }
        public string BFMXRQ_RequestContent { get; set; }
        public int CompanyId { get; set; }
        public string CurrentUrl { get; set; }
        public string UserRoleId { get; set; }
        public string ClientIP { get; set; }
        public string Id { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
        public string RPH { get; set; }
        public bool ValidInterlineTicket { get; set; }
        public bool Enable { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public bool Enabled { get; set; }
        public string Cabin { get; set; }
        public string PreferLevel { get; set; }
        public string ReqTypeName { get; set; }
        public string CurrencyCode { get; set; }
        public bool PublicFareInd { get; set; }
        public bool PrivateFareInd { get; set; }
        public bool DirectFlightsOnly { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsDirectFlight { get; set; }
        public string PseudoCityCode { get; set; }
        public string RequestJson { get; set; }
        public string ResponseJson { get; set; }
    }
}
