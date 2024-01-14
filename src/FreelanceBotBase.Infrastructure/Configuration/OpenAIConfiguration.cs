namespace FreelanceBotBase.Infrastructure.Configuration
{
    /// <summary>
    /// Provides configuration options for ChatGPT service.
    /// </summary>
    public class OpenAIConfiguration
    {
        /// <summary>
        /// Configuration route.
        /// </summary>
        public static readonly string Configuration = "OpenAIConfiguration";

        public string ApiKey { get; set; } = string.Empty;
    }
}
