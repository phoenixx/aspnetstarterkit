using System;
using Newtonsoft.Json;
using Spa.StarterKit.React.Extensions;

namespace Spa.StarterKit.React.Utilities
{
    public class MpdJsonEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            Enum e = (Enum)value;

            string enumName = e.ToString("G");

            if (char.IsNumber(enumName[0]) || enumName[0] == '-')
            {
                // enum value has no name so write number
                writer.WriteValue(value);
            }
            else
            {
                Type enumType = e.GetType();

                string finalName = e.ToDescription();

                writer.WriteValue(finalName);
            }
        }
    }
}