using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBot.App.Services;
using TelegramBot.Core;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Commands
{
    public class WeatherCommand : BaseCommand
    {
        public override Guid Id => new Guid("93EBAAE7-29A2-4EA1-A895-12202144F139");

        public WeatherService WeatherService { get; set; }

        public WeatherCommand(ICommandContext context, ITelegramBotClient botClient, BotLogger logger, WeatherService weatherService)
            : base(context, botClient, logger)
        {
            WeatherService = weatherService;
        }

        public override async Task OnExecute(ICommandInput input)
        {
            await Client.SendChatActionAsync(Context.ChatId, ChatAction.Typing);
            var inputMessage = input.Text;
            var messageParts = inputMessage.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
            var weather = await WeatherService.GetWeatherForCityAsync(city);

            var t = await Client.SendTextMessageAsync(Context.ChatId, $"In {city} {weather.Description} and the temperature is {weather.Temperature:+#;-#}°C");
        }
        
    }
}
