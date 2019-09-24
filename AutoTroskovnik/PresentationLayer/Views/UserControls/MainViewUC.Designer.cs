namespace PresentationLayer.Views
{
    partial class MainViewUC
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
            this.basePanel = new System.Windows.Forms.Panel();
            this.tabContent = new System.Windows.Forms.TabControl();
            this.allExpensesPage = new System.Windows.Forms.TabPage();
            this.allExpenseTypesPage = new System.Windows.Forms.TabPage();
            this.statisticsPage = new System.Windows.Forms.TabPage();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.basePanel.SuspendLayout();
            this.tabContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // basePanel
            // 
            this.basePanel.Controls.Add(this.tabContent);
            this.basePanel.Controls.Add(this.headerPanel);
            this.basePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basePanel.Location = new System.Drawing.Point(0, 0);
            this.basePanel.Name = "basePanel";
            this.basePanel.Size = new System.Drawing.Size(1000, 800);
            this.basePanel.TabIndex = 2;
            // 
            // tabContent
            // 
            this.tabContent.Controls.Add(this.allExpensesPage);
            this.tabContent.Controls.Add(this.allExpenseTypesPage);
            this.tabContent.Controls.Add(this.statisticsPage);
            this.tabContent.Location = new System.Drawing.Point(10, 177);
            this.tabContent.Name = "tabContent";
            this.tabContent.SelectedIndex = 0;
            this.tabContent.Size = new System.Drawing.Size(984, 542);
            this.tabContent.TabIndex = 2;
            // 
            // allExpensesPage
            // 
            this.allExpensesPage.Location = new System.Drawing.Point(4, 22);
            this.allExpensesPage.Name = "allExpensesPage";
            this.allExpensesPage.Padding = new System.Windows.Forms.Padding(3);
            this.allExpensesPage.Size = new System.Drawing.Size(976, 516);
            this.allExpensesPage.TabIndex = 0;
            this.allExpensesPage.Text = "Svi troškovi";
            this.allExpensesPage.UseVisualStyleBackColor = true;
            // 
            // allExpenseTypesPage
            // 
            this.allExpenseTypesPage.Location = new System.Drawing.Point(4, 22);
            this.allExpenseTypesPage.Name = "allExpenseTypesPage";
            this.allExpenseTypesPage.Size = new System.Drawing.Size(976, 516);
            this.allExpenseTypesPage.TabIndex = 2;
            this.allExpenseTypesPage.Text = "Vrste troškova";
            this.allExpenseTypesPage.UseVisualStyleBackColor = true;
            // 
            // statisticsPage
            // 
            this.statisticsPage.Location = new System.Drawing.Point(4, 22);
            this.statisticsPage.Name = "statisticsPage";
            this.statisticsPage.Padding = new System.Windows.Forms.Padding(3);
            this.statisticsPage.Size = new System.Drawing.Size(976, 516);
            this.statisticsPage.TabIndex = 1;
            this.statisticsPage.Text = "Statistike";
            this.statisticsPage.UseVisualStyleBackColor = true;
            // 
            // headerPanel
            // 
            this.headerPanel.Location = new System.Drawing.Point(10, 25);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(974, 146);
            this.headerPanel.TabIndex = 1;
            // 
            // MainViewUC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.basePanel);
            this.Name = "MainViewUC";
            this.Size = new System.Drawing.Size(1000, 800);
            this.basePanel.ResumeLayout(false);
            this.tabContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.TabControl tabContent;
        private System.Windows.Forms.TabPage statisticsPage;
        private System.Windows.Forms.Panel basePanel;
        private System.Windows.Forms.TabPage allExpenseTypesPage;
        private System.Windows.Forms.TabPage allExpensesPage;
    }
}