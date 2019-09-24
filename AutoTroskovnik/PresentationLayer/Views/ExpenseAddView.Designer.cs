namespace PresentationLayer.Views.UserControls
{
    partial class ExpenseAddView
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
            this.expenseTypeCombobox = new System.Windows.Forms.ComboBox();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.costPicker = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.costPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // expenseTypeCombobox
            // 
            this.expenseTypeCombobox.FormattingEnabled = true;
            this.expenseTypeCombobox.Location = new System.Drawing.Point(74, 87);
            this.expenseTypeCombobox.Name = "expenseTypeCombobox";
            this.expenseTypeCombobox.Size = new System.Drawing.Size(256, 24);
            this.expenseTypeCombobox.TabIndex = 0;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(74, 166);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(256, 22);
            this.datePicker.TabIndex = 1;
            // 
            // costPicker
            // 
            this.costPicker.DecimalPlaces = 2;
            this.costPicker.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.costPicker.Location = new System.Drawing.Point(77, 243);
            this.costPicker.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.costPicker.Name = "costPicker";
            this.costPicker.Size = new System.Drawing.Size(256, 22);
            this.costPicker.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tip troška";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cijena";
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(232, 299);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(101, 33);
            this.createBtn.TabIndex = 6;
            this.createBtn.Text = "Pohrani";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // ExpenseAddView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(397, 367);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.costPicker);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.expenseTypeCombobox);
            this.Name = "ExpenseAddView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kreiranje zapisa troška";
            ((System.ComponentModel.ISupportInitialize)(this.costPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox expenseTypeCombobox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.NumericUpDown costPicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createBtn;
    }
}