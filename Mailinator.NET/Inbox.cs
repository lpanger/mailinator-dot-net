using System.Collections.Generic;

namespace Mailinator
{
    public class Inbox
    {
        public IEnumerable<EmailMetadata> Messages { get; set; }
    }
}
