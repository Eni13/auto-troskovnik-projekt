namespace PresentationLayer.Views
{
    partial class ExpenseTypeDeleteView
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
            this.cofirmDeleteBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(100, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Želite li obrisati zapis?";
            // 
            // cofirmDeleteBtn
            // 
            this.cofirmDeleteBtn.Location = new System.Drawing.Point(66, 105);
            this.cofirmDeleteBtn.Name = "cofirmDeleteBtn";
            this.cofirmDeleteBtn.Size = new System.Drawing.Size(93, 41);
            this.cofirmDeleteBtn.TabIndex = 1;
            this.cofirmDeleteBtn.Text = "Da";
            this.cofirmDeleteBtn.UseVisualStyleBackColor = true;
            this.cofirmDeleteBtn.Click += new System.EventHandler(this.cofirmDeleteBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(187, 105);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(89, 41);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Odustani";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ExpenseTypeDeleteView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(355, 181);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.cofirmDeleteBtn);
            this.Controls.Add(this.label1);
            this.Name = "ExpenseTypeDeleteView";
            this.Text = "Brisanje";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cofirmDeleteBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}