using DomainLayer.Models.User;

namespace PresentationLayer.Presenters.Common
{
    public interface ISession
    {
        UserDTO GetUser();
        void SetUser(UserDTO user);
    }
}