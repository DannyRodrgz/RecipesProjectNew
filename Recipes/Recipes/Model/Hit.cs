using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Hit
    {
        [JsonProperty("recipe")]
        public Ingredients Recipe { get; set; }

        [JsonProperty("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonProperty("bought")]
        public bool Bought { get; set; }
    }
}
