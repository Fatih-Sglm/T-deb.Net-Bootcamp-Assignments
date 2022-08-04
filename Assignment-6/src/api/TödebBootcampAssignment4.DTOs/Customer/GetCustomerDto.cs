using System;

namespace TödebBootcampAssignment4.DTOs.Customer
{
    public class GetCustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
