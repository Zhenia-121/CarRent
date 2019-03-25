using System;

namespace CarRent.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}