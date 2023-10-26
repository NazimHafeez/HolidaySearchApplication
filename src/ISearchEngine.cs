using HolidaySearchApplication.QueryModel;

namespace HolidaySearchApplication
{
    public interface ISearchEngine<T, Data> where T: ISearchBase
        where Data : class
    {
        SearchResult<Data> Search(T searchCriteria);
    }
}
