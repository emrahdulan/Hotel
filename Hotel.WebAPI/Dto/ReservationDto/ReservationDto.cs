namespace Hotel.WebAPI.Dto.ReservationDto
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // change int to Room
        public int Room { get; set; }
        // change int to Guest
        public int Guest { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        // DateOnly doesnt support serialization
        public string ArrivalDate { get; set; }
        // DateOnly doesnt support serialization
        public string DepartureDate { get; set; }
        public int AdultsNum { get; set; }
        public int ChildrenNum { get; set; }
    }
}
