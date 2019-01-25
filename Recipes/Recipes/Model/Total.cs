using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Total
    {
        public Total() { }
        public Total(string LabelT, double QuantityT, Unit UnitT) {
            Label = LabelT;
            Quantity = QuantityT;
            Unit = UnitT;
        }
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }

    }
}
