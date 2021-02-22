using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException() : base()
        {

        }

        public EntityAlreadyExistsException(string message) : base(message)
        {

        }
    }
}
