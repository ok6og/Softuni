using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Telephony.Exceptions
{
    public class InvalidURLException : Exception
    {
        private const string Invalid_URL_exception_message = "Invalid URL!";
        public InvalidURLException()
            :base(Invalid_URL_exception_message)
        {

        }
    }
}
