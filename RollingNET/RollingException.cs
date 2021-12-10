using System;


namespace RollingRess.Exceptions
{
    public class RollingException : Exception
    {
        public RollingException() : base() { }
        public RollingException(string message) : base(message) { }
    }

    public class NetworkNotAvailableException : RollingException
    {
        public NetworkNotAvailableException() : base("Network is not available.") { }
        public NetworkNotAvailableException(string message) : base(message) { }
    }
}
