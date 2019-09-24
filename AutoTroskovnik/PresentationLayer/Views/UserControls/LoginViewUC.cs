using System;
using System.Windows.Forms;
using PresentationLayer.Views.ViewModels;
using CommonComponents;

namespace PresentationLayer.Views.UserControls
{
    public partial class LoginViewUC : BaseUserControlUC, ILoginViewUC
    {
        public event EventHandler<UserViewModel> LoginClickEventRaised;
        public event EventHandler RegistrationRedirectClickEventRaised;
        public LoginViewUC()
        {
            InitializeComponent();

        }

        private void redirectToRegisterLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, RegistrationRedirectClickEventRaised, e);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            UserViewModel vm = new UserViewModel();
            vm.FirstName = firstNameTextbox.Text;
            vm.LastName = lastNameTextbox.Text;
            EventHelpers.RaiseEvent(this, LoginClickEventRaised, vm);
        }
    }
}
