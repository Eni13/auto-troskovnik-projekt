using System;

namespace DomainLayer.Models.User
{
    public class UserDTO
    {
        public UserDTO() { }
        public int UserId { get; set; } = -1;
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }

    }
}
