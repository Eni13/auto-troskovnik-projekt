using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Views.UserControls;
using PresentationLayer.Views.ViewModels;
using ServiceLayer.Services.UserService;
using System;

namespace PresentationLayer.Presenters.UserControls
{
    public class RegistrationPresenter : IRegistrationPresenter
    {
        private IRegistrationViewUC _registrationViewUC;
        private IUserService _userService;
        public event EventHandler ShowLoginViewEvent;
        public event EventHandler<DataAccessException> DataAccessExceptionEvent;
        public event EventHandler<UserDTO> ShowMainViewEvent;

        public RegistrationPresenter(IRegistrationViewUC registrationViewUC, IUserService userService)
        {
            _registrationViewUC = registrationViewUC;
            _userService = userService;
            SubscribeToEvents();
        }
        public IRegistrationViewUC GetRegistrationViewUC()
        {
            return _registrationViewUC;
        }

        private void SubscribeToEvents()
        {
            _registrationViewUC.RegistrationClickEventRaised += new EventHandler<UserViewModel>(OnRegistrationClickEventRaised);
            _registrationViewUC.LoginRedirectEventRaised += new EventHandler(OnLoginRedirectClickEventRaised);
        }

        private void OnLoginRedirectClickEventRaised(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, ShowLoginViewEvent, e);
        }

        private void OnRegistrationClickEventRaised(object sender, UserViewModel args)
        {
            try
            {

                UserDTO userDTO = new UserDTO();
                userDTO.FirstName = args.FirstName;
                userDTO.LastName = args.LastName;
                userDTO.CarModel = args.CarModel;
                _userService.Create(userDTO);
                userDTO = _userService.GetByFirstAndLastName(userDTO.FirstName, userDTO.LastName);
                EventHelpers.RaiseEvent(this, ShowMainViewEvent, userDTO);
            }
            catch (DataAccessException e)
            {
                EventHelpers.RaiseEvent(this, DataAccessExceptionEvent, e);
            }
        }
    }
}
