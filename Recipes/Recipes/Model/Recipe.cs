using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public class Recipe : IRecipe
    {
        public Recipe ()
        {
        }

        [JsonProperty("uri")]
        public Uri Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("image")]
        public Uri Image { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("shareAs")]
        public Uri ShareAs { get; set; }

        [JsonProperty("yield")]
        public long Yield { get; set; }

        [JsonProperty("cautions")]
        public string[] Cautions { get; set; }

        [JsonProperty("ingredientLines")]
        public string[] IngredientLines { get; set; }

        [JsonProperty("ingredients")]
        public Ingredient[] IngredientsRecipe { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("totalWeight")]
        public double TotalWeight { get; set; }

        [JsonProperty("totalTime")]
        public long TotalTime { get; set; }

        [JsonProperty("totalNutrients")]
        public Dictionary<string, Total> TotalNutrients { get; set; }

        [JsonProperty("totalDaily")]
        public Dictionary<string, Total> TotalDaily { get; set; }

        [JsonProperty("digest")]
        public Digest[] Digest { get; set; }
        public double CaloriesForRecipe { get; set; }

        public double RecipeCalories
        {
            get { return Yield / Calories; }
        }
    }
}
