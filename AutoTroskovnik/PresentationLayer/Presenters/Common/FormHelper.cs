﻿using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Common
{
    static public class FormHelper
    {
        static public void SetDialogAppearance(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.BackColor = Color.FromArgb(240, 242, 247);
            form.MinimizeBox = false;
            form.MaximizeBox = false;
        }

        static public void SetFormAppearance(Form form)
        {
            SetDialogAppearance(form);
            form.MinimizeBox = true;
        }
    }
}
