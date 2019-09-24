using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ErrorMessageView : Form, IErrorMessageView
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }

        public void ShowErrorMessageView(string windowTitle, string errorMessage)
        {
            Text = windowTitle;
            messageTextBox.Text = errorMessage;
            ShowDialog();
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            if (messageTextBox.Text != "")
            {
                Clipboard.SetText(messageTextBox.Text);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
