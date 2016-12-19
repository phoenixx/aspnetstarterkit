using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Spa.StarterKit.React.Utilities;

namespace Spa.StarterKit.React.ViewModels.Extensions
{
    public static class ModelExtensions
    {
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        public static string ToJsonEnumStringDateTimes(this object o, bool camelCase = false)
        {
            var converters = new List<JsonConverter>()
            {
                new IsoDateTimeConverter() { DateTimeFormat = "dd/MM/yyyy HH:mm"},
                new StringEnumConverter()
            };

            return JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings()
            {
                ContractResolver =
                    camelCase ? new CamelCasePropertyNamesContractResolver() : new DefaultContractResolver(),
                Converters = converters
            });
        }

        public static string ToJsonEnumString(this object o, bool camelCase = false, bool formatDates = false)
        {
            var converters = new List<JsonConverter>();
            if (formatDates)
            {
                converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            }

            converters.Add(new StringEnumConverter());

            return JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings
            {
                ContractResolver =
                    camelCase ? new CamelCasePropertyNamesContractResolver() : new DefaultContractResolver(),
                Converters = converters
            });
        }

        public static string ToJsonEnumDescriptionString(this object o, bool camelCase = false, bool formatDates = false)
        {
            var converters = new List<JsonConverter>();
            if (formatDates)
            {
                converters.Add(new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy"});
            }

            converters.Add(new MpdJsonEnumConverter());

            return JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings
            {
                ContractResolver =
                    camelCase ? new CamelCasePropertyNamesContractResolver() : new DefaultContractResolver(),
                Converters = converters
            });
        }

        public static string ToJsonFormatDates(this object o)
        {
            var converters = new List<JsonConverter>()
            {
                new IsoDateTimeConverter() {DateTimeFormat = "dd/MM/yyyy"}
            };
            return JsonConvert.SerializeObject(o, Formatting.None, new JsonSerializerSettings()
            {
                Converters = converters
            });
        }
    }
}