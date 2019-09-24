using System.Windows.Forms;

namespace PresentationLayer.Presenters
{
    public interface IMainView
    {
        TabControl GetTabControl();
        Panel GetHeaderPanel();
        Panel GetBasePanel();
    }
}