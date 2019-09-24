using DomainLayer.Models.User;

namespace ServiceLayer.Services.UserService
{
    public class UserService :  IUserService
    {

        private IUserRepository userRepository;

        public UserService() { }

        public UserService(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public void Create(UserDTO userDTO)
        {
            userRepository.Create(user_dtoToModel(userDTO));
        }

        public UserDTO GetByFirstAndLastName(string firstName, string lastName)
        {
            return user_modelToDto(userRepository.GetByFirstAndLastName(firstName, lastName));
        }

        private UserDTO user_modelToDto(IUserModel e)
        {
            UserDTO dto = new UserDTO();
            dto.UserId = e.UserId;
            dto.FirstName = e.FirstName;
            dto.LastName = e.LastName;
            dto.CarModel = e.CarModel;
            return dto;
        }
        private IUserModel user_dtoToModel(UserDTO dto)
        {
            UserModel model = new UserModel();
            model.UserId = dto.UserId;
            model.FirstName = dto.FirstName;
            model.LastName = dto.LastName;
            model.CarModel = dto.CarModel;
            return model;
        }



    }
}
