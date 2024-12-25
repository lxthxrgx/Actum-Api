using Microsoft.Extensions.Options;

namespace ACG_Api2.Model.TelegramBotSettings
{
    public class Settings
    {
        public string TelegramBotApi { get; set; }
        public long TelegramBotUser { get; set; }
    }
}
