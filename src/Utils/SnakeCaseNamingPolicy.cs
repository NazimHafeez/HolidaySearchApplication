using System.Text.Json;

namespace HolidaySearchApplication.Utils
{
    // .NET 8 Pre release candidate contains all the different policies but not support under 7 so had to use this work around
    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public static SnakeCaseNamingPolicy Instance { get; } = new SnakeCaseNamingPolicy();

        public override string ConvertName(string name)
        {
            return name.ToSnakeCase();
        }

    }
}

