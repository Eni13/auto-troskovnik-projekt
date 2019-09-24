namespace PresentationLayer.Views
{
    partial class ExpenseDeleteView
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
            this.deleteConfirmBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(95, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Želite li obrisati zapis?";
            // 
            // deleteConfirmBtn
            // 
            this.deleteConfirmBtn.Location = new System.Drawing.Point(62, 111);
            this.deleteConfirmBtn.Name = "deleteConfirmBtn";
            this.deleteConfirmBtn.Size = new System.Drawing.Size(101, 39);
            this.deleteConfirmBtn.TabIndex = 1;
            this.deleteConfirmBtn.Text = "Da";
            this.deleteConfirmBtn.UseVisualStyleBackColor = true;
            this.deleteConfirmBtn.Click += new System.EventHandler(this.deleteConfirmBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(194, 111);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 39);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Odustani";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ExpenseDeleteView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(344, 181);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.deleteConfirmBtn);
            this.Controls.Add(this.label1);
            this.Name = "ExpenseDeleteView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Brisanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteConfirmBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}