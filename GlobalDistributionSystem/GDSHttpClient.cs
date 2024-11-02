using Models.Common;
using Models.DTO;
using System;
using System.Net;
using BOL = BusinessObjectLayer;

namespace GlobalDistributionSystem
{
    public class GDSHttpClient
    {
        public CommonUtility PostAsync(string strUrl, string requestContent, string RequestId, string authtoken)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            CommonUtility Utility = new CommonUtility();
            Utility.Data = authtoken;
            dynamic RequestRespanceData = null;
            string reqSendTime = string.Empty;
            string resGetTime = string.Empty;

            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    reqSendTime = DateTime.Now.ToString();
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Add("Cache-control", "no-cache");
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Utility.Data);
                    System.Net.Http.HttpContent content = new System.Net.Http.StringContent(requestContent, System.Text.Encoding.UTF8, "application/json");
                    RequestRespanceData = httpClient.PostAsync(strUrl, content).Result;
                    resGetTime = DateTime.Now.ToString();
                    if (RequestRespanceData.IsSuccessStatusCode)
                    {
                        var RespanceResult = RequestRespanceData.Content.ReadAsStringAsync();
                        Utility = new CommonUtility()
                        {
                            Data = RespanceResult,
                            Data1 = RequestId,
                            ActionType = "Post",
                            Message = "HttpClient postAsync excuted successfully",
                            Status = true,
                            RequestPostTime = reqSendTime,
                            ResponseGetTime = resGetTime
                        };
                       
                    }
                    else
                    {
                        Utility = new CommonUtility()
                        {
                            Data= RequestRespanceData,
                            Data1 = RequestId,
                            ActionType = "Post",
                            Message = "HttpClient postAsync excution Returned False Status Code",
                            Status = false,
                            RequestPostTime = reqSendTime,
                            ResponseGetTime = resGetTime
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                
                    BOL.DbErrorLogs objDbErr = new BOL.DbErrorLogs
                    {
                        Exception = ex,
                        ProjectName = Types.ProjectNames.DataAccessLayer.ToString(),
                        SolutionName = "AirSolutions"
                    };
                    objDbErr.AddErrorLog();
               
                Utility = new CommonUtility()
                {
                    Data = RequestRespanceData,
                    Data1 = RequestId,
                    ActionType = "Post",
                    Message = "HttpClient postAsync excution Failed",
                    Status = false,
                    RequestPostTime = reqSendTime,
                    ResponseGetTime = resGetTime
                };
              
            }
            return Utility;
        }
       
    }
}
