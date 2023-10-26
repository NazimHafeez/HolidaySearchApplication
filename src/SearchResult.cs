namespace HolidaySearchApplication
{
    public class SearchResult<Data> where Data : class
    {
        public bool Success { get; set; }
        public string Error  => "";
        public Data? Value { get; set; }
    }
}