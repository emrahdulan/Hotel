namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoGuestException : Exception
    {
        public NoGuestException() { }
        public NoGuestException(string message) : base(message) { }
        public NoGuestException(string message, Exception inner) : base(message, inner) { }
        protected NoGuestException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}


