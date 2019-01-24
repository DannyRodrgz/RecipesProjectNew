using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    internal class HealthLabelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(HealthLabel) || t == typeof(HealthLabel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Alcohol-Free":
                    return HealthLabel.AlcoholFree;
                case "Peanut-Free":
                    return HealthLabel.PeanutFree;
                case "Sugar-Conscious":
                    return HealthLabel.SugarConscious;
                case "Tree-Nut-Free":
                    return HealthLabel.TreeNutFree;
            }
            throw new Exception("Cannot unmarshal type HealthLabel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (HealthLabel)untypedValue;
            switch (value)
            {
                case HealthLabel.AlcoholFree:
                    serializer.Serialize(writer, "Alcohol-Free");
                    return;
                case HealthLabel.PeanutFree:
                    serializer.Serialize(writer, "Peanut-Free");
                    return;
                case HealthLabel.SugarConscious:
                    serializer.Serialize(writer, "Sugar-Conscious");
                    return;
                case HealthLabel.TreeNutFree:
                    serializer.Serialize(writer, "Tree-Nut-Free");
                    return;
            }
            throw new Exception("Cannot marshal type HealthLabel");
        }

        public static readonly HealthLabelConverter Singleton = new HealthLabelConverter();
    }
}
