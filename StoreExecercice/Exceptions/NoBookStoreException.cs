using System;

namespace @StoreExecercice.Exceptions
{
    public class NoBookStoreException: Exception
    {
        public NoBookStoreException() 
        {}

        public NoBookStoreException(string message) : base(message)
        {}

        public NoBookStoreException(string message,Exception inner) : base(message, inner)
        {}
    }
}
