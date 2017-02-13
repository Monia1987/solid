using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBot.App.Services;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Commands
{
    public class RateCommand : BaseCommand
    {
        public override Guid Id => new Guid("68FDBC43-B8DB-47B9-B1BC-CF0581108A49");

        public RateService RateService { get; set; }

        public RateCommand(ICommandContext context, ITelegramBotClient botClient, RateService rateService)
            : base(context, botClient)
        {
            RateService = rateService;
        }

        public override async Task OnExecute(ICommandInput input)
        {
            await Client.SendChatActionAsync(Context.ChatId, ChatAction.Typing);
            
            var rate = await RateService.GetTodayUsdRate();
            var t = await Client.SendTextMessageAsync(Context.ChatId, $"Rate: {rate.Rate}");
        }
        
    }
}
