using DomainLayer.Models.User;

namespace PresentationLayer.Presenters.Common
{
    public class Session : ISession
    {
        private UserDTO currentUser;

        public void SetUser(UserDTO user) {
            currentUser = user;
        }

        public UserDTO GetUser()
        {
            return currentUser;
        }

    }
}
