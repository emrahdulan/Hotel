namespace Hotel.WebAPI.Dto.RoomDto
{
    public class RoomSearchDto
    {
       
        public int PageSize { get; set; } = 10;

       
        public int Page { get; set; }

        public string? Name { get; set; }
    }
}
