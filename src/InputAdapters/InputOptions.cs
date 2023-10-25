namespace HolidaySearchApplication.InputAdapters
{
    public class InputOptions<T> where T : IOptions
    {
        public InputOptions(T options)
        {
            Options = options;
        }

        public T Options { get; }
    }
}