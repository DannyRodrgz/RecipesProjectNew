using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    internal class UnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Unit) || t == typeof(Unit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "%":
                    return Unit.Empty;
                case "IU":
                    return Unit.Iu;
                case "g":
                    return Unit.G;
                case "kcal":
                    return Unit.Kcal;
                case "mg":
                    return Unit.Mg;
                case "µg":
                    return Unit.Μg;
            }
            throw new Exception("Cannot unmarshal type Unit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Unit)untypedValue;
            switch (value)
            {
                case Unit.Empty:
                    serializer.Serialize(writer, "%");
                    return;
                case Unit.Iu:
                    serializer.Serialize(writer, "IU");
                    return;
                case Unit.G:
                    serializer.Serialize(writer, "g");
                    return;
                case Unit.Kcal:
                    serializer.Serialize(writer, "kcal");
                    return;
                case Unit.Mg:
                    serializer.Serialize(writer, "mg");
                    return;
                case Unit.Μg:
                    serializer.Serialize(writer, "µg");
                    return;
            }
            throw new Exception("Cannot marshal type Unit");
        }

        public static readonly UnitConverter Singleton = new UnitConverter();
    }
}
