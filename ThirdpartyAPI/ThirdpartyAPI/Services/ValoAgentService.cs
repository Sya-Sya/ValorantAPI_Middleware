using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThirdpartyAPI.Helpers;
using static TPAPIModel.Models.ValoAgents;
using static TPAPIModel.NormalResponseModel;

namespace ThirdpartyAPI.Services
{
    public class ValoAgentService
    {
        public async Task<string> GetAgentList()
        {
            //var request = new HttpCallMe();
            NormalResponse Nres = new NormalResponse();
            var urls = "https://valorant-api.com/v1/agents";
            string responseString = "";

            try
            {
                //var client = new HttpClient();
                //var request = new HttpRequestMessage(HttpMethod.Get, urls);
                //var response = await client.SendAsync(request);
                //var CleanData = await response.Content.ReadAsStringAsync();
                //CleanData= CleanData.Trim().ToString();

                //return CleanData;


                var client1 = new HttpClient();
                var request1 = new HttpRequestMessage(HttpMethod.Get, urls);
                var responseTask = client1.SendAsync(request1);
                responseTask.Wait();
                var response1 = responseTask.Result;

                response1.EnsureSuccessStatusCode();
                var contentTask = response1.Content.ReadAsStringAsync();
                contentTask.Wait();
                var content = contentTask.Result;

                return content;
                //return await response.Content.ReadAsStringAsync();

                //var GetData = request.HttpPostRequest(url, "", "", "", "", "", reqType);
                //var PostManRequest = new HttpRequestMessage(HttpMethod.Get, url);
                //if (GetData != null)
                //{
                //    Root getMyData = JsonConvert.DeserializeObject<Root>(GetData);
                //    if (getMyData.status == 200)
                //    {
                //        Root ResponseData = JsonConvert.DeserializeObject<Root>(GetData);
                //        return new NormalResponse { ResCode = ResponseCode.SUCCESS, Data = ResponseData, Error = "", Message = "SUCCESS" };
                //    }
                //    else
                //    {
                //        return new NormalResponse { ResCode = ResponseCode.FAILED, Data = "", Error = getMyData, Message = "FAILED" };
                //    }
                //}
            }
            catch (WebException wex)
            {
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            responseString = reader.ReadToEnd(); 
                        }
                    }

                }
                return responseString;
            }
        }
    }
}