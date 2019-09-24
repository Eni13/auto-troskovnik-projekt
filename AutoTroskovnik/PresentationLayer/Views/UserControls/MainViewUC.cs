using PresentationLayer.Presenters;
using PresentationLayer.Views.UserControls;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class MainViewUC : BaseUserControlUC, IMainView
    {
        public MainViewUC()
        {
            InitializeComponent();
        }
 
        public Panel GetHeaderPanel()
        {
            return headerPanel;
        }

        public Panel GetMainPanel()
        {
            return basePanel;
        }
    
        public TabControl GetTabControl()
        {
            return tabContent;
        }

        public Panel GetBasePanel()
        {
            return basePanel;
        }
    }
}
