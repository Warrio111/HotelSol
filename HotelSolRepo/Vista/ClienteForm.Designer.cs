namespace HotelSolRepo.Vista
{
    partial class ClienteForm
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
            this.Login = new System.Windows.Forms.Button();
            this.NIF = new System.Windows.Forms.TextBox();
            this.Pass = new System.Windows.Forms.TextBox();
            this.Register = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxSurname1 = new System.Windows.Forms.TextBox();
            this.textBoxSurname2 = new System.Windows.Forms.TextBox();
            this.textBoxNIF = new System.Windows.Forms.TextBox();
            this.textBoxTel = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPsswdCheck = new System.Windows.Forms.TextBox();
            this.textBoxPsswd = new System.Windows.Forms.TextBox();
            this.Registrar = new System.Windows.Forms.Button();
            this.BuscadorCliente = new System.Windows.Forms.TextBox();
            this.textBoxCalle = new System.Windows.Forms.TextBox();
            this.textBoxCalleNumero = new System.Windows.Forms.TextBox();
            this.textBoxPuerta = new System.Windows.Forms.TextBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.textBoxCodigoPostal = new System.Windows.Forms.TextBox();
            this.textBoxProvincia = new System.Windows.Forms.TextBox();
            this.textBoxPais = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.AccessibleName = "LoginButton";
            this.Login.Location = new System.Drawing.Point(465, 277);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(243, 31);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // NIF
            // 
            this.NIF.AccessibleName = "NIFText";
            this.NIF.Location = new System.Drawing.Point(465, 186);
            this.NIF.Name = "NIF";
            this.NIF.Size = new System.Drawing.Size(243, 22);
            this.NIF.TabIndex = 1;
            this.NIF.Text = "NIF";
            this.NIF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Pass
            // 
            this.Pass.AccessibleName = "PasswordText";
            this.Pass.Location = new System.Drawing.Point(465, 237);
            this.Pass.MaxLength = 255;
            this.Pass.Name = "Pass";
            this.Pass.PasswordChar = '*';
            this.Pass.Size = new System.Drawing.Size(243, 22);
            this.Pass.TabIndex = 2;
            this.Pass.Text = "Password";
            this.Pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Pass.UseSystemPasswordChar = true;
            // 
            // Register
            // 
            this.Register.AccessibleName = "RegisterButton";
            this.Register.Location = new System.Drawing.Point(465, 325);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(243, 31);
            this.Register.TabIndex = 3;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.AccessibleName = "nombreText";
            this.textBoxName.Location = new System.Drawing.Point(72, 96);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.MaxLength = 255;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(320, 22);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Text = "NOMBRE";
            this.textBoxName.Visible = false;
            // 
            // textBoxSurname1
            // 
            this.textBoxSurname1.AccessibleName = "apellidoText";
            this.textBoxSurname1.Location = new System.Drawing.Point(72, 135);
            this.textBoxSurname1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSurname1.MaxLength = 255;
            this.textBoxSurname1.Name = "textBoxSurname1";
            this.textBoxSurname1.Size = new System.Drawing.Size(320, 22);
            this.textBoxSurname1.TabIndex = 5;
            this.textBoxSurname1.Text = "APELLIDO 1";
            this.textBoxSurname1.Visible = false;
            // 
            // textBoxSurname2
            // 
            this.textBoxSurname2.AccessibleName = "apellido2text";
            this.textBoxSurname2.Location = new System.Drawing.Point(72, 177);
            this.textBoxSurname2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSurname2.MaxLength = 255;
            this.textBoxSurname2.Name = "textBoxSurname2";
            this.textBoxSurname2.Size = new System.Drawing.Size(320, 22);
            this.textBoxSurname2.TabIndex = 6;
            this.textBoxSurname2.Text = "APELLIDO 2";
            this.textBoxSurname2.Visible = false;
            // 
            // textBoxNIF
            // 
            this.textBoxNIF.AccessibleName = "niftext";
            this.textBoxNIF.Location = new System.Drawing.Point(72, 220);
            this.textBoxNIF.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxNIF.MaxLength = 9;
            this.textBoxNIF.Name = "textBoxNIF";
            this.textBoxNIF.Size = new System.Drawing.Size(320, 22);
            this.textBoxNIF.TabIndex = 7;
            this.textBoxNIF.Text = "NIF/DNI";
            this.textBoxNIF.Visible = false;
            // 
            // textBoxTel
            // 
            this.textBoxTel.AccessibleName = "tlftext";
            this.textBoxTel.Location = new System.Drawing.Point(72, 263);
            this.textBoxTel.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTel.MaxLength = 9;
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(320, 22);
            this.textBoxTel.TabIndex = 8;
            this.textBoxTel.Text = "TELEFONO";
            this.textBoxTel.Visible = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AccessibleName = "emailtext";
            this.textBoxEmail.Location = new System.Drawing.Point(72, 305);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmail.MaxLength = 255;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(320, 22);
            this.textBoxEmail.TabIndex = 9;
            this.textBoxEmail.Text = "Email";
            this.textBoxEmail.Visible = false;
            // 
            // textBoxPsswdCheck
            // 
            this.textBoxPsswdCheck.AccessibleName = "2passwordtext";
            this.textBoxPsswdCheck.Location = new System.Drawing.Point(72, 394);
            this.textBoxPsswdCheck.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPsswdCheck.MaxLength = 255;
            this.textBoxPsswdCheck.Name = "textBoxPsswdCheck";
            this.textBoxPsswdCheck.PasswordChar = '*';
            this.textBoxPsswdCheck.Size = new System.Drawing.Size(320, 22);
            this.textBoxPsswdCheck.TabIndex = 11;
            this.textBoxPsswdCheck.Text = "REPITA PASSWORD";
            this.textBoxPsswdCheck.UseSystemPasswordChar = true;
            this.textBoxPsswdCheck.Visible = false;
            // 
            // textBoxPsswd
            // 
            this.textBoxPsswd.AccessibleName = "passwordtext";
            this.textBoxPsswd.Location = new System.Drawing.Point(72, 349);
            this.textBoxPsswd.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPsswd.MaxLength = 255;
            this.textBoxPsswd.Name = "textBoxPsswd";
            this.textBoxPsswd.PasswordChar = '*';
            this.textBoxPsswd.Size = new System.Drawing.Size(320, 22);
            this.textBoxPsswd.TabIndex = 10;
            this.textBoxPsswd.Text = "PASSWORD";
            this.textBoxPsswd.UseSystemPasswordChar = true;
            this.textBoxPsswd.Visible = false;
            // 
            // Registrar
            // 
            this.Registrar.AccessibleName = "RegistrarButton";
            this.Registrar.Location = new System.Drawing.Point(72, 632);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(243, 31);
            this.Registrar.TabIndex = 12;
            this.Registrar.Text = "Registrar";
            this.Registrar.UseVisualStyleBackColor = true;
            this.Registrar.Visible = false;
            this.Registrar.Click += new System.EventHandler(this.registrarButton_Click);
            // 
            // BuscadorCliente
            // 
            this.BuscadorCliente.AccessibleName = "buscadorClientetext";
            this.BuscadorCliente.Location = new System.Drawing.Point(72, 56);
            this.BuscadorCliente.MaxLength = 9;
            this.BuscadorCliente.Name = "BuscadorCliente";
            this.BuscadorCliente.Size = new System.Drawing.Size(319, 22);
            this.BuscadorCliente.TabIndex = 13;
            this.BuscadorCliente.Text = "NIF de Cliente";
            this.BuscadorCliente.Visible = false;
            this.BuscadorCliente.DoubleClick += new System.EventHandler(this.buscadorDoubleClick_button);
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(72, 436);
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(319, 22);
            this.textBoxCalle.TabIndex = 15;
            this.textBoxCalle.Text = "Calle";
            this.textBoxCalle.Visible = false;
            // 
            // textBoxCalleNumero
            // 
            this.textBoxCalleNumero.Location = new System.Drawing.Point(73, 464);
            this.textBoxCalleNumero.MaxLength = 5;
            this.textBoxCalleNumero.Name = "textBoxCalleNumero";
            this.textBoxCalleNumero.Size = new System.Drawing.Size(319, 22);
            this.textBoxCalleNumero.TabIndex = 16;
            this.textBoxCalleNumero.Text = "Numero";
            this.textBoxCalleNumero.Visible = false;
            // 
            // textBoxPuerta
            // 
            this.textBoxPuerta.Location = new System.Drawing.Point(72, 492);
            this.textBoxPuerta.MaxLength = 5;
            this.textBoxPuerta.Name = "textBoxPuerta";
            this.textBoxPuerta.Size = new System.Drawing.Size(319, 22);
            this.textBoxPuerta.TabIndex = 17;
            this.textBoxPuerta.Text = "Puerta";
            this.textBoxPuerta.Visible = false;
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(72, 520);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(319, 22);
            this.textBoxPiso.TabIndex = 18;
            this.textBoxPiso.Text = "Piso";
            this.textBoxPiso.Visible = false;
            // 
            // textBoxCodigoPostal
            // 
            this.textBoxCodigoPostal.Location = new System.Drawing.Point(73, 548);
            this.textBoxCodigoPostal.MaxLength = 10;
            this.textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            this.textBoxCodigoPostal.Size = new System.Drawing.Size(319, 22);
            this.textBoxCodigoPostal.TabIndex = 19;
            this.textBoxCodigoPostal.Text = "CodigoPostal";
            this.textBoxCodigoPostal.Visible = false;
            // 
            // textBoxProvincia
            // 
            this.textBoxProvincia.Location = new System.Drawing.Point(72, 576);
            this.textBoxProvincia.MaxLength = 255;
            this.textBoxProvincia.Name = "textBoxProvincia";
            this.textBoxProvincia.Size = new System.Drawing.Size(319, 22);
            this.textBoxProvincia.TabIndex = 20;
            this.textBoxProvincia.Text = "Provincia";
            this.textBoxProvincia.Visible = false;
            // 
            // textBoxPais
            // 
            this.textBoxPais.Location = new System.Drawing.Point(72, 604);
            this.textBoxPais.MaxLength = 255;
            this.textBoxPais.Name = "textBoxPais";
            this.textBoxPais.Size = new System.Drawing.Size(319, 22);
            this.textBoxPais.TabIndex = 21;
            this.textBoxPais.Text = "Pais";
            this.textBoxPais.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(73, 96);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(951, 556);
            this.webBrowser1.TabIndex = 22;
            this.webBrowser1.Visible = false;
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1403, 727);
            this.Controls.Add(this.textBoxPais);
            this.Controls.Add(this.textBoxProvincia);
            this.Controls.Add(this.textBoxCodigoPostal);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.textBoxPuerta);
            this.Controls.Add(this.textBoxCalleNumero);
            this.Controls.Add(this.textBoxCalle);
            this.Controls.Add(this.BuscadorCliente);
            this.Controls.Add(this.Registrar);
            this.Controls.Add(this.textBoxPsswdCheck);
            this.Controls.Add(this.textBoxPsswd);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxTel);
            this.Controls.Add(this.textBoxNIF);
            this.Controls.Add(this.textBoxSurname2);
            this.Controls.Add(this.textBoxSurname1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Pass);
            this.Controls.Add(this.NIF);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClienteForm";
            this.Text = "ClienteForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox NIF;
        private System.Windows.Forms.TextBox Pass;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxSurname1;
        private System.Windows.Forms.TextBox textBoxSurname2;
        private System.Windows.Forms.TextBox textBoxNIF;
        private System.Windows.Forms.TextBox textBoxTel;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPsswdCheck;
        private System.Windows.Forms.TextBox textBoxPsswd;
        private System.Windows.Forms.Button Registrar;
        private System.Windows.Forms.TextBox BuscadorCliente;
        private System.Windows.Forms.TextBox textBoxCalle;
        private System.Windows.Forms.TextBox textBoxCalleNumero;
        private System.Windows.Forms.TextBox textBoxPuerta;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.TextBox textBoxCodigoPostal;
        private System.Windows.Forms.TextBox textBoxProvincia;
        private System.Windows.Forms.TextBox textBoxPais;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}