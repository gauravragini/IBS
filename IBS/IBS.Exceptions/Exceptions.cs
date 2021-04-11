using System;
using System.Collections.Generic;
using System.Text;

namespace IBS.Exceptions
{
    public class Exceptions
    {
        public class FirstDepositException : Exception
        {
            public FirstDepositException() : base() { }
            public FirstDepositException(string message) : base(message) { }
        }

        public class InsufficientBalanceException : Exception
        {
            public InsufficientBalanceException() : base() { }
            public InsufficientBalanceException(string message) : base(message) { }
        }

        public class AccountDoesNotExistException : Exception
        {
            public AccountDoesNotExistException() : base() { }
            public AccountDoesNotExistException(string message) : base(message) { }
        }

        public class InterestException : Exception
        {
            public InterestException() : base() { }
            public InterestException(string message) : base(message) { }
        }
    }
}
