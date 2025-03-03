using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Options;

namespace ACG_Api2.Middleware
{

    public class TelegramBot
    {
        private readonly TelegramBotSettings _settings;
        private TelegramBotClient _bot;
        private readonly long _chatId;
        private CancellationTokenSource? _cts;

        public TelegramBot() { }

        public TelegramBot(IOptions<TelegramBotSettings> options)
        {
            _settings = options.Value;
            _bot = new TelegramBotClient(_settings.TelegramBotApi);
            _chatId = _settings.TelegramBotUser;
        }

        public async Task BotStart()
        {
            _cts = new CancellationTokenSource();
            _bot = new TelegramBotClient(_settings.TelegramBotApi);
            var me = await _bot.GetMe();
            _bot.OnError += OnError;
            _bot.OnMessage += OnMessage;
            _bot.OnUpdate += OnUpdate;
            Console.WriteLine($"Bot @{me.Username} is running...");
        }

        public async Task SendErrorMessage(string message)
        {
            try
            {
                Console.WriteLine("Attempting to send message...");
                await _bot.SendMessage(_chatId, message);
                Console.WriteLine("Message sent.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        async Task OnMessage(Message msg, UpdateType type)
        {
            var chatId = msg.Chat.Id;
            if (msg.Text is null) return;
            Console.WriteLine($"Received message: {msg.Text} in chat {chatId}");
            await _bot.SendMessage(msg.Chat.Id, $"{msg.From} said: {msg.Text}");
        }

        async Task OnError(Exception exception, HandleErrorSource source)
        {
            Console.WriteLine($"Error: {exception.Message}");
            await _bot.SendMessage(_chatId, exception.ToString());
        }

        async Task OnUpdate(Telegram.Bot.Types.Update update)
        {
            if (update.CallbackQuery != null)
            {
                await _bot.AnswerCallbackQuery(update.CallbackQuery.Id, $"You picked {update.CallbackQuery.Data}");
                await _bot.SendMessage(update.CallbackQuery.Message.Chat.Id, $"User {update.CallbackQuery.From.Username} clicked on {update.CallbackQuery.Data}");
            }
        }

        public async Task StopBot(bool end)
        {
            if (end && _cts != null)
            {
                _cts.Cancel();
                Console.WriteLine("Bot stopped.");
            }
        }
    }

    public class TelegramBotSettings
    {
        public string TelegramBotApi { get; set; } = "ur api";
        public long TelegramBotUser { get; set; }
    }
}
