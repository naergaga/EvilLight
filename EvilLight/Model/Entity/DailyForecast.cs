﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EvilLight.Model.Entity
{

    public class DailyForecast
    {

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("astro")]
        public Astro Astro { get; set; }

        [JsonProperty("cond")]
        public Cond2 Cond { get; set; }

        [JsonProperty("hum")]
        public string Hum { get; set; }

        [JsonProperty("pcpn")]
        public string Pcpn { get; set; }

        [JsonProperty("pop")]
        public string Pop { get; set; }

        [JsonProperty("pres")]
        public string Pres { get; set; }

        [JsonProperty("tmp")]
        public Tmp Tmp { get; set; }

        [JsonProperty("vis")]
        public string Vis { get; set; }

        [JsonProperty("wind")]
        public Wind2 Wind { get; set; }
    }

}