using Newtonsoft.Json;

namespace TelegramBot.App.Models
{
    public class Wind
    {

        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public double Deg { get; set; }
    }
}