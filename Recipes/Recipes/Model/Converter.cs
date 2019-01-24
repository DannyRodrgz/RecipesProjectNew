using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace Recipes.Model
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DietLabelConverter.Singleton,
                SchemaOrgTagConverter.Singleton,
                UnitConverter.Singleton,
                HealthLabelConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
