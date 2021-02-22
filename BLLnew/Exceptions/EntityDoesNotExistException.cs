using System;
using System.Collections.Generic;
using System.Text;

namespace BLLnew.Exceptions
{
    public class EntityDoesNotExistException : Exception
    {
        public EntityDoesNotExistException() : base()
        {

        }

        public EntityDoesNotExistException(string message) : base(message)
        {

        }
    }
}
