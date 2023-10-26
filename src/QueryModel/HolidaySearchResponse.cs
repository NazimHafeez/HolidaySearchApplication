using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.DomainModel.Hotel;

namespace HolidaySearchApplication.QueryModel
{
    public class HolidaySearchResponse
    {
        public Flight Flight { get; set; }

        public Hotel Hotel { get; set; }

        public int TotalPrice => (Hotel.PricePerNight * Hotel.Nights) + Flight.Price;

    }
}
