using System;
using Newtonsoft.Json;

namespace TelegramBot.App.Models.RateModels
{
    public class RateItem
    {
        [JsonProperty("Cur_ID")]
        public int CurrencyId { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("Cur_Abbreviation")]
        public string Code { get; set; }

        [JsonProperty("Cur_Scale")]
        public string Scale { get; set; }

        [JsonProperty("Cur_Name")]
        public string Name { get; set; }

        [JsonProperty("Cur_OfficialRate")]
        public decimal Rate { get; set; }
    }
}
