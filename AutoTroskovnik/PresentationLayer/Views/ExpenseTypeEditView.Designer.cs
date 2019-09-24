namespace PresentationLayer.Views
{
    partial class ExpenseTypeEditView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.expenseTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Naziv kategorije troška";
            // 
            // expenseTypeNameTextBox
            // 
            this.expenseTypeNameTextBox.Location = new System.Drawing.Point(60, 96);
            this.expenseTypeNameTextBox.Name = "expenseTypeNameTextBox";
            this.expenseTypeNameTextBox.Size = new System.Drawing.Size(308, 22);
            this.expenseTypeNameTextBox.TabIndex = 1;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(174, 152);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(91, 36);
            this.saveBtn.TabIndex = 2;
            this.saveBtn.Text = "Pohrani";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // ExpenseTypeEditView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(418, 237);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.expenseTypeNameTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ExpenseTypeEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izmjena kategorije troška";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox expenseTypeNameTextBox;
        private System.Windows.Forms.Button saveBtn;
    }
}