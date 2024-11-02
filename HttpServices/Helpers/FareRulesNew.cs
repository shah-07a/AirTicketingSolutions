using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOL = BusinessObjectLayer;
using Models.Sabre.JsonModels.Response;
using Models.DTO;
using Newtonsoft.Json;
using AirItineraryPricingInfo = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1;
using OriginDestinationOption1 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItinerary1.OriginDestinationOptions1.OriginDestinationOption1;
using OriginDestinationOptions = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItinerary1.OriginDestinationOptions1;
using PricedItineraries = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1;
using PTC_FareBreakdowns = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.PTC_FareBreakdowns1;
using PassengerFare = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.PTC_FareBreakdowns1.PTC_FareBreakdown1.PassengerFare1;
using Endorsements = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.PTC_FareBreakdowns1.PTC_FareBreakdown1.Endorsements1;
using TPA_Extensions3 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.PTC_FareBreakdowns1.PTC_FareBreakdown1.TPA_Extensions3;
using FareInfos = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.PTC_FareBreakdowns1.PTC_FareBreakdown1.FareInfos1;
using FareInfos2 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.AirItineraryPricingInfo1.FareInfos2;
using TicketingInfo = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TicketingInfo1;
using TPA_Extensions7 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7;
using AF_AirItineraryPricingInfo = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1;
using AF_PTC_FareBreakdowns = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_PTC_FareBreakdowns1;
using AF_PassengerFare = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_PTC_FareBreakdowns1.AF_PTC_FareBreakdown1.AF_PassengerFare1;
using AF_Endorsements = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_PTC_FareBreakdowns1.AF_PTC_FareBreakdown1.AF_Endorsements1;

using AF_TPA_Extensions3 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_PTC_FareBreakdowns1.AF_PTC_FareBreakdown1.AF_TPA_Extensions3;
using AF_FareInfos = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_PTC_FareBreakdowns1.AF_PTC_FareBreakdown1.AF_FareInfos1;
using AF_FareInfos2 = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_AirItineraryPricingInfo1.AF_FareInfos2;
using AF_TicketingInfo = Models.DTO.SearchResponseBaseModel.OTAAirLowFareSearchRS1.PricedItineraries1.PricedItinerary1.TPA_Extensions7.AdditionalFare1.AF_TicketingInfo1;
using System.Data;
using System.Text;
using System.Web.Security;
using System.Threading.Tasks;

namespace HttpServices.Helpers
{
    public class FareRulesNew
    {
        public SearchResponseBaseModel SetFareRules(string _searchResponse, string _requestId, string _domainname, int _userid, int _defaultcompanyid, int _userroleid, double _defaultinfantfae, bool _directonly)
        {
            List<ProcessingTime> lstprocstime = new List<ProcessingTime>();
            ProcessingTime procstime = new ProcessingTime();
            procstime.ProcessName = "Get User, Blocked Airlines and Markups from Db";
            procstime.RequestId = _requestId;
            procstime.StartTime = DateTime.Now.ToString();

            DataSet dataSet = GetDbData(_domainname, _userid, _defaultcompanyid, _userroleid);

            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);

            procstime = new ProcessingTime();
            procstime.ProcessName = "Get Blocked Airlines";
            procstime.RequestId = _requestId;
            procstime.StartTime = DateTime.Now.ToString();

            List<Models.DTO.BlockedAirlines> lstBlockedAirlines = null;
            if (!(_userroleid == 0 || _userroleid == 8))
            {
                lstBlockedAirlines = GetBlockedAirlines(dataSet.Tables[1]);
            }

            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);

            procstime = new ProcessingTime();
            procstime.ProcessName = "Get Markups";
            procstime.RequestId = _requestId;
            procstime.StartTime = DateTime.Now.ToString();

            List<Models.DTO.Markups> lstMarkups = GetMarkups(dataSet.Tables[2]);

            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);

            SearchResponseBaseModelJson searchResponse = new SearchResponseBaseModelJson();
            SearchResponseBaseModel filteredSearchResponse = new SearchResponseBaseModel();
            try
            {
                procstime = new ProcessingTime();
                procstime.ProcessName = "Filter Search Response";
                procstime.RequestId = _requestId;
                procstime.StartTime = DateTime.Now.ToString();

                searchResponse = JsonConvert.DeserializeObject<SearchResponseBaseModelJson>(_searchResponse);
                searchResponse.RequestId = _requestId;
                filteredSearchResponse.RequestId = _requestId;
                foreach (var item in searchResponse.Links)
                {
                    filteredSearchResponse.Links.Add(new SearchResponseBaseModel.Link1
                    {
                        href = item.href,
                        rel = item.rel,
                    });
                }

                SearchResponseBaseModel.OTAAirLowFareSearchRS1 objOTA = new SearchResponseBaseModel.OTAAirLowFareSearchRS1();

                objOTA.Success.Add(new SearchResponseBaseModel.OTAAirLowFareSearchRS1.Success1
                {
                    Message = searchResponse.OTA_AirLowFareSearchRS.Success.Message ?? "",

                });

                if (searchResponse.OTA_AirLowFareSearchRS.PricedItinCount > 0)
                {
                    PricedItineraries objPricedItineraries1 = new PricedItineraries();
                    objOTA.AvailableItinCount = searchResponse.OTA_AirLowFareSearchRS.AvailableItinCount;
                    objOTA.BrandedOneWayItinCount = searchResponse.OTA_AirLowFareSearchRS.BrandedOneWayItinCount;
                    objOTA.DepartedItinCount = searchResponse.OTA_AirLowFareSearchRS.DepartedItinCount;
                    objOTA.PricedItinCount = searchResponse.OTA_AirLowFareSearchRS.PricedItinCount;
                    objOTA.SimpleOneWayItinCount = searchResponse.OTA_AirLowFareSearchRS.SimpleOneWayItinCount;
                    objOTA.SoldOutItinCount = searchResponse.OTA_AirLowFareSearchRS.SoldOutItinCount;
                    objOTA.StatusMessage = "Successfully done";
                    objOTA.Version = searchResponse.OTA_AirLowFareSearchRS.Version;
                    int i = 0;

                    foreach (var item1 in searchResponse.OTA_AirLowFareSearchRS.PricedItineraries.PricedItinerary)
                    {
                        bool isDisplay = true;
                        if (_directonly)
                        {
                            foreach (var orig_des in item1.AirItinerary.OriginDestinationOptions.OriginDestinationOption)
                            {

                                if (orig_des.FlightSegment.Count > 1)
                                {
                                    isDisplay = false;
                                    break;
                                }

                            }
                        }
                        bool isBlockedAL = false;
                        if (isDisplay == true)
                        {
                            if (lstBlockedAirlines != null && lstBlockedAirlines.Count > 0)
                            {
                                foreach (var al in lstBlockedAirlines)
                                {
                                    if (item1.AirItinerary.OriginDestinationOptions.OriginDestinationOption[0].FlightSegment[0].MarketingAirline.Code == al.IATACode)
                                    {
                                        isBlockedAL = true;
                                        break;
                                    }
                                    else
                                    {
                                        isBlockedAL = false;
                                    }
                                }
                            }

                            if (isBlockedAL == false)
                            {
                                PricedItineraries.PricedItinerary1.AirItinerary1 objAirItinerary1 = new PricedItineraries.PricedItinerary1.AirItinerary1();
                                PricedItineraries.PricedItinerary1 objPricedItinerary1 = new PricedItineraries.PricedItinerary1();
                                OriginDestinationOptions objOriginDestinationOptions1 = new OriginDestinationOptions();
                                objPricedItinerary1.SequenceNumber = item1.SequenceNumber;
                                objAirItinerary1.DirectionInd = item1.AirItinerary.DirectionInd;

                                int cont = item1.AirItinerary.OriginDestinationOptions.OriginDestinationOption.Count;

                                foreach (var item_1 in item1.AirItinerary.OriginDestinationOptions.OriginDestinationOption)
                                {
                                    OriginDestinationOption1 objOriginDestinationOption1 = new OriginDestinationOption1();
                                    objOriginDestinationOption1.ElapsedTime = item_1.ElapsedTime;
                                    List<OriginDestinationOption1.FlightSegment1> lstFlightSegment = new List<OriginDestinationOption1.FlightSegment1>();
                                    foreach (var item in item_1.FlightSegment)
                                    {
                                        int idx = 0;
                                        lstFlightSegment.Add(new OriginDestinationOption1.FlightSegment1
                                        {
                                            ArrivalDateTime = item.ArrivalDateTime,
                                            DepartureDateTime = item.DepartureDateTime,
                                            ElapsedTime = item.ElapsedTime,
                                            FlightNumber = item.FlightNumber,
                                            FlightSegmentId = idx,
                                            InOutBound = item.MarriageGrp,
                                            ResBookDesigCode = item.ResBookDesigCode,
                                            StopQuantity = item.StopQuantity,
                                            MarriageGrp = item.MarriageGrp,


                                            DepartureAirport = new List<OriginDestinationOption1.FlightSegment1.DepartureAirport1>()
                                        {
                                             new OriginDestinationOption1.FlightSegment1.DepartureAirport1
                                              {
                                                LocationCode = item.DepartureAirport.LocationCode,
                                                TerminalID = item.DepartureAirport.TerminalID ?? "",
                                                content = item.DepartureAirport.content,
                                                DepartureAirportCity = GetAirportCityName(dataSet.Tables[3],item.DepartureAirport.LocationCode)
                                              }
                                        },
                                            ArrivalAirport = new List<OriginDestinationOption1.FlightSegment1.ArrivalAirport1>()
                                        {
                                            new OriginDestinationOption1.FlightSegment1.ArrivalAirport1
                                            {
                                                LocationCode = item.ArrivalAirport.LocationCode,
                                                TerminalID = item.ArrivalAirport.TerminalID ?? "",
                                                content = item.ArrivalAirport.content,
                                                ArrivalAirportCity = GetAirportCityName(dataSet.Tables[3], item.ArrivalAirport.LocationCode)
                                            }
                                        },
                                            OperatingAirline = new List<OriginDestinationOption1.FlightSegment1.OperatingAirline1>()
                                        {
                                            new OriginDestinationOption1.FlightSegment1.OperatingAirline1
                                            {
                                                 Code = item.OperatingAirline.Code,
                                                 FlightNumber = item.OperatingAirline.FlightNumber,
                                                 content = item.OperatingAirline.content
                                            }
                                        },
                                            Equipment = new List<OriginDestinationOption1.FlightSegment1.Equipment1>()
                                        {
                                            new OriginDestinationOption1.FlightSegment1.Equipment1
                                            {
                                                 AirEquipType = item.Equipment[0].AirEquipType,
                                                 content = item.Equipment[0].content
                                            }
                                        },
                                            MarketingAirline = new List<OriginDestinationOption1.FlightSegment1.MarketingAirline1>()
                                        {
                                            new OriginDestinationOption1.FlightSegment1.MarketingAirline1
                                            {
                                                Code = item.MarketingAirline.Code,
                                                content = item.MarketingAirline.content,
                                                AirlineName = GetAirlineName(dataSet.Tables[0], item.MarketingAirline.Code)
                                            }
                                        },

                                            TPA_Extensions = new List<OriginDestinationOption1.FlightSegment1.TPA_Extensions1>()
                                        {
                                            new OriginDestinationOption1.FlightSegment1.TPA_Extensions1
                                            {
                                                 eTicket = new List<OriginDestinationOption1.FlightSegment1.TPA_Extensions1.ETicket1>()
                                                 {
                                                     new OriginDestinationOption1.FlightSegment1.TPA_Extensions1.ETicket1
                                                     {
                                                          Ind = item.TPA_Extensions.eTicket.Ind
                                                     }
                                                 }

                                            }
                                        }
                                        });
                                        objOriginDestinationOption1.FlightSegment = lstFlightSegment;
                                        idx++;
                                    }
                                    objOriginDestinationOptions1.OriginDestinationOption.Add(objOriginDestinationOption1);
                                }
                                objAirItinerary1.OriginDestinationOptions.Add(objOriginDestinationOptions1);
                                objPricedItinerary1.AirItinerary.Add(objAirItinerary1);

                                AirItineraryPricingInfo objAirItineraryPricingInfo1 = new AirItineraryPricingInfo();
                                /*=== Find lowest fare ===*/
                                double adtTotalFare = 0;
                                double adtAFTotalFare = 0;
                                double jcbTotalFare = 0;
                                double itxTotalFare = 0;
                                string passengerTypeQuantityCode = "ADT";
                                foreach (var item4 in item1.AirItineraryPricingInfo)
                                {
                                    foreach (var item5 in item4.PTC_FareBreakdowns.PTC_FareBreakdown)
                                    {
                                        if (item5.PassengerTypeQuantity.Code == "ADT")
                                        {
                                            adtTotalFare = item4.ItinTotalFare.TotalFare.Amount;
                                            adtAFTotalFare = 0;
                                            jcbTotalFare = 0;
                                            itxTotalFare = 0;
                                        }
                                    }
                                }
                                if (item1.TPA_Extensions != null)
                                {
                                    if (item1.TPA_Extensions.AdditionalFares != null && item1.TPA_Extensions.AdditionalFares.Count > 0)
                                    {
                                        foreach (var itemAF in item1.TPA_Extensions.AdditionalFares)
                                        {
                                            foreach (var itemAF1 in itemAF.AirItineraryPricingInfo.PTC_FareBreakdowns.PTC_FareBreakdown)
                                            {
                                                if (itemAF1.PassengerTypeQuantity.Code == "ADT")
                                                {
                                                    adtAFTotalFare = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount;
                                                    if (adtAFTotalFare < adtTotalFare)
                                                    {
                                                        adtTotalFare = adtAFTotalFare;
                                                        adtAFTotalFare = 0;
                                                    }
                                                    else
                                                    {
                                                        adtAFTotalFare = 0;
                                                    }
                                                    passengerTypeQuantityCode = "ADT";
                                                    jcbTotalFare = 0;
                                                    itxTotalFare = 0;
                                                }

                                                if (itemAF1.PassengerTypeQuantity.Code == "JCB")
                                                {
                                                    jcbTotalFare = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount;
                                                    if (jcbTotalFare < adtTotalFare)
                                                    {
                                                        adtTotalFare = 0;
                                                        passengerTypeQuantityCode = "JCB";
                                                    }
                                                    else
                                                    {
                                                        jcbTotalFare = 0;
                                                    }
                                                    itxTotalFare = 0;
                                                }
                                                if (itemAF1.PassengerTypeQuantity.Code == "ITX")
                                                {
                                                    itxTotalFare = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount;
                                                    if (adtTotalFare > 0 && jcbTotalFare == 0)
                                                    {
                                                        if (itxTotalFare < adtTotalFare)
                                                        {
                                                            adtTotalFare = 0;
                                                            jcbTotalFare = 0;
                                                            passengerTypeQuantityCode = "ITX";
                                                        }
                                                        else
                                                        {
                                                            itxTotalFare = 0;
                                                        }
                                                    }

                                                    if (jcbTotalFare > 0 && adtTotalFare == 0)
                                                    {
                                                        if (itxTotalFare < jcbTotalFare)
                                                        {
                                                            adtTotalFare = 0;
                                                            jcbTotalFare = 0;
                                                            passengerTypeQuantityCode = "ITX";
                                                        }
                                                        else
                                                        {
                                                            itxTotalFare = 0;
                                                        }
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }

                                /*=== End of find lowest fare ===*/
                                double infantDefaultFare = _defaultinfantfae;
                                if (adtTotalFare > 0)
                                {
                                    foreach (var item4 in item1.AirItineraryPricingInfo)
                                    {
                                        objAirItineraryPricingInfo1.LastTicketDate = item4.LastTicketDate;
                                        objAirItineraryPricingInfo1.PricingSource = item4.PricingSource;
                                        objAirItineraryPricingInfo1.PricingSubSource = item4.PricingSubSource;
                                        objAirItineraryPricingInfo1.FareReturned = item4.FareReturned;

                                        AirItineraryPricingInfo.ItinTotalFare1 objItinTotalFare1 = new AirItineraryPricingInfo.ItinTotalFare1();

                                        AirItineraryPricingInfo.ItinTotalFare1.EquivFare1 objEquivFare1 = new AirItineraryPricingInfo.ItinTotalFare1.EquivFare1
                                        {
                                            Amount = item4.ItinTotalFare.EquivFare.Amount,
                                            CurrencyCode = item4.ItinTotalFare.EquivFare.CurrencyCode,
                                            DecimalPlaces = item4.ItinTotalFare.EquivFare.DecimalPlaces
                                        };
                                        objItinTotalFare1.EquivFare.Add(objEquivFare1);
                                        AirItineraryPricingInfo.ItinTotalFare1.Taxes1 objTaxes1 = new AirItineraryPricingInfo.ItinTotalFare1.Taxes1();
                                        int txCont = item4.ItinTotalFare.Taxes.Tax.Count;
                                        for (int ix = 0; ix < txCont; ix++)
                                        {
                                            objTaxes1.Tax.Add(new AirItineraryPricingInfo.ItinTotalFare1.Taxes1.Tax1
                                            {
                                                TaxCode = item4.ItinTotalFare.Taxes.Tax[ix].TaxCode,
                                                Amount = item4.ItinTotalFare.Taxes.Tax[ix].Amount,
                                                CurrencyCode = item4.ItinTotalFare.Taxes.Tax[ix].CurrencyCode,
                                                DecimalPlaces = item4.ItinTotalFare.Taxes.Tax[ix].DecimalPlaces,
                                                content = item4.ItinTotalFare.Taxes.Tax[ix].content
                                            });
                                        }
                                        objItinTotalFare1.Taxes.Add(objTaxes1);
                                        AirItineraryPricingInfo.ItinTotalFare1.TotalFare1 objTotalFare1 = new AirItineraryPricingInfo.ItinTotalFare1.TotalFare1
                                        {
                                            Amount = item4.ItinTotalFare.TotalFare.Amount,
                                            CurrencyCode = item4.ItinTotalFare.TotalFare.CurrencyCode,
                                            DecimalPlaces = item4.ItinTotalFare.TotalFare.DecimalPlaces
                                        };
                                        objItinTotalFare1.TotalFare.Add(objTotalFare1);
                                        objAirItineraryPricingInfo1.ItinTotalFare.Add(objItinTotalFare1);

                                        PTC_FareBreakdowns objPTC_FareBreakdowns1 = new PTC_FareBreakdowns();
                                        PTC_FareBreakdowns.PTC_FareBreakdown1 objPTC_FareBreakdown1 = new PTC_FareBreakdowns.PTC_FareBreakdown1();
                                        foreach (var item5 in item4.PTC_FareBreakdowns.PTC_FareBreakdown)
                                        {
                                            PTC_FareBreakdowns.PTC_FareBreakdown1.PassengerTypeQuantity1 objPassengerTypeQuantity1 = new PTC_FareBreakdowns.PTC_FareBreakdown1.PassengerTypeQuantity1
                                            {
                                                Code = item5.PassengerTypeQuantity.Code,
                                                Quantity = item5.PassengerTypeQuantity.Quantity
                                            };
                                            objPTC_FareBreakdown1.PassengerTypeQuantity.Add(objPassengerTypeQuantity1);

                                            PassengerFare objPassengerFare = new PassengerFare();

                                            PassengerFare.EquivFare2 objEquivFare2 = new PassengerFare.EquivFare2
                                            {
                                                Amount = item5.PassengerFare.EquivFare.Amount,
                                                CurrencyCode = item5.PassengerFare.EquivFare.CurrencyCode,
                                                DecimalPlaces = item5.PassengerFare.EquivFare.DecimalPlaces,
                                                PassengerType = item5.PassengerTypeQuantity.Code
                                            };
                                            objPassengerFare.EquivFare.Add(objEquivFare2);

                                            PassengerFare.Taxes2 objTaxes2 = new PassengerFare.Taxes2();

                                            objPassengerFare.Taxes.Add(objTaxes2);
                                            if (item5.PassengerFare.Taxes != null)
                                            {
                                                PassengerFare.Taxes2.TotalTax1 objTotalTax1 = new PassengerFare.Taxes2.TotalTax1
                                                {
                                                    Amount = item5.PassengerFare.Taxes.TotalTax.Amount,
                                                    CurrencyCode = item5.PassengerFare.Taxes.TotalTax.CurrencyCode,
                                                    DecimalPlaces = item5.PassengerFare.Taxes.TotalTax.DecimalPlaces,
                                                    PassengerType = item5.PassengerTypeQuantity.Code
                                                };
                                                objTaxes2.TotalTax.Add(objTotalTax1);
                                                objPassengerFare.Taxes.Add(objTaxes2);
                                            }
                                            MarkupParameters markupParms = new MarkupParameters();
                                            if (item5.PassengerTypeQuantity.Code == "ADT")
                                            {
                                                //===  infantDefaultFare = item5.PassengerFare.TotalFare.Amount;
                                            }
                                            markupParms.PassengerFare = item5.PassengerFare.TotalFare.Amount == 0 ? infantDefaultFare : item5.PassengerFare.TotalFare.Amount;
                                            markupParms.PassengerQnty = item5.PassengerTypeQuantity.Quantity;
                                            markupParms.PassengerType = item5.PassengerTypeQuantity.Code;
                                            markupParms.AirlineCode = item1.TPA_Extensions.ValidatingCarrier.Code;
                                            markupParms.FareType = "PublishedFare";
                                            if (item5.PassengerTypeQuantity.Code == "INF")
                                            {
                                                markupParms.PassengerEquivFare = item5.PassengerFare.EquivFare.Amount == 0 ? infantDefaultFare : item5.PassengerFare.EquivFare.Amount;
                                            }
                                            else
                                            {
                                                markupParms.PassengerEquivFare = item5.PassengerFare.EquivFare.Amount;
                                            }
                                            markupParms.Markups = lstMarkups;
                                            markupParms.PassengerTotalTax = item5.PassengerFare.Taxes == null ? 0 : item5.PassengerFare.Taxes.TotalTax.Amount;

                                            PassengerFare.TotalFare2 objTotalFare2 = new PassengerFare.TotalFare2
                                            {
                                                Amount = item5.PassengerFare.TotalFare.Amount,
                                                CurrencyCode = item5.PassengerFare.TotalFare.CurrencyCode,
                                                PassengerType = item5.PassengerTypeQuantity.Code,
                                                MarkupParameters = GetMarkup(markupParms),
                                                FareParameters = GetFareParameters(dataSet.Tables[04])
                                            };
                                            objPassengerFare.TotalFare.Add(objTotalFare2);

                                            PassengerFare.PenaltiesInfo1 objPenaltiesInfo1 = new PassengerFare.PenaltiesInfo1();
                                            if (item5.PassengerFare.PenaltiesInfo != null)
                                            {
                                                foreach (var item7 in item5.PassengerFare.PenaltiesInfo.Penalty)
                                                {
                                                    objPenaltiesInfo1.Penalty.Add(new PassengerFare.PenaltiesInfo1.Penalty1
                                                    {
                                                        Type = item7.Type,
                                                        Applicability = item7.Applicability,
                                                        Changeable = item7.Changeable,
                                                        Amount = item7.Amount,
                                                        CurrencyCode = item7.CurrencyCode,
                                                        DecimalPlaces = item7.DecimalPlaces,
                                                        PassengerType = item5.PassengerTypeQuantity.Code
                                                    });
                                                }
                                                objPassengerFare.PenaltiesInfo.Add(objPenaltiesInfo1);
                                            }
                                            PassengerFare.TPA_Extensions2 objTPA_Extensions2 = new PassengerFare.TPA_Extensions2();
                                            PassengerFare.TPA_Extensions2.Messages1 objMessages1 = new PassengerFare.TPA_Extensions2.Messages1();
                                            foreach (var item8 in item5.PassengerFare.TPA_Extensions.Messages.Message)
                                            {
                                                objMessages1.Message.Add(new PassengerFare.TPA_Extensions2.Messages1.Message1
                                                {
                                                    Type = item8.Type,
                                                    AirlineCode = item8.AirlineCode ?? "",
                                                    FailCode = item8.FailCode,
                                                    Info = item8.Info,
                                                    PassengerType = item5.PassengerTypeQuantity.Code
                                                });
                                            }
                                            objTPA_Extensions2.Messages.Add(objMessages1);
                                            PassengerFare.TPA_Extensions2.BaggageInformationList1 objBaggageInformationList1 = new PassengerFare.TPA_Extensions2.BaggageInformationList1();
                                            PassengerFare.TPA_Extensions2.BaggageInformationList1.BaggageInformation1 objBaggageInformation1 = new PassengerFare.TPA_Extensions2.BaggageInformationList1.BaggageInformation1();
                                            if (item5.PassengerFare.TPA_Extensions.BaggageInformationList.BaggageInformation.Count > 0)
                                            {
                                                foreach (var item9 in item5.PassengerFare.TPA_Extensions.BaggageInformationList.BaggageInformation)
                                                {
                                                    objBaggageInformation1.AirlineCode = item9.AirlineCode;
                                                    objBaggageInformation1.ProvisionType = item9.ProvisionType;
                                                    objBaggageInformation1.PassengerType = item5.PassengerTypeQuantity.Code;
                                                    foreach (var item10 in item9.Segment)
                                                    {
                                                        objBaggageInformation1.Segment.Add(new PassengerFare.TPA_Extensions2.BaggageInformationList1.BaggageInformation1.Segment1
                                                        {
                                                            SegmentId = item10.Id,
                                                            PassengerType = item5.PassengerTypeQuantity.Code
                                                        });
                                                    }
                                                    foreach (var item11 in item9.Allowance)
                                                    {
                                                        objBaggageInformation1.Allowance.Add(new PassengerFare.TPA_Extensions2.BaggageInformationList1.BaggageInformation1.Allowance1
                                                        {
                                                            Pieces = item11.Pieces,
                                                            PassengerType = item5.PassengerTypeQuantity.Code
                                                        });
                                                    }
                                                }
                                            }
                                            objBaggageInformationList1.BaggageInformation.Add(objBaggageInformation1);
                                            objTPA_Extensions2.BaggageInformationList.Add(objBaggageInformationList1);

                                            objPassengerFare.TPA_Extensions.Add(objTPA_Extensions2);
                                            objPTC_FareBreakdown1.PassengerFare.Add(objPassengerFare);

                                            Endorsements objEndorsements1 = new Endorsements
                                            {
                                                NonRefundableIndicator = item5.Endorsements.NonRefundableIndicator,
                                                PassengerType = item5.PassengerTypeQuantity.Code
                                            };
                                            objPTC_FareBreakdown1.Endorsements.Add(objEndorsements1);
                                            TPA_Extensions3 objTPA_Extensions3 = new TPA_Extensions3();
                                            objTPA_Extensions3.FareCalcLine.Add(new TPA_Extensions3.FareCalcLine1
                                            {
                                                Info = item5.TPA_Extensions.FareCalcLine.Info,
                                                PassengerType = item5.PassengerTypeQuantity.Code
                                            });
                                            objPTC_FareBreakdown1.TPA_Extensions.Add(objTPA_Extensions3);
                                            if (item5.FareInfos.FareInfo.Count > 0)
                                            {
                                                FareInfos objFareInfos1 = new FareInfos();
                                                foreach (var item12 in item5.FareInfos.FareInfo)
                                                {
                                                    objFareInfos1.FareInfo.Add(new FareInfos.FareInfo1
                                                    {
                                                        FareReference = item12.FareReference,
                                                        PassengerType = item5.PassengerTypeQuantity.Code,
                                                        TPA_Extensions = new List<FareInfos.FareInfo1.TPA_Extensions4>()
                                                  {
                                                      new FareInfos.FareInfo1.TPA_Extensions4
                                                      {
                                                           SeatsRemaining = new List<FareInfos.FareInfo1.TPA_Extensions4.SeatsRemaining1>()
                                                           {
                                                               new FareInfos.FareInfo1.TPA_Extensions4.SeatsRemaining1
                                                               {
                                                                    Number = item12.TPA_Extensions.SeatsRemaining.Number,
                                                                    BelowMin = item12.TPA_Extensions.SeatsRemaining.BelowMin,
                                                                    PassengerType = item5.PassengerTypeQuantity.Code
                                                               }
                                                           },
                                                           Cabin = new List<FareInfos.FareInfo1.TPA_Extensions4.Cabin1>()
                                                           {
                                                               new FareInfos.FareInfo1.TPA_Extensions4.Cabin1
                                                               {
                                                                    Cabins = item12.TPA_Extensions.Cabin.Cabin,
                                                                    PassengerType = item5.PassengerTypeQuantity.Code
                                                               }
                                                           },
                                                                Meal = new List<FareInfos.FareInfo1.TPA_Extensions4.Meal1>()
                                                           {
                                                               new FareInfos.FareInfo1.TPA_Extensions4.Meal1
                                                               {
                                                                    Code = item12.TPA_Extensions.Meal != null ? item12.TPA_Extensions.Meal.Code : "",
                                                                    PassengerType = item5.PassengerTypeQuantity.Code
                                                               }
                                                           }
                                                      }
                                                  }
                                                    });
                                                }
                                                objPTC_FareBreakdown1.FareInfos.Add(objFareInfos1);
                                            }
                                        }
                                        objPTC_FareBreakdowns1.PTC_FareBreakdown.Add(objPTC_FareBreakdown1);
                                        objAirItineraryPricingInfo1.PTC_FareBreakdowns.Add(objPTC_FareBreakdowns1);

                                        AirItineraryPricingInfo.TPA_Extensions6 objTPA_Extensions6 = new AirItineraryPricingInfo.TPA_Extensions6();
                                        objTPA_Extensions6.DivideInParty.Add(new AirItineraryPricingInfo.TPA_Extensions6.DivideInParty1
                                        {
                                            Indicator = item4.TPA_Extensions.DivideInParty.Indicator
                                        });
                                        foreach (var item14 in item4.TPA_Extensions.ValidatingCarrier)
                                        {
                                            objTPA_Extensions6.ValidatingCarrier.Add(new AirItineraryPricingInfo.TPA_Extensions6.ValidatingCarrier1
                                            {
                                                SettlementMethod = item14.SettlementMethod,
                                                NewVcxProcess = item14.NewVcxProcess,
                                                Default = new List<AirItineraryPricingInfo.TPA_Extensions6.ValidatingCarrier1.Default1>()
                                         {
                                             new AirItineraryPricingInfo.TPA_Extensions6.ValidatingCarrier1.Default1
                                             {
                                                 Code = item14.Default.Code,
                                                 AirlineName = GetAirlineName(dataSet.Tables[0], item14.Default.Code)
                                             }
                                         }
                                            });
                                        }
                                        objAirItineraryPricingInfo1.TPA_Extensions.Add(objTPA_Extensions6);
                                    }
                                    objPricedItinerary1.AirItineraryPricingInfo.Add(objAirItineraryPricingInfo1);
                                }
                                TicketingInfo objTicketingInfo1 = new TicketingInfo
                                {
                                    TicketType = item1.TicketingInfo.TicketType,
                                    ValidInterline = item1.TicketingInfo.ValidInterline
                                };
                                objPricedItinerary1.TicketingInfo.Add(objTicketingInfo1);

                                if (item1.TPA_Extensions != null)
                                {
                                    if (item1.TPA_Extensions.AdditionalFares != null && item1.TPA_Extensions.AdditionalFares.Count > 0)
                                    {
                                        if (adtAFTotalFare > 0 || jcbTotalFare > 0 || itxTotalFare > 0)
                                        {
                                            string faretyp = string.Empty;
                                            if (adtAFTotalFare > 0)
                                            {
                                                faretyp = "ADT";
                                            }
                                            else if (jcbTotalFare > 0)
                                            {
                                                faretyp = "JCB";
                                            }
                                            else if (itxTotalFare > 0)
                                            {
                                                faretyp = "ITX";
                                            }

                                            TPA_Extensions7 objTPA_Extensions7 = new TPA_Extensions7();
                                            foreach (var itemAF in item1.TPA_Extensions.AdditionalFares)
                                            {
                                                if (faretyp == itemAF.AirItineraryPricingInfo.PTC_FareBreakdowns.PTC_FareBreakdown[0].PassengerTypeQuantity.Code)
                                                {
                                                    TPA_Extensions7.AdditionalFare1 objAdditionalFare1 = new TPA_Extensions7.AdditionalFare1();
                                                    AF_AirItineraryPricingInfo objAF_AirItineraryPricingInfo1 = new AF_AirItineraryPricingInfo();

                                                    objAF_AirItineraryPricingInfo1.LastTicketDate = itemAF.AirItineraryPricingInfo.LastTicketDate;
                                                    objAF_AirItineraryPricingInfo1.PricingSource = itemAF.AirItineraryPricingInfo.PricingSource;
                                                    objAF_AirItineraryPricingInfo1.PricingSubSource = itemAF.AirItineraryPricingInfo.PricingSubSource;
                                                    objAF_AirItineraryPricingInfo1.FareReturned = itemAF.AirItineraryPricingInfo.FareReturned;

                                                    AF_AirItineraryPricingInfo.AF_ItinTotalFare1 objAF_ItinTotalFare1 = new AF_AirItineraryPricingInfo.AF_ItinTotalFare1();

                                                    AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_EquivFare1 objAF_EquivFare1 = new AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_EquivFare1
                                                    {
                                                        Amount = itemAF.AirItineraryPricingInfo.ItinTotalFare.EquivFare.Amount,
                                                        CurrencyCode = itemAF.AirItineraryPricingInfo.ItinTotalFare.EquivFare.CurrencyCode,
                                                        DecimalPlaces = itemAF.AirItineraryPricingInfo.ItinTotalFare.EquivFare.DecimalPlaces
                                                    };
                                                    objAF_ItinTotalFare1.EquivFare.Add(objAF_EquivFare1);

                                                    AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_Taxes1 objAF_Taxes1 = new AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_Taxes1();
                                                    int txCont = 0;
                                                    if (itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes != null)
                                                    {
                                                        txCont = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax.Count;
                                                    }
                                                    for (int ix = 0; ix < txCont; ix++)
                                                    {
                                                        objAF_Taxes1.Tax.Add(new AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_Taxes1.AF_Tax1
                                                        {
                                                            TaxCode = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax[ix].TaxCode,
                                                            Amount = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax[ix].Amount,
                                                            CurrencyCode = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax[ix].CurrencyCode,
                                                            DecimalPlaces = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax[ix].DecimalPlaces,
                                                            content = itemAF.AirItineraryPricingInfo.ItinTotalFare.Taxes.Tax[ix].content
                                                        });
                                                    }
                                                    objAF_ItinTotalFare1.Taxes.Add(objAF_Taxes1);

                                                    AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_TotalFare1 objAF_TotalFare1 = new AF_AirItineraryPricingInfo.AF_ItinTotalFare1.AF_TotalFare1
                                                    {
                                                        Amount = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.Amount,
                                                        CurrencyCode = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.CurrencyCode,
                                                        DecimalPlaces = itemAF.AirItineraryPricingInfo.ItinTotalFare.TotalFare.DecimalPlaces
                                                    };
                                                    objAF_ItinTotalFare1.TotalFare.Add(objAF_TotalFare1);
                                                    objAF_AirItineraryPricingInfo1.ItinTotalFare.Add(objAF_ItinTotalFare1);

                                                    AF_PTC_FareBreakdowns objAF_PTC_FareBreakdowns1 = new AF_PTC_FareBreakdowns();
                                                    AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1 objAF_PTC_FareBreakdown1 = new AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1();
                                                    foreach (var itemAF1 in itemAF.AirItineraryPricingInfo.PTC_FareBreakdowns.PTC_FareBreakdown)
                                                    {
                                                        if (itemAF.AirItineraryPricingInfo.PTC_FareBreakdowns.PTC_FareBreakdown[0].PassengerTypeQuantity.Code == passengerTypeQuantityCode)
                                                        {
                                                            AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1.AF_PassengerTypeQuantity1 objAF_PassengerTypeQuantity1 = new AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1.AF_PassengerTypeQuantity1
                                                            {
                                                                Code = itemAF1.PassengerTypeQuantity.Code,
                                                                Quantity = itemAF1.PassengerTypeQuantity.Quantity
                                                            };
                                                            objAF_PTC_FareBreakdown1.PassengerTypeQuantity.Add(objAF_PassengerTypeQuantity1);
                                                            AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1.AF_FareBasisCodes1 objAF_FareBasisCodes1 = new AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1.AF_FareBasisCodes1();
                                                            foreach (var itemAF2 in itemAF1.FareBasisCodes.FareBasisCode)
                                                            {
                                                                objAF_FareBasisCodes1.FareBasisCode.Add(new AF_PTC_FareBreakdowns.AF_PTC_FareBreakdown1.AF_FareBasisCodes1.AF_FareBasisCode1
                                                                {
                                                                    BookingCode = itemAF2.BookingCode,
                                                                    DepartureAirportCode = itemAF2.DepartureAirportCode,
                                                                    ArrivalAirportCode = itemAF2.ArrivalAirportCode,
                                                                    FareComponentBeginAirport = itemAF2.FareComponentBeginAirport,
                                                                    FareComponentEndAirport = itemAF2.FareComponentEndAirport,
                                                                    FareComponentDirectionality = itemAF2.FareComponentDirectionality,
                                                                    FareComponentVendorCode = itemAF2.FareComponentVendorCode,
                                                                    GovCarrier = itemAF2.GovCarrier,
                                                                    content = itemAF2.content,
                                                                    AvailabilityBreak = itemAF2.AvailabilityBreak ?? false,
                                                                    PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                                });
                                                            }
                                                            objAF_PTC_FareBreakdown1.FareBasisCodes.Add(objAF_FareBasisCodes1);

                                                            AF_PassengerFare objAF_PassengerFare = new AF_PassengerFare();

                                                            AF_PassengerFare.AF_EquivFare2 objAF_EquivFare2 = new AF_PassengerFare.AF_EquivFare2
                                                            {
                                                                Amount = itemAF1.PassengerFare.EquivFare.Amount,
                                                                CurrencyCode = itemAF1.PassengerFare.EquivFare.CurrencyCode,
                                                                DecimalPlaces = itemAF1.PassengerFare.EquivFare.DecimalPlaces,
                                                                PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                            };
                                                            objAF_PassengerFare.EquivFare.Add(objAF_EquivFare2);

                                                            AF_PassengerFare.AF_Taxes2 objAF_Taxes2 = new AF_PassengerFare.AF_Taxes2();

                                                            if (itemAF1.PassengerFare.Taxes != null)
                                                            {
                                                                AF_PassengerFare.AF_Taxes2.AF_TotalTax1 objAF_TotalTax1 = new AF_PassengerFare.AF_Taxes2.AF_TotalTax1
                                                                {
                                                                    Amount = itemAF1.PassengerFare.Taxes.TotalTax.Amount,
                                                                    CurrencyCode = itemAF1.PassengerFare.Taxes.TotalTax.CurrencyCode,
                                                                    DecimalPlaces = itemAF1.PassengerFare.Taxes.TotalTax.DecimalPlaces,
                                                                    PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                                };
                                                                objAF_Taxes2.TotalTax.Add(objAF_TotalTax1);
                                                            }
                                                            objAF_PassengerFare.Taxes.Add(objAF_Taxes2);
                                                            MarkupParameters markupParms = new MarkupParameters();

                                                            markupParms.PassengerFare = itemAF1.PassengerFare.TotalFare.Amount == 0 ? infantDefaultFare : itemAF1.PassengerFare.TotalFare.Amount;
                                                            markupParms.PassengerQnty = itemAF1.PassengerTypeQuantity.Quantity;
                                                            markupParms.PassengerType = itemAF1.PassengerTypeQuantity.Code;
                                                            markupParms.AirlineCode = item1.TPA_Extensions.ValidatingCarrier.Code;
                                                            if (itemAF1.PassengerTypeQuantity.Code == "101" || itemAF1.PassengerTypeQuantity.Code == "JNF")
                                                            {
                                                                markupParms.PassengerEquivFare = itemAF1.PassengerFare.TotalFare.Amount == 0 ? infantDefaultFare : itemAF1.PassengerFare.TotalFare.Amount;
                                                            }
                                                            else
                                                            {
                                                                markupParms.PassengerEquivFare = itemAF1.PassengerFare.TotalFare.Amount;
                                                            }

                                                            markupParms.Markups = lstMarkups;
                                                            string markuptype = string.Empty;
                                                            if (passengerTypeQuantityCode == "ADT")
                                                            {
                                                                markuptype = "PublishedFare";
                                                            }
                                                            else if (passengerTypeQuantityCode == "JCB")
                                                            {
                                                                markuptype = "NetFare";
                                                            }
                                                            else
                                                            {
                                                                markuptype = "TourNetFare";
                                                            }
                                                            markupParms.FareType = markuptype;
                                                            markupParms.PassengerEquivFare = itemAF1.PassengerFare.EquivFare.Amount;
                                                            markupParms.PassengerTotalTax = itemAF1.PassengerFare.Taxes.TotalTax.Amount;

                                                            AF_PassengerFare.AF_TotalFare2 objAF_TotalFare2 = new AF_PassengerFare.AF_TotalFare2
                                                            {
                                                                Amount = itemAF1.PassengerFare.TotalFare.Amount,
                                                                CurrencyCode = itemAF1.PassengerFare.TotalFare.CurrencyCode,
                                                                PassengerType = itemAF1.PassengerTypeQuantity.Code,
                                                                MarkupParameters = GetMarkup(markupParms),
                                                                FareParameters = GetFareParameters(dataSet.Tables[04])
                                                            };
                                                            objAF_PassengerFare.TotalFare.Add(objAF_TotalFare2);

                                                            AF_PassengerFare.AF_TPA_Extensions2 objAF_TPA_Extensions2 = new AF_PassengerFare.AF_TPA_Extensions2();
                                                            AF_PassengerFare.AF_TPA_Extensions2.AF_Messages1 objAF_Messages1 = new AF_PassengerFare.AF_TPA_Extensions2.AF_Messages1();
                                                            foreach (var item8 in itemAF1.PassengerFare.TPA_Extensions.Messages.Message)
                                                            {
                                                                objAF_Messages1.Message.Add(new AF_PassengerFare.AF_TPA_Extensions2.AF_Messages1.AF_Message1
                                                                {
                                                                    Type = item8.Type,
                                                                    AirlineCode = item8.AirlineCode ?? "",
                                                                    FailCode = item8.FailCode,
                                                                    Info = item8.Info,
                                                                    PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                                });
                                                            }
                                                            objAF_TPA_Extensions2.Messages.Add(objAF_Messages1);
                                                            AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1 objAF_BaggageInformationList1 = new AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1();
                                                            AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1.AF_BaggageInformation1 objAF_BaggageInformation1 = new AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1.AF_BaggageInformation1();

                                                            foreach (var item9 in itemAF1.PassengerFare.TPA_Extensions.BaggageInformationList.BaggageInformation)
                                                            {
                                                                objAF_BaggageInformation1.AirlineCode = item9.AirlineCode;
                                                                objAF_BaggageInformation1.ProvisionType = item9.ProvisionType;
                                                                objAF_BaggageInformation1.PassengerType = itemAF1.PassengerTypeQuantity.Code;
                                                                foreach (var item10 in item9.Segment)
                                                                {
                                                                    objAF_BaggageInformation1.Segment.Add(new AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1.AF_BaggageInformation1.AF_Segment1
                                                                    {
                                                                        SegmentId = item10.Id,
                                                                        PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                                    });
                                                                }
                                                                foreach (var item11 in item9.Allowance)
                                                                {
                                                                    objAF_BaggageInformation1.Allowance.Add(new AF_PassengerFare.AF_TPA_Extensions2.AF_BaggageInformationList1.AF_BaggageInformation1.AF_Allowance1
                                                                    {
                                                                        Pieces = item11.Pieces,
                                                                        PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                                    });
                                                                }
                                                            }
                                                            objAF_BaggageInformationList1.BaggageInformation.Add(objAF_BaggageInformation1);
                                                            objAF_TPA_Extensions2.BaggageInformationList.Add(objAF_BaggageInformationList1);

                                                            objAF_PassengerFare.TPA_Extensions.Add(objAF_TPA_Extensions2);
                                                            objAF_PTC_FareBreakdown1.PassengerFare.Add(objAF_PassengerFare);

                                                            AF_Endorsements objAF_Endorsements1 = new AF_Endorsements
                                                            {
                                                                NonRefundableIndicator = itemAF1.Endorsements.NonRefundableIndicator,
                                                                PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                            };
                                                            objAF_PTC_FareBreakdown1.Endorsements.Add(objAF_Endorsements1);
                                                            AF_TPA_Extensions3 objAF_TPA_Extensions3 = new AF_TPA_Extensions3();
                                                            objAF_TPA_Extensions3.FareCalcLine.Add(new AF_TPA_Extensions3.AF_FareCalcLine1
                                                            {
                                                                Info = itemAF1.TPA_Extensions.FareCalcLine.Info,
                                                                PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                            });
                                                            objAF_PTC_FareBreakdown1.TPA_Extensions.Add(objAF_TPA_Extensions3);
                                                            if (itemAF1.FareInfos.FareInfo.Count > 0)
                                                            {
                                                                AF_FareInfos objAF_FareInfos1 = new AF_FareInfos();
                                                                foreach (var item12 in itemAF1.FareInfos.FareInfo)
                                                                {

                                                                    objAF_FareInfos1.FareInfo.Add(new AF_FareInfos.AF_FareInfo1
                                                                    {
                                                                        FareReference = item12.FareReference,
                                                                        PassengerType = itemAF1.PassengerTypeQuantity.Code,
                                                                        TPA_Extensions = new List<AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4>()
                                                  {
                                                      new AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4
                                                      {
                                                           SeatsRemaining = new List<AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_SeatsRemaining1>()
                                                           {
                                                               new AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_SeatsRemaining1
                                                               {
                                                                    Number = item12.TPA_Extensions.SeatsRemaining.Number,
                                                                    BelowMin = item12.TPA_Extensions.SeatsRemaining.BelowMin,
                                                                    PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                               }
                                                           },
                                                           Cabin = new List<AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_Cabin1>()
                                                           {
                                                               new AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_Cabin1
                                                               {
                                                                    Cabins = item12.TPA_Extensions.Cabin.Cabin,
                                                                    PassengerType = _requestId + "-" + itemAF1.PassengerTypeQuantity.Code
                                                               }
                                                           },
                                                                Meal = new List<AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_Meal1>()
                                                           {
                                                               new AF_FareInfos.AF_FareInfo1.AF_TPA_Extensions4.AF_Meal1
                                                               {
                                                                    Code = item12.TPA_Extensions.Meal != null ? item12.TPA_Extensions.Meal.Code : "",
                                                                    PassengerType = itemAF1.PassengerTypeQuantity.Code
                                                               }
                                                           }
                                                      }
                                                  }
                                                                    });
                                                                }
                                                                objAF_PTC_FareBreakdown1.FareInfos.Add(objAF_FareInfos1);
                                                            }
                                                        }
                                                    }
                                                    objAF_PTC_FareBreakdowns1.PTC_FareBreakdown.Add(objAF_PTC_FareBreakdown1);
                                                    objAF_AirItineraryPricingInfo1.PTC_FareBreakdowns.Add(objAF_PTC_FareBreakdowns1);

                                                    AF_AirItineraryPricingInfo.AF_TPA_Extensions6 objAF_TPA_Extensions6 = new AF_AirItineraryPricingInfo.AF_TPA_Extensions6();
                                                    objAF_TPA_Extensions6.DivideInParty.Add(new AF_AirItineraryPricingInfo.AF_TPA_Extensions6.AF_DivideInParty1
                                                    {
                                                        Indicator = itemAF.AirItineraryPricingInfo.TPA_Extensions.DivideInParty.Indicator
                                                    });
                                                    foreach (var itemAF4 in itemAF.AirItineraryPricingInfo.TPA_Extensions.ValidatingCarrier)
                                                    {
                                                        objAF_TPA_Extensions6.ValidatingCarrier.Add(new AF_AirItineraryPricingInfo.AF_TPA_Extensions6.AF_ValidatingCarrier1
                                                        {
                                                            SettlementMethod = itemAF4.SettlementMethod,
                                                            NewVcxProcess = itemAF4.NewVcxProcess,
                                                            Default = new List<AF_AirItineraryPricingInfo.AF_TPA_Extensions6.AF_ValidatingCarrier1.AF_Default1>()
                                         {
                                             new AF_AirItineraryPricingInfo.AF_TPA_Extensions6.AF_ValidatingCarrier1.AF_Default1
                                             {
                                                 Code = itemAF4.Default.Code,
                                                 AirlineName = GetAirlineName(dataSet.Tables[0], itemAF4.Default.Code)
                                             }
                                          }
                                                        });
                                                    }
                                                    objAF_AirItineraryPricingInfo1.TPA_Extensions.Add(objAF_TPA_Extensions6);
                                                    objAdditionalFare1.AirItineraryPricingInfo.Add(objAF_AirItineraryPricingInfo1);
                                                    objTPA_Extensions7.AdditionalFares.Add(objAdditionalFare1);

                                                    TPA_Extensions7.AF_ValidatingCarrier2 objAF_ValidatingCarrier2 = new TPA_Extensions7.AF_ValidatingCarrier2
                                                    {
                                                        Code = item1.TPA_Extensions.ValidatingCarrier.Code
                                                    };
                                                    objTPA_Extensions7.ValidatingCarrier.Add(objAF_ValidatingCarrier2);
                                                    TPA_Extensions7.AF_DiversitySwapper1 AF_DiversitySwapper1 = new TPA_Extensions7.AF_DiversitySwapper1
                                                    {
                                                        WeighedPriceAmount = item1.TPA_Extensions.DiversitySwapper.WeighedPriceAmount
                                                    };
                                                    objTPA_Extensions7.DiversitySwapper.Add(AF_DiversitySwapper1);
                                                }
                                            }

                                            objPricedItinerary1.TPA_Extensions.Add(objTPA_Extensions7);
                                        }

                                    }
                                }
                                objPricedItineraries1.PricedItinerary.Add(objPricedItinerary1);

                            }
                            i++;
                            objOTA.PricedItineraries.Add(objPricedItineraries1);
                        }

                    }
                }
                filteredSearchResponse.OTA_AirLowFareSearchRS.Add(objOTA);
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Types.ProjectNames.HttpServices.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            procstime.EndTime = DateTime.Now.ToString();
            lstprocstime.Add(procstime);
            Task.Run(() => {
               SaveData sd = new SaveData();
                sd.AddProcessingTimes(lstprocstime);
            });
            return filteredSearchResponse;
        }
        #region Private Functions
        private DataSet GetDbData(string _domainname, int _userid, int _defaultcompanyid, int _userroleid)
        {
            DataSet ds = new DataSet();
            try
            {
                BOL.GetSetData.FareRules objBOL = new BOL.GetSetData.FareRules();
                List<Models.DTO.Parameter> lstParms = new List<Models.DTO.Parameter>();
                lstParms.Add(new Models.DTO.Parameter
                {
                    Name = "DomainName",
                    Value = _domainname,
                    TypeOfData = Models.DTO.Types.DataTypes.String.ToString()
                });
                lstParms.Add(new Models.DTO.Parameter
                {
                    Name = "UserId",
                    Value = _userid,
                    TypeOfData = Models.DTO.Types.DataTypes.Int.ToString()
                });
                lstParms.Add(new Models.DTO.Parameter
                {
                    Name = "DefaultCompanyId",
                    Value = _defaultcompanyid,
                    TypeOfData = Models.DTO.Types.DataTypes.Int.ToString()
                });

                lstParms.Add(new Models.DTO.Parameter
                {
                    Name = "UserRoleId",
                    Value = _userroleid,
                    TypeOfData = Models.DTO.Types.DataTypes.Int.ToString()
                });
                objBOL.Parameters = lstParms;
                ds = objBOL.GetDbDataCollections();
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }

            return ds;
        }

        private List<Markups> GetMarkups(DataTable _dt)
        {
            List<Markups> listMarkups = new List<Markups>();
            try
            {
                if (_dt.Rows.Count > 0)
                {
                        foreach (DataRow row in _dt.Rows)
                        {
                            listMarkups.Add(new Markups
                            {
                                CompanyId = Convert.ToInt32(row["CompanyId"]),
                                CompanyTypeId = Convert.ToInt32(row["CompanyTypeId"]),
                                NetFareMarkup = Convert.ToDouble(row["NetFareMarkup"]),
                                PublishedFareMarkup = Convert.ToDouble(row["PublishedFareMarkup"]),
                                TourNetFareMarkup = Convert.ToDouble(row["TourNets"]),
                                IATACode = row["IATACode"].ToString(),
                                WebSiteUrl = row["WebsiteURL"].ToString(),
                                MarkupType = row["PublishedMarkupType"].ToString()
                            });
                        }

                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }

            return listMarkups;
        }
        private List<Models.DTO.BlockedAirlines> GetBlockedAirlines(DataTable _dt)
        {
            List<Models.DTO.BlockedAirlines> lstBlockedAL = new List<BlockedAirlines>();
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        lstBlockedAL.Add(new Models.DTO.BlockedAirlines
                        {
                            IATACode = row["IATACode"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            return lstBlockedAL;
        }
        private string GetAirlineName(DataTable _dt, string _iatacode)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        if(row["airlinecode"].ToString().ToLower() == _iatacode.ToLower())
                        {
                            return row["airlinename"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            return string.Empty;
        }
        private string GetAirportCityName(DataTable _dt, string _iatacode)
        {
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        if (row["IATACode"].ToString().ToLower() == _iatacode.ToLower())
                        {
                            return row["City"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            return string.Empty;
        }
        
        private MarkupParameters GetMarkup(MarkupParameters _markupParameters)
        {
            MarkupParameters markupParms = new MarkupParameters();
            double serviceFee = 0;
            double commission = 0;
            double markupVal = 0;
            double perpassengermarkup = 0;
            string markuptype = "Value";
            bool isAirlineMatched = false;
            try
            {
                if (_markupParameters.Markups.Count > 0)
                {
                    foreach (var item in _markupParameters.Markups)
                    {
                        if (item.IATACode == _markupParameters.AirlineCode)
                        {
                            if (_markupParameters.FareType == "PublishedFare")
                            {
                                markupVal = item.PublishedFareMarkup;
                            }
                            else if (_markupParameters.FareType == "NetFare")
                            {
                                markupVal = item.NetFareMarkup;
                            }
                            else if (_markupParameters.FareType == "TourNetFare")
                            {
                                markupVal = item.TourNetFareMarkup;
                            }
                            if (item.MarkupType.ToLower() == "value")
                            {
                                if (markupVal > 0)
                                {
                                    serviceFee += markupVal * _markupParameters.PassengerQnty;
                                    perpassengermarkup = markupVal;
                                }
                                else if (markupVal < 0)
                                {
                                    commission += markupVal * _markupParameters.PassengerQnty;
                                }
                            }
                            else
                            {
                                if (markupVal > 0)
                                {
                                    serviceFee += (_markupParameters.PassengerFare * _markupParameters.PassengerQnty * markupVal) / 100;
                                    perpassengermarkup = (_markupParameters.PassengerFare * 1 * markupVal) / 100;
                                }
                                else if (markupVal < 0)
                                {
                                    commission += (_markupParameters.PassengerFare * _markupParameters.PassengerQnty * markupVal) / 100; ;
                                }
                                markuptype = "Percentage";
                            }
                            isAirlineMatched = true;
                        }
                    }
                    if (isAirlineMatched == false)
                    {
                        foreach (var item1 in _markupParameters.Markups)
                        {
                            if (item1.IATACode.ToLower() == "stdparent" || item1.IATACode.ToLower() == "stdmember")
                            {
                                if (_markupParameters.FareType == "PublishedFare")
                                {
                                    markupVal = item1.PublishedFareMarkup;
                                }
                                else if (_markupParameters.FareType == "NetFare")
                                {
                                    markupVal = item1.NetFareMarkup;
                                }
                                else if (_markupParameters.FareType == "TourNetFare")
                                {
                                    markupVal = item1.TourNetFareMarkup;
                                }

                                if (item1.MarkupType.ToLower() == "value")
                                {
                                    if (markupVal > 0)
                                    {
                                        serviceFee += markupVal * _markupParameters.PassengerQnty;
                                        perpassengermarkup = markupVal;
                                    }
                                    else if (markupVal < 0)
                                    {
                                        commission += markupVal * _markupParameters.PassengerQnty;
                                    }
                                }
                                else
                                {
                                    if (markupVal > 0)
                                    {
                                        serviceFee += (_markupParameters.PassengerFare * _markupParameters.PassengerQnty * markupVal) / 100;
                                        perpassengermarkup = (_markupParameters.PassengerFare * 1 * markupVal) / 100;
                                    }
                                    else if (markupVal < 0)
                                    {
                                        commission += (_markupParameters.PassengerFare * _markupParameters.PassengerQnty * markupVal) / 100; ;
                                    }
                                    markuptype = "Percentage";
                                }
                            }
                        }
                    }
                    markupParms.ServiceFee = serviceFee;
                    markupParms.Commission = commission;
                    markupParms.AirlineCode = _markupParameters.AirlineCode;
                    markupParms.FareType = _markupParameters.FareType;
                    markupParms.Markups = null;
                    markupParms.PassengerFare = _markupParameters.PassengerFare * _markupParameters.PassengerQnty;
                    markupParms.PassengerQnty = _markupParameters.PassengerQnty;
                    markupParms.PassengerType = _markupParameters.PassengerType;
                    markupParms.FareDetails.Add(new FareDetails
                    {
                        TotalPrice = (_markupParameters.PassengerFare * _markupParameters.PassengerQnty) + serviceFee,
                        PerPassengerFare = _markupParameters.PassengerEquivFare + _markupParameters.PassengerTotalTax + perpassengermarkup,
                        NumberOfPassenger = _markupParameters.PassengerQnty,
                        BaseFare = _markupParameters.PassengerEquivFare,
                        Taxes = _markupParameters.PassengerTotalTax,
                        FareType = _markupParameters.FareType,
                        MarkupType = markuptype,
                        PassengerType = _markupParameters.PassengerType,
                        PerPassengerMarkup = perpassengermarkup
                    });
                    return markupParms;
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }

            return markupParms;
        }
        private FareSettingsParameters GetFareParameters(DataTable _dt)
        {
            FareSettingsParameters fparms = new FareSettingsParameters();
            try
            {
                if (_dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        fparms.CCEnableAir = Convert.ToBoolean(row["CCEnableAir"]);
                        fparms.StandardPublishedMarkup = Convert.ToDouble(row["StandardPublishedMarkup"]);
                        fparms.StandardTourNetMarkup = Convert.ToDouble(row["StandardTourNetMarkup"]);
                        fparms.StandardNetMarkup = Convert.ToDouble(row["StandardNetMarkup"]);
                        fparms.InfantFare = Convert.ToDouble(row["InfantFare"]);
                        fparms.IsAveragefare = Convert.ToBoolean(row["IsAveragefare"]);
                        fparms.IsChangeCancelDisplay = Convert.ToBoolean(row["IsChangeCancelDisplay"]);
                    }
                }
            }
            catch (Exception ex)
            {
                BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                {
                    Exception = ex,
                    ProjectName = Models.DTO.Types.ProjectNames.DataAccessLayer.ToString(),
                    SolutionName = "AirSolutions"
                };
                objDbErr.AddErrorLog();
            }
            return fparms;
        }
        private string FormatDateExcludeTime(string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
                return string.Empty;

            DateTime dateTime = default(DateTime);
            DateTime.TryParse(datetime, out dateTime);
            return dateTime.ToString("dddd, dd MMMM yyyy");
        }
        private string FormatDate(string datetime)
        {
            if (string.IsNullOrEmpty(datetime))
                return string.Empty;

            DateTime dateTime = default(DateTime);
            DateTime.TryParse(datetime, out dateTime);
            return dateTime.ToString("dddd, dd MMMM yyyy hh:mm:ss");
        }
        #endregion
    }
}