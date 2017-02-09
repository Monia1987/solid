using Newtonsoft.Json;

namespace TelegramBot.App.Models
{
    public class Clouds
    {

        [JsonProperty("all")]
        public int All { get; set; }
    }
}