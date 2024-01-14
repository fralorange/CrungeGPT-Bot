using ChatGPT.Net;
using FreelanceBotBase.Bot.Commands.Base;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FreelanceBotBase.Bot.Commands.Ask
{
    public class AskCommand : CommandBase
    {
        private readonly ChatGpt _chatGpt;

        public AskCommand(ITelegramBotClient botClient, ChatGpt chatGpt) : base(botClient) 
            => _chatGpt = chatGpt;

        public override async Task<Message> ExecuteAsync(Message message, CancellationToken cancellationToken)
        {
            var parts = message.Text!.Split(' ', 2);

            var response = parts.Length > 1 
                ? await _chatGpt.Ask(parts[1]) 
                : "Чтобы что-то спросить надо что-то спросить! (с) Кличко.. возможно";

            return await BotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: response,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }
    }
}
