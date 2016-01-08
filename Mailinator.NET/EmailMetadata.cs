using Newtonsoft.Json;

namespace Mailinator
{
    public class EmailMetadata
    {
        [JsonProperty("fromfull")]
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string IP { get; set; }
        [JsonProperty("from")]
        public string FromName { get; set; }
        [JsonProperty("been_read")]
        public bool IsRead { get; set; }
        [JsonProperty("to")]
        public string ToEmail { get; set; }
        public string Id { get; set; }
        public long Time { get; set; }
        [JsonProperty("seconds_ago")]
        public long SecondsAgo { get; set; }
    }
}
