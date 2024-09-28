using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShop.Utility
{
    public class UrlHelper
    {
        public static string UrlEncode<T>(T t)
        {
            string UrlResult = JsonConvert.SerializeObject(t, Formatting.Indented);
            UrlResult = HttpUtility.UrlEncode(UrlResult);
            
            return UrlResult;
        }

        public static string UrlDecode(string AfterDecrypt)
        {
            string AfterDecode = HttpUtility.UrlDecode(AfterDecrypt);
            return AfterDecode;
        }
    }
}
