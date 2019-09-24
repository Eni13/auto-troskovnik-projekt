using CommonComponents;
using PresentationLayer.Common;
using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class RootView : Form, IRootView
    {
        public event EventHandler RootViewLoadedEventRaised;
        public RootView()
        {
            InitializeComponent();
        }

        public void ShowRootView()
        {
            ShowDialog();
        }

        public void SetUserControl(UserControl uc)
        {
            rootPanel.Controls.Clear();
            uc.Left = (ClientSize.Width - uc.Width) / 2;
            uc.Top = (ClientSize.Height - uc.Height) / 2;
            uc.AutoSize = true;
            rootPanel.Controls.Add(uc);
        }


        private void RootView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(this, RootViewLoadedEventRaised, e);
            FormHelper.SetFormAppearance(this);
        }
    }
}
