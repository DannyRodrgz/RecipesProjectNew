using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public class SpecificDigest
    {
        public string label { get; set; }
        public Sub total { get; set; }

        public string Label { get; set; }
        public double Quantity { get; set; }
        public Unit Unit { get; set; }

        public SpecificDigest(string titleNutrientValue, Total totalValue)
        {
            label = titleNutrientValue;
            total = totalValue;
            Label = total.Label;
            Quantity = total.Quantity;
            Unit = total.Unit;
        }
    }
}
