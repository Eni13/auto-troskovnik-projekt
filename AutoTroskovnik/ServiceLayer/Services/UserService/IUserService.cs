using DomainLayer.Models.User;
using System;

namespace ServiceLayer.Services.UserService
{
    public interface IUserService
    {
        void Create(UserDTO userDTO);

        UserDTO GetByFirstAndLastName(String firstName, String lastName);
    }
}
