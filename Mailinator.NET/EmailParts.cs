using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mailinator
{
    public class EmailParts
    {
        public Dictionary<string, string> Headers { get; set; }
        public string Body { get; set; }
    }
}
