namespace TelegramBot.Core
{
    public class BotInfo
    {
        public BotInfo(string apiToken)
        {
            ApiToken = apiToken;
        }

        public string ApiToken { get; }
    }
}
