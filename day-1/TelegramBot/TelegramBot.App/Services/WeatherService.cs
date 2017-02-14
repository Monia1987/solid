using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TelegramBot.App.Models.WeatherModels;
using TelegramBot.App.Parsers;

namespace TelegramBot.App.Services
{
    public class WeatherService
    {
        private readonly HttpService _httpService;
        private readonly JsonParser _jsonParser;

        string url = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";

        public WeatherService(HttpService httpService, JsonParser jsonParser)
        {
            _httpService = httpService;
            _jsonParser = jsonParser;
        }

        public async Task<Weather> GetWeatherForCityAsync(string city)
        {
            WebUtility.UrlEncode(city);

            var weatherJson = await _httpService.GetAsync(string.Format(url, city, weatherApiKey));
            var weatherResponce = _jsonParser.Parse<WeatherResponce>(weatherJson);
            var details = weatherResponce.Weather.First();

            return new Weather
                {
                    Name = weatherResponce.Name,
                    Description = details.Description,
                    Temperature = weatherResponce.Main.Temp
                };
        }
    }
}

