﻿namespace Hotel.WebAPI.Dto.HotelDto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int HotelID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Salary { get; set; }
    }
}
