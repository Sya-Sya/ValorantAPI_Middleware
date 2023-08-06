using MiddlewareTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using ThirdpartyAPI.Services;
using static MiddlewareTest.Models.MModel;
using static MiddlewareTest.Models.MyValoData;
using static MiddlewareTest.Models.MyValoData.Root;
using System.CodeDom;
using static MiddlewareTest.Models.WeaponModel;

namespace MiddlewareTest.Controllers
{
    public class HomeController : Controller
    {
        WeaponsService WC = new WeaponsService();
        public ActionResult Index()
        {
            ValoPlayerCard VPC = new ValoPlayerCard();
            var WeaponData = WC.GetWeapons();
            var data = VPC.GetPlayerCard();

            object Edata = data.Result.ToString();
            object GunData = WeaponData.Result.ToString();
            var mappedData = JsonConvert.DeserializeObject<WeaponModel.Root>((string)GunData);
            //WeaponModel.Root passing = new WeaponModel.Root();
            //passing = mappedData;
            GetWeaponModel mydata = new GetWeaponModel();
            List<GetWeaponModel> mydata1 = new List<GetWeaponModel>();
            foreach (var item in mappedData.data)
            {
                GetWeaponModel GWM = new GetWeaponModel();
                if (item.displayName.ToLower() == "melee")
                {
                    GWM.uuid = item.uuid;
                    GWM.displayName = item.displayName;
                    GWM.category = item.category;
                    GWM.displayIcon = item.displayIcon;
                }
                else
                {
                    GWM.cost = !string.IsNullOrEmpty(item.shopData.cost.ToString()) ? item.shopData.cost.ToString() : "";
                    GWM.newImage = !string.IsNullOrEmpty(item.shopData.newImage) ? item.shopData.newImage : "";
                    GWM.category = string.IsNullOrEmpty(item.shopData.category) ? item.shopData.category : "";
                    GWM.uuid = item.uuid;
                    GWM.displayName = item.displayName;
                    GWM.category = item.category;
                    GWM.displayIcon = item.displayIcon;
                }
                mydata1.Add(GWM);
            }
            //IEnumerable<GetWeaponModel> Data =
            // passing.data.Select(s => new GetWeaponModel
            // {
            //     uuid = s.uuid,
            //     displayIcon = s.displayIcon,
            //     displayName = s.displayName,
            //     category = s.category.Remove(0, 21), // removes / deletes from 0-21 characters of category (Starts from Index)
            //     defaultSkinUuid = s.defaultSkinUuid,
            //     themeUuid = s.assetPath
            // });

            //var weaponLoop = passing.data.FirstOrDefault(x => x.displayName == "Phantom");
            //return View(Data);
            return View(mydata1);
        }
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost, OverrideResultFilters]
        public JsonResult About(string GunName)
        {
            GunName = GunName.ToLower();
            if (!string.IsNullOrEmpty(GunName))
            {
                var WeaponData = WC.GetWeapons();
                object GunData = WeaponData.Result.ToString();
                var mappedData = JsonConvert.DeserializeObject<WeaponModel.Root>((string)GunData);
                var Type = mappedData.data.FirstOrDefault(x => x.displayName.ToLower() == GunName);
                List<GetWeaponModel> GWM2 = new List<GetWeaponModel>();
                GetWeaponModel model2 = new GetWeaponModel();
                model2.cost = Type.shopData.cost.ToString();
                model2.category = Type.shopData.category.ToString();
                model2.newImage = Type.shopData.newImage;
                var skins = new List<MModel.Skin>();
                var Chroma = new List<MModel.Chroma>();
                var Level = new List<MModel.Level>();

                return Json(
                new
                {
                    status = "Success"
                }
                );
            }
            else
            {
                return Json(
                new
                {
                    status = "Failed",
                    Message = "Gun Name not found"
                }
                );
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}