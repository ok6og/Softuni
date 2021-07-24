using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Telephony.Exceptions
{
    public class InvalidPhoneNumberException : Exception
    {
        private const string Invalid_URL_exception_message = "Invalid number!";

        public InvalidPhoneNumberException()
            :base(Invalid_URL_exception_message)
        {

        }
    }
}
