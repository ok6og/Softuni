using System;
using System.Collections.Generic;
using System.Text;

namespace _3._Telephony
{
    using _3._Telephony.Exceptions;
    using _3._Telephony.Interfaces;
    using System.Linq;

    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }
            return "Dialing... " + phoneNumber;
        }
    }
}
