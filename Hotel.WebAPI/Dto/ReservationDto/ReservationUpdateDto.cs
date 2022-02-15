namespace Hotel.WebAPI.Dto.ReservationDto
{
    public class ReservationUpdateDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string GuestId { get; set; }
        public int ReservationDate { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int ZipCode { get; set; }
    }
}