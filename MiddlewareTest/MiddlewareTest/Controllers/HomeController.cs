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
using MiddlewareTest.Static;

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
        public ActionResult About(string GunName)
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
                var ListSkins = new List<MModel.Skin>();
                var ListChroma = new List<MModel.Chroma>();
                var ListLevel = new List<MModel.Level>();
                model2.cost = Type.shopData.cost.ToString();
                model2.category = Type.shopData.category.ToString();
                model2.newImage = Type.shopData.newImage;
                model2.skins = ListSkins;
                model2.chromas = ListChroma;
                model2.levels = ListLevel;

                foreach (var item in Type.skins)
                {
                    MModel.Skin MMS = new MModel.Skin();
                    MMS.uuid = item.uuid;
                    MMS.assetPath = item.assetPath;
                    MMS.displayIcon = item.displayIcon;
                    MMS.assetPath = item.assetPath;
                    ListSkins.Add(MMS);

                    foreach (var chormas in item.chromas)
                    {
                        MModel.Chroma MMC = new MModel.Chroma();
                        MMC.uuid = chormas.uuid;
                        MMC.assetPath = chormas.assetPath;
                        MMC.fullRender = chormas.fullRender;
                        MMC.displayName = chormas.displayName;
                        ListChroma.Add(MMC);
                    }

                    foreach (var lvl in item.levels)
                    {
                        MModel.Level MML = new MModel.Level();
                        MML.uuid = lvl.uuid;
                        MML.assetPath = lvl.assetPath;
                        MML.displayName = lvl.displayName;
                        MML.displayIcon = lvl.displayIcon;
                        MML.streamedVideo = lvl.streamedVideo;
                        ListLevel.Add(MML);
                    }
                }

                if (model2 != null)
                {
                    return RedirectToAction("Contact", new { myData = model2 });
                }
                else
                {
                    return Json(
                    new
                    {
                        status = "Faile",
                        Message = "Filed to get data"
                    }
                    );
                }

                return Json(
                        new
                        {
                            status = "Success",
                            Message = "Filed to get data"
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

        public ActionResult Contact(GetWeaponModel myData)
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}