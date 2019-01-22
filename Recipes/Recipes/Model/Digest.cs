using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Digest
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("schemaOrgTag")]
        public SchemaOrgTag? SchemaOrgTag { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("hasRDI")]
        public bool HasRdi { get; set; }

        [JsonProperty("daily")]
        public double Daily { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }

        [JsonProperty("sub", NullValueHandling = NullValueHandling.Ignore)]
        public Digest[] Sub { get; set; }
    }
}
