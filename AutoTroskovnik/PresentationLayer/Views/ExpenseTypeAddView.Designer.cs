namespace PresentationLayer.Views
{
    partial class ExpenseTypeAddView
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
            this.expenseTypeNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // expenseTypeNameTextBox
            // 
            this.expenseTypeNameTextBox.Location = new System.Drawing.Point(43, 63);
            this.expenseTypeNameTextBox.Multiline = true;
            this.expenseTypeNameTextBox.Name = "expenseTypeNameTextBox";
            this.expenseTypeNameTextBox.Size = new System.Drawing.Size(307, 32);
            this.expenseTypeNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime kategorije troška";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(255, 119);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(95, 32);
            this.createBtn.TabIndex = 2;
            this.createBtn.Text = "Pohrani";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // ExpenseTypeAddView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(393, 200);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expenseTypeNameTextBox);
            this.Name = "ExpenseTypeAddView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kreiranje tipa troška";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox expenseTypeNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBtn;
    }
}