namespace PresentationLayer.Views
{
    partial class ExpenseEditView
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
            this.expenseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.costNumericPicker = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveChangedBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.costNumericPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // expenseTypeComboBox
            // 
            this.expenseTypeComboBox.FormattingEnabled = true;
            this.expenseTypeComboBox.Location = new System.Drawing.Point(124, 36);
            this.expenseTypeComboBox.Name = "expenseTypeComboBox";
            this.expenseTypeComboBox.Size = new System.Drawing.Size(342, 24);
            this.expenseTypeComboBox.TabIndex = 0;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(124, 86);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(342, 22);
            this.datePicker.TabIndex = 1;
            // 
            // costNumericPicker
            // 
            this.costNumericPicker.DecimalPlaces = 2;
            this.costNumericPicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.costNumericPicker.Location = new System.Drawing.Point(124, 131);
            this.costNumericPicker.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.costNumericPicker.Name = "costNumericPicker";
            this.costNumericPicker.Size = new System.Drawing.Size(342, 22);
            this.costNumericPicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tip troška";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cijena";
            // 
            // saveChangedBtn
            // 
            this.saveChangedBtn.Location = new System.Drawing.Point(224, 181);
            this.saveChangedBtn.Name = "saveChangedBtn";
            this.saveChangedBtn.Size = new System.Drawing.Size(96, 35);
            this.saveChangedBtn.TabIndex = 6;
            this.saveChangedBtn.Text = "Pohrani";
            this.saveChangedBtn.UseVisualStyleBackColor = true;
            this.saveChangedBtn.Click += new System.EventHandler(this.saveChangedBtn_Click);
            // 
            // ExpenseEditView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(525, 278);
            this.Controls.Add(this.saveChangedBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.costNumericPicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.expenseTypeComboBox);
            this.Name = "ExpenseEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Izmjena zapisa o trošku";
            ((System.ComponentModel.ISupportInitialize)(this.costNumericPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox expenseTypeComboBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.NumericUpDown costNumericPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveChangedBtn;
    }
}