using EvilLight.Model.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace EvilLight.Builder
{
    public class WeatherDataBuilder
    {
        private static string key = "9b74fc91b2a8438cbc070b3f3ec41857";
        private static string url = "https://api.heweather.com/x3/weather?cityid=";

        public async Task<WetherData> Get(string cityid)
        {
            HttpClient hc = new HttpClient();
            Uri uri1 = new Uri(url+cityid + "&key=" + key);
            var obj = await hc.GetStringAsync(uri1);
            int index1 = obj.IndexOf('[');
            int index2 = obj.LastIndexOf(']');
            var str = obj.Substring(index1 + 1, index2 - index1 - 1);

            return JsonConvert.DeserializeObject<WetherData>(str);
        }
    }
}
