namespace HotelSolRepo.Vista
{
    partial class RegisterForm
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
            this.components = new System.ComponentModel.Container();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxSurname1 = new System.Windows.Forms.TextBox();
            this.textBoxSurname2 = new System.Windows.Forms.TextBox();
            this.textBoxNIF = new System.Windows.Forms.TextBox();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.btnRegisterValidation = new System.Windows.Forms.Button();
            this.textBoxPsswd = new System.Windows.Forms.TextBox();
            this.textBoxPsswdCheck = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(115, 94);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(241, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Text = "NOMBRE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxSurname1
            // 
            this.textBoxSurname1.Location = new System.Drawing.Point(115, 147);
            this.textBoxSurname1.Name = "textBoxSurname1";
            this.textBoxSurname1.Size = new System.Drawing.Size(241, 20);
            this.textBoxSurname1.TabIndex = 2;
            this.textBoxSurname1.Text = "APELLIDO 1";
            // 
            // textBoxSurname2
            // 
            this.textBoxSurname2.Location = new System.Drawing.Point(379, 147);
            this.textBoxSurname2.Name = "textBoxSurname2";
            this.textBoxSurname2.Size = new System.Drawing.Size(271, 20);
            this.textBoxSurname2.TabIndex = 3;
            this.textBoxSurname2.Text = "APELLIDO 2";
            // 
            // textBoxNIF
            // 
            this.textBoxNIF.Location = new System.Drawing.Point(115, 198);
            this.textBoxNIF.Name = "textBoxNIF";
            this.textBoxNIF.Size = new System.Drawing.Size(139, 20);
            this.textBoxNIF.TabIndex = 4;
            this.textBoxNIF.Text = "NIF/DNI";
            // 
            // textBoxTel
            // 
            this.textBoxTel.Location = new System.Drawing.Point(311, 198);
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(139, 20);
            this.textBoxTel.TabIndex = 5;
            this.textBoxTel.Text = "TELEFONO";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(511, 198);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(139, 20);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.Text = "Email";
            // 
            // btnRegisterValidation
            // 
            this.btnRegisterValidation.Location = new System.Drawing.Point(575, 379);
            this.btnRegisterValidation.Name = "btnRegisterValidation";
            this.btnRegisterValidation.Size = new System.Drawing.Size(86, 23);
            this.btnRegisterValidation.TabIndex = 7;
            this.btnRegisterValidation.Text = "REGISTRAR";
            this.btnRegisterValidation.UseVisualStyleBackColor = true;
            // 
            // textBoxPsswd
            // 
            this.textBoxPsswd.Location = new System.Drawing.Point(115, 250);
            this.textBoxPsswd.Name = "textBoxPsswd";
            this.textBoxPsswd.Size = new System.Drawing.Size(271, 20);
            this.textBoxPsswd.TabIndex = 8;
            this.textBoxPsswd.Text = "PASSWORD ";
            // 
            // textBoxPsswdCheck
            // 
            this.textBoxPsswdCheck.Location = new System.Drawing.Point(115, 287);
            this.textBoxPsswdCheck.Name = "textBoxPsswdCheck";
            this.textBoxPsswdCheck.Size = new System.Drawing.Size(271, 20);
            this.textBoxPsswdCheck.TabIndex = 9;
            this.textBoxPsswdCheck.Text = "REPITA PASSWORD";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(921, 486);
            this.Controls.Add(this.textBoxPsswdCheck);
            this.Controls.Add(this.textBoxPsswd);
            this.Controls.Add(this.btnRegisterValidation);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxTel);
            this.Controls.Add(this.textBoxNIF);
            this.Controls.Add(this.textBoxSurname2);
            this.Controls.Add(this.textBoxSurname1);
            this.Controls.Add(this.textBoxName);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxSurname1;
        private System.Windows.Forms.TextBox textBoxSurname2;
        private System.Windows.Forms.TextBox textBoxNIF;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Button btnRegisterValidation;
        private System.Windows.Forms.TextBox textBoxPsswd;
        private System.Windows.Forms.TextBox textBoxPsswdCheck;
    }
}