namespace HolidaySearchApplication.InputAdapters
{
    public class SourceOptions<T> where T : IOptions
    {
        public SourceOptions(T options)
        {
            Options = options;
        }

        public T Options { get; }
    }
}