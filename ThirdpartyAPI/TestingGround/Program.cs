using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ThirdpartyAPI.Services;

namespace TestingGround
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //var url = "https://valorant-api.com/v1/agents";
            //var client = new HttpClient();

            //var result = await client.GetAsync(url);
            //result.EnsureSuccessStatusCode();
            //if (result != null)
            //{
            //    Console.WriteLine("DalatList :" + await result.Content.ReadAsStringAsync());
            //    Console.ReadLine();
            //}
            //else
            //{
            //    Console.WriteLine("DalatList :" + JsonConvert.SerializeObject(result));
            //    Console.ReadLine();
            //}

            ValoAgentService VAS = new ValoAgentService();
            ValoPlayerCard VPC = new ValoPlayerCard();
            WeaponsService WS = new WeaponsService();
            //var getData = VAS.GetAgentList();
            //var getPXC = VPC.GetPlayerCard();

            var getWSData = WS.GetWeapons();

            if (getWSData != null)
            {
                Console.WriteLine("Result :" + JsonConvert.SerializeObject(getWSData.Result));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("FAILED !!!");
                Console.ReadLine();
            }
        }
    }
}
