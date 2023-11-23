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
            this.buttonObtenerClientePorNif = new System.Windows.Forms.Button();
            this.buttonObtenerHistorialEstanciaCliente = new System.Windows.Forms.Button();
            this.buttonObtenerClientes = new System.Windows.Forms.Button();
            this.buttonObtenerClientesConReservas = new System.Windows.Forms.Button();
            this.buttonRegistrarCliente = new System.Windows.Forms.Button();
            this.buttonActualizarCliente = new System.Windows.Forms.Button();
            this.buttonEliminarCliente = new System.Windows.Forms.Button();
            this.buttonRealizarActualizarCliente = new System.Windows.Forms.Button();
            this.textBoxNifClienteActualizar = new System.Windows.Forms.TextBox();
            this.textBoxNifClienteHistorial = new System.Windows.Forms.TextBox();
            this.textBoxEliminarCliente = new System.Windows.Forms.TextBox();
            this.buttonObtenerFacturaCliente = new System.Windows.Forms.Button();
            this.textBoxObtenerFacturaCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.AccessibleName = "nombreText";
            this.textBoxName.Location = new System.Drawing.Point(54, 78);
            this.textBoxName.MaxLength = 255;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(241, 20);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.Text = "NOMBRE";
            this.textBoxName.Visible = false;
            // 
            // textBoxSurname1
            // 
            this.textBoxSurname1.AccessibleName = "apellidoText";
            this.textBoxSurname1.Location = new System.Drawing.Point(54, 110);
            this.textBoxSurname1.MaxLength = 255;
            this.textBoxSurname1.Name = "textBoxSurname1";
            this.textBoxSurname1.Size = new System.Drawing.Size(241, 20);
            this.textBoxSurname1.TabIndex = 5;
            this.textBoxSurname1.Text = "APELLIDO 1";
            this.textBoxSurname1.Visible = false;
            // 
            // textBoxSurname2
            // 
            this.textBoxSurname2.AccessibleName = "apellido2text";
            this.textBoxSurname2.Location = new System.Drawing.Point(54, 144);
            this.textBoxSurname2.MaxLength = 255;
            this.textBoxSurname2.Name = "textBoxSurname2";
            this.textBoxSurname2.Size = new System.Drawing.Size(241, 20);
            this.textBoxSurname2.TabIndex = 6;
            this.textBoxSurname2.Text = "APELLIDO 2";
            this.textBoxSurname2.Visible = false;
            // 
            // textBoxNIF
            // 
            this.textBoxNIF.AccessibleName = "niftext";
            this.textBoxNIF.Location = new System.Drawing.Point(54, 179);
            this.textBoxNIF.MaxLength = 9;
            this.textBoxNIF.Name = "textBoxNIF";
            this.textBoxNIF.Size = new System.Drawing.Size(241, 20);
            this.textBoxNIF.TabIndex = 7;
            this.textBoxNIF.Text = "NIF/DNI";
            this.textBoxNIF.Visible = false;
            // 
            // textBoxTel
            // 
            this.textBoxTel.AccessibleName = "tlftext";
            this.textBoxTel.Location = new System.Drawing.Point(54, 214);
            this.textBoxTel.MaxLength = 9;
            this.textBoxTel.Name = "textBoxTel";
            this.textBoxTel.Size = new System.Drawing.Size(241, 20);
            this.textBoxTel.TabIndex = 8;
            this.textBoxTel.Text = "TELEFONO";
            this.textBoxTel.Visible = false;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AccessibleName = "emailtext";
            this.textBoxEmail.Location = new System.Drawing.Point(54, 248);
            this.textBoxEmail.MaxLength = 255;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(241, 20);
            this.textBoxEmail.TabIndex = 9;
            this.textBoxEmail.Text = "Email";
            this.textBoxEmail.Visible = false;
            // 
            // textBoxPsswdCheck
            // 
            this.textBoxPsswdCheck.AccessibleName = "2passwordtext";
            this.textBoxPsswdCheck.Location = new System.Drawing.Point(54, 320);
            this.textBoxPsswdCheck.MaxLength = 255;
            this.textBoxPsswdCheck.Name = "textBoxPsswdCheck";
            this.textBoxPsswdCheck.PasswordChar = '*';
            this.textBoxPsswdCheck.Size = new System.Drawing.Size(241, 20);
            this.textBoxPsswdCheck.TabIndex = 11;
            this.textBoxPsswdCheck.Text = "REPITA PASSWORD";
            this.textBoxPsswdCheck.UseSystemPasswordChar = true;
            this.textBoxPsswdCheck.Visible = false;
            // 
            // textBoxPsswd
            // 
            this.textBoxPsswd.AccessibleName = "passwordtext";
            this.textBoxPsswd.Location = new System.Drawing.Point(54, 284);
            this.textBoxPsswd.MaxLength = 255;
            this.textBoxPsswd.Name = "textBoxPsswd";
            this.textBoxPsswd.PasswordChar = '*';
            this.textBoxPsswd.Size = new System.Drawing.Size(241, 20);
            this.textBoxPsswd.TabIndex = 10;
            this.textBoxPsswd.Text = "PASSWORD";
            this.textBoxPsswd.UseSystemPasswordChar = true;
            this.textBoxPsswd.Visible = false;
            // 
            // Registrar
            // 
            this.Registrar.AccessibleName = "RegistrarButton";
            this.Registrar.Location = new System.Drawing.Point(54, 514);
            this.Registrar.Margin = new System.Windows.Forms.Padding(2);
            this.Registrar.Name = "Registrar";
            this.Registrar.Size = new System.Drawing.Size(182, 25);
            this.Registrar.TabIndex = 12;
            this.Registrar.Text = "Registrar";
            this.Registrar.UseVisualStyleBackColor = true;
            this.Registrar.Visible = false;
            this.Registrar.Click += new System.EventHandler(this.registrarButton_Click);
            // 
            // BuscadorCliente
            // 
            this.BuscadorCliente.AccessibleName = "buscadorClientetext";
            this.BuscadorCliente.Location = new System.Drawing.Point(54, 46);
            this.BuscadorCliente.Margin = new System.Windows.Forms.Padding(2);
            this.BuscadorCliente.MaxLength = 9;
            this.BuscadorCliente.Name = "BuscadorCliente";
            this.BuscadorCliente.Size = new System.Drawing.Size(240, 20);
            this.BuscadorCliente.TabIndex = 13;
            this.BuscadorCliente.Text = "NIF de Cliente";
            this.BuscadorCliente.Visible = false;
            this.BuscadorCliente.DoubleClick += new System.EventHandler(this.buscadorDoubleClick_button);
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(54, 354);
            this.textBoxCalle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(240, 20);
            this.textBoxCalle.TabIndex = 15;
            this.textBoxCalle.Text = "Calle";
            this.textBoxCalle.Visible = false;
            // 
            // textBoxCalleNumero
            // 
            this.textBoxCalleNumero.Location = new System.Drawing.Point(55, 377);
            this.textBoxCalleNumero.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCalleNumero.MaxLength = 5;
            this.textBoxCalleNumero.Name = "textBoxCalleNumero";
            this.textBoxCalleNumero.Size = new System.Drawing.Size(240, 20);
            this.textBoxCalleNumero.TabIndex = 16;
            this.textBoxCalleNumero.Text = "Numero";
            this.textBoxCalleNumero.Visible = false;
            // 
            // textBoxPuerta
            // 
            this.textBoxPuerta.Location = new System.Drawing.Point(54, 400);
            this.textBoxPuerta.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPuerta.MaxLength = 5;
            this.textBoxPuerta.Name = "textBoxPuerta";
            this.textBoxPuerta.Size = new System.Drawing.Size(240, 20);
            this.textBoxPuerta.TabIndex = 17;
            this.textBoxPuerta.Text = "Puerta";
            this.textBoxPuerta.Visible = false;
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(54, 422);
            this.textBoxPiso.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(240, 20);
            this.textBoxPiso.TabIndex = 18;
            this.textBoxPiso.Text = "Piso";
            this.textBoxPiso.Visible = false;
            // 
            // textBoxCodigoPostal
            // 
            this.textBoxCodigoPostal.Location = new System.Drawing.Point(55, 445);
            this.textBoxCodigoPostal.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCodigoPostal.MaxLength = 10;
            this.textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            this.textBoxCodigoPostal.Size = new System.Drawing.Size(240, 20);
            this.textBoxCodigoPostal.TabIndex = 19;
            this.textBoxCodigoPostal.Text = "CodigoPostal";
            this.textBoxCodigoPostal.Visible = false;
            // 
            // textBoxProvincia
            // 
            this.textBoxProvincia.Location = new System.Drawing.Point(54, 468);
            this.textBoxProvincia.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxProvincia.MaxLength = 255;
            this.textBoxProvincia.Name = "textBoxProvincia";
            this.textBoxProvincia.Size = new System.Drawing.Size(240, 20);
            this.textBoxProvincia.TabIndex = 20;
            this.textBoxProvincia.Text = "Provincia";
            this.textBoxProvincia.Visible = false;
            // 
            // textBoxPais
            // 
            this.textBoxPais.Location = new System.Drawing.Point(54, 491);
            this.textBoxPais.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPais.MaxLength = 255;
            this.textBoxPais.Name = "textBoxPais";
            this.textBoxPais.Size = new System.Drawing.Size(240, 20);
            this.textBoxPais.TabIndex = 21;
            this.textBoxPais.Text = "Pais";
            this.textBoxPais.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(55, 78);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(15, 16);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(713, 452);
            this.webBrowser1.TabIndex = 22;
            this.webBrowser1.Visible = false;
            // 
            // buttonObtenerClientePorNif
            // 
            this.buttonObtenerClientePorNif.Location = new System.Drawing.Point(891, 248);
            this.buttonObtenerClientePorNif.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerClientePorNif.Name = "buttonObtenerClientePorNif";
            this.buttonObtenerClientePorNif.Size = new System.Drawing.Size(175, 40);
            this.buttonObtenerClientePorNif.TabIndex = 23;
            this.buttonObtenerClientePorNif.Text = "ObtenerClientePorNif";
            this.buttonObtenerClientePorNif.UseVisualStyleBackColor = true;
            this.buttonObtenerClientePorNif.Click += new System.EventHandler(this.ObtenerClientePorNif_Click);
            // 
            // buttonObtenerHistorialEstanciaCliente
            // 
            this.buttonObtenerHistorialEstanciaCliente.Location = new System.Drawing.Point(891, 337);
            this.buttonObtenerHistorialEstanciaCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerHistorialEstanciaCliente.Name = "buttonObtenerHistorialEstanciaCliente";
            this.buttonObtenerHistorialEstanciaCliente.Size = new System.Drawing.Size(175, 40);
            this.buttonObtenerHistorialEstanciaCliente.TabIndex = 24;
            this.buttonObtenerHistorialEstanciaCliente.Text = "ObtenerHistorialEstanciaCliente";
            this.buttonObtenerHistorialEstanciaCliente.UseVisualStyleBackColor = true;
            this.buttonObtenerHistorialEstanciaCliente.Click += new System.EventHandler(this.ObtenerHistorialEstanciaCliente_Click);
            // 
            // buttonObtenerClientes
            // 
            this.buttonObtenerClientes.Location = new System.Drawing.Point(891, 293);
            this.buttonObtenerClientes.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerClientes.Name = "buttonObtenerClientes";
            this.buttonObtenerClientes.Size = new System.Drawing.Size(175, 40);
            this.buttonObtenerClientes.TabIndex = 24;
            this.buttonObtenerClientes.Text = "ObtenerClientes";
            this.buttonObtenerClientes.UseVisualStyleBackColor = true;
            this.buttonObtenerClientes.Click += new System.EventHandler(this.ObtenerClientes_Click);
            // 
            // buttonObtenerClientesConReservas
            // 
            this.buttonObtenerClientesConReservas.Location = new System.Drawing.Point(891, 382);
            this.buttonObtenerClientesConReservas.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerClientesConReservas.Name = "buttonObtenerClientesConReservas";
            this.buttonObtenerClientesConReservas.Size = new System.Drawing.Size(175, 40);
            this.buttonObtenerClientesConReservas.TabIndex = 25;
            this.buttonObtenerClientesConReservas.Text = "ObtenerClientesConReservas";
            this.buttonObtenerClientesConReservas.UseVisualStyleBackColor = true;
            this.buttonObtenerClientesConReservas.Click += new System.EventHandler(this.ObtenerClientesConReservas_Click);
            // 
            // buttonRegistrarCliente
            // 
            this.buttonRegistrarCliente.Location = new System.Drawing.Point(891, 477);
            this.buttonRegistrarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRegistrarCliente.Name = "buttonRegistrarCliente";
            this.buttonRegistrarCliente.Size = new System.Drawing.Size(175, 40);
            this.buttonRegistrarCliente.TabIndex = 26;
            this.buttonRegistrarCliente.Text = "RegistrarCliente";
            this.buttonRegistrarCliente.UseVisualStyleBackColor = true;
            this.buttonRegistrarCliente.Click += new System.EventHandler(this.RegistrarCliente_Click);
            // 
            // buttonActualizarCliente
            // 
            this.buttonActualizarCliente.Location = new System.Drawing.Point(891, 521);
            this.buttonActualizarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonActualizarCliente.Name = "buttonActualizarCliente";
            this.buttonActualizarCliente.Size = new System.Drawing.Size(175, 40);
            this.buttonActualizarCliente.TabIndex = 27;
            this.buttonActualizarCliente.Text = "ActualizarCliente";
            this.buttonActualizarCliente.UseVisualStyleBackColor = true;
            this.buttonActualizarCliente.Click += new System.EventHandler(this.ActualizarCliente_Click);
            // 
            // buttonEliminarCliente
            // 
            this.buttonEliminarCliente.Location = new System.Drawing.Point(891, 566);
            this.buttonEliminarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonEliminarCliente.Name = "buttonEliminarCliente";
            this.buttonEliminarCliente.Size = new System.Drawing.Size(175, 40);
            this.buttonEliminarCliente.TabIndex = 28;
            this.buttonEliminarCliente.Text = "EliminarCliente";
            this.buttonEliminarCliente.UseVisualStyleBackColor = true;
            this.buttonEliminarCliente.Click += new System.EventHandler(this.EliminarCliente_Click);
            // 
            // buttonRealizarActualizarCliente
            // 
            this.buttonRealizarActualizarCliente.AccessibleName = "";
            this.buttonRealizarActualizarCliente.Location = new System.Drawing.Point(55, 526);
            this.buttonRealizarActualizarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRealizarActualizarCliente.Name = "buttonRealizarActualizarCliente";
            this.buttonRealizarActualizarCliente.Size = new System.Drawing.Size(182, 25);
            this.buttonRealizarActualizarCliente.TabIndex = 29;
            this.buttonRealizarActualizarCliente.Text = "RealizarActualizarCliente";
            this.buttonRealizarActualizarCliente.UseVisualStyleBackColor = true;
            this.buttonRealizarActualizarCliente.Visible = false;
            this.buttonRealizarActualizarCliente.Click += new System.EventHandler(this.RealizarActualizarCliente_Click);
            // 
            // textBoxNifClienteActualizar
            // 
            this.textBoxNifClienteActualizar.AccessibleName = "";
            this.textBoxNifClienteActualizar.Location = new System.Drawing.Point(54, 55);
            this.textBoxNifClienteActualizar.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNifClienteActualizar.MaxLength = 9;
            this.textBoxNifClienteActualizar.Name = "textBoxNifClienteActualizar";
            this.textBoxNifClienteActualizar.Size = new System.Drawing.Size(240, 20);
            this.textBoxNifClienteActualizar.TabIndex = 30;
            this.textBoxNifClienteActualizar.Text = "Nif Cliente Actualizar";
            this.textBoxNifClienteActualizar.Visible = false;
            this.textBoxNifClienteActualizar.Click += new System.EventHandler(this.NifClienteActualizar_Click);
            // 
            // textBoxNifClienteHistorial
            // 
            this.textBoxNifClienteHistorial.AccessibleName = "";
            this.textBoxNifClienteHistorial.Location = new System.Drawing.Point(55, 31);
            this.textBoxNifClienteHistorial.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNifClienteHistorial.MaxLength = 9;
            this.textBoxNifClienteHistorial.Name = "textBoxNifClienteHistorial";
            this.textBoxNifClienteHistorial.Size = new System.Drawing.Size(240, 20);
            this.textBoxNifClienteHistorial.TabIndex = 31;
            this.textBoxNifClienteHistorial.Text = "Nif Cliente Historial";
            this.textBoxNifClienteHistorial.Visible = false;
            this.textBoxNifClienteHistorial.DoubleClick += new System.EventHandler(this.NifClienteHistorial_DoubleClick);
            // 
            // textBoxEliminarCliente
            // 
            this.textBoxEliminarCliente.AccessibleName = "";
            this.textBoxEliminarCliente.Location = new System.Drawing.Point(55, 46);
            this.textBoxEliminarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxEliminarCliente.MaxLength = 9;
            this.textBoxEliminarCliente.Name = "textBoxEliminarCliente";
            this.textBoxEliminarCliente.Size = new System.Drawing.Size(240, 20);
            this.textBoxEliminarCliente.TabIndex = 32;
            this.textBoxEliminarCliente.Text = "Nif Cliente Eliminar";
            this.textBoxEliminarCliente.Visible = false;
            this.textBoxEliminarCliente.DoubleClick += new System.EventHandler(this.textBoxEliminarCliente_Click);
            // 
            // buttonObtenerFacturaCliente
            // 
            this.buttonObtenerFacturaCliente.Location = new System.Drawing.Point(891, 431);
            this.buttonObtenerFacturaCliente.Margin = new System.Windows.Forms.Padding(2);
            this.buttonObtenerFacturaCliente.Name = "buttonObtenerFacturaCliente";
            this.buttonObtenerFacturaCliente.Size = new System.Drawing.Size(175, 40);
            this.buttonObtenerFacturaCliente.TabIndex = 33;
            this.buttonObtenerFacturaCliente.Text = "ObtenerFacturaCliente";
            this.buttonObtenerFacturaCliente.UseVisualStyleBackColor = true;
            this.buttonObtenerFacturaCliente.Click += new System.EventHandler(this.ObtenerFacturaCliente_Click);
            // 
            // textBoxObtenerFacturaCliente
            // 
            this.textBoxObtenerFacturaCliente.AccessibleName = "";
            this.textBoxObtenerFacturaCliente.Location = new System.Drawing.Point(55, 46);
            this.textBoxObtenerFacturaCliente.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxObtenerFacturaCliente.MaxLength = 9;
            this.textBoxObtenerFacturaCliente.Name = "textBoxObtenerFacturaCliente";
            this.textBoxObtenerFacturaCliente.Size = new System.Drawing.Size(240, 20);
            this.textBoxObtenerFacturaCliente.TabIndex = 34;
            this.textBoxObtenerFacturaCliente.Text = "ID de la Reserva";
            this.textBoxObtenerFacturaCliente.Visible = false;
            this.textBoxObtenerFacturaCliente.DoubleClick += new System.EventHandler(this.ObtenerFacturaCliente_DoubleClick);
            // 
            // ClienteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1167, 650);
            this.Controls.Add(this.textBoxObtenerFacturaCliente);
            this.Controls.Add(this.buttonObtenerFacturaCliente);
            this.Controls.Add(this.textBoxEliminarCliente);
            this.Controls.Add(this.textBoxNifClienteHistorial);
            this.Controls.Add(this.textBoxNifClienteActualizar);
            this.Controls.Add(this.buttonRealizarActualizarCliente);
            this.Controls.Add(this.textBoxPais);
            this.Controls.Add(this.textBoxProvincia);
            this.Controls.Add(this.textBoxCodigoPostal);
            this.Controls.Add(this.textBoxPiso);
            this.Controls.Add(this.textBoxPuerta);
            this.Controls.Add(this.textBoxCalleNumero);
            this.Controls.Add(this.textBoxCalle);
            this.Controls.Add(this.buttonEliminarCliente);
            this.Controls.Add(this.buttonActualizarCliente);
            this.Controls.Add(this.buttonRegistrarCliente);
            this.Controls.Add(this.buttonObtenerClientesConReservas);
            this.Controls.Add(this.buttonObtenerClientes);
            this.Controls.Add(this.buttonObtenerHistorialEstanciaCliente);
            this.Controls.Add(this.buttonObtenerClientePorNif);
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
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClienteForm";
            this.Text = "ClienteForm";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Button buttonObtenerClientePorNif;
        private System.Windows.Forms.Button buttonObtenerHistorialEstanciaCliente;
        private System.Windows.Forms.Button buttonObtenerClientes;
        private System.Windows.Forms.Button buttonObtenerClientesConReservas;
        private System.Windows.Forms.Button buttonRegistrarCliente;
        private System.Windows.Forms.Button buttonActualizarCliente;
        private System.Windows.Forms.Button buttonEliminarCliente;
        private System.Windows.Forms.Button buttonRealizarActualizarCliente;
        private System.Windows.Forms.TextBox textBoxNifClienteActualizar;
        private System.Windows.Forms.TextBox textBoxNifClienteHistorial;
        private System.Windows.Forms.TextBox textBoxEliminarCliente;
        private System.Windows.Forms.Button buttonObtenerFacturaCliente;
        private System.Windows.Forms.TextBox textBoxObtenerFacturaCliente;
    }
}