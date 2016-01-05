using System;

namespace Mailinator.NET
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(string message) :
            base(message)
        {
            
        }
    }
}
