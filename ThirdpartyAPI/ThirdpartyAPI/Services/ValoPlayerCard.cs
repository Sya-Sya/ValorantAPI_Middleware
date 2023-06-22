using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ThirdpartyAPI.Services
{
    public class ValoPlayerCard
    {
        public async Task<object> GetPlayerCard()
        {
            var url = "https://valorant-api.com/v1/playercards";
            string responseString = "";
            try
            {
                ValoPlayerCard VPC = new ValoPlayerCard();
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var responseTask = client.SendAsync(request);
                responseTask.Wait();
                var response = responseTask.Result;
                response.EnsureSuccessStatusCode();
                var contentTask = response.Content.ReadAsStringAsync();
                contentTask.Wait();
                var content = contentTask.Result;

                var mapModel = JsonConvert.DeserializeObject<ValoPlayerCard>(content);
                return content;


                //var client = new HttpClient();
                //var request = new HttpRequestMessage(HttpMethod.Get, "https://valorant-api.com/v1/playercards");
                //var content = new StringContent("", null, "text/plain");
                //request.Content = content;
                //var response = await client.SendAsync(request);
                //response.EnsureSuccessStatusCode();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
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
                throw;
            }
        }
    }
}
