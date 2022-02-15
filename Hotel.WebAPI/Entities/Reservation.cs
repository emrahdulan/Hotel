namespace Hotel.WebAPI.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int  RoomId { get; set; }
        public string GuestId { get; set; }
        public int ReservationDate  { get; set; }
        public int  Adults { get; set; }
        public int Children { get; set; }
        public int ZipCode { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}