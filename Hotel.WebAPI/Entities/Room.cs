namespace Hotel.WebAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelID { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
