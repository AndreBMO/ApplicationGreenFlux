using GreenFlux.Domain.Model;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GreenFluxAPI.Contract
{
    public class HolidayTypeConverter : JsonConverter<HolidayType>
    {
        public override HolidayType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return HolidayType.Authorities;
        }

        public override void Write(Utf8JsonWriter writer, HolidayType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
