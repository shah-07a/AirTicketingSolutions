using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using MDL = Models.DTO;

namespace DataAccessLayer.DataModel.DbModels.GetSetData
{
    public static class CompanyDetails
    {
        static CompanyDetails()
        {

        }

        public static MDL.CompanyDetails GetCompanyDetails(List<MDL.Parameter> _parameters)
        {
            SqlHelpers.ExecuteReader er = new SqlHelpers.ExecuteReader();
            MDL.CompanyDetails cd = new MDL.CompanyDetails();
            
            using (DataSet ds = er.CallStoredProcedure("usp_GetCompanyDetailsFromView", _parameters, "Conn_CommonDB"))
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            cd.Id = Convert.ToInt32(row["id"]);
                            cd.WebsiteUrl = row["WebsiteURL"].ToString();
                            cd.Name = row["Name"].ToString();
                            cd.CityName = row["CityName"].ToString();
                            cd.Country = row["country"].ToString();
                            cd.PostalCode = row["PostalCode"].ToString();
                            cd.State = row["state"].ToString();
                            cd.StreetAddress = row["StreetAddress"].ToString();
                            cd.CompanyType = row["CompanyType"].ToString();
                            cd.HeaderUrl = row["HeaderURL"].ToString();
                            cd.FooterUrl = row["FooterURL"].ToString();
                            cd.PrivacyUrl = row["PrivacyUrl"].ToString();
                            cd.TermsUrl = row["TermsUrl"].ToString();
                            cd.PhoneNumber = row["PhoneNumber"].ToString();
                            cd.UserName = row["UserName"].ToString();
                            cd.Password = row["Password"].ToString();
                            cd.QueueNo = row["QueueNo"].ToString();
                            cd.PseudoCityCode = row["PseudoCityCode"].ToString();
                            cd.FromEmail = row["FromEmail"].ToString();
                            cd.ToEmail = row["ToEmail"].ToString();
                            cd.Domain = row["Domain"].ToString();
                            cd.CurrencyCode = row["CurrencyCode"].ToString();
                            cd.CompanyTypeId = Convert.ToInt32(row["CompanyTypeId"]);
                            cd.FaviconUrl = row["FaviconUrl"].ToString();
                            cd.IsAir = Convert.ToBoolean(row["Air"]);
                            cd.IsHotel = Convert.ToBoolean(row["Hotel"]);
                            cd.IsCarRental = Convert.ToBoolean(row["CarRental"]);
                            cd.IsInsurance = Convert.ToBoolean(row["Insurance"]);
                            cd.IsPublishedInclude = Convert.ToBoolean(row["IsPublishedInclude"]);
                            cd.IsNetInclude = Convert.ToBoolean(row["IsNetInclude"]);
                            cd.IsTourNetInclude = Convert.ToBoolean(row["IsTourNetInclude"]);
                            cd.EmailCC = row["EmailCC"].ToString();
                            cd.EmailBCC = row["EmailBCC"].ToString();
                            cd.QueuePlacePcc = row["QueuePlacePcc"].ToString();
                            cd.QueuePlaceQueueNo = row["QueuePlaceQueueNo"].ToString();
                            cd.DKNumber = row["Dk_Number"].ToString();
                            cd.DefaultInfantFare = (float)Convert.ToInt32(row["InfantFare"]);
                            cd.AdvancePurchaseDays = Convert.ToInt32(row["AdvancePurchase"]);
                            cd.AutoCancelledTime = row["AutocancelledTime"].ToString();
                            cd.IsAverageFare = Convert.ToBoolean(row["IsAverageFare"]);
                            cd.IsChangeCancelDisplay = Convert.ToBoolean(row["IsChangeCancelDisplay"]);
                            cd.NumberOfMonths = Convert.ToInt32(row["NumberOfMonths"]);
                            cd.IsDisCouponDisplay = Convert.ToBoolean(row["IsDisCouponDisplay"]);
                            cd.IsEnable = Convert.ToBoolean(row["Enable"]);
                        }
                    }
                    if (ds.Tables.Count > 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            foreach (DataRow row in ds.Tables[1].Rows)
                            {
                                cd.LoggedInUser.Id = Convert.ToInt32(row["Id"]);
                                cd.LoggedInUser.FirstName = row["FirstName"].ToString();
                                cd.LoggedInUser.LastName = row["LastName"].ToString();
                                cd.LoggedInUser.EmailId = row["EmailAddress"].ToString();
                                cd.LoggedInUser.CompanyId = Convert.ToInt32(row["CompanyDetailId"]);
                                cd.LoggedInUser.UserRoleId = Convert.ToInt32(row["UserRoleId"]);
                            }
                        }
                    }
                    else
                    {
                        cd.LoggedInUser.Id = 0;
                        cd.LoggedInUser.FirstName = string.Empty;
                        cd.LoggedInUser.LastName = string.Empty;
                        cd.LoggedInUser.EmailId = string.Empty;
                        cd.LoggedInUser.CompanyId = 0;
                        cd.LoggedInUser.UserRoleId = 0;
                    }
                }

            }
            return cd;
   
        }
    }
}
