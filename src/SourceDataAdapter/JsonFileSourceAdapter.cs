using System.Text.Json;

namespace HolidaySearchApplication.InputAdapters
{
    public class JsonFileSourceAdapter : ISourceDataAdapter<JsonFileSourceAdapterOptions>
    {
        public IReadOnlyList<InputModel> Read<InputModel, OptionsType>(SourceOptions<OptionsType> inputOptions)
            where InputModel : class
            where OptionsType : IOptions
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<InputModel> Read<InputModel>(SourceOptions<JsonFileSourceAdapterOptions> inputOptions)
        {
            var jsonString = File.ReadAllText(inputOptions.Options.JsonFile);
            if (jsonString == null) 
            {
                return new List<InputModel>();
            }

            return JsonSerializer.Deserialize<List<InputModel>>(
                jsonString, JsonFileSourceAdapterOptions.SerializationOptions) ?? new List<InputModel>();
        }
    }
}