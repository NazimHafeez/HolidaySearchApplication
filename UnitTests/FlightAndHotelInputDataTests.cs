using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.DomainModel.Hotel;
using HolidaySearchApplication.InputAdapters;
using FluentAssertions;

namespace UnitTests
{
    public class FlightAndHotelInputDataTests
    {
        [Fact]
        public void ReadFlightInputData()
        {
            var data= new JsonFileSourceAdapter().Read<Flight>(GetJsonFileAdapterOptions("Flights.json"));
            
            // Asserts
            data.Should().NotBeNull();
            data.Count.Should().Be(12);
            data[0].Airline.Should().Be("First Class Air");  // This confirms that the deserialization worked
        }

        [Fact]
        public void ReadHotelInputData()
        {
            var data = new JsonFileSourceAdapter().Read<Hotel>(GetJsonFileAdapterOptions("Hotels.json"));
            Assert.NotNull(data);

            // Asserts
            data.Should().NotBeNull();
            data.Count.Should().Be(13);
            data[0].Name.Should().Be("Iberostar Grand Portals Nous");  // This confirms that the deserialization worked
        }

        [Fact]
        public void ReadEmptyJsonInput()
        {
            var data = new JsonFileSourceAdapter().Read<Hotel>(GetJsonFileAdapterOptions("EmptyInput.json"));
            Assert.NotNull(data);

            // Asserts
            data.Should().BeEmpty();
            data.Count.Should().Be(0);
        }

        private SourceOptions<JsonFileSourceAdapterOptions> GetJsonFileAdapterOptions(string jsonFileName)
        {
            var jsonInputFile = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName) + $"\\TestData\\{jsonFileName}";
            return new SourceOptions<JsonFileSourceAdapterOptions>(new JsonFileSourceAdapterOptions { JsonFile = jsonInputFile });
        }
    }
}