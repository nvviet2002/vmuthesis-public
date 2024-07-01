

using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BE_thesis.Data
{
    public class CustomDatetimeConverter: JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader
            ,Type typeToConvert,JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString(), null, System.Globalization.DateTimeStyles.RoundtripKind);
        }
                

        public override void Write(Utf8JsonWriter writer
            ,DateTime dateTimeValue,JsonSerializerOptions options)
        {
            writer.WriteStringValue(dateTimeValue.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture));
        }
               

    }
}
