using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Models.Sabre.JsonModels.FilteredResponse
{
    public class Warning
    {
        public int WarningId { get; set; }
        public string Type { get; set; }
        public string ShortText { get; set; }
        public string Code { get; set; }
        public string content { get; set; }
        public string MessageClass { get; set; }
    }
    public class Warnings
    {
        public int WarningsId { get; set; }
        public List<Warning> Warning { get; set; }
    }
    public class Success
    {
        public int SuccessId { get; set; }
        public string Message { get; set; }
    }
    public class DepartureAirport
    {
        public int DepartureAirportId { get; set; }
        public string LocationCode { get; set; }
        public string TerminalID { get; set; }
        public string content { get; set; }
        public string DepartureAirportCity { get; set; }
    }
    public class ArrivalAirport
    {
        public int ArrivalAirportId { get; set; }
        public string LocationCode { get; set; }
        public string TerminalID { get; set; }
        public string content { get; set; }
        public string ArrivalAirportCity { get; set; }
    }
    public class OperatingAirline
    {
        public int OperatingAirlineId { get; set; }
        public string Code { get; set; }
        public string FlightNumber { get; set; }
        public string content { get; set; }
    }
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string AirEquipType { get; set; }
        public string content { get; set; }
    }
    public class MarketingAirline
    {
        public int MarketingAirlineId { get; set; }
        public string Code { get; set; }
        public string content { get; set; }
        public string AirlineName { get; set; }
    }
    public class DisclosureAirline
    {
        public int DisclosureAirlineId { get; set; }
        public string Code { get; set; }
        public string content { get; set; }
    }
    public class DepartureTimeZone
    {
        public int DepartureTimeZoneId { get; set; }
        public double GMTOffset { get; set; }
    }
    public class ArrivalTimeZone
    {
        public int ArrivalTimeZoneId { get; set; }
        public double GMTOffset { get; set; }
    }
    public class ETicket
    {
        public int ETicketId { get; set; }
        public bool Ind { get; set; }
    }
    public class Mileage
    {
        public int MileageId { get; set; }
        public int Amount { get; set; }
    }
    public class TPAExtension
    {
        public int TPA_Extensions1Id { get; set; }
        public List<ETicket> eTicket { get; set; }
        public List<Mileage> Mileage { get; set; }
    }
    public class FlightSegment
    {
        public int FlightSegmentId { get; set; }
        public int SegmentOrderNo { get; set; }
        public string InOutBound { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public int StopQuantity { get; set; }
        public string FlightNumber { get; set; }
        public string ResBookDesigCode { get; set; }
        public int ElapsedTime { get; set; }
        public string MarriageGrp { get; set; }
        public List<DepartureAirport> DepartureAirport { get; set; }
        public List<ArrivalAirport> ArrivalAirport { get; set; }
        public List<OperatingAirline> OperatingAirline { get; set; }
        public List<Equipment> Equipment { get; set; }
        public List<MarketingAirline> MarketingAirline { get; set; }
        public List<DisclosureAirline> DisclosureAirline { get; set; }
        public List<DepartureTimeZone> DepartureTimeZone { get; set; }
        public List<ArrivalTimeZone> ArrivalTimeZone { get; set; }
        public List<TPAExtension> TPA_Extensions { get; set; }
    }
    public class OriginDestinationOption
    {
        public int OriginDestinationOptionId { get; set; }
        public int ElapsedTime { get; set; }
        public List<FlightSegment> FlightSegment { get; set; }
    }
    public class OriginDestinationOptions
    {
        public int OriginDestinationOptionsId { get; set; }
        public List<OriginDestinationOption> OriginDestinationOption { get; set; }
    }
    public class AirItinerary
    {
        public int AirItineraryId { get; set; }
        public string DirectionInd { get; set; }
        public List<OriginDestinationOptions> OriginDestinationOptions { get; set; }
    }
    public class BaseFare
    {
        public int BaseFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class FareConstruction
    {
        public int FareConstructionId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare
    {
        public int EquivFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax
    {
        public int TaxId { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
    }
    public class Taxes
    {
        public int TaxesId { get; set; }
        public List<Tax> Tax { get; set; }
    }
    public class TotalFare
    {
        public int TotalFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class ItinTotalFare
    {
        public int ItinTotalFareId { get; set; }
        public List<BaseFare> BaseFare { get; set; }
        public List<FareConstruction> FareConstruction { get; set; }
        public List<EquivFare> EquivFare { get; set; }
        public List<Taxes> Taxes { get; set; }
        public List<TotalFare> TotalFare { get; set; }
    }
    public class PassengerTypeQuantity
    {
        public int PTQId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
    public class FareBasisCode
    {
        public int FareBasisCodeId { get; set; }
        public string BookingCode { get; set; }
        public string DepartureAirportCode { get; set; }
        public string ArrivalAirportCode { get; set; }
        public string FareComponentBeginAirport { get; set; }
        public string FareComponentEndAirport { get; set; }
        public string FareComponentDirectionality { get; set; }
        public string FareComponentVendorCode { get; set; }
        public string GovCarrier { get; set; }
        public string content { get; set; }
        public bool AvailabilityBreak { get; set; }
    }
    public class FareBasisCodes
    {
        public int FareBasisCodesId { get; set; }
        public List<FareBasisCode> FareBasisCode { get; set; }
    }
    public class BaseFare2
    {
        public int BaseFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class FareConstruction2
    {
        public int FareConstruction2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare2
    {
        public int EquivFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax4
    {
        public int Tax2Id { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string CountryCode { get; set; }
        public string content { get; set; }
    }
    public class TaxSummary
    {
        public int TaxSummaryId { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TotalTax
    {
        public int TotalTaxId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax2
    {
        public int Taxes2Id { get; set; }
        public List<Tax4> Tax { get; set; }
        public List<TaxSummary> TaxSummary { get; set; }
        public List<TotalTax> TotalTax { get; set; }
    }
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
    public class FareSettingsParameters
    {
        public bool CCEnableAir { get; set; }
        public double StandardPublishedMarkup { get; set; }
        public double StandardNetMarkup { get; set; }
        public double StandardTourNetMarkup { get; set; }
        public double InfantFare { get; set; }
        public bool IsAveragefare { get; set; }
        public bool IsChangeCancelDisplay { get; set; }
    }
    public class TotalFare2
    {
        public int TotalFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public MarkupParameters MarkupParameters { get; set; }
        public FareSettingsParameters FareParameters { get; set; }
    }
    public class Penalty
    {
        public int PenaltyId { get; set; }
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
        public int PenaltiesInfoId { get; set; }
        public List<Penalty> Penalty { get; set; }
    }
    public class Message
    {
        public int MessageId { get; set; }
        public string AirlineCode { get; set; }
        public string Type { get; set; }
        public int FailCode { get; set; }
        public string Info { get; set; }
    }
    public class Messages
    {
        public int MessagesId { get; set; }
        public List<Message> Message { get; set; }
    }
    public class Segment
    {
        public int SegmentId { get; set; }
        public int Id { get; set; }
    }
    public class Allowance
    {
        public int AllowanceId { get; set; }
        public int Pieces { get; set; }
    }
    public class BaggageInformation
    {
        public int BaggageInformationId { get; set; }
        public string ProvisionType { get; set; }
        public string AirlineCode { get; set; }
        public int OrderNo { get; set; }
        public List<Segment> Segment { get; set; }
        public List<Allowance> Allowance { get; set; }
    }
    public class BaggageInformationList
    {
        public int BaggageInformationListId { get; set; }
        public List<BaggageInformation> BaggageInformation { get; set; }
    }
    public class TPAExtension2
    {
        public int TPA_Extensions2Id { get; set; }
        public List<Message> Messages { get; set; }
        public List<BaggageInformationList> BaggageInformationList { get; set; }
    }
    public class PassengerFare
    {
        public int PassengerFareId { get; set; }
        public List<BaseFare2> BaseFare { get; set; }
        public List<FareConstruction2> FareConstruction { get; set; }
        public List<EquivFare2> EquivFare { get; set; }
        public List<Tax2> Taxes { get; set; }
        public List<TotalFare2> TotalFare { get; set; }
        public List<PenaltiesInfo> PenaltiesInfo { get; set; }
        public List<TPAExtension2> TPA_Extensions { get; set; }
    }
    public class Endorsement
    {
        public int EndorsementsId { get; set; }
        public bool NonRefundableIndicator { get; set; }
    }
    public class FareCalcLine
    {
        public int FareCalcLineId { get; set; }
        public string Info { get; set; }
    }
    public class TPAExtension3
    {
        public int TPA_Extensions3Id { get; set; }
        public List<FareCalcLine> FareCalcLine { get; set; }
    }
    public class SeatsRemaining
    {
        public int SeatsRemainingId { get; set; }
        public string PassengerType { get; set; }
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin
    {
        public int CabinId { get; set; }
        public string PassengerType { get; set; }
        public string Cabins { get; set; }
    }
    public class Meal
    {
        public int MealId { get; set; }
        public string PassengerType { get; set; }
        public string Code { get; set; }
    }
    public class TPAExtension4
    {
        public int TPA_Extensions4Id { get; set; }
        public IList<SeatsRemaining> SeatsRemaining { get; set; }
        public IList<Cabin> Cabin { get; set; }
        public IList<Meal> Meal { get; set; }
    }
    public class FareInfo
    {
        public int FareInfoId { get; set; }
        public string PassengerType { get; set; }
        public string FareReference { get; set; }
        public IList<TPAExtension4> TPA_Extensions { get; set; }
    }
    public class FareInfoTest
    {
        public int FareInfoId { get; set; }
        public string PassengerType { get; set; }
        public string FareReference { get; set; }
        public IList<TPAExtension4> TPA_Extensions { get; set; }
    }
    public class FareInfos
    {
        public int FareInfosId { get; set; }
        public IList<FareInfo> FareInfo { get; set; }
    }
    public class FareInfostest
    {
        public int FareInfosId { get; set; }
        public IList<FareInfoTest> FareInfo { get; set; }
    }
    public class PTCFareBreakdown2
    {
        public int PTC_FareBreakdownId { get; set; }
        public List<PassengerTypeQuantity> PassengerTypeQuantity { get; set; }
        public List<FareBasisCode> FareBasisCodes { get; set; }
        public List<PassengerFare> PassengerFare { get; set; }
        public List<Endorsement> Endorsements { get; set; }
        public List<TPAExtension3> TPA_Extensions { get; set; }
        public IList<FareInfos> FareInfos { get; set; }
    }
    public class PTCFareBreakdown
    {
        public int PTC_FareBreakdownsId { get; set; }
        public List<PTCFareBreakdown2> PTC_FareBreakdown { get; set; }
    }
    public class DivideInParty
    {
        public int DivideInPartyId { get; set; }
        public bool Indicator { get; set; }
    }
    public class Default
    {
        public int DefaultId { get; set; }
        public string Code { get; set; }
        public string AirlineName { get; set; }
    }
    public class ValidatingCarrier
    {
        public int ValidatingCarrierId { get; set; }
        public string SettlementMethod { get; set; }
        public bool NewVcxProcess { get; set; }
        public List<Default> Default { get; set; }
    }
    public class TPAExtension5
    {
        public int TPA_Extensions6Id { get; set; }
        public List<DivideInParty> DivideInParty { get; set; }
        public List<ValidatingCarrier> ValidatingCarrier { get; set; }
    }
    public class AirItineraryPricingInfo
    {
        public int AirItineraryPricingInfoId { get; set; }
        public string LastTicketDate { get; set; }
        public string PricingSource { get; set; }
        public string PricingSubSource { get; set; }
        public bool FareReturned { get; set; }
        public List<ItinTotalFare> ItinTotalFare { get; set; }
        public List<PTCFareBreakdown> PTC_FareBreakdowns { get; set; }
        public FareInfo FareInfos { get; set; }
        public List<TPAExtension5> TPA_Extensions { get; set; }
    }
    public class TicketingInfo
    {
        public int TicketingInfoId { get; set; }
        public string TicketType { get; set; }
        public string ValidInterline { get; set; }
    }
    public class BaseFare3
    {
        public int BaseFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class FareConstruction3
    {
        public int FareConstructionId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare3
    {
        public int EquivFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax6
    {
        public int TaxId { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
    }
    public class Tax5
    {
        public int TaxesId { get; set; }
        public List<Tax6> Tax { get; set; }
    }
    public class TotalFare3
    {
        public int TotalFareId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class ItinTotalFare2
    {
        public int ItinTotalFareId { get; set; }
        public List<BaseFare3> BaseFare { get; set; }
        public List<FareConstruction3> FareConstruction { get; set; }
        public List<EquivFare3> EquivFare { get; set; }
        public List<Tax5> Taxes { get; set; }
        public List<TotalFare3> TotalFare { get; set; }
    }
    public class PassengerTypeQuantity2
    {
        public int PTQId { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
    }
    public class FareBasisCode4
    {
        public int FareBasisCodeId { get; set; }
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
        public bool AvailabilityBreak { get; set; }
    }
    public class FareBasisCode3
    {
        public int FareBasisCodesId { get; set; }
        public List<FareBasisCode4> FareBasisCode { get; set; }
    }
    public class BaseFare4
    {
        public int BaseFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
    public class FareConstruction4
    {
        public int FareConstruction2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class EquivFare4
    {
        public int EquivFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax8
    {
        public int Tax2Id { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string CountryCode { get; set; }
        public string content { get; set; }
    }
    public class TaxSummary2
    {
        public int TaxSummaryId { get; set; }
        public string TaxCode { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
        public string content { get; set; }
        public string CountryCode { get; set; }
    }
    public class TotalTax2
    {
        public int TotalTaxId { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int DecimalPlaces { get; set; }
    }
    public class Tax7
    {
        public int Taxes2Id { get; set; }
        public List<Tax8> Tax { get; set; }
        public List<TaxSummary2> TaxSummary { get; set; }
        public List<TotalTax2> TotalTax { get; set; }
    }
    public class MarkupParameters2
    {
        public double PassengerFare { get; set; }
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
    public class TotalFare4
    {
        public int TotalFare2Id { get; set; }
        public double Amount { get; set; }
        public string CurrencyCode { get; set; }
        public MarkupParameters2 MarkupParameters { get; set; }
        public FareSettingsParameters FareParameters { get; set; }
    }
    public class Message4
    {
        public int MessageId { get; set; }
        public string AirlineCode { get; set; }
        public string Type { get; set; }
        public int FailCode { get; set; }
        public string Info { get; set; }
    }
    public class Message3
    {
        public int MessagesId { get; set; }
        public List<Message4> Message { get; set; }
    }
    public class Segment2
    {
        public int SegmentId { get; set; }
        public int Id { get; set; }
    }
    public class Allowance2
    {
        public int AllowanceId { get; set; }
        public int Pieces { get; set; }
    }
    public class BaggageInformation2
    {
        public int BaggageInformationId { get; set; }
        public string ProvisionType { get; set; }
        public string AirlineCode { get; set; }
        public int OrderNo { get; set; }
        public List<Segment2> Segment { get; set; }
        public List<Allowance2> Allowance { get; set; }
    }
    public class BaggageInformationList2
    {
        public int BaggageInformationListId { get; set; }
        public List<BaggageInformation2> BaggageInformation { get; set; }
    }
    public class CommissionData
    {
        public double Cat35MarkupAmount { get; set; }
        public double CommissionAmountInEquivalent { get; set; }
    }
    public class TPAExtension7
    {
        public int TPA_Extensions2Id { get; set; }
        public List<Message3> Messages { get; set; }
        public List<BaggageInformationList2> BaggageInformationList { get; set; }
        public List<CommissionData> CommissionData { get; set; }
    }
    public class PassengerFare2
    {
        public int PassengerFareId { get; set; }
        public List<BaseFare4> BaseFare { get; set; }
        public List<FareConstruction4> FareConstruction { get; set; }
        public List<EquivFare4> EquivFare { get; set; }
        public List<Tax7> Taxes { get; set; }
        public List<TotalFare4> TotalFare { get; set; }
        public List<TPAExtension7> TPA_Extensions { get; set; }
    }
    public class Endorsement2
    {
        public int EndorsementsId { get; set; }
        public bool NonRefundableIndicator { get; set; }
    }
    public class FareCalcLine2
    {
        public int FareCalcLineId { get; set; }
        public string Info { get; set; }
    }
    public class FareType
    {
        public string Name { get; set; }
        public string content { get; set; }
    }
    public class TPAExtension8
    {
        public int TPA_Extensions3Id { get; set; }
        public List<FareCalcLine2> FareCalcLine { get; set; }
        public List<FareType> FareType { get; set; }
    }
    public class SeatsRemaining2
    {
        public int SeatsRemainingId { get; set; }
        public int Number { get; set; }
        public bool BelowMin { get; set; }
    }
    public class Cabin2
    {
        public int CabinId { get; set; }
        public string Cabins { get; set; }
    }
    public class Meal2
    {
        public int MealId { get; set; }
        public string Code { get; set; }
    }
    public class TPAExtension9
    {
        public int TPA_Extensions4Id { get; set; }
        public List<SeatsRemaining2> SeatsRemaining { get; set; }
        public List<Cabin2> Cabin { get; set; }
        public List<Meal2> Meal { get; set; }
    }
    public class FareInfo4
    {
        public int FareInfoId { get; set; }
        public string FareReference { get; set; }
        public List<TPAExtension9> TPA_Extensions { get; set; }
    }
    public class FareInfo3
    {
        public int FareInfosId { get; set; }
        public List<FareInfo4> FareInfo { get; set; }
    }
    public class PTCFareBreakdown4
    {
        public int PTC_FareBreakdownId { get; set; }
        public string PrivateFareType { get; set; }
        public List<PassengerTypeQuantity2> PassengerTypeQuantity { get; set; }
        public List<FareBasisCode3> FareBasisCodes { get; set; }
        public List<PassengerFare2> PassengerFare { get; set; }
        public List<Endorsement2> Endorsements { get; set; }
        public List<TPAExtension8> TPA_Extensions { get; set; }
        public List<FareInfo3> FareInfos { get; set; }
    }
    public class PTCFareBreakdown3
    {
        public int PTC_FareBreakdownsId { get; set; }
        public List<PTCFareBreakdown4> PTC_FareBreakdown { get; set; }
    }
    public class DivideInParty2
    {
        public int DivideInPartyId { get; set; }
        public bool Indicator { get; set; }
    }
    public class Default2
    {
        public int DefaultId { get; set; }
        public string Code { get; set; }
        public string AirlineName { get; set; }
    }
    public class ValidatingCarrier2
    {
        public int ValidatingCarrierId { get; set; }
        public string SettlementMethod { get; set; }
        public bool NewVcxProcess { get; set; }
        public List<Default2> Default { get; set; }
    }
    public class TPAExtension10
    {
        public int TPA_Extensions6Id { get; set; }
        public List<DivideInParty2> DivideInParty { get; set; }
        public List<ValidatingCarrier2> ValidatingCarrier { get; set; }
    }
    public class AirItineraryPricingInfo2
    {
        public int AirItineraryPricingInfoId { get; set; }
        public string LastTicketDate { get; set; }
        public string PrivateFareType { get; set; }
        public int FlexibleFareID { get; set; }
        public string PricingSource { get; set; }
        public string PricingSubSource { get; set; }
        public bool FareReturned { get; set; }
        public List<ItinTotalFare2> ItinTotalFare { get; set; }
        public List<PTCFareBreakdown3> PTC_FareBreakdowns { get; set; }
        public List<FareInfo3> FareInfos { get; set; }
        public List<TPAExtension10> TPA_Extensions { get; set; }
    }
    public class AdditionalFare
    {
        public int AdditionalFareId { get; set; }
        public List<AirItineraryPricingInfo2> AirItineraryPricingInfo { get; set; }
        public List<TicketingInfo> TicketingInfo { get; set; }
    }
    public class ValidatingCarrier3
    {
        public int ValidatingCarrier2Id { get; set; }
        public string Code { get; set; }

    }
    public class DiversitySwapper
    {
        public int DiversitySwapperId { get; set; }
        public double WeighedPriceAmount { get; set; }
    }
    public class TPAExtension6
    {
        public int TPA_Extensions7Id { get; set; }
        public List<AdditionalFare> AdditionalFares { get; set; }
        public List<ValidatingCarrier3> ValidatingCarrier { get; set; }
        public List<DiversitySwapper> DiversitySwapper { get; set; }
    }
    public class PricedItinerary
    {
        public int PricedItineraryId { get; set; }
        public int SequenceNumber { get; set; }
        public List<AirItinerary> AirItinerary { get; set; }
        public List<AirItineraryPricingInfo> AirItineraryPricingInfo { get; set; }
        public List<TicketingInfo> TicketingInfo { get; set; }
        public List<TPAExtension6> TPA_Extensions { get; set; }
    }
    public class PricedItineraries
    {
        public int PricedItinerariesId { get; set; }
        public List<PricedItinerary> PricedItinerary { get; set; }
    }
    public class OTAAirLowFareSearchRS
    {
        public int OTAId { get; set; }
        public int PricedItinCount { get; set; }
        public int BrandedOneWayItinCount { get; set; }
        public int SimpleOneWayItinCount { get; set; }
        public int DepartedItinCount { get; set; }
        public int SoldOutItinCount { get; set; }
        public int AvailableItinCount { get; set; }
        public string Version { get; set; }
        public string StatusMessage { get; set; }
        public List<Warnings> Warnings { get; set; }
        public List<Success> Success { get; set; }
        public List<PricedItineraries> PricedItineraries { get; set; }
    }
    public class Link
    {
        public int LinkId { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
    }
    public class Data
    {
        public int SearchResponseBaseModelId { get; set; }
        public string RequestId { get; set; }
        public List<OTAAirLowFareSearchRS> OTA_AirLowFareSearchRS { get; set; }
        public List<Link> Links { get; set; }
       
    }
    public class FilteredSearchResponse
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public string Airline { get; set; }
        public string AirlineText { get; set; }
        public string OAirlineText { get; set; }
        public string MAirlineText { get; set; }
        public string FareType { get; set; }
        public string Adults { get; set; }
        public string Children { get; set; }
        public string Infants { get; set; }
        public string DirectOnly { get; set; }

        public string Departure1 { get; set; }
        public string Destination1 { get; set; }
        public string DepartureDate1 { get; set; }
        public string Departure2 { get; set; }
        public string Destination2 { get; set; }
        public string DepartureDate2 { get; set; }
        public string ODeparture { get; set; }
        public string ODestination { get; set; }
        public string ODepartureDate { get; set; }
        public string OReturnDate { get; set; }
        public string OAirline { get; set; }
        public string OFareType { get; set; }
        public string ONoOfAdults { get; set; }
        public string ONoOfChildrens { get; set; }
        public string ONoOfInfants { get; set; }
        public string ODirectFlights { get; set; }

        public Data Data { get; set; }
        public string Data1 { get; set; }
        public bool IsCancellationDisplay { get; set; }
        public string AgencyDetails { get; set; }
        public string CCFEE { get; set; }
        public string PolicyNumber { get; set; }
        public string PurchaseDate { get; set; }
        public string Price { get; set; }
        public string CancellationDate { get; set; }
        public string RequestPostTime { get; set; }
        public string ResponseGetTime { get; set; }
        public string Information { get; set; }
        public string ActionType { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }
       
    }
}