using HolidaySearchApplication.QueryModel;

namespace HolidaySearchApplication.SearchEngine
{
    public interface ISearchEngine<T, Data> where T : ISearchBase
        where Data : class, ISearchResponseBase
    {
        SearchResult<Data> Search(T searchCriteria);
    }
}
