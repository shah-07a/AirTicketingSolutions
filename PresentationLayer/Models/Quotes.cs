using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentationLayer.Models
{
    public class QuotesVariables
    {
        public QuotesVariables()
        {

        }
        public string SequenceNumber { get; set; }
        public string IATACode { get; set; }
        public string LogoPath { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepDateTime { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string HoursMinutes { get; set; }
        public string[] MonthName { get; set; } = { "0", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public string Day { get; set; }
        public string MonthDayYear { get; set; }
        public string CityName { get; set; }
        public int ElapsedTime { get; set; }
        public int ElapsedHours { get; set; }
        public int ElapsedMinutes { get; set; }
        public int StopCount { get; set; }
        public string Stops { get; set; }
        public DateTime ArrDateTime { get; set; }
        public string ArrHours { get; set; }
        public string ArrMinutes { get; set; }
        public string ArrHoursMinutes { get; set; }
        public string ArrDay { get; set; }
        public string ArrMonthDayYear { get; set; }
        public string ArrCityName { get; set; }
        public int ArrElapsedTime { get; set; }
    }
    public class OutboundFlights : QuotesVariables
    {
        public OutboundFlights()
        {

        }
        public int Id { get; set; }
    }
        
    public class Quotes
    {
        public Quotes()
        {

        }
        public string Flight { get; set; }
        public string DepatureTime { get; set; }
        public string Stops { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public string Layover { get; set; }
        public string TripTotalDuration { get; set; }
    }
    public class FilteredQuotes 
    {
        public FilteredQuotes()
        {

        }
        public string SequenceNumber { get; set; }
        public Fares Fares { get; set; } = new Fares();
        public double TotalFare { get; set; }
        public string ValidatingAirline { get; set; }
        public string FareType { get; set; }
        public string Cabin { get; set; }
        public string Meal { get; set; }
        public string Flight { get; set; }
        public string DepatureTime { get; set; }
        public string OutBoundStops { get; set; }
        public string InBoundStops { get; set; }
        public string ArrivalTime { get; set; }
        public string Duration { get; set; }
        public string LayOver { get; set; }
        public string OutBoundTotalTripDuration { get; set; }
        public string InBoundTotalTripDuration { get; set; }
        public string Message { get; set; }
        public string SearchType { get; set; }
        public int OrgDesOptionCount { get; set; }
        public int AirItnryPricingInfoCount { get; set; }
        public int AdnlFaresAirItnryPricingInfoCount { get; set; }
        public Quotes OutBound { get; set; } = new Quotes();
        public Quotes InBound { get; set; } = new Quotes();
        public List<Quotes> InBoundFlights { get; set; } = new List<Quotes>();
        public List<Quotes> OutBoundFlights { get; set; } = new List<Quotes>();
    }
    public class Fares
    {
        public Fares()
        {

        }
        public string Currency { get; set; }
        public double EquivFare { get; set; }
        public double Taxes { get; set; }
        public double TotalFare { get; set; }
        public double Commission { get; set; }
        public double ServiceFee { get; set; }
        public FareSettingsParameters FareParameters { get; set; } = new FareSettingsParameters();
        public string FareCalculationType { get; set; }
        public BaggagesPenalties BaggagesPenalties { get; set; } = new BaggagesPenalties();
        public string FareDetailsHtml { get; set; }
        public string FareType { get; set; }
    }
    public class BaggagesPenalties
    {
        public string CancellationFee { get; set; } = "";
        public string ChangeFee { get; set; } = "";
        public string CancellationBefore { get; set; } = "Non-Changeable";
        public string CancellationAfter { get; set; } = "Non-Changeable";
        public string ChangeBefore { get; set; } = "Non-refundable";
        public string ChangeAfter { get; set; } = "Non-refundable";
        public string BagQntyInCabin { get; set; } = "0";
        public string BagQntyCheckIn { get; set; } = "0";
        public string BagWeightCabin { get; set; } = "0";
        public string BagWeightCheckIn { get; set; } = "0";

    }
    
}