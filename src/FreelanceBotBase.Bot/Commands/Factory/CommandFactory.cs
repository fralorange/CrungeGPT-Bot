using ChatGPT.Net;
using FreelanceBotBase.Bot.Commands.Ask;
using FreelanceBotBase.Bot.Commands.Interface;
using FreelanceBotBase.Bot.Commands.Null;
using FreelanceBotBase.Bot.Commands.Usage;
using Telegram.Bot;

namespace FreelanceBotBase.Bot.Commands.Factory
{
    public class CommandFactory
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ChatGpt _chatGpt;

        public CommandFactory(ITelegramBotClient botClient, ChatGpt chatGpt)
        {
            _botClient = botClient;
            _chatGpt = chatGpt;
        }

        public ICommand CreateCommand(string commandName)
        {
            return commandName switch
            {
                "/ask" => new AskCommand(_botClient, _chatGpt),
                "/usage" => new UsageCommand(_botClient),
                _ => new NullCommand()
            };
        }
    }
}
