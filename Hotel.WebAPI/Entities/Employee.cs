namespace Hotel.WebAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int HotelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
