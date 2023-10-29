namespace HotelSolRepo.Vista
{
    partial class SystemLogin
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
            this.textBoxNameEmployee = new System.Windows.Forms.TextBox();
            this.textBoxIdEmployee = new System.Windows.Forms.TextBox();
            this.btnLoginEmployee = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNameEmployee
            // 
            this.textBoxNameEmployee.Location = new System.Drawing.Point(231, 101);
            this.textBoxNameEmployee.Name = "textBoxNameEmployee";
            this.textBoxNameEmployee.Size = new System.Drawing.Size(298, 20);
            this.textBoxNameEmployee.TabIndex = 0;
            // 
            // textBoxIdEmployee
            // 
            this.textBoxIdEmployee.Location = new System.Drawing.Point(255, 152);
            this.textBoxIdEmployee.Name = "textBoxIdEmployee";
            this.textBoxIdEmployee.Size = new System.Drawing.Size(244, 20);
            this.textBoxIdEmployee.TabIndex = 1;
            // 
            // btnLoginEmployee
            // 
            this.btnLoginEmployee.Location = new System.Drawing.Point(311, 210);
            this.btnLoginEmployee.Name = "btnLoginEmployee";
            this.btnLoginEmployee.Size = new System.Drawing.Size(137, 23);
            this.btnLoginEmployee.TabIndex = 2;
            this.btnLoginEmployee.Text = "Login";
            this.btnLoginEmployee.UseVisualStyleBackColor = true;
            // 
            // SystemLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoginEmployee);
            this.Controls.Add(this.textBoxIdEmployee);
            this.Controls.Add(this.textBoxNameEmployee);
            this.Name = "SystemLogin";
            this.Text = "SystemLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameEmployee;
        private System.Windows.Forms.TextBox textBoxIdEmployee;
        private System.Windows.Forms.Button btnLoginEmployee;
    }
}