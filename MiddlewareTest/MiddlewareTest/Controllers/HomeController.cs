using MiddlewareTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ThirdpartyAPI.Services;
using static MiddlewareTest.Models.MModel;
using static MiddlewareTest.Models.MyValoData;
using static MiddlewareTest.Models.MyValoData.Root;

namespace MiddlewareTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ValoPlayerCard VPC = new ValoPlayerCard();
            WeaponsService WC = new WeaponsService();
            var WeaponData = WC.GetWeapons();
            var data = VPC.GetPlayerCard();

            object Edata = data.Result.ToString();
            object GunData = WeaponData.Result.ToString();
            var mappedData = JsonConvert.DeserializeObject<WeaponModel.Root>((string)GunData);
            WeaponModel.Root passing = new WeaponModel.Root();
            passing = mappedData;
            GetWeaponModel mydata = new GetWeaponModel();
            IEnumerable<GetWeaponModel> Data =
             passing.data.Select(s => new GetWeaponModel
             {
                 uuid = s.uuid,
                 displayIcon = s.displayIcon,
                 displayName = s.displayName,
                 category = s.category.Remove(0,21), // removes / deletes from 0-21 characters of category (Starts from Index)
                 defaultSkinUuid = s.defaultSkinUuid,
                 themeUuid = s.assetPath
             });

            var weaponLoop = passing.data.FirstOrDefault(x => x.displayName == "Phantom");
            return View(Data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}