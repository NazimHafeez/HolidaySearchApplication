using System.Text.Json;

namespace HolidaySearchApplication.InputAdapters
{
    public class JsonFileAdapter : IInputAdapter<JsonFileAdapterOptions>
    {
        public IReadOnlyList<InputModel> Read<InputModel, OptionsType>(InputOptions<OptionsType> inputOptions)
            where InputModel : class
            where OptionsType : IOptions
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<InputModel> Read<InputModel>(InputOptions<JsonFileAdapterOptions> inputOptions)
        {
            var jsonString = File.ReadAllText(inputOptions.Options.JsonFile);
            if (jsonString == null) 
            {
                return new List<InputModel>();
            }

            return JsonSerializer.Deserialize<List<InputModel>>(
                jsonString, JsonFileAdapterOptions.SerializationOptions) ?? new List<InputModel>();
        }
    }
}