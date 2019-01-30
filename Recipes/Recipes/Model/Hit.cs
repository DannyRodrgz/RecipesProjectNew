using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    public partial class Hit
    {
        [JsonProperty("recipe")]
        public Recipe Recipe { get; set; }
    }
}
