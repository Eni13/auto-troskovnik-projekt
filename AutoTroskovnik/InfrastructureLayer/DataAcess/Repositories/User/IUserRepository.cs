using DomainLayer.Models.User;
using System;

namespace ServiceLayer.Services.UserService
{
    public interface IUserRepository
    {
        void Create(IUserModel userModel);

        IUserModel GetByFirstAndLastName(String firstName, String lastName);
    }
}