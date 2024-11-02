using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Models.DTO
{
    public class SearchResponseBaseModel
    {
        public SearchResponseBaseModel()
        {
            this.Links = new List<Link1>();
            this.OTA_AirLowFareSearchRS = new List<OTAAirLowFareSearchRS1>();
            //===  this.ProcessingTimes = new List<ProcessingTime>();
        }
        [Key, Column(Order = 1)]
        public int SearchResponseBaseModelId { get; set; }
        [StringLength(100)]
        public string RequestId { get; set; }
        
        public class OTAAirLowFareSearchRS1
        {
            public OTAAirLowFareSearchRS1()
            {
                this.Warnings = new List<Warnings1>();
                this.Success = new List<Success1>();
                this.PricedItineraries = new List<PricedItineraries1>();
            }
            [Key, Column(Order = 1)]
            public int OTAId { get; set; }
            public int PricedItinCount { get; set; }
            public int BrandedOneWayItinCount { get; set; }
            public int SimpleOneWayItinCount { get; set; }
            public int DepartedItinCount { get; set; }
            public int SoldOutItinCount { get; set; }
            public int AvailableItinCount { get; set; }
            [StringLength(50)]
            public string Version { get; set; }
            [StringLength(100)]
            public string StatusMessage { get; set; }
            public class Success1
            {
                [Key]
                [Column(Order = 1)]
                public int SuccessId { get; set; }
                [StringLength(200)]
                public string Message { get; set; }
            }
            public class Warnings1
            {
                public Warnings1()
                {
                    this.Warning = new List<Warning1>();
                }
                [Key]
                [Column(Order = 1)]
                public int WarningsId { get; set; }
                public class Warning1
                {
                    [Key]
                    [Column(Order = 1)]
                    public int WarningId { get; set; }
                    [StringLength(50)]
                    public string Type { get; set; }
                    [StringLength(200)]
                    public string ShortText { get; set; }
                    [StringLength(100)]
                    public string Code { get; set; }
                    [StringLength(200)]
                    public string content { get; set; }
                    [StringLength(200)]
                    public string MessageClass { get; set; }
                }
                public List<Warning1> Warning { get; set; }
            }
            public class PricedItineraries1
            {
                public PricedItineraries1()
                {
                    this.PricedItinerary = new List<PricedItinerary1>();
                }
                [Key]
                [Column(Order = 1)]
                public int PricedItinerariesId { get; set; }
                public class PricedItinerary1
                {
                    public PricedItinerary1()
                    {
                        this.AirItinerary = new List<AirItinerary1>();
                        this.AirItineraryPricingInfo = new List<AirItineraryPricingInfo1>();
                        this.TicketingInfo = new List<TicketingInfo1>();
                        this.TPA_Extensions = new List<TPA_Extensions7>();
                    }
                    [Key]
                    [Column(Order = 1)]
                    public int PricedItineraryId { get; set; }
                    public int SequenceNumber { get; set; }
                    public class AirItinerary1
                    {
                        public AirItinerary1()
                        {
                            this.OriginDestinationOptions = new List<OriginDestinationOptions1>();
                        }
                        [Key]
                        [Column(Order = 1)]
                        public int AirItineraryId { get; set; }
                        [StringLength(30)]
                        public string DirectionInd { get; set; }
                        public class OriginDestinationOptions1
                        {
                            public OriginDestinationOptions1()
                            {
                                this.OriginDestinationOption = new List<OriginDestinationOption1>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int OriginDestinationOptionsId { get; set; }
                            public class OriginDestinationOption1
                            {
                                public OriginDestinationOption1()
                                {
                                    this.FlightSegment = new List<FlightSegment1>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int OriginDestinationOptionId { get; set; }
                                public int ElapsedTime { get; set; }
                                public class FlightSegment1
                                {
                                    public FlightSegment1()
                                    {
                                        this.DepartureAirport = new List<DepartureAirport1>();
                                        this.ArrivalAirport = new List<ArrivalAirport1>();
                                        this.OperatingAirline = new List<OperatingAirline1>();
                                        this.Equipment = new List<Equipment1>();
                                        this.MarketingAirline = new List<MarketingAirline1>();
                                        this.DisclosureAirline = new List<DisclosureAirline1>();
                                        this.DepartureTimeZone = new List<DepartureTimeZone1>();
                                        this.ArrivalTimeZone = new List<ArrivalTimeZone1>();
                                        this.TPA_Extensions = new List<TPA_Extensions1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int FlightSegmentId { get; set; }
                                    public int SegmentOrderNo { get; set; }
                                    [StringLength(50)]
                                    public string InOutBound { get; set; } /*=== "OutBound" or "InBound" ===*/
                                    [StringLength(30)]
                                    public string DepartureDateTime { get; set; }
                                    [StringLength(30)]
                                    public string ArrivalDateTime { get; set; }
                                    public int StopQuantity { get; set; }
                                    [StringLength(10)]
                                    public string FlightNumber { get; set; }
                                    [StringLength(5)]
                                    public string ResBookDesigCode { get; set; }
                                    public int ElapsedTime { get; set; }
                                    [StringLength(5)]
                                    public string MarriageGrp { get; set; }
                                    
                                    public class DepartureAirport1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int DepartureAirportId { get; set; }
                                        [StringLength(5)]
                                        public string LocationCode { get; set; }
                                        [StringLength(5)]
                                        public string TerminalID { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                        public string DepartureAirportCity { get; set; }
                                    }
                                    public class ArrivalAirport1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int ArrivalAirportId { get; set; }
                                        [StringLength(5)]
                                        public string LocationCode { get; set; }
                                        [StringLength(5)]
                                        public string TerminalID { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                        public string ArrivalAirportCity { get; set; }
                                    }
                                    public class OperatingAirline1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int OperatingAirlineId { get; set; }
                                        [StringLength(5)]
                                        public string Code { get; set; }
                                        [StringLength(10)]
                                        public string FlightNumber { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                    }
                                    public class Equipment1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int EquipmentId { get; set; }
                                        [StringLength(50)]
                                        public string AirEquipType { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                    }
                                    public class MarketingAirline1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int MarketingAirlineId { get; set; }
                                        [StringLength(5)]
                                        public string Code { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                        public string AirlineName { get; set; }
                                    }
                                    public class DisclosureAirline1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int DisclosureAirlineId { get; set; }
                                        [StringLength(5)]
                                        public string Code { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                    }
                                    public class DepartureTimeZone1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int DepartureTimeZoneId { get; set; }
                                        public double GMTOffset { get; set; }
                                    }
                                    public class ArrivalTimeZone1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int ArrivalTimeZoneId { get; set; }
                                        public double GMTOffset { get; set; }
                                    }
                                    public class TPA_Extensions1
                                    {
                                        public TPA_Extensions1()
                                        {
                                            this.eTicket = new List<ETicket1>();
                                            this.Mileage = new List<Mileage1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int TPA_Extensions1Id { get; set; }
                                        public class ETicket1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int ETicketId { get; set; }
                                            [StringLength(100)]
                                            public bool Ind { get; set; }
                                        }
                                        public class Mileage1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int MileageId { get; set; }
                                            public int Amount { get; set; }
                                        }
                                        public List<ETicket1> eTicket { get; set; }
                                        public List<Mileage1> Mileage { get; set; }
                                    }
                                    public List<DepartureAirport1> DepartureAirport { get; set; }
                                    public List<ArrivalAirport1> ArrivalAirport { get; set; }
                                    public List<OperatingAirline1> OperatingAirline { get; set; }
                                    public List<Equipment1> Equipment { get; set; }
                                    public List<MarketingAirline1> MarketingAirline { get; set; }
                                    public List<DisclosureAirline1> DisclosureAirline { get; set; }
                                    public List<DepartureTimeZone1> DepartureTimeZone { get; set; }
                                    public List<ArrivalTimeZone1> ArrivalTimeZone { get; set; }
                                    public List<TPA_Extensions1> TPA_Extensions { get; set; }
                                }
                                public List<FlightSegment1> FlightSegment { get; set; }
                            }
                            public List<OriginDestinationOption1> OriginDestinationOption { get; set; }
                        }
                        public List<OriginDestinationOptions1> OriginDestinationOptions { get; set; }
                    }
                    public class AirItineraryPricingInfo1
                    {
                        public AirItineraryPricingInfo1()
                        {
                            this.ItinTotalFare = new List<ItinTotalFare1>();
                            this.PTC_FareBreakdowns = new List<PTC_FareBreakdowns1>();
                            //===this.FareInfos = new List<FareInfos2>();
                            this.TPA_Extensions = new List<TPA_Extensions6>();
                        }
                        [Key]
                        [Column(Order = 1)]
                        public int AirItineraryPricingInfoId { get; set; }
                        [StringLength(30)]
                        public string LastTicketDate { get; set; }
                        [StringLength(10)]
                        public string PricingSource { get; set; }
                        [StringLength(10)]
                        public string PricingSubSource { get; set; }
                        public bool FareReturned { get; set; }
                        public class ItinTotalFare1
                        {
                            public ItinTotalFare1()
                            {
                                this.BaseFare = new List<BaseFare1>();
                                this.FareConstruction = new List<FareConstruction1>();
                                this.EquivFare = new List<EquivFare1>();
                                this.Taxes = new List<Taxes1>();
                                this.TotalFare = new List<TotalFare1>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int ItinTotalFareId { get; set; }
                            public class BaseFare1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int BaseFareId { get; set; }
                                [StringLength(100)]
                                public double Amount { get; set; }
                                [StringLength(5)]
                                public string CurrencyCode { get; set; }
                                public int DecimalPlaces { get; set; }
                            }
                            public class FareConstruction1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int FareConstructionId { get; set; }
                                public double Amount { get; set; }
                                [StringLength(5)]
                                public string CurrencyCode { get; set; }
                                public int DecimalPlaces { get; set; }
                            }
                            public class EquivFare1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int EquivFareId { get; set; }
                                public double Amount { get; set; }
                                [StringLength(5)]
                                public string CurrencyCode { get; set; }
                                public int DecimalPlaces { get; set; }
                            }
                            public class Taxes1
                            {
                                public Taxes1()
                                {
                                    this.Tax = new List<Tax1>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int TaxesId { get; set; }
                                public class Tax1
                                {
                                    [Key]
                                    [Column(Order = 1)]
                                    public int TaxId { get; set; }
                                    [StringLength(15)]
                                    public string TaxCode { get; set; }
                                    public double Amount { get; set; }
                                    [StringLength(5)]
                                    public string CurrencyCode { get; set; }
                                    public int DecimalPlaces { get; set; }
                                    [StringLength(200)]
                                    public string content { get; set; }
                                }
                                public List<Tax1> Tax { get; set; }
                            }
                            public class TotalFare1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int TotalFareId { get; set; }
                                public double Amount { get; set; }
                                [StringLength(5)]
                                public string CurrencyCode { get; set; }
                                public int DecimalPlaces { get; set; }
                            }
                            public List<BaseFare1> BaseFare { get; set; }
                            public List<FareConstruction1> FareConstruction { get; set; }
                            public List<EquivFare1> EquivFare { get; set; }
                            public List<Taxes1> Taxes { get; set; }
                            public List<TotalFare1> TotalFare { get; set; }
                        }
                        public class PTC_FareBreakdowns1
                        {
                            public PTC_FareBreakdowns1()
                            {
                                this.PTC_FareBreakdown = new List<PTC_FareBreakdown1>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int PTC_FareBreakdownsId { get; set; }
                            public class PTC_FareBreakdown1
                            {
                                public PTC_FareBreakdown1()
                                {
                                    this.PassengerTypeQuantity = new List<PassengerTypeQuantity1>();
                                    this.FareBasisCodes = new List<FareBasisCodes1>();
                                    this.PassengerFare = new List<PassengerFare1>();
                                    this.Endorsements = new List<Endorsements1>();
                                    this.TPA_Extensions = new List<TPA_Extensions3>();
                                    this.FareInfos = new List<FareInfos1>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int PTC_FareBreakdownId { get; set; }
                                public class PassengerTypeQuantity1
                                {
                                    [Key]
                                    [Column(Order = 1)]
                                    public int PTQId { get; set; }
                                    [StringLength(10)]
                                    public string Code { get; set; }
                                    public int Quantity { get; set; }
                                }
                                public class FareBasisCodes1
                                {
                                    public FareBasisCodes1()
                                    {
                                        this.FareBasisCode = new List<FareBasisCode1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int FareBasisCodesId { get; set; }
                                    public class FareBasisCode1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareBasisCodeId { get; set; }
                                        public string PassengerType { get; set; }
                                        [StringLength(5)]
                                        public string BookingCode { get; set; }
                                        [StringLength(5)]
                                        public string DepartureAirportCode { get; set; }
                                        [StringLength(5)]
                                        public string ArrivalAirportCode { get; set; }
                                        [StringLength(5)]
                                        public string FareComponentBeginAirport { get; set; }
                                        [StringLength(5)]
                                        public string FareComponentEndAirport { get; set; }
                                        [StringLength(5)]
                                        public string FareComponentDirectionality { get; set; }
                                        [StringLength(5)]
                                        public string FareComponentVendorCode { get; set; }
                                        [StringLength(5)]
                                        public string GovCarrier { get; set; }
                                        [StringLength(200)]
                                        public string content { get; set; }
                                        public bool? AvailabilityBreak { get; set; }
                                    }
                                    public List<FareBasisCode1> FareBasisCode { get; set; }
                                }
                                public class PassengerFare1
                                {
                                    public PassengerFare1()
                                    {
                                        this.BaseFare = new List<BaseFare2>();
                                        this.FareConstruction = new List<FareConstruction2>();
                                        this.EquivFare = new List<EquivFare2>();
                                        this.Taxes = new List<Taxes2>();
                                        this.TotalFare = new List<TotalFare2>();
                                        this.PenaltiesInfo = new List<PenaltiesInfo1>();
                                        this.TPA_Extensions = new List<TPA_Extensions2>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int PassengerFareId { get; set; }
                                    public class BaseFare2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int BaseFare2Id { get; set; }
                                        public string PassengerType { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                    }
                                    public class FareConstruction2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareConstruction2Id { get; set; }
                                        public string PassengerType { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public class EquivFare2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int EquivFare2Id { get; set; }
                                        public string PassengerType { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public class Taxes2
                                    {
                                        public Taxes2()
                                        {
                                            this.Tax = new List<Tax2>();
                                            this.TaxSummary = new List<TaxSummary1>();
                                            this.TotalTax = new List<TotalTax1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int Taxes2Id { get; set; }
                                        public class Tax2
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int Tax2Id { get; set; }
                                            public string PassengerType { get; set; }
                                            [StringLength(15)]
                                            public string TaxCode { get; set; }
                                            public double Amount { get; set; }
                                            [StringLength(5)]
                                            public string CurrencyCode { get; set; }
                                            public int DecimalPlaces { get; set; }
                                            [StringLength(5)]
                                            public string CountryCode { get; set; }
                                            [StringLength(200)]
                                            public string content { get; set; }
                                        }
                                        public class TaxSummary1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TaxSummaryId { get; set; }
                                            public string PassengerType { get; set; }
                                            [StringLength(15)]
                                            public string TaxCode { get; set; }
                                            public double Amount { get; set; }
                                            [StringLength(5)]
                                            public string CurrencyCode { get; set; }
                                            public int DecimalPlaces { get; set; }
                                            [StringLength(200)]
                                            public string content { get; set; }
                                            [StringLength(5)]
                                            public string CountryCode { get; set; }
                                        }
                                        public class TotalTax1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TotalTaxId { get; set; }
                                            public string PassengerType { get; set; }
                                            public double Amount { get; set; }
                                            [StringLength(5)]
                                            public string CurrencyCode { get; set; }
                                            public int DecimalPlaces { get; set; }
                                        }
                                        public List<Tax2> Tax { get; set; }
                                        public List<TaxSummary1> TaxSummary { get; set; }
                                        public List<TotalTax1> TotalTax { get; set; }
                                    }
                                    public class TotalFare2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int TotalFare2Id { get; set; }
                                        public string PassengerType { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public MarkupParameters MarkupParameters { get; set; }
                                        public FareSettingsParameters FareParameters { get; set; }
                                    }
                                    public class PenaltiesInfo1
                                    {
                                        public PenaltiesInfo1()
                                        {
                                            this.Penalty = new List<Penalty1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int PenaltiesInfoId { get; set; }
                                        public class Penalty1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int PenaltyId { get; set; }
                                            public string PassengerType { get; set; }
                                            [StringLength(25)]
                                            public string Type { get; set; }
                                            [StringLength(25)]
                                            public string Applicability { get; set; }
                                            public bool Changeable { get; set; }
                                            public double Amount { get; set; }
                                            [StringLength(5)]
                                            public string CurrencyCode { get; set; }
                                            public int DecimalPlaces { get; set; }
                                            public bool? Refundable { get; set; }
                                        }
                                        public List<Penalty1> Penalty { get; set; }
                                    }
                                    public class TPA_Extensions2
                                    {
                                        public TPA_Extensions2()
                                        {
                                            this.Messages = new List<Messages1>();
                                            this.BaggageInformationList = new List<BaggageInformationList1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int TPA_Extensions2Id { get; set; }
                                        public class Messages1
                                        {
                                            public Messages1()
                                            {
                                                this.Message = new List<Message1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int MessagesId { get; set; }
                                            public class Message1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int MessageId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string AirlineCode { get; set; }
                                                [StringLength(5)]
                                                public string Type { get; set; }
                                                public int FailCode { get; set; }
                                                [StringLength(500)]
                                                public string Info { get; set; }
                                            }
                                            public List<Message1> Message { get; set; }
                                        }
                                        public class BaggageInformationList1
                                        {
                                            public BaggageInformationList1()
                                            {
                                                this.BaggageInformation = new List<BaggageInformation1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int BaggageInformationListId { get; set; }
                                            public class BaggageInformation1
                                            {
                                                public BaggageInformation1()
                                                {
                                                    this.Segment = new List<Segment1>();
                                                    this.Allowance = new List<Allowance1>();
                                                }
                                                [Key]
                                                [Column(Order = 1)]
                                                public int BaggageInformationId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string ProvisionType { get; set; }
                                                [StringLength(5)]
                                                public string AirlineCode { get; set; }
                                                public int OrderNo { get; set; }
                                                public class Segment1
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int SegmentId { get; set; }
                                                    public string PassengerType { get; set; }
                                                    public int Id { get; set; }
                                                }
                                                public class Allowance1
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int AllowanceId { get; set; }
                                                    [StringLength(100)]
                                                    public string PassengerType { get; set; }
                                                    public int Pieces { get; set; }
                                                }
                                                public List<Segment1> Segment { get; set; }
                                                public List<Allowance1> Allowance { get; set; }
                                            }
                                            public List<BaggageInformation1> BaggageInformation { get; set; }
                                        }
                                        public List<Messages1> Messages { get; set; }
                                        public List<BaggageInformationList1> BaggageInformationList { get; set; }
                                    }
                                    public List<BaseFare2> BaseFare { get; set; }
                                    public List<FareConstruction2> FareConstruction { get; set; }
                                    public List<EquivFare2> EquivFare { get; set; }
                                    public List<Taxes2> Taxes { get; set; }
                                    public List<TotalFare2> TotalFare { get; set; }
                                    public List<PenaltiesInfo1> PenaltiesInfo { get; set; }
                                    public List<TPA_Extensions2> TPA_Extensions { get; set; }
                                }
                                public class Endorsements1
                                {
                                    [Key]
                                    [Column(Order = 1)]
                                    public int EndorsementsId { get; set; }
                                    public string PassengerType { get; set; }
                                    public bool NonRefundableIndicator { get; set; }
                                }
                                public class TPA_Extensions3
                                {
                                    public TPA_Extensions3()
                                    {
                                        this.FareCalcLine = new List<FareCalcLine1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int TPA_Extensions3Id { get; set; }
                                    public class FareCalcLine1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareCalcLineId { get; set; }
                                        public string PassengerType { get; set; }
                                        [StringLength(500)]
                                        public string Info { get; set; }
                                    }
                                    public List<FareCalcLine1> FareCalcLine { get; set; }
                                }
                                public class FareInfos1
                                {
                                    public FareInfos1()
                                    {
                                        this.FareInfo = new List<FareInfo1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int FareInfosId { get; set; }
                                    public class FareInfo1
                                    {
                                        public FareInfo1()
                                        {
                                            this.TPA_Extensions = new List<TPA_Extensions4>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareInfoId { get; set; }
                                        public string PassengerType { get; set; }
                                        [StringLength(5)]
                                        public string FareReference { get; set; }
                                        public class TPA_Extensions4
                                        {
                                            public TPA_Extensions4()
                                            {
                                                SeatsRemaining = new List<SeatsRemaining1>();
                                                Cabin = new List<Cabin1>();
                                                Meal = new List<Meal1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TPA_Extensions4Id { get; set; }
                                            public class SeatsRemaining1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int SeatsRemainingId { get; set; }
                                                public string PassengerType { get; set; }
                                                public int Number { get; set; }
                                                public bool BelowMin { get; set; }
                                            }
                                            public class Cabin1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int CabinId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string Cabins { get; set; }
                                            }
                                            public class Meal1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int MealId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string Code { get; set; }
                                            }
                                            public List<SeatsRemaining1> SeatsRemaining { get; set; }
                                            public List<Cabin1> Cabin { get; set; }
                                            public List<Meal1> Meal { get; set; }
                                        }
                                        public List<TPA_Extensions4> TPA_Extensions { get; set; }
                                    }
                                    public List<FareInfo1> FareInfo { get; set; }
                                }
                                public List<PassengerTypeQuantity1> PassengerTypeQuantity { get; set; }
                                public List<FareBasisCodes1> FareBasisCodes { get; set; }
                                public List<PassengerFare1> PassengerFare { get; set; }
                                public List<Endorsements1> Endorsements { get; set; }
                                public List<TPA_Extensions3> TPA_Extensions { get; set; }
                               public List<FareInfos1> FareInfos { get; set; }
                            }
                            public List<PTC_FareBreakdown1> PTC_FareBreakdown { get; set; }
                        }
                        public class FareInfos2
                        {
                            public FareInfos2()
                            {
                                this.FareInfo = new List<FareInfo2>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int FareInfos2Id { get; set; }
                            public class FareInfo2
                            {
                                public FareInfo2()
                                {
                                    this.TPA_Extensions = new List<TPA_Extensions5>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int FareInfo2Id { get; set; }
                                public string FareReference { get; set; }
                                public class TPA_Extensions5
                                {
                                    public TPA_Extensions5()
                                    {
                                        this.SeatsRemaining = new List<SeatsRemaining2>();
                                        this.Cabin = new List<Cabin2>();
                                        this.Meal = new List<Meal2>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int TPA_Extensions5Id { get; set; }
                                    public class SeatsRemaining2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int SeatsRemaining2Id { get; set; }
                                        [StringLength(100)]
                                        public int Number { get; set; }
                                        public bool BelowMin { get; set; }
                                    }
                                    public class Cabin2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int Cabin2Id { get; set; }
                                        [StringLength(5)]
                                        public string Cabin { get; set; }
                                    }
                                    public class Meal2
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int Meal2Id { get; set; }
                                        [StringLength(5)]
                                        public string Code { get; set; }
                                    }
                                    public List<SeatsRemaining2> SeatsRemaining { get; set; }
                                    public List<Cabin2> Cabin { get; set; }
                                    public List<Meal2> Meal { get; set; }
                                }
                                public List<TPA_Extensions5> TPA_Extensions { get; set; }
                            }
                            public List<FareInfo2> FareInfo { get; set; }
                        }
                        public class TPA_Extensions6
                        {
                            public TPA_Extensions6()
                            {
                                this.DivideInParty = new List<DivideInParty1>();
                                this.ValidatingCarrier = new List<ValidatingCarrier1>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int TPA_Extensions6Id { get; set; }
                            public class DivideInParty1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int DivideInPartyId { get; set; }
                                public bool Indicator { get; set; }
                            }
                            public class ValidatingCarrier1
                            {
                                public ValidatingCarrier1()
                                {
                                    this.Default = new List<Default1>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int ValidatingCarrierId { get; set; }
                                [StringLength(10)]
                                public string SettlementMethod { get; set; }
                                public bool NewVcxProcess { get; set; }
                                public class Default1
                                {
                                    [Key]
                                    [Column(Order = 1)]
                                    public int DefaultId { get; set; }
                                    [StringLength(5)]
                                    public string Code { get; set; }
                                    public string AirlineName { get; set; }
                                }
                                public List<Default1> Default { get; set; }
                            }
                            public List<DivideInParty1> DivideInParty { get; set; }
                            public List<ValidatingCarrier1> ValidatingCarrier { get; set; }
                        }
                        public List<ItinTotalFare1> ItinTotalFare { get; set; }
                        public List<PTC_FareBreakdowns1> PTC_FareBreakdowns { get; set; }
                       //=== public List<FareInfos2> FareInfos { get; set; }
                        public List<TPA_Extensions6> TPA_Extensions { get; set; }
                    }
                    public class TicketingInfo1
                    {
                        [Key]
                        [Column(Order = 1)]
                        public int TicketingInfoId { get; set; }
                        [StringLength(10)]
                        public string TicketType { get; set; }
                        [StringLength(10)]
                        public string ValidInterline { get; set; }
                    }
                    #region Additional Fares Section
                    public class TPA_Extensions7
                    {
                        public TPA_Extensions7()
                        {
                            this.AdditionalFares = new List<AdditionalFare1>();
                            this.ValidatingCarrier = new List<AF_ValidatingCarrier2>();
                            this.DiversitySwapper = new List<AF_DiversitySwapper1>();
                        }
                        [Key]
                        [Column(Order = 1)]
                        public int TPA_Extensions7Id { get; set; }
                        public class AdditionalFare1
                        {
                            public AdditionalFare1()
                            {
                                this.AirItineraryPricingInfo = new List<AF_AirItineraryPricingInfo1>();
                                this.TicketingInfo = new List<AF_TicketingInfo1>();
                            }
                            [Key]
                            [Column(Order = 1)]
                            public int AdditionalFareId { get; set; }
                            public class AF_AirItineraryPricingInfo1
                            {
                                public AF_AirItineraryPricingInfo1()
                                {
                                    this.ItinTotalFare = new List<AF_ItinTotalFare1>();
                                    this.PTC_FareBreakdowns = new List<AF_PTC_FareBreakdowns1>();
                                    //===this.FareInfos = new List<AF_FareInfos2>();
                                    this.TPA_Extensions = new List<AF_TPA_Extensions6>();
                                }
                                [Key]
                                [Column(Order = 1)]
                                public int AirItineraryPricingInfoId { get; set; }
                                [StringLength(30)]
                                public string LastTicketDate { get; set; }
                                [StringLength(5)]
                                public string PrivateFareType { get; set; }
                                public int FlexibleFareID { get; set; }
                                [StringLength(10)]
                                public string PricingSource { get; set; }
                                [StringLength(10)]
                                public string PricingSubSource { get; set; }
                                public bool FareReturned { get; set; }
                                public class AF_ItinTotalFare1
                                {
                                    public AF_ItinTotalFare1()
                                    {
                                        this.BaseFare = new List<AF_BaseFare1>();
                                        this.FareConstruction = new List<AF_FareConstruction1>();
                                        this.EquivFare = new List<AF_EquivFare1>();
                                        this.Taxes = new List<AF_Taxes1>();
                                        this.TotalFare = new List<AF_TotalFare1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int ItinTotalFareId { get; set; }
                                    public class AF_BaseFare1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int BaseFareId { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public class AF_FareConstruction1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareConstructionId { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public class AF_EquivFare1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int EquivFareId { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public class AF_Taxes1
                                    {
                                        public AF_Taxes1()
                                        {
                                            this.Tax = new List<AF_Tax1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int TaxesId { get; set; }
                                        public class AF_Tax1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TaxId { get; set; }
                                            [StringLength(15)]
                                            public string TaxCode { get; set; }
                                            public double Amount { get; set; }
                                            [StringLength(5)]
                                            public string CurrencyCode { get; set; }
                                            public int DecimalPlaces { get; set; }
                                            [StringLength(200)]
                                            public string content { get; set; }
                                        }
                                        public List<AF_Tax1> Tax { get; set; }
                                    }
                                    public class AF_TotalFare1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int TotalFareId { get; set; }
                                        public double Amount { get; set; }
                                        [StringLength(5)]
                                        public string CurrencyCode { get; set; }
                                        public int DecimalPlaces { get; set; }
                                    }
                                    public List<AF_BaseFare1> BaseFare { get; set; }
                                    public List<AF_FareConstruction1> FareConstruction { get; set; }
                                    public List<AF_EquivFare1> EquivFare { get; set; }
                                    public List<AF_Taxes1> Taxes { get; set; }
                                    public List<AF_TotalFare1> TotalFare { get; set; }
                                }
                                public class AF_PTC_FareBreakdowns1
                                {
                                    public AF_PTC_FareBreakdowns1()
                                    {
                                        this.PTC_FareBreakdown = new List<AF_PTC_FareBreakdown1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int PTC_FareBreakdownsId { get; set; }
                                    public class AF_PTC_FareBreakdown1
                                    {
                                        public AF_PTC_FareBreakdown1()
                                        {
                                            this.PassengerTypeQuantity = new List<AF_PassengerTypeQuantity1>();
                                            this.FareBasisCodes = new List<AF_FareBasisCodes1>();
                                            this.PassengerFare = new List<AF_PassengerFare1>();
                                            this.Endorsements = new List<AF_Endorsements1>();
                                            this.TPA_Extensions = new List<AF_TPA_Extensions3>();
                                            this.FareInfos = new List<AF_FareInfos1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int PTC_FareBreakdownId { get; set; }
                                        [StringLength(5)]
                                        public string PrivateFareType { get; set; }
                                        public class AF_PassengerTypeQuantity1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int PTQId { get; set; }
                                            [StringLength(10)]
                                            public string Code { get; set; }
                                            public int Quantity { get; set; }
                                        }
                                        public class AF_FareBasisCodes1
                                        {
                                            public AF_FareBasisCodes1()
                                            {
                                                this.FareBasisCode = new List<AF_FareBasisCode1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int FareBasisCodesId { get; set; }
                                            public class AF_FareBasisCode1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int FareBasisCodeId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string PrivateFareType { get; set; }
                                                [StringLength(5)]
                                                public string BookingCode { get; set; }
                                                [StringLength(5)]
                                                public string DepartureAirportCode { get; set; }
                                                [StringLength(5)]
                                                public string ArrivalAirportCode { get; set; }
                                                [StringLength(5)]
                                                public string FareComponentBeginAirport { get; set; }
                                                [StringLength(5)]
                                                public string FareComponentEndAirport { get; set; }
                                                [StringLength(5)]
                                                public string FareComponentDirectionality { get; set; }
                                                [StringLength(5)]
                                                public string FareComponentVendorCode { get; set; }
                                                [StringLength(5)]
                                                public string GovCarrier { get; set; }
                                                [StringLength(200)]
                                                public string content { get; set; }
                                                public bool? AvailabilityBreak { get; set; }
                                            }
                                            public List<AF_FareBasisCode1> FareBasisCode { get; set; }
                                        }
                                        public class AF_PassengerFare1
                                        {
                                            public AF_PassengerFare1()
                                            {
                                                this.BaseFare = new List<AF_BaseFare2>();
                                                this.FareConstruction = new List<AF_FareConstruction2>();
                                                this.EquivFare = new List<AF_EquivFare2>();
                                                this.Taxes = new List<AF_Taxes2>();
                                                this.TotalFare = new List<AF_TotalFare2>();
                                                this.TPA_Extensions = new List<AF_TPA_Extensions2>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int PassengerFareId { get; set; }
                                            public class AF_BaseFare2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int BaseFare2Id { get; set; }
                                                public string PassengerType { get; set; }
                                                public double Amount { get; set; }
                                                [StringLength(5)]
                                                public string CurrencyCode { get; set; }
                                            }
                                            public class AF_FareConstruction2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int FareConstruction2Id { get; set; }
                                                public string PassengerType { get; set; }
                                                public double Amount { get; set; }
                                                [StringLength(5)]
                                                public string CurrencyCode { get; set; }
                                                public int DecimalPlaces { get; set; }
                                            }
                                            public class AF_EquivFare2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int EquivFare2Id { get; set; }
                                                public string PassengerType { get; set; }
                                                public double Amount { get; set; }
                                                [StringLength(5)]
                                                public string CurrencyCode { get; set; }
                                                public int DecimalPlaces { get; set; }
                                            }
                                            public class AF_Taxes2
                                            {
                                                public AF_Taxes2()
                                                {
                                                    this.Tax = new List<AF_Tax2>();
                                                    this.TaxSummary = new List<AF_TaxSummary1>();
                                                    this.TotalTax = new List<AF_TotalTax1>();
                                                }
                                                [Key]
                                                [Column(Order = 1)]
                                                public int Taxes2Id { get; set; }
                                                public class AF_Tax2
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int Tax2Id { get; set; }
                                                    public string PassengerType { get; set; }
                                                    [StringLength(15)]
                                                    public string TaxCode { get; set; }
                                                    public double Amount { get; set; }
                                                    [StringLength(5)]
                                                    public string CurrencyCode { get; set; }
                                                    public int DecimalPlaces { get; set; }
                                                    [StringLength(5)]
                                                    public string CountryCode { get; set; }
                                                    [StringLength(200)]
                                                    public string content { get; set; }
                                                }
                                                public class AF_TaxSummary1
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int TaxSummaryId { get; set; }
                                                    public string PassengerType { get; set; }
                                                    [StringLength(15)]
                                                    public string TaxCode { get; set; }
                                                    public double Amount { get; set; }
                                                    [StringLength(5)]
                                                    public string CurrencyCode { get; set; }
                                                    public int DecimalPlaces { get; set; }
                                                    [StringLength(200)]
                                                    public string content { get; set; }
                                                    [StringLength(5)]
                                                    public string CountryCode { get; set; }
                                                }
                                                public class AF_TotalTax1
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int TotalTaxId { get; set; }
                                                    public string PassengerType { get; set; }
                                                    public double Amount { get; set; }
                                                    [StringLength(5)]
                                                    public string CurrencyCode { get; set; }
                                                    public int DecimalPlaces { get; set; }
                                                }
                                                public List<AF_Tax2> Tax { get; set; }
                                                public List<AF_TaxSummary1> TaxSummary { get; set; }
                                                public List<AF_TotalTax1> TotalTax { get; set; }
                                            }
                                            public class AF_TotalFare2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int TotalFare2Id { get; set; }
                                                public string PassengerType { get; set; }
                                                public double Amount { get; set; }
                                                [StringLength(5)]
                                                public string CurrencyCode { get; set; }
                                                public MarkupParameters MarkupParameters { get; set; }
                                                public FareSettingsParameters FareParameters { get; set; }
                                            }
                                            public class AF_TPA_Extensions2
                                            {
                                                public AF_TPA_Extensions2()
                                                {
                                                    this.Messages = new List<AF_Messages1>();
                                                    this.BaggageInformationList = new List<AF_BaggageInformationList1>();
                                                    this.CommissionData = new List<AF_CommissionData1>();
                                                }
                                                [Key]
                                                [Column(Order = 1)]
                                                public int TPA_Extensions2Id { get; set; }
                                                public class AF_Messages1
                                                {
                                                    public AF_Messages1()
                                                    {
                                                        this.Message = new List<AF_Message1>();
                                                    }
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int MessagesId { get; set; }
                                                    public class AF_Message1
                                                    {
                                                        [Key]
                                                        [Column(Order = 1)]
                                                        public int MessageId { get; set; }
                                                        public string PassengerType { get; set; }
                                                        [StringLength(5)]
                                                        public string AirlineCode { get; set; }
                                                        [StringLength(5)]
                                                        public string Type { get; set; }
                                                        public int FailCode { get; set; }
                                                        [StringLength(500)]
                                                        public string Info { get; set; }
                                                    }
                                                    public List<AF_Message1> Message { get; set; }
                                                }
                                                public class AF_BaggageInformationList1
                                                {
                                                    public AF_BaggageInformationList1()
                                                    {
                                                        this.BaggageInformation = new List<AF_BaggageInformation1>();
                                                    }
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int BaggageInformationListId { get; set; }
                                                    public class AF_BaggageInformation1
                                                    {
                                                        public AF_BaggageInformation1()
                                                        {
                                                            this.Segment = new List<AF_Segment1>();
                                                            this.Allowance = new List<AF_Allowance1>();
                                                        }
                                                        [Key]
                                                        [Column(Order = 1)]
                                                        public int BaggageInformationId { get; set; }
                                                        public string PassengerType { get; set; }
                                                        [StringLength(5)]
                                                        public string ProvisionType { get; set; }
                                                        [StringLength(5)]
                                                        public string AirlineCode { get; set; }
                                                        public int OrderNo { get; set; }
                                                        public class AF_Segment1
                                                        {
                                                            [Key]
                                                            [Column(Order = 1)]
                                                            public int SegmentId { get; set; }
                                                            [StringLength(100)]
                                                            public string PassengerType { get; set; }
                                                            public int Id { get; set; }
                                                        }
                                                        public class AF_Allowance1
                                                        {
                                                            [Key]
                                                            [Column(Order = 1)]
                                                            public int AllowanceId { get; set; }
                                                            public string PassengerType { get; set; }
                                                            public int Pieces { get; set; }
                                                        }
                                                        public List<AF_Segment1> Segment { get; set; }
                                                        public List<AF_Allowance1> Allowance { get; set; }
                                                    }
                                                    public List<AF_BaggageInformation1> BaggageInformation { get; set; }
                                                }
                                                public class AF_CommissionData1
                                                {
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int CommissionDataId { get; set; }
                                                    public int Cat35MarkupAmount { get; set; }
                                                    public int CommissionAmountInEquivalent { get; set; }
                                                }
                                                public List<AF_Messages1> Messages { get; set; }
                                                public List<AF_BaggageInformationList1> BaggageInformationList { get; set; }
                                                public List<AF_CommissionData1> CommissionData { get; set; }
                                            }
                                            public List<AF_BaseFare2> BaseFare { get; set; }
                                            public List<AF_FareConstruction2> FareConstruction { get; set; }
                                            public List<AF_EquivFare2> EquivFare { get; set; }
                                            public List<AF_Taxes2> Taxes { get; set; }
                                            public List<AF_TotalFare2> TotalFare { get; set; }
                                            public List<AF_TPA_Extensions2> TPA_Extensions { get; set; }
                                        }
                                        public class AF_Endorsements1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int EndorsementsId { get; set; }
                                            public string PassengerType { get; set; }
                                            public bool NonRefundableIndicator { get; set; }
                                        }
                                        public class AF_TPA_Extensions3
                                        {
                                            public AF_TPA_Extensions3()
                                            {
                                                this.FareCalcLine = new List<AF_FareCalcLine1>();
                                                this.FareType = new List<AF_FareType1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TPA_Extensions3Id { get; set; }
                                            public class AF_FareCalcLine1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int FareCalcLineId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(500)]
                                                public string Info { get; set; }
                                            }
                                            public class AF_FareType1
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int FareTypeId { get; set; }
                                                [StringLength(10)]
                                                public string Name { get; set; }
                                                [StringLength(200)]
                                                public string content { get; set; }
                                            }
                                            public List<AF_FareCalcLine1> FareCalcLine { get; set; }
                                            public List<AF_FareType1> FareType { get; set; }
                                        }
                                        public class AF_FareInfos1
                                        {
                                            public AF_FareInfos1()
                                            {
                                                this.FareInfo = new List<AF_FareInfo1>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int FareInfosId { get; set; }
                                            public class AF_FareInfo1
                                            {
                                                public AF_FareInfo1()
                                                {
                                                    this.TPA_Extensions = new List<AF_TPA_Extensions4>();
                                                }
                                                [Key]
                                                [Column(Order = 1)]
                                                public int FareInfoId { get; set; }
                                                public string PassengerType { get; set; }
                                                [StringLength(5)]
                                                public string FareReference { get; set; }
                                                public class AF_TPA_Extensions4
                                                {
                                                    public AF_TPA_Extensions4()
                                                    {
                                                        SeatsRemaining = new List<AF_SeatsRemaining1>();
                                                        Cabin = new List<AF_Cabin1>();
                                                        Meal = new List<AF_Meal1>();
                                                    }
                                                    [Key]
                                                    [Column(Order = 1)]
                                                    public int TPA_Extensions4Id { get; set; }
                                                    public class AF_SeatsRemaining1
                                                    {
                                                        [Key]
                                                        [Column(Order = 1)]
                                                        public int SeatsRemainingId { get; set; }
                                                        public string PassengerType { get; set; }
                                                        public int Number { get; set; }
                                                        public bool BelowMin { get; set; }
                                                    }
                                                    public class AF_Cabin1
                                                    {
                                                        [Key]
                                                        [Column(Order = 1)]
                                                        public int CabinId { get; set; }
                                                        public string PassengerType { get; set; }
                                                        [StringLength(5)]
                                                        public string Cabins { get; set; }
                                                    }
                                                    public class AF_Meal1
                                                    {
                                                        [Key]
                                                        [Column(Order = 1)]
                                                        public int MealId { get; set; }
                                                        public string PassengerType { get; set; }
                                                        [StringLength(5)]
                                                        public string Code { get; set; }
                                                    }
                                                    public List<AF_SeatsRemaining1> SeatsRemaining { get; set; }
                                                    public List<AF_Cabin1> Cabin { get; set; }
                                                    public List<AF_Meal1> Meal { get; set; }
                                                }
                                                public List<AF_TPA_Extensions4> TPA_Extensions { get; set; }
                                            }
                                            public List<AF_FareInfo1> FareInfo { get; set; }
                                        }
                                        public List<AF_PassengerTypeQuantity1> PassengerTypeQuantity { get; set; }
                                        public List<AF_FareBasisCodes1> FareBasisCodes { get; set; }
                                        public List<AF_PassengerFare1> PassengerFare { get; set; }
                                        public List<AF_Endorsements1> Endorsements { get; set; }
                                        public List<AF_TPA_Extensions3> TPA_Extensions { get; set; }
                                        public List<AF_FareInfos1> FareInfos { get; set; }
                                    }
                                    public List<AF_PTC_FareBreakdown1> PTC_FareBreakdown { get; set; }
                                }
                                public class AF_FareInfos2
                                {
                                    public AF_FareInfos2()
                                    {
                                        this.FareInfo = new List<AF_FareInfo2>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int FareInfos2Id { get; set; }
                                    public class AF_FareInfo2
                                    {
                                        public AF_FareInfo2()
                                        {
                                            this.TPA_Extensions = new List<AF_TPA_Extensions5>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int FareInfo2Id { get; set; }
                                        public string FareReference { get; set; }
                                        public class AF_TPA_Extensions5
                                        {
                                            public AF_TPA_Extensions5()
                                            {
                                                this.SeatsRemaining = new List<AF_SeatsRemaining2>();
                                                this.Cabin = new List<AF_Cabin2>();
                                                this.Meal = new List<AF_Meal2>();
                                            }
                                            [Key]
                                            [Column(Order = 1)]
                                            public int TPA_Extensions5Id { get; set; }
                                            public class AF_SeatsRemaining2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int SeatsRemaining2Id { get; set; }
                                                [StringLength(100)]
                                                public int Number { get; set; }
                                                public bool BelowMin { get; set; }
                                            }
                                            public class AF_Cabin2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int Cabin2Id { get; set; }
                                                [StringLength(5)]
                                                public string Cabin { get; set; }
                                            }
                                            public class AF_Meal2
                                            {
                                                [Key]
                                                [Column(Order = 1)]
                                                public int Meal2Id { get; set; }
                                                [StringLength(5)]
                                                public string Code { get; set; }
                                            }
                                            public List<AF_SeatsRemaining2> SeatsRemaining { get; set; }
                                            public List<AF_Cabin2> Cabin { get; set; }
                                            public List<AF_Meal2> Meal { get; set; }
                                        }
                                        public List<AF_TPA_Extensions5> TPA_Extensions { get; set; }
                                    }
                                    public List<AF_FareInfo2> FareInfo { get; set; }
                                }
                                public class AF_TPA_Extensions6
                                {
                                    public AF_TPA_Extensions6()
                                    {
                                        this.DivideInParty = new List<AF_DivideInParty1>();
                                        this.ValidatingCarrier = new List<AF_ValidatingCarrier1>();
                                    }
                                    [Key]
                                    [Column(Order = 1)]
                                    public int TPA_Extensions6Id { get; set; }
                                    public class AF_DivideInParty1
                                    {
                                        [Key]
                                        [Column(Order = 1)]
                                        public int DivideInPartyId { get; set; }
                                        public bool Indicator { get; set; }
                                    }
                                    public class AF_ValidatingCarrier1
                                    {
                                        public AF_ValidatingCarrier1()
                                        {
                                            this.Default = new List<AF_Default1>();
                                        }
                                        [Key]
                                        [Column(Order = 1)]
                                        public int ValidatingCarrierId { get; set; }
                                        [StringLength(10)]
                                        public string SettlementMethod { get; set; }
                                        public bool NewVcxProcess { get; set; }
                                        public class AF_Default1
                                        {
                                            [Key]
                                            [Column(Order = 1)]
                                            public int DefaultId { get; set; }
                                            [StringLength(5)]
                                            public string Code { get; set; }
                                            public string AirlineName { get; set; }
                                        }
                                        public List<AF_Default1> Default { get; set; }
                                    }
                                    public List<AF_DivideInParty1> DivideInParty { get; set; }
                                    public List<AF_ValidatingCarrier1> ValidatingCarrier { get; set; }
                                }
                                public List<AF_ItinTotalFare1> ItinTotalFare { get; set; }
                                public List<AF_PTC_FareBreakdowns1> PTC_FareBreakdowns { get; set; }
                               //=== public List<AF_FareInfos2> FareInfos { get; set; }
                                public List<AF_TPA_Extensions6> TPA_Extensions { get; set; }
                            }
                            public class AF_TicketingInfo1
                            {
                                [Key]
                                [Column(Order = 1)]
                                public int TicketingInfoId { get; set; }
                                [StringLength(10)]
                                public string TicketType { get; set; }
                            }
                            public List<AF_AirItineraryPricingInfo1> AirItineraryPricingInfo { get; set; }
                            public List<AF_TicketingInfo1> TicketingInfo { get; set; }
                        }
                        public class AF_ValidatingCarrier2
                        {
                            [Key]
                            [Column(Order = 1)]
                            public int ValidatingCarrier2Id { get; set; }
                            [StringLength(5)]
                            public string Code { get; set; }
                        }
                        public class AF_DiversitySwapper1
                        {
                            [Key]
                            [Column(Order = 1)]
                            public int DiversitySwapperId { get; set; }
                            public double WeighedPriceAmount { get; set; }
                        }
                        public List<AdditionalFare1> AdditionalFares { get; set; }
                        public List<AF_ValidatingCarrier2> ValidatingCarrier { get; set; }
                        public List<AF_DiversitySwapper1> DiversitySwapper { get; set; }
                    }
                    #endregion
                    public List<AirItinerary1> AirItinerary { get; set; }
                    public List<AirItineraryPricingInfo1> AirItineraryPricingInfo { get; set; }
                    public List<TicketingInfo1> TicketingInfo { get; set; }
                    public List<TPA_Extensions7> TPA_Extensions { get; set; }
                }
                public List<PricedItinerary1> PricedItinerary { get; set; }
            }
            public List<Warnings1> Warnings { get; set; }
            public List<Success1> Success { get; set; }
            public List<PricedItineraries1> PricedItineraries { get; set; }
        }
        public class Link1
        {
            [Key]
            [Column(Order = 1)]
            public int LinkId { get; set; }
            [StringLength(500)]
            public string rel { get; set; }
            [StringLength(500)]
            public string href { get; set; }
        }
        public class ProcessingTime
        {
            [Key]
            [Column(Order = 1)]
            public int PTId { get; set; }
            [StringLength(50)]
            public string StartTime { get; set; }
            [StringLength(50)]
            public string EndTime { get; set; }
            [StringLength(100)]
            public string ProcessName { get; set; }
            [StringLength(200)]
            public string Remarks { get; set; }
            public List<ProcessingTime> ProcessingTimes { get; set; }
        }
        public List<OTAAirLowFareSearchRS1> OTA_AirLowFareSearchRS { get; set; }
        public List<Link1> Links { get; set; }
        //===  public  List<ProcessingTime> ProcessingTimes { get; set; }
    }
}