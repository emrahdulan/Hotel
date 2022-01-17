namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoHotelException : Exception
    {
        public NoHotelException() { }
        public NoHotelException(string message) : base(message) { }
        public NoHotelException(string message, Exception inner) : base(message, inner) { }
        protected NoHotelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
