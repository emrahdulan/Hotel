namespace Hotel.WebAPI.Dto.GuestDto
{
    public class GuestSearchDto
    {
        /// <summary>
        /// Broj rezultata po stranici
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// Broj stranice koja se vraća
        /// </summary>
        public int Page { get; set; }

        public string? Name { get; set; }
    }
}

