using CommonComponents;
using DomainLayer.Models.User;
using PresentationLayer.Presenters.Common;
using PresentationLayer.Presenters.UserControls;
using PresentationLayer.Views;
using PresentationLayer.Views.UserControls;
using System;

namespace PresentationLayer.Presenters
{
    public class RootPresenter : IRootPresenter
    {
        private IErrorMessageView _errorMessageView;
        private IRootView _rootView;
        private ILoginPresenter _loginPresenter;
        private IRegistrationPresenter _registrationPresenter;
        private IMainPresenter _mainPresenter;
        private IHeaderViewPresenter _headerViewPresenter;
        private ISession _session;
        public RootPresenter(IRootView rootView,
            IErrorMessageView errorMessageView,
            ILoginPresenter loginPresenter,
            IRegistrationPresenter registrationPresenter,
            IHeaderViewPresenter headerViewPresenter,
            IMainPresenter mainPresenter,
            ISession session)
        {
            _rootView = rootView;
            _errorMessageView = errorMessageView;
            _loginPresenter = loginPresenter;
            _registrationPresenter = registrationPresenter;   
            _mainPresenter = mainPresenter;
            _headerViewPresenter = headerViewPresenter;
            _session = session;
            SubscribeToEvents();
        }
        public IRootView GetRootView()
        {
            return _rootView;
        }
        public void ShowErrorMessage(string windowTitle, string errorMessage)
        {
            _errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
        }

        public void ShowLoginView()
        {
            _rootView.SetUserControl((BaseUserControlUC)_loginPresenter.GetLoginViewUC());
        }
        public void ShowMainView(UserDTO user)
        {
            _mainPresenter.LoadAll();
            _rootView.SetUserControl((BaseUserControlUC)_mainPresenter.GetMainView());
        }
        public void ShowRegistrationView()
        {
            _rootView.SetUserControl((BaseUserControlUC)_registrationPresenter.GetRegistrationViewUC());
        }
        private void SubscribeToEvents()
        {
            _rootView.RootViewLoadedEventRaised += new EventHandler(RootViewLoadedEventRaised);
            _loginPresenter.ShowMainViewEvent += new EventHandler<UserDTO>(OnShowMainViewEvent);
            _loginPresenter.ShowRegistrationViewEvent += new EventHandler(OnShowRegistrationViewEvent);
            _loginPresenter.DataAccessExceptionEvent += new EventHandler<DataAccessException>(OnDataAccessExceptionEvent);
            _registrationPresenter.ShowMainViewEvent += new EventHandler<UserDTO>(OnShowMainViewEvent);
            _registrationPresenter.ShowLoginViewEvent += new EventHandler(OnShowLoginViewEvent);
            _registrationPresenter.DataAccessExceptionEvent += new EventHandler<DataAccessException>(OnDataAccessExceptionEvent);
            _headerViewPresenter.LogoutEvent += new EventHandler(OnLogoutEvent);
            _mainPresenter.DataAccessExceptionEvent += new EventHandler<DataAccessException>(OnDataAccessExceptionEvent);
        }

        private void OnLogoutEvent(object sender, EventArgs e)
        {
            _session.SetUser(null);
            ShowLoginView();
        }

        private void OnDataAccessExceptionEvent(object sender, DataAccessException e)
        {
            ShowErrorMessage("Error", e.DataAccessResult.CustomMessage);
        }

        private void OnShowLoginViewEvent(object sender, EventArgs e)
        {
            ShowLoginView();
        }

        private void OnShowRegistrationViewEvent(object sender, EventArgs e)
        {
            ShowRegistrationView();
        }

        private void OnShowMainViewEvent(object sender, UserDTO e)
        {
            _session.SetUser(e);
            ShowMainView(e);
        }

        private void RootViewLoadedEventRaised(object sender, EventArgs e)
        {
            ShowLoginView();
        }
    }

}
