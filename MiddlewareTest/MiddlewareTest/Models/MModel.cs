using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareTest.Models
{
    public class MModel
    {
        public class GetWeaponModel
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string category { get; set; }
            public string defaultSkinUuid { get; set; }
            public string displayIcon { get; set; }
            public string killStreamIcon { get; set; }
            public string assetPath { get; set; }
            public double fireRate { get; set; }
            public int magazineSize { get; set; }
            public double runSpeedMultiplier { get; set; }
            public double equipTimeSeconds { get; set; }
            public double reloadTimeSeconds { get; set; }
            public double firstBulletAccuracy { get; set; }
            public int shotgunPelletCount { get; set; }
            public string wallPenetration { get; set; }
            public string feature { get; set; }
            public string fireMode { get; set; }
            public string altFireType { get; set; }
            public int cost { get; set; }
            public string categoryText { get; set; }
            public bool canBeTrashed { get; set; }
            public object image { get; set; }
            public string newImage { get; set; }
            public object newImage2 { get; set; }
            public string themeUuid { get; set; }
            public string contentTierUuid { get; set; }
            public string wallpaper { get; set; }
        }
    }
}