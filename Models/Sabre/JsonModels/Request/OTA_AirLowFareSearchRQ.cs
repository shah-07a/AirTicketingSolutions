using System.Collections.Generic;

namespace Models.Sabre.JsonModels.Request
{

    public class OTA_AirLowFareSearchParent  //===Parent Class ====
    {
        public OTA_AirLowFareSearchRQ OTA_AirLowFareSearchRQ { get; set; }
        public AlternatePCC AlternatePCC { get; set; }
        public PriceRequestInformation PriceRequestInformation { get; set; }
        public bool DirectFlightsOnly { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsDirectFlight { get; set; }
        public int CompanyId { get; set; }
    }

    public class OTA_AirLowFareSearchRQ
    {
        public POS POS { get; set; }
        public IList<OriginDestinationInformation> OriginDestinationInformation { get; set; }
        public TravelPreferences TravelPreferences { get; set; }
        public TravelerInfoSummary TravelerInfoSummary { get; set; }
        public TPA_Extensions TPA_Extensions { get; set; }
    }

    public class POS
    {
        public IList<Source> Source { get; set; }
    }
    public class Source
    {
        public RequestorID RequestorID { get; set; }
        public string PseudoCityCode { get; set; }
    }
    public class RequestorID
    {
        public string Type { get; set; }
        public string ID { get; set; }
        public CompanyName CompanyName { get; set; }
    }
    public class CompanyName
    {
        public string Code { get; set; }
    }

    public class OriginDestinationInformation
    {
        public string RPH { get; set; }
        public string DepartureDateTime { get; set; }
        public OriginLocation OriginLocation { get; set; }
        public DestinationLocation DestinationLocation { get; set; }
    }
    public class OriginLocation
    {
        public string LocationCode { get; set; }
    }
    public class DestinationLocation
    {
        public string LocationCode { get; set; }
    }
    public class TravelPreferences
    {
        public bool ValidInterlineTicket { get; set; }
        public TravelPreferencesTPA_Extensions TPA_Extensions { get; set; }
        public IList<CabinPref> CabinPref { get; set; }
        public IList<VendorPref> VendorPref { get; set; }
    }
    public class TravelPreferencesTPA_Extensions
    {
        public LongConnectTime LongConnectTime { get; set; }
        public LongConnectPoints LongConnectPoints { get; set; }
        public ExcludeCallDirectCarriers ExcludeCallDirectCarriers { get; set; }
        public FlexibleFares FlexibleFares { get; set; }
    }
    public class PTQ_TPA_Extensions
    {
        public VoluntaryChanges VoluntaryChanges { get; set; }
    }
    public class TPA_Extensions
    {
        public IntelliSellTransaction IntelliSellTransaction { get; set; }
    }
    public class TPA_Extensions_1
    {
        public Indicators Indicators { get; set; }
        public PrivateFare PrivateFare { get; set; }
    }
    public class CabinPref
    {
        public string Cabin { get; set; }
        public string PreferLevel { get; set; }
    }
    public class VendorPref
    {
        public string Code { get; set; }
        public string PreferLevel { get; set; }
    }
    public class LongConnectTime
    {
        public bool Enable { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public class LongConnectPoints
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
    public class ExcludeCallDirectCarriers
    {
        public bool Enabled { get; set; }
    }
    public class TravelerInfoSummary
    {
        public IList<AirTravelerAvail> AirTravelerAvail { get; set; }
    }
    public class AirTravelerAvail
    {
        public IList<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }
    }
    public class PassengerTypeQuantity
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
        public PTQ_TPA_Extensions TPA_Extensions { get; set; }
    }
    public class FlexifareParameterPassengerTypeQuantity
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
    public class VoluntaryChanges
    {
        public string Match { get; set; }
    }
    public class RequestType
    {
        public string Name { get; set; }
    }
    public class IntelliSellTransaction
    {
        public RequestType RequestType { get; set; }
    }
    public class AlternatePCC
    {
        public string PseudoCityCode { get; set; }
    }
    public class PublicFare
    {
        public bool Ind { get; set; }
    }
    public class Indicators
    {
        public PublicFare PublicFare { get; set; }
    }
    public class PrivateFare
    {
        public bool Ind { get; set; }
    }
    public class PriceRequestInformation
    {
        public string CurrencyCode { get; set; }
        public TPA_Extensions_1 TPA_Extensions { get; set; }
    }
    public class FareParameters
    {
        public IList<FlexifareParameterPassengerTypeQuantity> PassengerTypeQuantity { get; set; }
    }
    public class FlexibleFares
    {
        public IList<FareParameters> FareParameters { get; set; }
    }


}
