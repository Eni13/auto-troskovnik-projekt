using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views.UserControls
{
    public partial class BaseUserControlUC : UserControl
    {
        public BaseUserControlUC()
        {
            InitializeComponent();
        }

        public AnchorStyles SetAnchorStylesTopBottomLeftRight()
        {
            return (((AnchorStyles.Top | AnchorStyles.Bottom)
                  | AnchorStyles.Left)
                  | AnchorStyles.Right);
        }
        public void SetParentSizeLocationAnchor(Panel parentPanel)
        {
            Parent = parentPanel;
            Height = parentPanel.Height;
            Width = parentPanel.Width;
            Location = new Point(0, 0);
            Anchor = SetAnchorStylesTopBottomLeftRight();
        }

    }
}
