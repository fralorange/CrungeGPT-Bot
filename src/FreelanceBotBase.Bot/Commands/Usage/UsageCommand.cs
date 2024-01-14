using FreelanceBotBase.Bot.Commands.Base;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace FreelanceBotBase.Bot.Commands.Usage
{
    public class UsageCommand : CommandBase
    {
        public UsageCommand(ITelegramBotClient botClient) : base(botClient) { }

        public override async Task<Message> ExecuteAsync(Message message, CancellationToken cancellationToken)
        {
            const string usage = "Usage\n" +
                     "/ask <args> - Спросить бота о чём либо, ответ идёт на базе GPT 3.5;\n" +
                     "/usage - Вывести данный список команд.";

            return await BotClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: usage,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }
    }
}
