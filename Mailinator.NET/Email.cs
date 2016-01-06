using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mailinator
{
    public class Email
    {
        [JsonProperty("fromfull")]
        public string FromEmail { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Subject { get; set; }
        public int RequestId { get; set; }
        public string IP { get; set; }
        public IEnumerable<EmailParts> Parts { get; set; }
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
