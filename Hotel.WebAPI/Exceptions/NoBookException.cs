namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoBookException : Exception
    {
        public NoBookException() { }
        public NoBookException(string message) : base(message) { }
        public NoBookException(string message, Exception inner) : base(message, inner) { }
        protected NoBookException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
