using System.Text.Json.Serialization;

namespace SantanderTest.Model
{
    public class BestStoryResponse
    {
        [JsonPropertyName("by")]
        public string PostedBy { get; set; } = string.Empty;

        [JsonPropertyName("descendants")]
        public long Descendants { get; set; }

        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("time")]
        public long Time { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }
}
