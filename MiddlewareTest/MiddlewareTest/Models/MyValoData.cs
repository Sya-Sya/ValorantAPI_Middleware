using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareTest.Models
{
    public class MyValoData
    {
        public object Mydata { get; set; }
        public class Ability
        {
            public string slot { get; set; }
            public string displayName { get; set; }
            public string description { get; set; }
            public string displayIcon { get; set; }
        }

        public class Data
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string description { get; set; }
            public string developerName { get; set; }
            public List<string> characterTags { get; set; }
            public string displayIcon { get; set; }
            public string displayIconSmall { get; set; }
            public string bustPortrait { get; set; }
            public string fullPortrait { get; set; }
            public string fullPortraitV2 { get; set; }
            public string killfeedPortrait { get; set; }
            public string background { get; set; }
            public List<string> backgroundGradientColors { get; set; }
            public string assetPath { get; set; }
            public bool isFullPortraitRightFacing { get; set; }
            public bool isPlayableCharacter { get; set; }
            public bool isAvailableForTest { get; set; }
            public bool isBaseContent { get; set; }
            public Role role { get; set; }
            public List<Ability> abilities { get; set; }
            public VoiceLine voiceLine { get; set; }
            public IEnumerable<Data> DataList { get; internal set; }
        }

        public class MediaList
        {
            public int id { get; set; }
            public string wwise { get; set; }
            public string wave { get; set; }
        }

        public class Role
        {
            public string uuid { get; set; }
            public string displayName { get; set; }
            public string description { get; set; }
            public string displayIcon { get; set; }
            public string assetPath { get; set; }
        }

        public class Root
        {
            public int status { get; set; }
            public List<Data> data { get; set; }
        }

        public class VoiceLine
        {
            public double minDuration { get; set; }
            public double maxDuration { get; set; }
            public List<MediaList> mediaList { get; set; }
        }
    }
}