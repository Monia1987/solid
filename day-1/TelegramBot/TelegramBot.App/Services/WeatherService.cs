using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using TelegramBot.App.Models;

namespace TelegramBot.App.Services
{
    public class WeatherService
    {
        string url = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";

        public Weather GetWeatherForCity(string city)
        {
            WebUtility.UrlEncode(city);

            WebRequest request = WebRequest.Create(string.Format(url, city, weatherApiKey));
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();

                var weatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(responseString);

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
}
