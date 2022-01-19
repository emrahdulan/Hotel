namespace Hotel.WebAPI.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Reservation Reservation { get; set; }
        // change int to Guest after merge
        public int Guest { get; set; }
        public float Price { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public string CreditCard { get; set; }
        public string ExpDate { get; set; }
        public string Cvc { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
