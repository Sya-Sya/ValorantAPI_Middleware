using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareTest.Static
{
    public static class HelpMe
    {
        public static List<T> MapObjects<T>(this object item)
        {
            List<T> sr = default(List<T>);
            if (item != null)
            {
                var obj = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                sr = JsonConvert.DeserializeObject<List<T>>(obj);
            }
            return sr;
        }
    }
}