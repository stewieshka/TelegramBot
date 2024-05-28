using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Api.Common;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "dd.MM.yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();
        if (DateTime.TryParseExact(dateString, DateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            return date;
        }
        throw new JsonException($"Unable to convert \"{dateString}\" to DateTime. Expected format: {DateFormat}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateFormat));
    }
}