using System;

namespace Mailinator
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(string message) :
            base(message)
        {
            
        }
    }
}
