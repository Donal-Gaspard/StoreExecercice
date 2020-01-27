using System;
using System.Collections.Generic;
using System.Text;

namespace @StoreExecercice.Exceptions
{
    public class StoreNotLoadExceException : Exception
    {
        public StoreNotLoadExceException()
        {}
        public StoreNotLoadExceException(string message) : base(message)
        {}

        public StoreNotLoadExceException(string message, Exception inner) : base(message, inner)
        {}
    }
}
