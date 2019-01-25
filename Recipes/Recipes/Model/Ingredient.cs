using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Ingredient
    {
        public Ingredient(string TextIngredient, double WeightIngredient)
        {
            Text = TextIngredient;
            Weight = WeightIngredient;
        }

        public Ingredient()
        {

        }
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }
}
