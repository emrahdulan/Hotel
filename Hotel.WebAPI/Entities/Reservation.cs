namespace Hotel.WebAPI.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // change int to Room
        public int Room { get; set; }
        // change int to Guest
        public int Guest { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public int AdultsNum { get; set; }
        public int ChildrenNum { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
