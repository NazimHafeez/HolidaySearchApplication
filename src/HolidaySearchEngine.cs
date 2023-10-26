using HolidaySearchApplication.QueryModel;

namespace HolidaySearchApplication
{
    public class HolidaySearchEngine : ISearchEngine<HolidaySearch, HolidaySearchResponse>
    {
        public SearchResult<HolidaySearchResponse> Search(HolidaySearch searchCriteria)
        {
            return new SearchResult<HolidaySearchResponse> { Success = false, Value = new HolidaySearchResponse { Flight = new DomainModel.Flight.Flight(), Hotel = new DomainModel.Hotel.Hotel() } };
        }
    }
}
