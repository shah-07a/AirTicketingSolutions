using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Models.Sabre.JsonModels.Response
{
    public class Wrapper
    {
        [JsonProperty("OTA_AirLowFareSearchRS")]
         public DataSet DataSet { get; set; }
    }
    public class Success
    {
        public int SuccessId { get; set; }
        public string Message { get; set; }
    }
    public class Warning
    {
        public string Type { get; set; }
        public string ShortText { get; set; }
        public string Code { get; set; }
        public string content { get; set; }
        public string MessageClass { get; set; }
    }
    public class Warnings
    {
        public List<Warning> Warning { get; set; }
    }
    public class DepartureAirport
    {
        public string LocationCode { get; set; }
        public string TerminalID { get; set; }
        public string content { get; set; }
    }
    public class ArrivalAirport
    {
        public string LocationCode { get; set; }
        public string TerminalID { get; set; }
        public string content { get; set; }
    }
    public class OperatingAirline
    {
        public string Code { get; set; }
        public string FlightNumber { get; set; }
        public string content { get; set; }
    }
    public class Equipment
    {
        public string AirEquipType { get; set; }
        public string content { get; set; }
    }
    public class MarketingAirline
    {
        public string Code { get; set; }
        public string content { get; set; }
    }
    public class DisclosureAirline
    {
        public string Code { get; set; }
        public string content { get; set; }
    }
    public class DepartureTimeZone
    {
        public double GMTOffset { get; set; }
    }
    public class ArrivalTimeZone
    {
        public double GMTOffset { get; set; }
    }
    public class ETicket
    {
        public bool Ind { get; set; }
    }
    public class Mileage
    {
        public int Amount { get; set; }
    }
    public class TPAExtensions
    {
        public ETicket eTicket { get; set; }
        public Mileage Mileage { get; set; }
    }
    public class FlightSegment
    {
        public string DepartureDateTime { get; set; }
        public string ArrivalDateTime { get; set; }
        public int StopQuantity { get; set; }
        public string FlightNumber { get; set; }
        public string ResBookDesigCode { get; set; }
        public int ElapsedTime { get; set; }
        public DepartureAirport DepartureAirport { get; set; }
        public ArrivalAirport ArrivalAirport { get; set; }
        public OperatingAirline OperatingAirline { get; set; }
        public List<Equipment> Equipment { get; set; }
        public MarketingAirline MarketingAirline { get; set; }
        public DisclosureAirline DisclosureAirline { get; set; }
        public string MarriageGrp { get; set; }
        public DepartureTimeZone DepartureTimeZone { get; set; }
        public ArrivalTimeZone ArrivalTimeZone { get; set; }
        public TPAExtensions TPA_Extensions { get; set; }
    }
    public class OriginDestinationOption
    {
        public int ElapsedTime { get; set; }
        public List<FlightSegment> FlightSegment { get; set; }
    }
    public class OriginDestinationOptions
    {
        public List<OriginDestinationOption> OriginDestinationOption { get; set; }
    }
    public class AirItinerary
    {
        public string DirectionInd { get; set; }
        public OriginDestinationOptions OriginDestinationOptions { get; set; }
    }
    public class BaseFare
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class FareConstruction
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
    }
    public class Taxes
    {
        public List<Tax> Tax { get; set; }
    }
    public class TotalFare
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class ItinTotalFare
    {
        public BaseFare BaseFare { get; set; }
        public FareConstruction FareConstruction { get; set; }
        public EquivFare EquivFare { get; set; }
        public Taxes Taxes { get; set; }
        public TotalFare TotalFare { get; set; }
    }
    public class PassengerTypeQuantity
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
    public class FareBasisCode
    {
        public string BookingCode { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string FareComponentBeginAirport { get; set; }
        public string FareComponentEndAirport { get; set; }
        public string FareComponentDirectionality { get; set; }
        public string FareComponentVendorCode { get; set; }
        public string GovCarrier { get; set; }
        public string content { get; set; }
        public bool? AvailabilityBreak { get; set; }
    }
    public class FareBasisCodes
    {
        public List<FareBasisCode> FareBasisCode { get; set; }
    }
    public class BaseFare2
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class FareConstruction2
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare2
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax2
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TaxSummary
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TotalTax
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Taxes2
    {
        public List<Tax2> Tax { get; set; }
        public List<TaxSummary> TaxSummary { get; set; }
        public TotalTax TotalTax { get; set; }
    }
    public class TotalFare2
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class Penalty
    {
        public string Type { get; set; }
        public string Applicability { get; set; }
        public bool Changeable { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public bool? Refundable { get; set; }
    }
    public class PenaltiesInfo
    {
        public List<Penalty> Penalty { get; set; }
    }
    public class Message
    {
        public string AirlineCode { get; set; }
        public string Type { get; set; }
        public int FailCode { get; set; }
        public string Info { get; set; }
    }
    public class Messages
    {
        public List<Message> Message { get; set; }
    }
    public class Segment
    {
        public int Id { get; set; }
    }
    public class Allowance
    {
        public int Pieces { get; set; }
    }
    public class BaggageInformation
    {
        public string ProvisionType { get; set; }
        public string AirlineCode { get; set; }
        public List<Segment> Segment { get; set; }
        public List<Allowance> Allowance { get; set; }
    }
    public class BaggageInformationList
    {
        public List<BaggageInformation> BaggageInformation { get; set; }
    }
    public class TPAExtensions2
    {
        public Messages Messages { get; set; }
        public BaggageInformationList BaggageInformationList { get; set; }
    }
    public class PassengerFare
    {
        public BaseFare2 BaseFare { get; set; }
        public FareConstruction2 FareConstruction { get; set; }
        public EquivFare2 EquivFare { get; set; }
        public Taxes2 Taxes { get; set; }
        public TotalFare2 TotalFare { get; set; }
        public PenaltiesInfo PenaltiesInfo { get; set; }
        public TPAExtensions2 TPA_Extensions { get; set; }
    }
    public class Endorsements
    {
        public bool NonRefundableIndicator { get; set; }
    }
    public class FareCalcLine
    {
        public string Info { get; set; }
    }
    public class TPAExtensions3
    {
        public FareCalcLine FareCalcLine { get; set; }
    }
    public class SeatsRemaining
    {
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin1
    {
        public string Cabin { get; set; }
    }
    public class Meal
    {
        public string Code { get; set; }
    }
    public class TPAExtensions4
    {
        public SeatsRemaining SeatsRemaining { get; set; }
        public Cabin1 Cabin { get; set; }
        public Meal Meal { get; set; }
    }
    public class FareInfo
    {
        public string FareReference { get; set; }
        public TPAExtensions4 TPA_Extensions { get; set; }
    }
    public class FareInfos
    {
        public List<FareInfo> FareInfo { get; set; }
    }
    public class PTCFareBreakdown
    {
        public PassengerTypeQuantity PassengerTypeQuantity { get; set; }
        public FareBasisCodes FareBasisCodes { get; set; }
        public PassengerFare PassengerFare { get; set; }
        public Endorsements Endorsements { get; set; }
        public TPAExtensions3 TPA_Extensions { get; set; }
        public FareInfos FareInfos { get; set; }
    }
    public class PTCFareBreakdowns
    {
        public List<PTCFareBreakdown> PTC_FareBreakdown { get; set; }
    }
    public class SeatsRemaining2
    {
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin2
    {
        public string Cabin { get; set; }
    }
    public class Meal2
    {
        public string Code { get; set; }
    }
    public class TPAExtensions5
    {
        public SeatsRemaining2 SeatsRemaining { get; set; }
        public Cabin2 Cabin { get; set; }
        public Meal2 Meal { get; set; }
    }
    public class FareInfo2
    {
        public string FareReference { get; set; }
        public TPAExtensions5 TPA_Extensions { get; set; }
    }
    public class FareInfos2
    {
        public List<FareInfo2> FareInfo { get; set; }
    }
    public class DivideInParty
    {
        public bool Indicator { get; set; }
    }
    public class Default
    {
        public string Code { get; set; }
    }
    public class ValidatingCarrier
    {
        public string SettlementMethod { get; set; }
        public bool NewVcxProcess { get; set; }
        public Default Default { get; set; }
    }
    public class TPAExtensions6
    {
        public DivideInParty DivideInParty { get; set; }
        public List<ValidatingCarrier> ValidatingCarrier { get; set; }
    }
    public class AirItineraryPricingInfo
    {
        public string LastTicketDate { get; set; }
        public string PricingSource { get; set; }
        public string PricingSubSource { get; set; }
        public bool FareReturned { get; set; }
        public ItinTotalFare ItinTotalFare { get; set; }
        public PTCFareBreakdowns PTC_FareBreakdowns { get; set; }
        public FareInfos2 FareInfos { get; set; }
        public TPAExtensions6 TPA_Extensions { get; set; }
    }
    public class TicketingInfo
    {
        public string TicketType { get; set; }
        public string ValidInterline { get; set; }
    }
    public class BaseFare3
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class FareConstruction3
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare3
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax3
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
    }
    public class Taxes3
    {
        public List<Tax3> Tax { get; set; }
    }
    public class TotalFare3
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class ItinTotalFare2
    {
        public BaseFare3 BaseFare { get; set; }
        public FareConstruction3 FareConstruction { get; set; }
        public EquivFare3 EquivFare { get; set; }
        public Taxes3 Taxes { get; set; }
        public TotalFare3 TotalFare { get; set; }
    }
    public class PassengerTypeQuantity2
    {
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
    public class FareBasisCode2
    {
        public string PrivateFareType { get; set; }
        public string BookingCode { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string FareComponentBeginAirport { get; set; }
        public string FareComponentEndAirport { get; set; }
        public string FareComponentDirectionality { get; set; }
        public string FareComponentVendorCode { get; set; }
        public string GovCarrier { get; set; }
        public string content { get; set; }
        public bool? AvailabilityBreak { get; set; }
    }
    public class FareBasisCodes2
    {
        public List<FareBasisCode2> FareBasisCode { get; set; }
    }
    public class BaseFare4
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class FareConstruction4
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare4
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax4
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TaxSummary2
    {
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TotalTax2
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Taxes4
    {
        public List<Tax4> Tax { get; set; }
        public List<TaxSummary2> TaxSummary { get; set; }
        public TotalTax2 TotalTax { get; set; }
    }
    public class TotalFare4
    {
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class Message2
    {
        public string AirlineCode { get; set; }
        public string Type { get; set; }
        public int FailCode { get; set; }
        public string Info { get; set; }
    }
    public class Messages2
    {
        public List<Message2> Message { get; set; }
    }
    public class Segment2
    {
        public int Id { get; set; }
    }
    public class Allowance2
    {
        public int Pieces { get; set; }
    }
    public class BaggageInformation2
    {
        public string ProvisionType { get; set; }
        public string AirlineCode { get; set; }
        public List<Segment2> Segment { get; set; }
        public List<Allowance2> Allowance { get; set; }
    }
    public class BaggageInformationList2
    {
        public List<BaggageInformation2> BaggageInformation { get; set; }
    }
    public class CommissionData
    {
        public double Cat35MarkupAmount { get; set; }
        public double CommissionAmountInEquivalent { get; set; }
    }
    public class TPAExtensions8
    {
        public Messages2 Messages { get; set; }
        public BaggageInformationList2 BaggageInformationList { get; set; }
        public CommissionData CommissionData { get; set; }
    }
    public class PassengerFare2
    {
        public BaseFare4 BaseFare { get; set; }
        public FareConstruction4 FareConstruction { get; set; }
        public EquivFare4 EquivFare { get; set; }
        public Taxes4 Taxes { get; set; }
        public TotalFare4 TotalFare { get; set; }
        public TPAExtensions8 TPA_Extensions { get; set; }
    }
    public class Endorsements2
    {
        public bool NonRefundableIndicator { get; set; }
    }
    public class FareCalcLine2
    {
        public string Info { get; set; }
    }
    public class FareType
    {
        public string Name { get; set; }
        public string content { get; set; }
    }
    public class TPAExtensions9
    {
        public FareCalcLine2 FareCalcLine { get; set; }
        public FareType FareType { get; set; }
    }
    public class SeatsRemaining3
    {
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin3
    {
        public string Cabin { get; set; }
    }
    public class Meal3
    {
        public string Code { get; set; }
    }
    public class TPAExtensions10
    {
        public SeatsRemaining3 SeatsRemaining { get; set; }
        public Cabin3 Cabin { get; set; }
        public Meal3 Meal { get; set; }
    }
    public class FareInfo3
    {
        public string FareReference { get; set; }
        public TPAExtensions10 TPA_Extensions { get; set; }
    }
    public class FareInfos3
    {
        public List<FareInfo3> FareInfo { get; set; }
    }
    public class PTCFareBreakdown2
    {
        public string PrivateFareType { get; set; }
        public PassengerTypeQuantity2 PassengerTypeQuantity { get; set; }
        public FareBasisCodes2 FareBasisCodes { get; set; }
        public PassengerFare2 PassengerFare { get; set; }
        public Endorsements2 Endorsements { get; set; }
        public TPAExtensions9 TPA_Extensions { get; set; }
        public FareInfos3 FareInfos { get; set; }
    }
    public class PTCFareBreakdowns2
    {
        public List<PTCFareBreakdown2> PTC_FareBreakdown { get; set; }
    }
    public class SeatsRemaining4
    {
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin4
    {
        public string Cabin { get; set; }
    }
    public class Meal4
    {
        public string Code { get; set; }
    }
    public class TPAExtensions11
    {
        public SeatsRemaining4 SeatsRemaining { get; set; }
        public Cabin4 Cabin { get; set; }
        public Meal4 Meal { get; set; }
    }
    public class FareInfo4
    {
        public string FareReference { get; set; }
        public TPAExtensions11 TPA_Extensions { get; set; }
    }
    public class FareInfos4
    {
        public List<FareInfo4> FareInfo { get; set; }
    }
    public class DivideInParty2
    {
        public bool Indicator { get; set; }
    }
    public class Default2
    {
        public string Code { get; set; }
    }
    public class ValidatingCarrier2
    {
        public string SettlementMethod { get; set; }
        public bool NewVcxProcess { get; set; }
        public Default2 Default { get; set; }
    }
    public class TPAExtensions12
    {
        public DivideInParty2 DivideInParty { get; set; }
        public List<ValidatingCarrier2> ValidatingCarrier { get; set; }
    }
    public class AirItineraryPricingInfo2
    {
        public string LastTicketDate { get; set; }
        public string PrivateFareType { get; set; }
        public int FlexibleFareID { get; set; }
        public string PricingSource { get; set; }
        public string PricingSubSource { get; set; }
        public bool FareReturned { get; set; }
        public ItinTotalFare2 ItinTotalFare { get; set; }
        public PTCFareBreakdowns2 PTC_FareBreakdowns { get; set; }
        public FareInfos4 FareInfos { get; set; }
        public TPAExtensions12 TPA_Extensions { get; set; }
    }
    public class TicketingInfo2
    {
        public string TicketType { get; set; }
    }
    public class AdditionalFare
    {
        public AirItineraryPricingInfo2 AirItineraryPricingInfo { get; set; }
        public TicketingInfo2 TicketingInfo { get; set; }
    }
    public class ValidatingCarrier3
    {
        public string Code { get; set; }
    }
    public class DiversitySwapper
    {
        public double WeighedPriceAmount { get; set; }
    }
    public class TPAExtensions7
    {
        public List<AdditionalFare> AdditionalFares { get; set; }
        public ValidatingCarrier3 ValidatingCarrier { get; set; }
        public DiversitySwapper DiversitySwapper { get; set; }
    }
    public class PricedItinerary
    {
        public int SequenceNumber { get; set; }
        public AirItinerary AirItinerary { get; set; }
        public List<AirItineraryPricingInfo> AirItineraryPricingInfo { get; set; }
        public TicketingInfo TicketingInfo { get; set; }
        public TPAExtensions7 TPA_Extensions { get; set; }
    }
    public class PricedItineraries
    {
        public List<PricedItinerary> PricedItinerary { get; set; }
    }
    public class OTAAirLowFareSearchRS
    {
        public int PricedItinCount { get; set; }
        public int BrandedOneWayItinCount { get; set; }
        public int SimpleOneWayItinCount { get; set; }
        public int DepartedItinCount { get; set; }
        public int SoldOutItinCount { get; set; }
        public int AvailableItinCount { get; set; }
        public string Version { get; set; }
        public string StatusMessage { get; set; }
        public Success Success { get; set; }
        public Warnings Warnings { get; set; }
        public PricedItineraries PricedItineraries { get; set; }
    }
    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
    }
      
    public class SearchResponseBaseModelJson
    {
        public OTAAirLowFareSearchRS OTA_AirLowFareSearchRS { get; set; }
        public string RequestId { get; set; }
        public List<Link> Links { get; set; }
    }
}
