using System;
using System.Windows.Forms;
using CommonComponents;
using PresentationLayer.Views.ViewModels;

namespace PresentationLayer.Views.UserControls
{
    public partial class RegistrationViewUC : BaseUserControlUC, IRegistrationViewUC
    {
        public event EventHandler<UserViewModel> RegistrationClickEventRaised;
        public event EventHandler LoginRedirectEventRaised;
        public RegistrationViewUC()
        {
            InitializeComponent();
        }

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            UserViewModel vm = new UserViewModel();
            vm.FirstName = firstNameTextbox.Text;
            vm.LastName = lastNameTextbox.Text;
            vm.CarModel = carModelTextbox.Text;
            if (vm.FirstName.Length > 0 && vm.LastName.Length > 0)
            {
                EventHelpers.RaiseEvent(this, RegistrationClickEventRaised, vm);
            }

        }

        private void redirectToLoginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EventHelpers.RaiseEvent(this, LoginRedirectEventRaised, e);
        }
    }
}
