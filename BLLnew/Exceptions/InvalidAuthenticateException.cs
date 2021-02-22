using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Exceptions
{
    public class InvalidAuthenticateException: Exception
    {
        public InvalidAuthenticateException(): base()
        {

        }

        public InvalidAuthenticateException(string message): base(message)
        {

        }
    }
}
