using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBot.App.Services;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Commands
{
    public class DefaultCommand : BaseCommand
    {
        private readonly DummyMessagesService _messagesService;

        public override Guid Id => new Guid("2C2449E4-E0A0-435A-BC53-6725FBECC109");

        public DefaultCommand(ICommandContext context, ITelegramBotClient botClient, DummyMessagesService messagesService) 
            : base(context, botClient)
        {
            _messagesService = messagesService;
        }

        
        public override async Task OnExecute(ICommandInput input)
        {
            if (ShouldISpam() == false)
                return;

            await Client.SendChatActionAsync(Context.ChatId, ChatAction.Typing);
            await Task.Delay(1000);
            await Client.SendTextMessageAsync(Context.ChatId, _messagesService.GetPhrase());
        }

        private bool ShouldISpam()
        {
            return Context.LastCommandId.HasValue == false;
        }
    }
}
