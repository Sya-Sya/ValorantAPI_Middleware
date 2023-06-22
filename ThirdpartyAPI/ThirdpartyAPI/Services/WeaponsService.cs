using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TPAPIModel;
using static ThirdpartyAPI.Models.WeaponModel;
using static TPAPIModel.NormalResponseModel;

namespace ThirdpartyAPI.Services
{
    public class WeaponsService
    {
        public async Task<object> GetWeapons()
        {
            var URL = "https://valorant-api.com/v1/weapons";
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URL);
                var responseTask = client.SendAsync(request);
                responseTask.Wait();
                var response = responseTask.Result;
                response.EnsureSuccessStatusCode();
                var contentTask = response.Content.ReadAsStringAsync();
                contentTask.Wait();
                var content = contentTask.Result;

                var mapModel = JsonConvert.DeserializeObject<Root>(content);
                
                return content;
            }
            catch (Exception exe)
            {
                return new NormalResponse { ResCode = ResponseCode.FAILED, Message = "FAILED", Data = "", Error = exe };
            }
            return new NormalResponse { ResCode = ResponseCode.FAILED, Message = "FAILED", Data = "", Error = "Unknown Error xD !!!" };
        }
    }
}
