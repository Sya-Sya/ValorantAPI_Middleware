using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ThirdpartyAPI.Helpers
{
    public class HttpCallMe
    {
        public string HttpPostRequest(string url, object model, string header_auth, string username = "", string password = "", string token = "", string reqType = "")
        {
            var request = WebRequest.Create(url) as HttpWebRequest;

            var dataBytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(model));

            request.Method = reqType;
            switch (request.Method)
            {
                case "POST":
                    request.Method = "POST";
                    break;
                case "PUT":
                    request.Method = "PUT";
                    break;
                case "DELETE":
                    request.Method = "DELETE";
                    break;
                case "GET":
                    request.Method = "GET";
                    break;
                default:
                    request.Method = "POST";
                    break;
            }

            request.ContentType = "application/json;charset=UTF-8";
            request.ContentLength = dataBytes.Length;
            request.Accept = "application/json";
            request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";
            if (header_auth.ToUpper() == "BASIC")
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
                var basiccreds = System.Convert.ToBase64String(plainTextBytes);
                request.Headers.Add(HttpRequestHeader.Authorization, "Basic " + basiccreds);
            }
            else if (header_auth.ToUpper() == "BEARER")
            {
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + token);
            }

            string responseString = "";

            try
            {
                if (ConfigurationManager.AppSettings["EnableTls"] != null && ConfigurationManager.AppSettings["EnableTls"].ToString().ToUpper() == "Y")
                {
                    ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
                    ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                }
                //using (WebResponse Getresponse = request.GetResponse())
                //{
                //    using (Stream stream = Getresponse.GetResponseStream())
                //    {
                //        var responseGet = (HttpWebResponse)request.GetResponse();
                //        responseString = new StreamReader(Getresponse.GetResponseStream()).ReadToEnd();
                //    }
                //}
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dataBytes, 0, dataBytes.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
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
            }
            return responseString;
        }
    }
}