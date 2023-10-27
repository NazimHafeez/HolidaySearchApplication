using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.DomainModel.Hotel;
using HolidaySearchApplication.QueryModel;
using HolidaySearchApplication.Repository;

namespace HolidaySearchApplication.SearchEngine
{
    public class HolidaySearchEngine : ISearchEngine<HolidaySearch, HolidaySearchResponse>
    {
        private readonly HolidaySearchValidator _inputValidator;
        private readonly IRepository<Hotel> _hotelRepository;
        private readonly IRepository<Flight> _flightRepository;

        public HolidaySearchEngine(HolidaySearchValidator validator, IRepository<Hotel> hotelRepository, IRepository<Flight> flightRepository)
        {
            _inputValidator = validator;
            _hotelRepository = hotelRepository;
            _flightRepository = flightRepository;
        }

        public SearchResult<HolidaySearchResponse> Search(HolidaySearch searchCriteria)
        {
            var validationResult = _inputValidator.Validate(searchCriteria);
            if (!validationResult.IsValid)
            {
                return new SearchResult<HolidaySearchResponse> { Success = false, Error = validationResult.Errors.First().ErrorMessage };
            }

            var departureAirports = new List<string>();

            if (AirportLookup.ContainsAirportCode(searchCriteria.DepartingFrom))
            {
                // There is only one origin Airport
                departureAirports.Add(searchCriteria.DepartingFrom);
            }
            else
            {
                if (searchCriteria.DepartingFrom.Equals("Any Airport", StringComparison.InvariantCultureIgnoreCase))
                {
                    // All the UK airports excluding destination airport
                    departureAirports.AddRange(AirportLookup.AllAirports.Where(airport => airport.Country == "UK" && !airport.Code.Equals(searchCriteria.TravellingTo, StringComparison.InvariantCultureIgnoreCase)).Select(a => a.Code).ToList());
                }
                else
                {
                    // All London Airports
                    departureAirports.AddRange(AirportLookup.AllAirports.Where(airport => airport.City == "London" && !airport.Code.Equals(searchCriteria.TravellingTo, StringComparison.InvariantCultureIgnoreCase)).Select(a => a.Code).ToList());
                }
            }

            var searchResponse = new SearchResult<HolidaySearchResponse> { Success = true, Value = new HolidaySearchResponse { Flights = new List<Flight>(), Hotels = new List<Hotel>(), Results = new List<HolidayPackage>() } };

            //Flights
            searchResponse.Value.Flights = GetFlightsForHolidaySearch(searchCriteria.TravellingTo, _flightRepository.GetAll(), departureAirports, DateOnly.Parse(searchCriteria.DepartureDate));

            if (!searchResponse.Value.Flights.Any())
            {
                searchResponse.Success = false;
                searchResponse.Error = "Sorry, there are no flights for the given search criteria";
                return searchResponse;
            }

            //Hotels
            searchResponse.Value.Hotels = GetHotelsForHolidaySearch(searchCriteria.TravellingTo, DateOnly.Parse(searchCriteria.DepartureDate), searchCriteria.Duration, _hotelRepository.GetAll());

            if (!searchResponse.Value.Hotels.Any())
            {
                searchResponse.Success = false;
                searchResponse.Error = "Sorry, there are no hotels for the given search criteria";
                return searchResponse;
            }

            //Package Holidays
            var packagedHolidayResults = new List<HolidayPackage>();
            foreach (var fligt in searchResponse.Value.Flights)
            {
                foreach (var hotel in searchResponse.Value.Hotels)
                {
                    packagedHolidayResults.Add(new HolidayPackage() { Flight = fligt, Hotel = hotel });
                }
            }

            searchResponse.Value.Results = packagedHolidayResults.OrderBy(x => x.TotalPrice).ToList();

            return searchResponse;
        }

        private static List<Flight> GetFlightsForHolidaySearch(string travellingTo, IEnumerable<Flight> flights, List<string> departureAirports, DateOnly departureDate)
        {
            var matchingFlights = new List<Flight>();
            foreach (var departureAirport in departureAirports)
            {
                var matchingFlightsByDepartureAirport = flights.Where(f =>
                f.From.Equals(departureAirport, StringComparison.InvariantCultureIgnoreCase)
                && f.To.Equals(travellingTo, StringComparison.InvariantCultureIgnoreCase)
                && f.DepartureDate.Equals(departureDate));
                if (!matchingFlightsByDepartureAirport.Any()) continue;
                matchingFlights.AddRange(matchingFlightsByDepartureAirport);
            }

            if (!matchingFlights.Any()) return new List<Flight>();

            return matchingFlights.OrderBy(x => x.Price).ToList();
        }

        private static List<Hotel> GetHotelsForHolidaySearch(string arrivalAirport, DateOnly arrivalDate, int duration, IEnumerable<Hotel> hotels)
        {
            var matchingHotels = hotels.Where(hotel =>
                hotel.LocalAirports.Any(airport => airport.Equals(arrivalAirport, StringComparison.InvariantCultureIgnoreCase))
                && DateOnly.Parse(hotel.ArrivalDate).Equals(arrivalDate)
                && hotel.Nights == duration
            );

            if (!matchingHotels.Any()) return new List<Hotel>();

            return matchingHotels.OrderBy(h => h.PricePerNight).ToList();
        }
    }
}
