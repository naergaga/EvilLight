﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EvilLight.Model.Entity
{

    public class Now
    {

        [JsonProperty("cond")]
        public Cond Cond { get; set; }

        [JsonProperty("fl")]
        public string Fl { get; set; }

        [JsonProperty("hum")]
        public string Hum { get; set; }

        [JsonProperty("pcpn")]
        public string Pcpn { get; set; }

        [JsonProperty("pres")]
        public string Pres { get; set; }

        [JsonProperty("tmp")]
        public string Tmp { get; set; }

        [JsonProperty("vis")]
        public string Vis { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }

}
