using ModelDTO = Models.DTO;
using Models.Sabre.JsonModels.FilteredResponse;
using System;
using System.Collections.Generic;
using System.Text;
using BOL = BusinessObjectLayer;
using MSabre = Models.Sabre;
using System.Linq;

namespace PresentationLayer.Models.ViewModels
{
    public class QuoteViewModel
    {
        public string CreateGridOfDistinctAirlines(List<ModelDTO.Airlines> lstDistinctAirlines)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var dal in lstDistinctAirlines)
                {
                    sb.Append("<div class='checkbox row'>");
                    sb.Append("<div class='col-md-7' style='padding-right:0'>");
                    sb.Append("<label>");
                    sb.Append("<input type='checkbox' id='"+ dal.IATACode + "' name='AirlinesGroup' class='airlineCheckbox'  value='" + dal.IATACode + "' checked='checked'>");
                    sb.Append("<span title='" + dal.AirlineName + "'>"+ dal.AirlineName +"</span>");
                    sb.Append("</label>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-md-5' style='padding-left:0'>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }

                return sb.ToString();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }

            return string.Empty;
        }
        public string CreatePreferredAirlines(List<FilteredQuotes> lstFilteredQuotes, List<ModelDTO.Airlines> lstDistinctAirlines)
        {
            string preferredAirlines = string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                if (lstFilteredQuotes != null && lstFilteredQuotes.Count > 0)
                {
                    string airline = string.Empty;
                    double airlineFare = 0;
                    int airlineCount = 0;
                    if (lstDistinctAirlines.Count > 0)
                    {
                        foreach (var al in lstDistinctAirlines)
                        {
                            airlineFare = 0;
                            airlineCount = 0;
                            string sno = string.Empty;
                            foreach (var item in lstFilteredQuotes)
                            {
                                airline = item.ValidatingAirline;
                                double fare = item.TotalFare;
                                if (al.IATACode == airline)
                                {
                                    airlineCount++;
                                    if (airlineFare < fare)
                                    {
                                        airlineFare = fare;
                                        sno = item.SequenceNumber;
                                    }
                                   
                                }
                            }
                            sb.Append("<div class='row'>");
                            sb.Append("<a href='#" + sno + "'>");
                            sb.Append("<div class='col-sm-9'>");
                            sb.Append("<div class='stop-filter'>");
                            sb.Append("<label>" + al.AirlineName + " <span>(" + airlineCount + ")</span></label>");
                            sb.Append("</div>");
                            sb.Append("</div>");
                            sb.Append("<div class='col-sm-3'>");
                            sb.Append("<div class='small-price'> C$" + airlineFare.ToString("0.00") + "</div>");
                            sb.Append("</div>");
                            sb.Append("</a>");
                            sb.Append("</div>");
                        }

                    }
                }
                return preferredAirlines = sb.ToString();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return preferredAirlines;
        }
        public string CreateStopFilter(List<FilteredQuotes> filteredQuotes)
        {
            string stopFilter = string.Empty;
            try
            {
                int dirtect = 0;
                int stop1 = 0;
                int stop1plus = 0;
                double directFare = 0;
                double stop1Fare = 0;
                double stop1plusFare = 0;
                string sno = string.Empty;
                string sno1 = string.Empty;
                string sno2 = string.Empty;
                StringBuilder sb = new StringBuilder();
                if (filteredQuotes != null && filteredQuotes.Count > 0)
                {
                    foreach (var item in filteredQuotes)
                    {
                        int obstops = item.OutBoundFlights.Count;
                        int ibstops = item.InBoundFlights.Count;
                        int segcount = 0;
                        if (obstops >= ibstops)
                        {
                            segcount = obstops;
                        }
                        else
                        {
                            segcount = ibstops;
                        }
                        
                        double fare = item.TotalFare;
                        if (segcount == 1)
                        {
                            dirtect++;
                            if (directFare < fare)
                            {
                                directFare = fare;
                                sno = item.SequenceNumber;
                            }
                        }
                        else if (segcount == 2)
                        {
                            stop1++;
                            if (stop1Fare < fare)
                            {
                                stop1Fare = fare;
                                sno1 = item.SequenceNumber;
                            }
                        }
                        else
                        {
                            stop1plus++;
                            if (stop1plusFare < fare)
                            {
                                stop1plusFare = fare;
                                sno2 = item.SequenceNumber;
                            }
                        }

                    }
                }
                /*===row ===*/
                if (dirtect > 0)
                {
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col-sm-8'>");
                    sb.Append("<div class='stop-filter'>");
                    sb.Append("<label><input name='' type='checkbox' value=''> Direct <span>(" + dirtect + ")</span></label>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-4'>");
                    sb.Append("<div class='small-price'><a href='#"+ sno +"'>C$" + directFare.ToString("0.00") + "</a></div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                /*===row end ===*/
                /*===row ===*/
                if (stop1 > 0)
                {
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col-sm-8'>");
                    sb.Append("<div class='stop-filter'>");
                    sb.Append("<label><input name='' type='checkbox' value=''> 1 Stop <span>(" + stop1 + ")</span></label>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-4'>");
                    sb.Append("<div class='small-price'><a href='#" + sno1 + "'>C$" + stop1Fare.ToString("0.00") + "</a></div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                /*===row end ===*/
                /*===row ===*/
                if (stop1plus > 0)
                {
                    sb.Append("<div class='row'>");
                    sb.Append("<div class='col-sm-8'>");
                    sb.Append("<div class='stop-filter'>");
                    sb.Append("<label><input name='' type='checkbox' value=''> 1+Stop <span>(" + stop1plus + ")</span></label>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                    sb.Append("<div class='col-sm-4'>");
                    sb.Append("<div class='small-price'><a href='#" + sno2 + "'>C$" + stop1plusFare.ToString("0.00") + "</a></div>");
                    sb.Append("</div>");
                    sb.Append("</div>");
                }
                /*===row end ===*/
                /*=== End Stop Filter===*/
                return stopFilter = sb.ToString();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return string.Empty;
        }
        public string CreateQuoteDisplay(List<FilteredQuotes> filteredQuotes, List<ModelDTO.Airlines> lstDistinctAirlines, int userroleid, bool iscancellationdisplay)
        {
            string quotes = string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<div id='flightdetails-panel'>");
                if (filteredQuotes.Count == 0 || filteredQuotes[0].Message == "Failed")
                {
                    sb.Append("<div class='alertmessage'>");
                    sb.Append("<h3>No flights are available for the selected criteria, please change your criteria and try again</h3>");
                    sb.Append("</div>");
                    return quotes = sb.ToString();
                }
                foreach (var item in filteredQuotes)
                {
                    bool isAlExist = false;
                    string valAirline = item.ValidatingAirline;
                    if (lstDistinctAirlines.Count > 0)
                    {
                        foreach (var dal in lstDistinctAirlines)
                        {
                            if (valAirline == dal.IATACode)
                            {
                                isAlExist = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        isAlExist = true;
                    }
                    if (isAlExist)
                    {
                        sb.Append("<div id='" + item.SequenceNumber + "' class='quote-section'>");
                        /*=== Horizontal Tab ===*/
                        sb.Append("<div id='parentHorizontalTab' class='parentHorizontalTab'>");
                        sb.Append("<ul class='tab-style resp-tabs-list hor_1'>");
                        sb.Append("<li id='tab1'>Summary</li>");
                        sb.Append("<li id='tab2'>Flight Details</li>");
                        if(userroleid == 0 || userroleid == 8)
                        {
                            sb.Append("<li id='tab2a'>Fare Details</li>");
                        }
                        else
                        {
                            sb.Append("<li id='tab2a'>Fare Details (" + item.Fares.FareType + ")</li>");
                        }
                        
                        sb.Append("</ul>");
                        sb.Append("<div class='resp-tabs-container hor_1'>");
                        sb.Append("<div id='tab1' class='first-content'>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-sm-9'>");
                        /*=== outbound starts here ===*/
                        sb.Append("<div class='bound'>");
                        sb.Append("<p><img src='../Content/images/outbound-icon.png'> Outbound</p> <hr>");
                        sb.Append("</div>");
                        /*=== outbound ends here ===*/
                        sb.Append("<div class='clearfix'></div>");
                        /*=== summary ===*/
                        sb.Append("<div class='summary'>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== outbound ===*/
                        sb.Append("<div class='outbound'>");
                        sb.Append(item.OutBound.Flight);
                        sb.Append("</div>");
                        /*=== outbound end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== departure time ===*/
                        sb.Append("<div class='departure-time'>");
                        sb.Append(item.OutBound.DepatureTime);
                        sb.Append("</div>");
                        /*=== departure time end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== duration ===*/
                        sb.Append("<div class='duration'>");
                        sb.Append(item.OutBound.Duration);
                        sb.Append("</div>");
                        /*=== duration end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== arrival time ===*/
                        sb.Append("<div class='arrival-time'>");
                        sb.Append(item.OutBound.ArrivalTime);
                        sb.Append("</div>");
                        /*=== arrival time end ===*/
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*=== summary end ===*/
                        /*=== inbound starts here ===*/
                        sb.Append("<div class='bound'>");
                        if (item.OrgDesOptionCount > 1 && item.SearchType != "M" )
                        {
                            if (item.SearchType != "O")
                            {
                                sb.Append("<p><img src='../Content/images/inbound-icon.png'> Inbound</p> <hr>");
                            }
                        }
                        sb.Append("</div>");
                        /*=== inbound ends here ===*/
                        sb.Append("<div class='clearfix'></div>");
                        /*=== <!--summary --> ===*/
                        sb.Append("<div class='summary'>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*===<!-- inbound ===*/
                        if (item.OrgDesOptionCount > 1 && item.SearchType != "M")
                        {
                            if (item.SearchType != "O")
                            {
                                sb.Append("<div class='inbound'>");
                                sb.Append(item.InBound.Flight);
                                sb.Append("</div>");
                            }
                        }
                        /*===  inbound end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== departure time ===*/
                        if (item.InBound != null)
                        {
                            sb.Append("<div class='departure-time'>");
                            sb.Append(item.InBound.DepatureTime);
                            sb.Append("</div>");
                        }
                        /*=== departure time end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== duration ===*/
                        if (item.InBound != null)
                        {
                            sb.Append("<div class='duration'>");
                            sb.Append(item.InBound.Duration);
                            sb.Append("</div>");
                        }
                        /*=== duration end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3 col-xs-6'>");
                        /*=== arrival time  ===*/

                        if (item.OrgDesOptionCount > 1 && item.SearchType != "M" )
                        {
                            sb.Append("<div class='arrival-time'>");
                            sb.Append(item.InBound.ArrivalTime);
                            sb.Append("</div>");
                        }
                        /*=== arrival time end ===*/
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*=== summary end ===*/
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-3'>");
                        /*=== total price ===*/
                        sb.Append("<div class='total-price'>");
                        sb.Append("<div class='functional-icons'>");
                        sb.Append("<a href='#'><img src='../Content/images/email-icon.png'></a>");
                        sb.Append("<a href='#'><img src='../Content/images/print-icon.png'></a>");
                        sb.Append("</div>");
                        sb.Append("<p>");
                        sb.Append("Total Price :");
                        sb.Append(item.Fares.Currency + item.Fares.EquivFare.ToString("0.00") + "+" + item.Fares.Currency + item.Fares.Taxes.ToString("0.00") + " (taxes) =" + "<span>" + item.Fares.Currency + item.Fares.TotalFare.ToString("0.00") + "</span>");
                        sb.Append("</p>");
                        sb.Append("<div class='avg'>(" + item.Fares.FareCalculationType + ")</div>");
                        sb.Append("<div class='book-btn'><a href='#'>Book Now <img src='../Content/images/plane-icon.png'></a></div>");
                        sb.Append("</div>");
                        /*=== total price end ===*/
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<div id='tab2'>");
                        /*===flight total price ===*/
                        sb.Append("<div class='flight-total-price'>");
                        sb.Append("<p>");
                        //=== sb.Append("<Total Price :>");
                        sb.Append("Total Price :");
                        sb.Append(item.Fares.Currency + item.Fares.EquivFare.ToString("0.00") + "+" + item.Fares.Currency + item.Fares.Taxes.ToString("0.00") + " (taxes) = <span> " + item.Fares.Currency + item.Fares.TotalFare.ToString("0.00") + "</span>");
                        sb.Append("</p>");
                        sb.Append("<div class='avg'>");
                        sb.Append(item.Fares.FareCalculationType);
                        sb.Append("</div>");
                        sb.Append("<div class='book-btn'>");
                        sb.Append("<a href='#'>");
                        sb.Append("Book Now");
                        sb.Append("<img src='../Content/images/plane-icon.png'>");
                        sb.Append("</a>");
                        sb.Append("</div>");
                        sb.Append("<div class='flight-functional-icons'>");
                        sb.Append("<a href='#'>");
                        sb.Append("<img src='../Content/images/email-icon.png'>");
                        sb.Append("</a>");
                        sb.Append("<a href='#'>");
                        sb.Append("<img src='../Content/images/print-icon.png'>");
                        sb.Append("</a>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*===flight total price end ===*/
                        sb.Append("<div class='clearfix'>");
                        sb.Append("</div>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-sm-7'>");
                        /*=== child tab ===*/
                        sb.Append("<div id='child-parentHorizontalTab' class='child-parentHorizontalTab'>");
                        sb.Append("<ul class='resp-tabs-list hor_child_2'>");
                        sb.Append("<li id='tab4'>");
                        sb.Append("<img src='../Content/images/outbound-icon-small.png'>");
                        sb.Append("Outbound");
                        sb.Append("</li>");
                        if (item.OrgDesOptionCount > 0 && item.SearchType != "M")
                        {
                            if (item.SearchType != "O")
                            {
                                sb.Append("<li id='tab5'><img src='../Content/images/inbound-icon-small.png'> Inbound</li>");
                            }
                        }
                        sb.Append("</ul>");
                        sb.Append("<div class='resp-tabs-container hor_child_2'>");
                        sb.Append("<div id='tab4'>");
                        if (item.SearchType == "M" && item.OutBoundFlights.Count > 0)
                        {
                            int obFlgtCont = item.OutBoundFlights.Count;
                            int cntr = 0;
                            foreach (var item1 in item.OutBoundFlights)
                            {
                                cntr++;
                                sb.Append("<div class='row'>");
                                sb.Append("<div class='col-sm-6 col-xs-8'>");
                                /*=== flight-detail-outbound ===*/
                                sb.Append("<div class='flight-detail-outbound'>");
                                sb.Append(item1.Flight);
                                sb.Append("</div>");
                                /*=== flight-detail-outbound end ===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-6 col-xs-4'>");
                                sb.Append("<div class='cabin'>");
                                sb.Append("(" + item.Cabin + ")");
                                sb.Append("</div>");
                                sb.Append("</div>");
                                sb.Append("</div>");
                                sb.Append("<div class='clearfix'>");
                                sb.Append("</div>");
                                sb.Append("<div class='row'>");
                                sb.Append("<div class='col-sm-4 col-xs-8'>");
                                /*===detail-flight ===*/
                                sb.Append("<div class='detail-flight'>");
                                sb.Append(item1.DepatureTime);
                                sb.Append("</div>");
                                /*===detail-flight end ===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-4 col-xs-4'>");
                                /*===duration ===*/
                                sb.Append("<div class='duration-detail'>");
                                sb.Append("<img src='../Content/images/duration-icon.png'>");
                                sb.Append(item1.Duration);
                                sb.Append("</div>");
                                /*===duration end ===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-4 col-xs-12'>");
                                /*===detail-flight ===*/
                                sb.Append("<div class='detail-flight right-txt'>");
                                sb.Append(item1.ArrivalTime);
                                sb.Append("</div>");
                                /*===detail-flight end ===*/
                                sb.Append("</div>");
                                sb.Append("</div>");
                                if (cntr < obFlgtCont)
                                {
                                    if(string.IsNullOrEmpty(item1.Layover) == false)
                                    {
                                        sb.Append("<div class='layover'>Layover " + item1.Layover + "</div>");
                                    }
                                    
                                }
                                if(string.IsNullOrEmpty(item1.TripTotalDuration) == false)
                                {
                                    sb.Append("<div class='total-trip'>Total Trip Duration " + item1.TripTotalDuration + "</div>");
                                }
                            }

                            
                        }
                        else
                        {
                            if (item.OutBoundFlights.Count > 0)
                            {
                                int obFlgtCont = item.OutBoundFlights.Count;
                                int cntr = 0;
                                foreach (var item2 in item.OutBoundFlights)
                                {
                                    cntr++;
                                    sb.Append("<div class='row'>");
                                    sb.Append("<div class='col-sm-6 col-xs-8'>");
                                    /*=== flight-detail-outbound ===*/
                                    sb.Append("<div class='flight-detail-outbound'>");
                                    sb.Append(item2.Flight);
                                    sb.Append("</div>");
                                    /*=== flight-detail-outbound //===*/
                                    sb.Append("</div>");
                                    sb.Append("<div class='col-sm-6 col-xs-4'>");
                                    sb.Append("<div class='cabin'>");
                                    sb.Append(item.Cabin);
                                    sb.Append(" </div>");
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    sb.Append("<div class='clearfix'>");
                                    sb.Append("</div>");
                                    sb.Append("<div class='row'>");
                                    sb.Append("<div class='col-sm-4 col-xs-8'>");
                                    /*===detail-flight ===*/
                                    sb.Append("<div class='detail-flight'>");
                                    sb.Append(item2.DepatureTime);
                                    sb.Append("</div>");
                                    /*===detail-flight //===*/
                                    sb.Append("</div>");
                                    sb.Append("<div class='col-sm-4 col-xs-4'>");
                                    /*===duration ===*/
                                    sb.Append("<div class='duration-detail'>");
                                    sb.Append("<img src = '../Content/images/duration-icon.png'>");
                                    sb.Append(item2.Duration);
                                    sb.Append("</div>");
                                    /*===duration //===*/
                                    sb.Append("</div>");
                                    sb.Append("<div class='col-sm-4 col-xs-12'>");
                                    /*===detail-flight ===*/
                                    sb.Append("<div class='detail-flight right-txt'>");
                                    sb.Append(item2.ArrivalTime);
                                    sb.Append("</div>");
                                    /*===detail-flight //===*/
                                    sb.Append("</div>");
                                    sb.Append("</div>");
                                    if (cntr < obFlgtCont)
                                    {
                                        sb.Append("<div class='layover'>Layover " + item2.Layover + "</div>");
                                    }
                                }
                                sb.Append("<div class='total-trip'>Total Trip Duration " + item.OutBoundTotalTripDuration + "</div>");
                            }
                        }
                        sb.Append("</div>");
                        /*=== End of Tab4 ===*/

                        /*=== Tab5===*/
                        sb.Append("<div id='tab5'>");
                        if (item.InBoundFlights.Count > 0 && item.SearchType != "M" )
                        {
                            int ibFlgtCont = item.OutBoundFlights.Count;
                            int icntr = 0;
                            foreach (var item3 in item.InBoundFlights)
                            {
                                icntr++;
                                sb.Append("<div class='row'>");
                                sb.Append("<div class='col-sm-6 col-xs-8'>");
                                /*=== flight-detail-outbound ===*/
                                sb.Append("<div class='flight-detail-outbound'>");
                                sb.Append(item3.Flight);
                                sb.Append("</div>");
                                /*=== flight-detail-outbound end===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-6 col-xs-4'>");
                                sb.Append("<div class='cabin'>");
                                sb.Append("(" + item.Cabin + ")");
                                sb.Append("</div>");
                                sb.Append("</div>");
                                sb.Append("</div>");
                                sb.Append("<div class='clearfix'>");
                                sb.Append("</div>");
                                sb.Append("<div class='row'>");
                                sb.Append("<div class='col-sm-4 col-xs-8'>");
                                /*===detail-flight ===*/
                                sb.Append("<div class='detail-flight'>");
                                sb.Append(item3.DepatureTime);
                                sb.Append("</div>");
                                /*===detail-flight end===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-4 col-xs-4'>");
                                /*===duration ===*/
                                sb.Append("<div class='duration-detail'>");
                                sb.Append("<img src='../Content/images/duration-icon.png'>");
                                sb.Append(item3.Duration);
                                sb.Append("</div>");
                                /*===duration end===*/
                                sb.Append("</div>");
                                sb.Append("<div class='col-sm-4 col-xs-12'>");
                                /*===detail-flight ===*/
                                sb.Append("<div class='detail-flight right-txt'>");
                                sb.Append(item3.ArrivalTime);
                                sb.Append("</div>");
                                /*===detail-flight end ===*/
                                sb.Append("</div>");
                                sb.Append("</div>");
                                if (icntr < ibFlgtCont)
                                {
                                    sb.Append("<div class='layover'>Layover @layover</div>");
                                }
                            }
                            sb.Append("<div class='total-trip'>Total Trip Duration " + item.InBoundTotalTripDuration + "</div>");
                        }
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*=== child tab ===*/
                        
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-5'>");
                        sb.Append("<div class='flight-detail-right-section'>");
                        sb.Append("<div class='full-row'>");
                        sb.Append("<h5>");
                        sb.Append("Baggage");
                        sb.Append("</h5>");
                        sb.Append("<p>");
                        sb.Append("Quantity: " + item.Fares.BaggagesPenalties.BagQntyCheckIn);
                        sb.Append("</p>");
                        sb.Append("</div>");
                        if (iscancellationdisplay)
                        {
                            sb.Append("<div class='full-row'>");
                        sb.Append("<h5>");
                        sb.Append("Change Fee");
                        sb.Append("</h5>");
                        sb.Append("<p>");
                        sb.Append("Before Departure: <span>" + item.Fares.BaggagesPenalties.ChangeBefore);
                        sb.Append("</span><br>");
                        sb.Append("After Departure: <span>" + item.Fares.BaggagesPenalties.ChangeAfter);
                        sb.Append("</span>");
                        sb.Append("</p>");
                        sb.Append("</div>");
                       
                            sb.Append("<div class='full-row'>");
                            sb.Append("<h5>Cancellation Fee</h5>");
                            sb.Append("<p>");
                            sb.Append("Before Departure: <span>" + item.Fares.BaggagesPenalties.CancellationBefore);
                            sb.Append("</span><br>");
                            sb.Append("After Departure: <span>" + item.Fares.BaggagesPenalties.CancellationAfter);
                            sb.Append("</span>");
                            sb.Append("</p>");
                            sb.Append("</div>");
                        }
                        sb.Append("<div class='baggage-section'>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-sm-4 right-border col-xs-4'>");
                        sb.Append("<div class='baggage-info'>");
                        sb.Append("<title>");
                        sb.Append("Baggage");
                        sb.Append("</title>");
                        sb.Append("<p>");
                        sb.Append("Adult");
                        sb.Append("</p>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-4 right-border col-xs-4'>");
                        sb.Append("<div class='baggage-info'>");
                        sb.Append("<title>");
                        sb.Append("Cabin");
                        sb.Append("</title>");
                        sb.Append("<p>5-7 Kg");
                        sb.Append("</p>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<div class='col-sm-4 col-xs-4'>");
                        sb.Append("<div class='baggage-info'>");
                        sb.Append("<title>");
                        sb.Append("Check-in");
                        sb.Append("</title>");
                        sb.Append("<p>20Kg</p>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*===other-features ===*/
                        sb.Append("<div class='other-features'>");
                        sb.Append("<ul>");
                        sb.Append("<li><img src='../Content/images/wifi-icon.png'> Wifi</li>");
                        sb.Append("<li><img src='../Content/images/power-icon.png'> In seat Power</li>");
                        sb.Append("<li><img src='../Content/images/food-icon.png'> Food</li>");
                        sb.Append("<li><img src='../Content/images/video-icon.png'> On demand video</li>");
                        sb.Append("</ul>");
                        sb.Append("</div>");
                        /*===other-features end ===*/
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        /*=== Fare Details ===*/
                        sb.Append("<div id='tab2a'>");
                        sb.Append("<div class='row'>");
                        sb.Append("<div class='col-md-12'>");
                        sb.Append("<div class='table-responsive fare-details'>");
                        sb.Append("<table class='table table-bordered'>");
                        sb.Append("<h5 style='padding:10px 0px;'>Fare Type: (" + item.Fares.FareType + ")</h5>");
                        sb.Append("<thead class='thead-light'>");
                        sb.Append("<tr>");
                        sb.Append("<th scope='col'>Type</th>");
                        sb.Append("<th scope='col'>Base Fare</th>");
                        sb.Append("<th scope='col'>Taxes</th>");
                        sb.Append("<th scope='col'>Service Fees</th>");
                        sb.Append("<th scope='col'>Fare Per Passenger</th>");
                        sb.Append("<th scope='col'>Passengers</th>");
                        sb.Append("<th scope='col'>Total Price</th>");
                        sb.Append("</tr>");
                        sb.Append("</thead>");
                        sb.Append("<tbody>");
                        sb.Append(item.Fares.FareDetailsHtml);
                        sb.Append("</tbody>");
                        sb.Append("</table>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("</div>");
                        sb.Append("<br>");
                        sb.Append("</div>");
                        /*=== End Fare Details ===*/

                    }

                }
                return quotes = sb.ToString();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }

            return "";
        }
        public List<FilteredQuotes> GetFilteredQuotes(FilteredSearchResponse filteredSearchResponse, string searchtype, List<ModelDTO.Airlines> lstAirlines, string fareType)
        {
            List<PresentationLayer.Models.FilteredQuotes> lstQoutes = new List<PresentationLayer.Models.FilteredQuotes>();
            try
            {
                if (filteredSearchResponse == null || (string.IsNullOrEmpty(filteredSearchResponse.Message) == false && filteredSearchResponse.Message != "HttpClient postAsync excuted successfully"))
                {
                    lstQoutes.Add(new FilteredQuotes
                    {
                        Message = "Failed"
                    });
                    return lstQoutes;
                }
                else
                {
                    string searchType = searchtype;
                    string validatingAirline = string.Empty;
                    string validatingAirline1 = string.Empty;
                    double totalFare = 0;
                    int fltcnt = 0;
                    int segcnt = 0;
                    int elapsedTime = 0;
                    int elapsedHours = 0;
                    int elapsedMinutes = 0;
                    string outboundLayover = string.Empty;
                    string inboundLayover = string.Empty;
                    string outboundTotalTripDuration = string.Empty;
                    string inboundTotalTripDuration = string.Empty;
                    int origindestinationOptionCount = 0;
                    DateTime arrdttime;
                    DateTime depdttime;
                    foreach (var priced_itinerary in filteredSearchResponse.Data.OTA_AirLowFareSearchRS[0].PricedItineraries[0].PricedItinerary)
                    {
                        if (priced_itinerary.AirItineraryPricingInfo.Count > 0)
                        {
                            validatingAirline1 = priced_itinerary.AirItineraryPricingInfo[0].TPA_Extensions[0].ValidatingCarrier[0].Default[0].Code;
                        }
                        else if (priced_itinerary.TPA_Extensions.Count > 0 && priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo.Count > 0)
                        {
                            validatingAirline1 = priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo[0].TPA_Extensions[0].ValidatingCarrier[0].Default[0].Code;
                        }
                        validatingAirline = validatingAirline1;
                        bool isBlockedAirline = false;
                        foreach (var al in lstAirlines)
                        {
                            if(al.IATACode == validatingAirline)
                            {
                                isBlockedAirline = false;
                            }
                        }
                        if(isBlockedAirline)
                        {
                            continue;
                        }
                        PresentationLayer.Models.ViewModels.QuoteViewModel quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();
                        /*=== Fares ===*/
                        PresentationLayer.Models.Fares fares = new PresentationLayer.Models.Fares();
                        if (priced_itinerary.AirItineraryPricingInfo.Count > 0)
                        {
                            fares = quoteViewModel.GetFares(priced_itinerary.AirItineraryPricingInfo[0], null);
                        }
                        else if (priced_itinerary.TPA_Extensions.Count > 0 && priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo.Count > 0)
                        {
                            fares = quoteViewModel.GetFares(null, priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo[0]);
                        }
                        else
                        {
                            continue;
                        }
                        totalFare = fares.TotalFare;
                        quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();
                        PresentationLayer.Models.Quotes objOutbount = quoteViewModel.GetFlightSegments(priced_itinerary.AirItinerary[0].OriginDestinationOptions[0], 0, searchType);

                        quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();
                        PresentationLayer.Models.Quotes objInbount = null;
                        origindestinationOptionCount = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption.Count;
                        if (origindestinationOptionCount > 1 && searchType != "M")
                        {
                            objInbount = quoteViewModel.GetFlightSegments(priced_itinerary.AirItinerary[0].OriginDestinationOptions[0], 1, searchType);
                        }
                        string cabin = "Economy";
                        string meal = "M";
                        if (priced_itinerary.AirItineraryPricingInfo != null && priced_itinerary.AirItineraryPricingInfo.Count > 0)
                        {
                            foreach (var itemFT in priced_itinerary.AirItineraryPricingInfo[0].PTC_FareBreakdowns[0].PTC_FareBreakdown[0].FareInfos[0].FareInfo[0].TPA_Extensions[0].Cabin)
                            {
                                if(itemFT.Cabins.ToString() == fareType)
                                {
                                    cabin = fareType == "Y" ? "Economy" : fareType == "F" ? "First" : fareType == "S" ? "Premium Economy" : fareType == "P" ? "Premium First" : fareType == "C" ? "Business" : fareType == "J" ? "Premium Business" : "All";
                                }
                            }
                            meal = priced_itinerary.AirItineraryPricingInfo[0].PTC_FareBreakdowns[0].PTC_FareBreakdown[0].FareInfos[0].FareInfo[0].TPA_Extensions[0].Meal[0].Code;
                        }
                        else if (priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo != null && priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo.Count > 0)
                        {
                            foreach (var itemAFFT in priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo[0].PTC_FareBreakdowns[0].PTC_FareBreakdown[0].FareInfos[0].FareInfo[0].TPA_Extensions[0].Cabin)
                            {
                                if (itemAFFT.Cabins.ToString() == fareType)
                                {
                                    cabin = fareType == "Y" ? "Economy" : fareType == "F" ? "First" : fareType == "S" ? "Premium Economy" : fareType == "P" ? "Premium First" : fareType == "C" ? "Business" : fareType == "J" ? "Premium Business" : "All";
                                }
                            }
                           
                            meal = priced_itinerary.TPA_Extensions[0].AdditionalFares[0].AirItineraryPricingInfo[0].PTC_FareBreakdowns[0].PTC_FareBreakdown[0].FareInfos[0].FareInfo[0].TPA_Extensions[0].Meal[0].Code;
                        }
                        List<PresentationLayer.Models.Quotes> lstOutboundFlights = new List<PresentationLayer.Models.Quotes>();
                        List<PresentationLayer.Models.Quotes> lstInboundFlights = new List<PresentationLayer.Models.Quotes>();
                        if (searchType == "M")
                        {
                            outboundLayover = string.Empty;
                            foreach (var origdes in priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption)
                            {
                                fltcnt = 1;
                                segcnt = origdes.FlightSegment.Count;

                                foreach (var fltseg in origdes.FlightSegment)
                                {
                                    outboundLayover = string.Empty;
                                    quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();

                                    var obf = quoteViewModel.GetFlightSegmentDetails(fltseg);
                                    if (segcnt > 1)
                                    {
                                        if (segcnt != fltcnt)
                                        {
                                            arrdttime = origdes.FlightSegment[fltcnt - 1].ArrivalDateTime;
                                            depdttime = origdes.FlightSegment[fltcnt].DepartureDateTime;
                                            TimeSpan timediff = depdttime.Subtract(arrdttime);

                                            if (timediff.Days > 0)
                                            {
                                                outboundLayover = timediff.Days + "d:" + timediff.Hours + "h:" + timediff.Minutes + "m";
                                            }
                                            else
                                            {
                                                outboundLayover = timediff.Hours + "h:" + timediff.Minutes + "m";
                                            }
                                        }
                                    }
                                    fltcnt++;
                                    lstOutboundFlights.Add(new Quotes
                                    {
                                        ArrivalTime = obf.ArrivalTime,
                                        DepatureTime = obf.DepatureTime,
                                        Duration = obf.Duration,
                                        Flight = obf.Flight,
                                        Stops = obf.Stops,
                                        Layover = outboundLayover
                                    });

                                }
                                
                                elapsedTime = origdes.ElapsedTime;
                                elapsedHours = elapsedTime / 60;
                                elapsedMinutes = elapsedTime % 60;
                                outboundTotalTripDuration = elapsedHours + "h:" + elapsedMinutes + "m";
                                int lstcnt = lstOutboundFlights.Count;
                                if (segcnt > 1)
                                {
                                    lstOutboundFlights.Insert(lstcnt, new Quotes { TripTotalDuration = outboundTotalTripDuration });
                                }
                            }
                        }
                        else
                        {
                            fltcnt = 1;
                            segcnt = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[0].FlightSegment.Count;
                            foreach (var flightSegments in priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[0].FlightSegment)
                            {
                                quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();
                                var obf = quoteViewModel.GetFlightSegmentDetails(flightSegments);

                                if (segcnt > 1)
                                {
                                    if (segcnt != fltcnt)
                                    {
                                        arrdttime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[0].FlightSegment[fltcnt - 1].ArrivalDateTime;
                                        depdttime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[0].FlightSegment[fltcnt].DepartureDateTime;
                                        TimeSpan timediff = depdttime.Subtract(arrdttime);

                                        if (timediff.Days > 0)
                                        {
                                            outboundLayover = timediff.Days + "d:" + timediff.Hours + "h:" + timediff.Minutes + "m";
                                        }
                                        else
                                        {
                                            outboundLayover = timediff.Hours + "h:" + timediff.Minutes + "m";
                                        }
                                    }
                                }
                                fltcnt++;
                                lstOutboundFlights.Add(new Quotes
                                {
                                    ArrivalTime = obf.ArrivalTime,
                                    DepatureTime = obf.DepatureTime,
                                    Duration = obf.Duration,
                                    Flight = obf.Flight,
                                    Stops = obf.Stops,
                                    Layover = outboundLayover
                                });
                            }
                            elapsedTime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[0].ElapsedTime;
                            elapsedHours = elapsedTime / 60;
                            elapsedMinutes = elapsedTime % 60;
                            outboundTotalTripDuration = elapsedHours + "h:" + elapsedMinutes + "m";
                        }
                        if (priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption.Count > 1 && searchType != "M")
                        {
                            fltcnt = 1;
                            segcnt = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[1].FlightSegment.Count;
                            foreach (var flightSegments in priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[1].FlightSegment)
                            {
                                quoteViewModel = new PresentationLayer.Models.ViewModels.QuoteViewModel();
                                var ibf = quoteViewModel.GetFlightSegmentDetails(flightSegments);
                                if (segcnt > 1)
                                {
                                    if (segcnt != fltcnt)
                                    {
                                        arrdttime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[1].FlightSegment[fltcnt - 1].ArrivalDateTime;
                                        depdttime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[1].FlightSegment[fltcnt].DepartureDateTime;
                                        TimeSpan timediff = depdttime.Subtract(arrdttime);
                                        if (timediff.Days > 0)
                                        {
                                            inboundLayover = timediff.Days + "d:" + timediff.Hours + "h:" + timediff.Minutes + "m";
                                        }
                                        else
                                        {
                                            inboundLayover = timediff.Hours + "h:" + timediff.Minutes + "m";
                                        }

                                    }
                                }
                                fltcnt++;
                                lstInboundFlights.Add(new Quotes
                                {
                                    ArrivalTime = ibf.ArrivalTime,
                                    DepatureTime = ibf.DepatureTime,
                                    Duration = ibf.Duration,
                                    Flight = ibf.Flight,
                                    Stops = ibf.Stops,
                                    Layover = inboundLayover
                                });
                            }
                            elapsedTime = priced_itinerary.AirItinerary[0].OriginDestinationOptions[0].OriginDestinationOption[1].ElapsedTime;
                            elapsedHours = elapsedTime / 60;
                            elapsedMinutes = elapsedTime % 60;
                            inboundTotalTripDuration = elapsedHours + "h:" + elapsedMinutes + "m";
                        }
                        lstQoutes.Add(new FilteredQuotes
                        {
                            SequenceNumber = priced_itinerary.SequenceNumber.ToString(),
                            InBoundStops = GetStops(lstInboundFlights),
                            OutBoundStops = GetStops(lstOutboundFlights),
                            ValidatingAirline = validatingAirline1,
                            TotalFare = totalFare,
                            Fares = fares,
                            OutBoundTotalTripDuration = outboundTotalTripDuration,
                            InBoundTotalTripDuration = inboundTotalTripDuration,
                            OutBound = objOutbount,
                            InBound = objInbount,
                            InBoundFlights = lstInboundFlights,
                            OutBoundFlights = lstOutboundFlights,
                            Cabin = cabin,
                            Meal = meal,
                            SearchType = searchType,
                            OrgDesOptionCount = origindestinationOptionCount,
                            Message = "Success"
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }

            return lstQoutes;
        }
        public Quotes GetFlightSegments(MSabre.JsonModels.FilteredResponse.OriginDestinationOptions _origindestinationoption, int indx, string _searchtype)
        {
            PresentationLayer.Models.Quotes quotes = new PresentationLayer.Models.Quotes();
            try
            {
                if (_origindestinationoption != null)
                {
                    PresentationLayer.Models.OutboundFlights objOBF = new PresentationLayer.Models.OutboundFlights();
                    var OB = objOBF;
                        OB.IATACode = _origindestinationoption.OriginDestinationOption[indx].FlightSegment[0].MarketingAirline[0].Code;
                        OB.LogoPath = "/services/AirWebApi/air/Content/fin-logos/" + OB.IATACode + ".png";
                        OB.AirlineName = _origindestinationoption.OriginDestinationOption[indx].FlightSegment[0].MarketingAirline[0].AirlineName;
                        OB.FlightNumber = _origindestinationoption.OriginDestinationOption[indx].FlightSegment[0].FlightNumber;
                        OB.DepDateTime = _origindestinationoption.OriginDestinationOption[indx].FlightSegment[0].DepartureDateTime;
                        OB.Hours = OB.DepDateTime.Hour < 10 ? "0" + OB.DepDateTime.Hour.ToString() : OB.DepDateTime.Hour.ToString();
                        OB.Minutes = OB.DepDateTime.Minute < 10 ? "0" + OB.DepDateTime.Minute.ToString() : OB.DepDateTime.Minute.ToString();
                        OB.HoursMinutes = OB.Hours + ":" + OB.Minutes;
                        OB.Day = OB.DepDateTime.Day < 10 ? "0" + OB.DepDateTime.Day.ToString() : OB.DepDateTime.Day.ToString();
                        OB.MonthDayYear = OB.MonthName[OB.DepDateTime.Month] + " " + OB.Day + ", " + OB.DepDateTime.Year;
                        OB.CityName = _origindestinationoption.OriginDestinationOption[indx].FlightSegment[0].DepartureAirport[0].DepartureAirportCity;
                        OB.ElapsedTime = _origindestinationoption.OriginDestinationOption[indx].ElapsedTime;
                        OB.ElapsedHours = OB.ElapsedTime / 60;
                        OB.ElapsedMinutes = OB.ElapsedTime % 60;
                        OB.StopCount = _origindestinationoption.OriginDestinationOption[indx].FlightSegment.Count;
                        if(_searchtype =="M")
                        {
                        OB.Stops = "1+ Stops"; //=== OB.StopCount == 1 ? "1+ Stops" : OB.StopCount == 2 ? "1 Stops" : "2+ Stops"; //=== "2+ Stops";
                        }
                        else
                        {
                            OB.Stops = OB.StopCount == 1 ? "Non-Stop" : OB.StopCount == 2 ? "1 Stops" : "2+ Stops";
                        }
                       
                        quotes.Flight = "<img src='" + OB.LogoPath + "'/><h5>" + OB.AirlineName + "</h5><p>" + OB.IATACode + "-" + OB.FlightNumber + "</p>";
                        quotes.DepatureTime = "<h3>" + OB.HoursMinutes + "</h3><div class='dep-date'>" + OB.MonthDayYear + "</div><div class='dep-city'>" + OB.CityName + "</div>";
                        string depArr = string.Empty;
                        int cnt = 0;
                        if(_searchtype == "M")
                        {
                            foreach (var item in _origindestinationoption.OriginDestinationOption)
                            {
                                depArr += item.FlightSegment[0].DepartureAirport[0].LocationCode + "-";
                            }
                            int i = _origindestinationoption.OriginDestinationOption.Count;
                            int fscnt = _origindestinationoption.OriginDestinationOption[i - 1].FlightSegment.Count;
                            depArr += _origindestinationoption.OriginDestinationOption[i - 1].FlightSegment[fscnt - 1].ArrivalAirport[0].LocationCode;
                        }
                         else
                        {
                        foreach (var seg in _origindestinationoption.OriginDestinationOption[indx].FlightSegment)
                        {
                            if (cnt == 0)
                            {
                                depArr += seg.DepartureAirport[0].LocationCode + "-" + seg.ArrivalAirport[0].LocationCode;
                            }
                            else
                            {
                                depArr += "-" + seg.ArrivalAirport[0].LocationCode;
                            }
                            cnt++;
                        }
                    }
                        if(_searchtype == "M")
                        {
                            quotes.Duration = "<p>" + OB.Stops + "</p><span>" + depArr + "</span>";
                        }
                            else
                        {
                            quotes.Duration = "<p>" + OB.ElapsedHours + "h:" + OB.ElapsedMinutes + "m | " + OB.Stops + "</p><span>" + depArr + "</span>";
                        }
                        
                        quotes.ArrivalTime = GetArrivalTime(_origindestinationoption.OriginDestinationOption[indx]);
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return quotes;
        }
        public Quotes GetFlightSegmentDetails(MSabre.JsonModels.FilteredResponse.FlightSegment _flightSegments)
        {
            PresentationLayer.Models.Quotes quotes = new PresentationLayer.Models.Quotes();
            try
            {
                if (_flightSegments != null)
                {
                        PresentationLayer.Models.OutboundFlights objOBF = new PresentationLayer.Models.OutboundFlights();
                        var OB = objOBF;
                        OB.IATACode = _flightSegments.MarketingAirline[0].Code;
                        OB.LogoPath = "/services/AirWebApi/air/Content/fin-logos/" + OB.IATACode + ".png";
                        OB.AirlineName = _flightSegments.MarketingAirline[0].AirlineName;
                        OB.FlightNumber = _flightSegments.FlightNumber;
                        OB.DepDateTime = _flightSegments.DepartureDateTime;
                        OB.Hours = OB.DepDateTime.Hour < 10 ? "0" + OB.DepDateTime.Hour.ToString() : OB.DepDateTime.Hour.ToString();
                        OB.Minutes = OB.DepDateTime.Minute < 10 ? "0" + OB.DepDateTime.Minute.ToString() : OB.DepDateTime.Minute.ToString();
                        OB.HoursMinutes = OB.Hours + ":" + OB.Minutes;
                        OB.Day = OB.DepDateTime.Day < 10 ? "0" + OB.DepDateTime.Day.ToString() : OB.DepDateTime.Day.ToString();
                        OB.MonthDayYear = OB.MonthName[OB.DepDateTime.Month] + " " + OB.Day + ", " + OB.DepDateTime.Year;
                        OB.CityName = _flightSegments.DepartureAirport[0].DepartureAirportCity;
                        OB.ElapsedTime = _flightSegments.ElapsedTime;
                        OB.ElapsedHours = OB.ElapsedTime / 60;
                        OB.ElapsedMinutes = OB.ElapsedTime % 60;
                        OB.StopCount = 0;
                        OB.Stops = OB.StopCount == 1 ? "Non-Stop" : OB.StopCount == 2 ? "1 Stops" : "2+ Stops";
                        quotes.Flight = "<img src='" + OB.LogoPath + "'/><h5>" + OB.AirlineName + "</h5><p>" + OB.IATACode + "-" + OB.FlightNumber + "</p>";
                        quotes.DepatureTime = "<div class='date-detail'>" + OB.HoursMinutes + " <span>- "+ OB.CityName + "</span></div><p>" + OB.MonthDayYear + "</p>";
                        quotes.Duration = "<p>" + OB.ElapsedHours + "h:" + OB.ElapsedMinutes + "m" + "</p>";

                        OB.ArrDateTime = _flightSegments.ArrivalDateTime;
                        OB.ArrHours = OB.ArrDateTime.Hour < 10 ? "0" + OB.ArrDateTime.Hour.ToString() : OB.ArrDateTime.Hour.ToString();
                        OB.ArrMinutes = OB.ArrDateTime.Minute < 10 ? "0" + OB.ArrDateTime.Minute.ToString() : OB.ArrDateTime.Minute.ToString();
                        OB.ArrHoursMinutes = OB.ArrHours + ":" + OB.ArrMinutes;
                        OB.ArrDay = OB.ArrDateTime.Day < 10 ? "0" + OB.ArrDateTime.Day.ToString() : OB.ArrDateTime.Day.ToString();
                        OB.ArrMonthDayYear = OB.MonthName[OB.ArrDateTime.Month] + " " + OB.ArrDay + ", " + OB.ArrDateTime.Year;  
                        OB.ArrCityName = _flightSegments.ArrivalAirport[0].ArrivalAirportCity;
                        quotes.ArrivalTime = "<div class='date-detail'>"+ OB.ArrHoursMinutes +" <span>- "+ OB.ArrCityName + "</span></div><p>"+ OB.ArrMonthDayYear +"</p>";
                        quotes.Stops = OB.Stops;
                    }
             }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return quotes;
        }
        public Fares GetFares(MSabre.JsonModels.FilteredResponse.AirItineraryPricingInfo _airItineraryPricingInfo, MSabre.JsonModels.FilteredResponse.AirItineraryPricingInfo2 _airItineraryPricingInfo2)
        {
            Fares fares = new Fares();
            int passengerQnty = 0;
            try
            {
                    if (_airItineraryPricingInfo != null && _airItineraryPricingInfo.ItinTotalFare.Count > 0)
                    {
                        var itinTotalFare = _airItineraryPricingInfo.ItinTotalFare[0];
                        fares.Currency = itinTotalFare.EquivFare[0].CurrencyCode;
                        fares.EquivFare = itinTotalFare.EquivFare[0].Amount;
                        if (itinTotalFare.Taxes.Count > 0)
                        {
                            fares.Taxes = itinTotalFare.Taxes[0].Tax[0].Amount;
                        }
                        var ptc_FareBreakdown = _airItineraryPricingInfo.PTC_FareBreakdowns[0].PTC_FareBreakdown;
                        fares.FareParameters.CCEnableAir = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.CCEnableAir;
                        fares.FareParameters.IsAveragefare = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.IsAveragefare;
                        fares.FareParameters.IsChangeCancelDisplay = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.IsChangeCancelDisplay;
                        fares.FareParameters.StandardPublishedMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardPublishedMarkup;
                        fares.FareParameters.StandardNetMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardNetMarkup;
                        fares.FareParameters.StandardTourNetMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardTourNetMarkup;
                        fares.FareParameters.InfantFare = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.InfantFare;
                    foreach (var ptcFareBreaks in ptc_FareBreakdown)
                    {
                        fares.Commission += ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.Commission;
                        fares.ServiceFee += ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.ServiceFee;
                        fares.FareType = ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.PassengerType;
                        StringBuilder sbfaredetailshtml = new StringBuilder();
                        double grandtotal = 0;
                        double basefare = 0;
                        foreach (var fd in ptcFareBreaks.PassengerFare)
                        {
                            string paxtype = fd.TotalFare[0].MarkupParameters.FareDetails[0].PassengerType;
                            paxtype = paxtype == "ADT" ? "Adult" : paxtype == "C07" ? "Child" : "Infant";
                            
                            sbfaredetailshtml.Append("<tr><th scope='row'>" + paxtype + "</th>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].BaseFare.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].Taxes.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].PerPassengerMarkup.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].PerPassengerFare.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].NumberOfPassenger + "</td>");
                            sbfaredetailshtml.Append("<td>"+ fd.TotalFare[0].MarkupParameters.FareDetails[0].TotalPrice.ToString("0.00") + "</td></tr>");
                            grandtotal += fd.TotalFare[0].MarkupParameters.FareDetails[0].TotalPrice;

                        }
                        sbfaredetailshtml.Append("<tr><td colspan='5'></td>");
                        sbfaredetailshtml.Append("<td style='font-weight:bold; font-size: 14px;'>Grand Total</td>");
                        sbfaredetailshtml.Append("<td style='font -weight:bold; font-size: 14px;'>" + grandtotal.ToString("0.00") + "</td></tr>");
                        fares.FareDetailsHtml = sbfaredetailshtml.ToString();
                        foreach (var item in ptcFareBreaks.PassengerTypeQuantity)
                        {
                            passengerQnty += item.Quantity;
                        }

                    }
                        string passengerTypeQuantityCode = ptc_FareBreakdown[0].PassengerTypeQuantity[0].Code;
                        if (ptc_FareBreakdown[0].PassengerFare[0].PenaltiesInfo.Count > 0)
                        {
                            foreach (var penalty in ptc_FareBreakdown[0].PassengerFare[0].PenaltiesInfo[0].Penalty)
                            {
                                if (passengerTypeQuantityCode == "ADT")
                                {
                                    if (penalty.Type == "Exchange")
                                    {
                                        if (penalty.Applicability == "Before")
                                        {
                                            fares.BaggagesPenalties.CancellationBefore = penalty.Amount == 0 ? "No Refund" : penalty.Amount.ToString("0.00");
                                        }
                                        if (penalty.Applicability == "After")
                                        {
                                            fares.BaggagesPenalties.CancellationAfter = penalty.Amount == 0 ? "No Refund" : penalty.Amount.ToString("0.00");
                                        }
                                    }
                                    if (penalty.Type == "Refund")
                                    {
                                        if (penalty.Applicability == "Before")
                                        {
                                            if (Convert.ToBoolean(penalty.Refundable))
                                                fares.BaggagesPenalties.ChangeBefore = penalty.Amount == 0 ? "Non-Changeable" : penalty.Amount.ToString("0.00");
                                            else
                                                fares.BaggagesPenalties.ChangeBefore = "Non-Changeable";
                                        }
                                        if (penalty.Applicability == "After")
                                        {
                                            if (Convert.ToBoolean(penalty.Refundable))
                                                fares.BaggagesPenalties.ChangeAfter = penalty.Amount == 0 ? "Non-Changeable" : penalty.Amount.ToString("0.00");
                                            else
                                                fares.BaggagesPenalties.ChangeAfter = "Non-Changeable";
                                        }
                                    }
                                }
                            }
                        }
                        int segIndx = 0;
                        if (ptc_FareBreakdown[0].PassengerFare[0].TPA_Extensions[0].BaggageInformationList.Count > 0)
                        {
                            foreach (var baggageInfo in ptc_FareBreakdown[0].PassengerFare[0].TPA_Extensions[0].BaggageInformationList[0].BaggageInformation)
                            {
                                if (baggageInfo.Segment[segIndx].Id == 0)
                                {
                                    if (baggageInfo.ProvisionType == "A")
                                    {
                                        fares.BaggagesPenalties.BagQntyCheckIn = baggageInfo.Allowance[0].Pieces.ToString();
                                    }
                                }
                                segIndx++;
                            }
                        }
                    }
                    else if (_airItineraryPricingInfo2 != null && _airItineraryPricingInfo2.ItinTotalFare.Count > 0)
                    {
                        var itinTotalFare = _airItineraryPricingInfo2.ItinTotalFare[0];
                        fares.Currency = itinTotalFare.EquivFare[0].CurrencyCode;
                        fares.EquivFare = itinTotalFare.EquivFare[0].Amount;
                        if (itinTotalFare.Taxes.Count > 0)
                        {
                            fares.Taxes = itinTotalFare.Taxes[0].Tax[0].Amount;
                        }
                        var ptc_FareBreakdown = _airItineraryPricingInfo2.PTC_FareBreakdowns[0].PTC_FareBreakdown;
                        fares.FareParameters.CCEnableAir = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.CCEnableAir;
                        fares.FareParameters.IsAveragefare = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.IsAveragefare;
                        fares.FareParameters.IsChangeCancelDisplay = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.IsChangeCancelDisplay;
                        fares.FareParameters.StandardPublishedMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardPublishedMarkup;
                        fares.FareParameters.StandardNetMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardNetMarkup;
                        fares.FareParameters.StandardTourNetMarkup = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.StandardTourNetMarkup;
                        fares.FareParameters.InfantFare = ptc_FareBreakdown[0].PassengerFare[0].TotalFare[0].FareParameters.InfantFare;
                        foreach (var ptcFareBreaks in ptc_FareBreakdown)
                        {
                            fares.Commission += ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.Commission;
                            fares.ServiceFee += ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.ServiceFee;
                            fares.FareType = ptcFareBreaks.PassengerFare[0].TotalFare[0].MarkupParameters.PassengerType;
                        StringBuilder sbfaredetailshtml = new StringBuilder();
                        double grandtotal = 0;
                        double basefare = 15.00;
                        foreach (var fd in ptcFareBreaks.PassengerFare)
                        {
                            string paxtype = fd.TotalFare[0].MarkupParameters.FareDetails[0].PassengerType;
                            
                            paxtype = (paxtype == "JCB" || paxtype == "ITX") ? "Adult" : (paxtype == "106" || paxtype == "JNN") ? "Child" : "Infant";
                            
                            sbfaredetailshtml.Append("<tr><th scope='row'>" + paxtype + "</th>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].BaseFare.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].Taxes.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].PerPassengerMarkup.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].PerPassengerFare.ToString("0.00") + "</td>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].NumberOfPassenger + "</td>");
                            sbfaredetailshtml.Append("<td>" + fd.TotalFare[0].MarkupParameters.FareDetails[0].TotalPrice.ToString("0.00") + "</td></tr>");
                            grandtotal += fd.TotalFare[0].MarkupParameters.FareDetails[0].TotalPrice;

                        }
                        sbfaredetailshtml.Append("<tr><td colspan='5'></td>");
                        sbfaredetailshtml.Append("<td style='font-weight:bold; font-size: 14px;'>Grand Total</td>");
                        sbfaredetailshtml.Append("<td style='font -weight:bold; font-size: 14px;'>" + grandtotal.ToString("0.00") + "</td></tr>");
                        fares.FareDetailsHtml = sbfaredetailshtml.ToString();
                        foreach (var item in ptcFareBreaks.PassengerTypeQuantity)
                            {
                                passengerQnty += item.Quantity;
                            }

                        }
                    }
                    else
                    {
                        fares.Currency = "CAD";
                        fares.EquivFare = 0;
                        fares.Taxes = 0;
                        fares.TotalFare = 0;
                        fares.Commission = 0;
                        fares.ServiceFee = 0;
                    }
                    if (fares.FareParameters.IsAveragefare)
                    {
                        fares.FareCalculationType = "Avg. fare/pass";
                        double taxPerPassenger = fares.Taxes / passengerQnty;
                        double farePerPassenger = fares.EquivFare / passengerQnty;
                        fares.Taxes = taxPerPassenger;
                        fares.EquivFare = farePerPassenger;
                        fares.TotalFare = farePerPassenger + taxPerPassenger;
                    }
                    else
                    {
                        fares.FareCalculationType = "Total Fare";
                        fares.TotalFare = fares.EquivFare + fares.Taxes;
                    }

            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return fares;
        }
        public List<ModelDTO.Airlines> GetDistinctAirlines(List<ModelDTO.Airlines> lstAirlines,List<FilteredQuotes> lstFilteredQuotes)
        {
            List<ModelDTO.Airlines> lstDal = new List<ModelDTO.Airlines>();
            try
            {
                foreach (var item in lstFilteredQuotes)
                {
                    string airline = item.ValidatingAirline;
                    bool isExist = false;
                    if (lstDal.Count > 0)
                    {
                        foreach (var al in lstDal)
                        {
                            if (al.IATACode == airline)
                            {
                                isExist = true;
                                break;
                            }
                        }
                    }
                    if (isExist == false)
                    {
                        foreach (var al1 in lstAirlines)
                        {
                            if (al1.IATACode == airline)
                            {
                                lstDal.Add(new ModelDTO.Airlines
                                {
                                    IATACode = airline,
                                    AirlineName = GetAirlineName(lstAirlines, airline)
                                });
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = ModelDTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions Presentation Layer"
                };
                objDbErr.AddErrorLog();
            }
            return lstDal;
        }
        private string GetArrivalTime(MSabre.JsonModels.FilteredResponse.OriginDestinationOption _depDesOptions)
        {
            PresentationLayer.Models.OutboundFlights objOBF = new PresentationLayer.Models.OutboundFlights();
            var OB = objOBF;
            string arrivalTime = string.Empty;
            var arrflightSegments = _depDesOptions.FlightSegment;
            int arrCnt = arrflightSegments.Count - 1;
            OB.ArrDateTime =  arrflightSegments[arrCnt].ArrivalDateTime;
            OB.Hours = OB.ArrDateTime.Hour < 10 ? "0" + OB.ArrDateTime.Hour.ToString() : OB.ArrDateTime.Hour.ToString();
            OB.Minutes = OB.ArrDateTime.Minute < 10 ? "0" + OB.ArrDateTime.Minute.ToString() : OB.ArrDateTime.Minute.ToString();
            OB.HoursMinutes = OB.Hours + ":" + OB.Minutes;
            OB.Day = OB.ArrDateTime.Day < 10 ? "0" + OB.ArrDateTime.Day.ToString() : OB.ArrDateTime.Day.ToString();
            OB.MonthDayYear = OB.MonthName[OB.ArrDateTime.Month] + " " + OB.Day + ", " + OB.ArrDateTime.Year;
            OB.CityName = _depDesOptions.FlightSegment[arrCnt].ArrivalAirport[0].ArrivalAirportCity;
            arrivalTime ="<h3>"+ OB.HoursMinutes +"</h3><div class='arr-date'>"+ OB.MonthDayYear +"</div><div class='arr-city'>"+ OB.CityName +"</div>";
            return arrivalTime;
        }
        private string GetStops(List<Quotes> flightSegments)
        {
            string stops = "Non-Stop";
            if (flightSegments.Count > 1)
            {
                foreach (var item in flightSegments)
                {
                    if (string.IsNullOrEmpty(item.Stops) == false)
                    {
                            stops = item.Stops;
                    }
                }
            }
            return stops;
        }

        private string GetAirlineName(List<ModelDTO.Airlines> lstAirlines, string iataCode)
        {
            if (lstAirlines.Count > 0)
            {
                foreach (var aL in lstAirlines)
                {
                    if (aL.IATACode == iataCode)
                    {
                        string airlineName = string.IsNullOrEmpty(aL.AirlineName.Trim()) ? aL.IATACode : aL.AirlineName;
                        return airlineName;
                    }
                }

            }
            return string.Empty;
        }
        
    }
}