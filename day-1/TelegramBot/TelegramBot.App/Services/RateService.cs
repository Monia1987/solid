using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.App.Models.RateModels;
using TelegramBot.App.Parsers;

namespace TelegramBot.App.Services
{
    public class RateService
    {
        private readonly HttpService _httpService;
        private readonly JsonParser _jsonParser;
        string url = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";

        public RateService(HttpService httpService, JsonParser jsonParser)
        {
            _httpService = httpService;
            _jsonParser = jsonParser;
        }
        
        public async Task<RateItem> GetTodayUsdRate()
        {
            var items = await GetRatesList();
            return items.FirstOrDefault(rateItem => rateItem.Code == "USD");
        }


        public async Task<IList<RateItem>> GetRatesList()
        {
            try
            {
                var result = await _httpService.GetAsync(url);
                return _jsonParser.Parse<List<RateItem>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRatesList exception", ex);
            }
        }
    }
}
