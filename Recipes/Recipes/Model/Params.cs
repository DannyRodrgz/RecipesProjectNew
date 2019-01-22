using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Params
    {
        [JsonProperty("sane")]
        public object[] Sane { get; set; }

        [JsonProperty("q")]
        public string[] Q { get; set; }

        [JsonProperty("app_key")]
        public string[] AppKey { get; set; }

        [JsonProperty("app_id")]
        public string[] AppId { get; set; }
    }
}
