using System.Collections.Generic;
using System.Linq;
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

        public string HtmlBody
        {
            get
            {
                var htmlPart = Parts.FirstOrDefault(p => p.Headers["content-type"].Contains("text/html"));
                return htmlPart != null ? htmlPart.Body : null;
            }
        }

        public string TextBody
        {
            get
            {
                var textBody = Parts.FirstOrDefault(p => p.Headers["content-type"].Contains("text/plain"));
                return textBody != null ? textBody.Body : null;
            }
        }

        /// <summary>
        /// Collection of string pairs. Key is the attachment filename and value is Base64 strings representation of attached file
        /// </summary>
        public IEnumerable<Attachment> Attachments
        {
            get
            {
                var col = new List<Attachment>();
                
                var attachments = Parts.Where(p => p.Headers["content-type"].Contains("octet-stream"));

                foreach (var attachment in attachments)
                {
                    var contentTypes = attachment.Headers["content-type"].Split(';');
                    var type = contentTypes.First(t => t.Trim().StartsWith("name"));
                    
                    var originalFilename = type.Split('=')[1];
                    var filename = originalFilename.Substring(1, originalFilename.Length - 2); // drop first and last double quote

                    var fileContentsAsString = attachment.Body.Replace("\r\n", string.Empty); // cleanup json body by removing carriage returns

                    col.Add(new Attachment(filename, fileContentsAsString));
                }

                return col;
            }
        }
    }
}
