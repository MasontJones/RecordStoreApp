
namespace Inventory_Main_Menu
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EmployeeButton = new System.Windows.Forms.Button();
            this.MerchSearchButton = new System.Windows.Forms.Button();
            this.MerchManageButton = new System.Windows.Forms.Button();
            this.HistoryButton = new System.Windows.Forms.Button();
            this.CheckoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(214, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Menu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(190, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please select a menu option:";
            // 
            // EmployeeButton
            // 
            this.EmployeeButton.Location = new System.Drawing.Point(214, 99);
            this.EmployeeButton.Name = "EmployeeButton";
            this.EmployeeButton.Size = new System.Drawing.Size(164, 23);
            this.EmployeeButton.TabIndex = 2;
            this.EmployeeButton.Text = "Employee Managment";
            this.EmployeeButton.UseVisualStyleBackColor = true;
            this.EmployeeButton.Click += new System.EventHandler(this.EmployeeButton_Click);
            // 
            // MerchSearchButton
            // 
            this.MerchSearchButton.Location = new System.Drawing.Point(214, 141);
            this.MerchSearchButton.Name = "MerchSearchButton";
            this.MerchSearchButton.Size = new System.Drawing.Size(164, 23);
            this.MerchSearchButton.TabIndex = 3;
            this.MerchSearchButton.Text = "Merchandise Search";
            this.MerchSearchButton.UseVisualStyleBackColor = true;
            this.MerchSearchButton.Click += new System.EventHandler(this.MerchSearchButton_Click);
            // 
            // MerchManageButton
            // 
            this.MerchManageButton.Location = new System.Drawing.Point(214, 184);
            this.MerchManageButton.Name = "MerchManageButton";
            this.MerchManageButton.Size = new System.Drawing.Size(164, 23);
            this.MerchManageButton.TabIndex = 4;
            this.MerchManageButton.Text = "Merchandise Management";
            this.MerchManageButton.UseVisualStyleBackColor = true;
            this.MerchManageButton.Click += new System.EventHandler(this.MerchManageButton_Click);
            // 
            // HistoryButton
            // 
            this.HistoryButton.Location = new System.Drawing.Point(214, 230);
            this.HistoryButton.Name = "HistoryButton";
            this.HistoryButton.Size = new System.Drawing.Size(164, 23);
            this.HistoryButton.TabIndex = 5;
            this.HistoryButton.Text = "Transaction History";
            this.HistoryButton.UseVisualStyleBackColor = true;
            this.HistoryButton.Click += new System.EventHandler(this.HistoryButton_Click);
            // 
            // CheckoutButton
            // 
            this.CheckoutButton.Location = new System.Drawing.Point(214, 274);
            this.CheckoutButton.Name = "CheckoutButton";
            this.CheckoutButton.Size = new System.Drawing.Size(164, 23);
            this.CheckoutButton.TabIndex = 6;
            this.CheckoutButton.Text = "Checkout";
            this.CheckoutButton.UseVisualStyleBackColor = true;
            this.CheckoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 340);
            this.Controls.Add(this.CheckoutButton);
            this.Controls.Add(this.HistoryButton);
            this.Controls.Add(this.MerchManageButton);
            this.Controls.Add(this.MerchSearchButton);
            this.Controls.Add(this.EmployeeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EmployeeButton;
        private System.Windows.Forms.Button MerchSearchButton;
        private System.Windows.Forms.Button MerchManageButton;
        private System.Windows.Forms.Button HistoryButton;
        private System.Windows.Forms.Button CheckoutButton;
    }
}

