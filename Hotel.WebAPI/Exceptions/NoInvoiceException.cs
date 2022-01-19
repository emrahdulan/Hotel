namespace Hotel.WebAPI.Exceptions
{
    [Serializable]
    public class NoInvoiceException : Exception
    {
        public NoInvoiceException() { }
        public NoInvoiceException(string message) : base(message) { }
        public NoInvoiceException(string message, Exception inner) : base(message, inner) { }
        protected NoInvoiceException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
