using Hotel.WebAPI.Entities;

namespace Hotel.WebAPI.Dto.InvoiceDto
{
    public class InvoiceUpdateDto
    {
        public string Name { get; set; }
        public Reservation Reservation { get; set; }
        // change int to Guest after merge
        public int Guest { get; set; }
        public float Price { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
