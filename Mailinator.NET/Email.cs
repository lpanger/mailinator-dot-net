using System.Collections.Generic;

namespace Mailinator.NET
{
    public class Email
    {
        private long _secondsAgo;
        private string _id;
        private string _to;
        private long _time;
        private string _subject;
        private string _fromFull;
        private Dictionary<string, string> _headers;
    }
}
