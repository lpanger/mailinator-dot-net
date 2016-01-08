using System.Collections.Generic;

namespace Mailinator
{
    public class EmailParts
    {
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}
