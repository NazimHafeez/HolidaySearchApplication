using HolidaySearchApplication.DomainModel.Flight;
using HolidaySearchApplication.DomainModel.Hotel;

namespace HolidaySearchApplication.QueryModel
{
    public class HolidaySearchResponse: ISearchResponseBase
    {
        public List<Flight> Flights { get; set; }

        public List<Hotel> Hotels { get; set; }

        public List<HolidayPackage> Results { get; set; }
    }
}
