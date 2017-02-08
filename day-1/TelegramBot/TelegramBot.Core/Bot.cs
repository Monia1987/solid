using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBot.Core
{
    public class Bot
    {
        private BotInfo botInfo;
        private TelegramBotClient botClient;
        private User botUser;


        public Bot(BotInfo botInfo)
        {
            this.botInfo = botInfo;
        }

        public async Task Awake()
        {
            botClient = new TelegramBotClient(botInfo.ApiToken);
            botUser = await botClient.GetMeAsync();
        }

        public async Task Run()
        {
            var offset = 0;

            while (true)
            {
                var updates = await botClient.GetUpdatesAsync(offset);

                foreach (var update in updates)
                {
                    await botClient.SendChatActionAsync(update.Message.Chat.Id, ChatAction.Typing);
                    await Task.Delay(1000);
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, "May the force be with you");

                    offset = update.Id + 1;
                }

                await Task.Delay(1000);
            }
        }
    }
}
