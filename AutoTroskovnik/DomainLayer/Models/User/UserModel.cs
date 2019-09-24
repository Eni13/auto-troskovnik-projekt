using System;

namespace DomainLayer.Models.User
{
    public class UserModel : IUserModel
    {
        public UserModel() { }
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String CarModel { get; set; }

    }
}
