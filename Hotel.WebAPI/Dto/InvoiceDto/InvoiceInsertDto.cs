using Hotel.WebAPI.Entities;

namespace Hotel.WebAPI.Dto.InvoiceDto
{
    public class InvoiceInsertDto
    {
        public string Name { get; set; }
        public Reservation Reservation { get; set; }
        // change int to Guest after merge
        public int Guest { get; set; }
        public float Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string Cvc { get; set; }
    }
}
