﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdpartyAPI.Models
{
    public class ValoPlayerCard
    {
        public class Datum
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public bool isHiddenIfNotOwned { get; set; }
            public object themeUuid { get; set; }
            public string displayIcon { get; set; }
            public string smallArt { get; set; }
            public string wideArt { get; set; }
            public string largeArt { get; set; }
            public string assetPath { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public List<Datum> data { get; set; }
        }
    }
}
