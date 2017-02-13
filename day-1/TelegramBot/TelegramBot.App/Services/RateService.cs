using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TelegramBot.App.Models.RateModels;

namespace TelegramBot.App.Services
{
    public class RateService
    {
        string url = "http://www.nbrb.by/API/ExRates/Rates?Periodicity=0";
        
        public async Task<RateItem> GetTodayUsdRate()
        {
            var items = await GetRatesList();
            return items.FirstOrDefault(rateItem => rateItem.Code == "USD");
        }


        public async Task<IList<RateItem>> GetRatesList()
        {
            using (var httpClient = CreateClient())
            {
                try
                {
                    var response = await httpClient.GetAsync(url);
                    return await ProcessRescponse<List<RateItem>>(response);
                }
                catch (Exception ex)
                {
                    throw new Exception("GetRatesList exception", ex);
                }
            }
        }

        private async Task<T> ProcessRescponse<T>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(responseString);

            return result;
        }

        private HttpClient CreateClient(int timeout=0)
        {
            var httpClient = new HttpClient();
            if (timeout > 0)
                httpClient.Timeout = TimeSpan.FromMilliseconds(timeout);

            return httpClient;
        }
    }
}
