using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using TelegramBot.Core.Commands;
using TelegramBot.Core.Context;
using TelegramBot.Core.Input;

namespace TelegramBot.App.Commands
{
    public class DefaultCommand : BaseCommand
    {
        private readonly List<string> _phrases = new List<string>
            {
                "May the force be with you",
                "Do. Or do not. There is no try.",
                "In my experience there is no such thing as luck.",
                "I find your lack of faith disturbing.",
                "I’ve got a bad feeling about this.",
                "It’s a trap!",
                "So this is how liberty dies…with thunderous applause.",
                "Your eyes can deceive you. Don’t trust them.",
                "Mind tricks don’t work on me.",
                "I’m one with the Force, and the Force will guide me.",
                "For my ally is the Force, and a powerful ally it is.",
                "Close your eyes. Feel it. The light…it’s always been there. It will guide you.",
                "Don’t underestimate the Force."
            };

        public override Guid Id => new Guid("2C2449E4-E0A0-435A-BC53-6725FBECC109");

        public override async Task OnExecute(ITelegramBotClient client, ICommandInput input)
        {
            await client.SendChatActionAsync(Context.ChatId, ChatAction.Typing);
            await Task.Delay(1000);
            await client.SendTextMessageAsync(Context.ChatId, GetPhrase());
        }

        private string GetPhrase()
        {
            return _phrases.OrderBy(x => Guid.NewGuid()).First();
        }

        public override bool IsApplicable(ICommandInput input)
        {
            return Context.LastCommandId.HasValue == false;
        }
    }
}
