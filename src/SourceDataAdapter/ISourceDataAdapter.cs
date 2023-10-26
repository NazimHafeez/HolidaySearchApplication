namespace HolidaySearchApplication.InputAdapters
{
    public interface ISourceDataAdapter<OptionType> where OptionType : IOptions
    {
        IReadOnlyList<InputModel> Read<InputModel>(SourceOptions<OptionType> inputOptions);
    }
}