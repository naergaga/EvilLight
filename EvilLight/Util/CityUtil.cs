using EvilLight.Model.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace EvilLight.Util
{
    public class CityUtil
    {
        private static string urlCity = "https://api.heweather.com/x3/citylist?search=allchina";
        private static string key = "9b74fc91b2a8438cbc070b3f3ec41857";

        public CityUtil()
        {
        }

        public async static Task<CityInfo> GetCityLocal()
        {
            HttpClient hc = new HttpClient();
            Uri uri1 = new Uri(urlCity + "&key=" + key);
            var obj =  await hc.GetStringAsync(uri1);
            
            return JsonConvert.DeserializeObject<CityInfo>(obj);
        }
    }

}
