using HolidaySearchApplication.Utils;
using System.Text.Json;

namespace HolidaySearchApplication.InputAdapters
{
    public class JsonFileSourceAdapterOptions : IOptions
    {
        public required string JsonFile { get; set; }
        public static JsonSerializerOptions SerializationOptions => new() { PropertyNamingPolicy = new SnakeCaseNamingPolicy() };
    }
}



