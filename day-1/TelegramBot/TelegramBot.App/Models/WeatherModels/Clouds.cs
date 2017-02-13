using Newtonsoft.Json;

namespace TelegramBot.App.Models.WeatherModels
{
    public class Clouds
    {

        [JsonProperty("all")]
        public int All { get; set; }
    }
}