using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recipes.Model
{
    internal class SchemaOrgTagConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(SchemaOrgTag) || t == typeof(SchemaOrgTag?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "carbohydrateContent":
                    return SchemaOrgTag.CarbohydrateContent;
                case "cholesterolContent":
                    return SchemaOrgTag.CholesterolContent;
                case "fatContent":
                    return SchemaOrgTag.FatContent;
                case "fiberContent":
                    return SchemaOrgTag.FiberContent;
                case "proteinContent":
                    return SchemaOrgTag.ProteinContent;
                case "saturatedFatContent":
                    return SchemaOrgTag.SaturatedFatContent;
                case "sodiumContent":
                    return SchemaOrgTag.SodiumContent;
                case "sugarContent":
                    return SchemaOrgTag.SugarContent;
                case "transFatContent":
                    return SchemaOrgTag.TransFatContent;
            }
            throw new Exception("Cannot unmarshal type SchemaOrgTag");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (SchemaOrgTag)untypedValue;
            switch (value)
            {
                case SchemaOrgTag.CarbohydrateContent:
                    serializer.Serialize(writer, "carbohydrateContent");
                    return;
                case SchemaOrgTag.CholesterolContent:
                    serializer.Serialize(writer, "cholesterolContent");
                    return;
                case SchemaOrgTag.FatContent:
                    serializer.Serialize(writer, "fatContent");
                    return;
                case SchemaOrgTag.FiberContent:
                    serializer.Serialize(writer, "fiberContent");
                    return;
                case SchemaOrgTag.ProteinContent:
                    serializer.Serialize(writer, "proteinContent");
                    return;
                case SchemaOrgTag.SaturatedFatContent:
                    serializer.Serialize(writer, "saturatedFatContent");
                    return;
                case SchemaOrgTag.SodiumContent:
                    serializer.Serialize(writer, "sodiumContent");
                    return;
                case SchemaOrgTag.SugarContent:
                    serializer.Serialize(writer, "sugarContent");
                    return;
                case SchemaOrgTag.TransFatContent:
                    serializer.Serialize(writer, "transFatContent");
                    return;
            }
            throw new Exception("Cannot marshal type SchemaOrgTag");
        }

        public static readonly SchemaOrgTagConverter Singleton = new SchemaOrgTagConverter();
    }
}
