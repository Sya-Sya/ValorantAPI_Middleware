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
            public string displayIcon { get; set; }
            public string altFireType { get; set; }
            public string cost { get; set; }
            public object image { get; set; }
            public string newImage { get; set; }
            public List<Skin> skins { get; set; }
            public List<Chroma> chromas { get; set; }
            public List<Level> levels { get; set; }
        }

        public class Skin
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string themeUuid { get; set; }
            public string contentTierUuid { get; set; }
            public string displayIcon { get; set; }
            public string wallpaper { get; set; }
            public string assetPath { get; set; }
            
        }
        public class Chroma
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string displayIcon { get; set; }
            public string fullRender { get; set; }
            public string swatch { get; set; }
            public string streamedVideo { get; set; }
            public string assetPath { get; set; }
        }

        public class Level
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string levelItem { get; set; }
            public string displayIcon { get; set; }
            public string streamedVideo { get; set; }
            public string assetPath { get; set; }
        }
    }
}