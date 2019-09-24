namespace PresentationLayer.Views.UserControls
{
    partial class HeaderViewUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addExpenseTypeBtn = new System.Windows.Forms.Button();
            this.addExpenseBtn = new System.Windows.Forms.Button();
            this.headerText = new System.Windows.Forms.Label();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addExpenseTypeBtn
            // 
            this.addExpenseTypeBtn.AutoEllipsis = true;
            this.addExpenseTypeBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addExpenseTypeBtn.Image = global::PresentationLayer.Properties.Resources.add_white;
            this.addExpenseTypeBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExpenseTypeBtn.Location = new System.Drawing.Point(161, 76);
            this.addExpenseTypeBtn.Name = "addExpenseTypeBtn";
            this.addExpenseTypeBtn.Padding = new System.Windows.Forms.Padding(4);
            this.addExpenseTypeBtn.Size = new System.Drawing.Size(189, 34);
            this.addExpenseTypeBtn.TabIndex = 4;
            this.addExpenseTypeBtn.Text = "NOVA KATEGORIJA TROŠKA";
            this.addExpenseTypeBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addExpenseTypeBtn.UseVisualStyleBackColor = false;
            this.addExpenseTypeBtn.Click += new System.EventHandler(this.addExpenseTypeBtn_Click);
            // 
            // addExpenseBtn
            // 
            this.addExpenseBtn.AutoEllipsis = true;
            this.addExpenseBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addExpenseBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.addExpenseBtn.Image = global::PresentationLayer.Properties.Resources.add_white;
            this.addExpenseBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addExpenseBtn.Location = new System.Drawing.Point(3, 77);
            this.addExpenseBtn.Name = "addExpenseBtn";
            this.addExpenseBtn.Padding = new System.Windows.Forms.Padding(4);
            this.addExpenseBtn.Size = new System.Drawing.Size(118, 34);
            this.addExpenseBtn.TabIndex = 3;
            this.addExpenseBtn.Text = "NOVI TROŠAK";
            this.addExpenseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addExpenseBtn.UseVisualStyleBackColor = false;
            this.addExpenseBtn.Click += new System.EventHandler(this.addExpenseBtn_Click);
            // 
            // headerText
            // 
            this.headerText.AutoSize = true;
            this.headerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.headerText.Location = new System.Drawing.Point(3, 35);
            this.headerText.Name = "headerText";
            this.headerText.Size = new System.Drawing.Size(298, 26);
            this.headerText.TabIndex = 2;
            this.headerText.Text = "Eni (VW3 Golf)";
            // 
            // logoutBtn
            // 
            this.logoutBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.logoutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logoutBtn.Location = new System.Drawing.Point(453, 75);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(107, 34);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Odjava";
            this.logoutBtn.UseVisualStyleBackColor = false;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // HeaderViewUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.addExpenseTypeBtn);
            this.Controls.Add(this.addExpenseBtn);
            this.Controls.Add(this.headerText);
            this.Controls.Add(this.logoutBtn);
            this.Name = "HeaderViewUC";
            this.Padding = new System.Windows.Forms.Padding(0, 25, 0, 0);
            this.Size = new System.Drawing.Size(579, 128);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button logoutBtn;
        private System.Windows.Forms.Label headerText;
        private System.Windows.Forms.Button addExpenseBtn;
        private System.Windows.Forms.Button addExpenseTypeBtn;
    }
}
