using _3._Telephony.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using _3._Telephony.Exceptions;

namespace _3._Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
            return "Browsing: " + url + "!";
        }

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return "Calling... " + phoneNumber;
        }
    }
}
