using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    internal class DietLabelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(DietLabel) || t == typeof(DietLabel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "High-Protein":
                    return DietLabel.HighProtein;
                case "Low-Carb":
                    return DietLabel.LowCarb;
                case "Low-Fat":
                    return DietLabel.LowFat;
            }
            throw new Exception("Cannot unmarshal type DietLabel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (DietLabel)untypedValue;
            switch (value)
            {
                case DietLabel.HighProtein:
                    serializer.Serialize(writer, "High-Protein");
                    return;
                case DietLabel.LowCarb:
                    serializer.Serialize(writer, "Low-Carb");
                    return;
                case DietLabel.LowFat:
                    serializer.Serialize(writer, "Low-Fat");
                    return;
            }
            throw new Exception("Cannot marshal type DietLabel");
        }

        public static readonly DietLabelConverter Singleton = new DietLabelConverter();
    }

}
