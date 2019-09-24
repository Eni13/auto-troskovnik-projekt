using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IRootView
    {
        event EventHandler RootViewLoadedEventRaised;

        void ShowRootView();
        void SetUserControl(UserControl userControl);
    }
}