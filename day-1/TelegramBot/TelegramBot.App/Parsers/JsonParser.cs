using Newtonsoft.Json;

namespace TelegramBot.App.Parsers
{
    public class JsonParser
    {
        public T Parse<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
    }
}
