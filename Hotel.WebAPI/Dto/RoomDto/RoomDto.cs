namespace Hotel.WebAPI.Dto.RoomDto
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int HotelID { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        
    }
}
