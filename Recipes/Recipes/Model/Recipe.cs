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
        public Recipe(string LabelR, double CaloriesR, Uri UriR, Uri Url)
        {
            Label = LabelR;
            Calories = CaloriesR;
            Uri = UriR;
            this.Url = Url;
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

        [JsonProperty("dietLabels")]
        public DietLabel[] DietLabels { get; set; }

        [JsonProperty("healthLabels")]
        public HealthLabel[] HealthLabels { get; set; }

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
    }
}
