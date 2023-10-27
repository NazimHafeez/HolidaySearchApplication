using FluentAssertions;
using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.DomainModel.Hotel;
using HolidaySearchApplication.InputAdapters;
using HolidaySearchApplication.Repository;
using HolidaySearchApplication.SearchEngine;
using HolidaySearchApplication.Validators;

namespace UnitTests
{
    public class InputTests
    {
        private IRepository<Hotel> _hotelRepository;
        private IRepository<Flight> _flightRepository;
        private HolidaySearchEngine _searchEngine;
        public InputTests()
        {
            InitializeTestData();
        }

        [Theory]
        [InlineData("MAN", "AGP", "2023/07/01", 7, 2, 9)]
        [InlineData("Any LONDON Airport", "PMI", "2023/06/15", 10, 6, 5)]
        [InlineData("Any Airport", "LPA", "2022/11/10", 14, 7, 6)]
        public void SearchExerciseTests(string from, string to, string departureDate, int duration, int expectedFlightId, int expectedHotelId)
        {
            // Holiday Search Input
            var searchInput = new HolidaySearchApplication.QueryModel.HolidaySearch { DepartingFrom = from, TravellingTo = to, DepartureDate = departureDate, Duration = duration };

            // Execute Query
            var searchResult = _searchEngine.Search(searchInput);

            searchResult.Success.Should().BeTrue();

            // Best Result
            var bestResult = searchResult.Value.Results.First();
            bestResult.Flight.Id.Should().Be(expectedFlightId);
            bestResult.Hotel.Id.Should().Be(expectedHotelId);

        }

        private SourceOptions<JsonFileSourceAdapterOptions> GetJsonFileAdapterOptions(string jsonFileName)
        {
            var jsonInputFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName) + $"\\TestData\\{jsonFileName}";
            return new SourceOptions<JsonFileSourceAdapterOptions>(new JsonFileSourceAdapterOptions { JsonFile = jsonInputFile });
        }

        private void InitializeTestData()
        {
            _hotelRepository = new HotelRepository();
            _flightRepository = new FlightRepository();
            var flights = new JsonFileSourceAdapter().Read<Flight>(GetJsonFileAdapterOptions("Flights.json"));
            var hotels = new JsonFileSourceAdapter().Read<Hotel>(GetJsonFileAdapterOptions("Hotels.json"));
            _flightRepository.AddRange(flights);
            _hotelRepository.AddRange(hotels);
            _searchEngine = new HolidaySearchEngine(new HolidaySearchValidator(), _hotelRepository, _flightRepository);
        }
    }
}
