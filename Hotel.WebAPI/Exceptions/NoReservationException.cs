namespace Hotel.WebAPI.Exceptions

{
    [Serializable]
    public class NoReservationException : Exception
    {
        public NoReservationException() { }
        public NoReservationException(string message) : base(message) { }
        public NoReservationException(string message, Exception inner) : base(message, inner) { }
        protected NoReservationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
