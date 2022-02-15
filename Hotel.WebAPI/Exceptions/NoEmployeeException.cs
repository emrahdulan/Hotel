namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoEmployeeException : Exception
    {
        public NoEmployeeException() { }
        public NoEmployeeException(string message) : base(message) { }
        public NoEmployeeException(string message, Exception inner) : base(message, inner) { }
        protected NoEmployeeException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}