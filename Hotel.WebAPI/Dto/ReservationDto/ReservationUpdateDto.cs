namespace Hotel.WebAPI.Dto.ReservationDto
{
    public class ReservationUpdateDto
    {
        public string Name { get; set; }
        public int Room { get; set; }
        // change int to Guest
        public int Guest { get; set; }
        public string ArrivalDate { get; set; }
        public string DepartureDate { get; set; }
        public int AdultsNum { get; set; }
        public int ChildrenNum { get; set; }
    }
}
