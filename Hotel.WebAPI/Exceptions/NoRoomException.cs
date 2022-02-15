namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoRoomException : Exception
    {
        public NoRoomException() { }
        public NoRoomException(string message) : base(message) { }
        public NoRoomException(string message, Exception inner) : base(message, inner) { }
        protected NoRoomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}