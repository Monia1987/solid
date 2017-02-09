using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBot.App.Services;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Commands
{
    public class WeatherCommand : BaseCommand
    {
        public override Guid Id => new Guid("93EBAAE7-29A2-4EA1-A895-12202144F139");

        public WeatherService WeatherService { get; set; }

        public WeatherCommand(WeatherService weatherService)
        {
            WeatherService = weatherService;
        }

        public override async Task OnExecute(ITelegramBotClient client, ICommandInput input)
        {
            await client.SendChatActionAsync(Context.ChatId, ChatAction.Typing);
            var inputMessage = input.Text;
            var messageParts = inputMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
            var weather = WeatherService.GetWeatherForCity(city);
            var t = await client.SendTextMessageAsync(Context.ChatId, "In " + city + " " + weather.Description + " and the temperature is " +
                          weather.Temperature.ToString("+#;-#") + "°C");
        }
        
    }
}
