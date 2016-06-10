using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilLight.Model.Domain
{
    public class City
    {
        [PrimaryKey, AutoIncrement]
        [JsonIgnore]
        public int Id { get; set; }

        [NotNull]
        [JsonProperty("city")]
        public string CityName { get; set; }

        [NotNull]
        [JsonProperty("id")]
        public string CityId { get; set; }

        [JsonProperty("lat")]
        public string Lat { get; set; }

        [JsonProperty("lon")]
        public string Lon { get; set; }

        [JsonProperty("prov")]
        public string Prov { get; set; }
    }
}
