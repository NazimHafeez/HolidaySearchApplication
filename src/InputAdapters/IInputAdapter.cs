namespace HolidaySearchApplication.InputAdapters
{
    public interface IInputAdapter<OptionType> where OptionType : IOptions
    {
        IReadOnlyList<InputModel> Read<InputModel>(InputOptions<OptionType> inputOptions);
    }
}