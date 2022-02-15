namespace Hotel.WebAPI.Dto.EmployeeDto
{
    public class EmployeeSearchDto
    {
        
        public int PageSize { get; set; } = 10;

      
        public int Page { get; set; }

        public string? Name { get; set; }
    }
}
