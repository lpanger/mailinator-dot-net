using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mailinator
{
    public class EmailParts
    {
        [JsonProperty("fromfull")]
        public string FromEmail { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string Subject { get; set; }
        public string RequestId { get; set; }
        public string IP { get; set; }
        public Dictionary<string, string> Parts { get; set; }
        [JsonProperty("from")]
        public string FromName { get; set; }
        [JsonProperty("been_read")]
        public bool IsRead { get; set; }
        public string ToEmail { get; set; }
        public string Id { get; set; }
        public long Time { get; set; }
        [JsonProperty("seconds_ago")]
        public long SecondsAgo { get; set; }
    }
}
