namespace HolidaySearchApplication.DomainModel.Flight
{
    public static class AirportLookup
    {
        private static List<Airport> _airports = new List<Airport>
        {
            new Airport{Name = "Manchester Airport (MAN)", Code = "MAN", City = "Manchester", Country = "UK"},
            new Airport{Name = "Gran Canaria Airport (LPA)", Code = "LPA", City = "Gran Canaria", Country = "Spain"},
            new Airport{Name = "Tenerife South Airport (TFA)", Code = "TFA", City = "Tenerife", Country = "Spain"},
            new Airport{Name = "Mallorca Airport (PMI)", Code = "PMI", City = "Palma", Country = "Spain"},
            new Airport{Name = "Malaga Airport (AGP)", Code = "AGP", City = "Malaga", Country = "Spain"},
            new Airport{Name = "London Luton Airport (LTN)", Code = "LTN", City = "London", Country = "UK"},
            new Airport{Name = "London Gatwick Airport (LGW)", Code = "LGW", City = "London", Country = "UK"},
        };

        public static List<Airport> AllAirports { get { return _airports; } }

        public static IEnumerable<Airport> GetAirportsByCity(string city)
        {
            // This will return all the airport for within a given city.
            return _airports.Where(x => x.City.Equals(city, StringComparison.InvariantCultureIgnoreCase));
        }

        public static bool ContainsAirportCode(string code)
        {
            return _airports.Any(x => x.Code == code);
        }
    }
}
