namespace HotelSolRepo.Vista
{
    partial class CrearReservaForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.DNI = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscaCliente = new System.Windows.Forms.Button();
            this.TextBoxNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCalle = new System.Windows.Forms.TextBox();
            this.textBoxApellido1 = new System.Windows.Forms.TextBox();
            this.textBoxApellido2 = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNumeroDireccion = new System.Windows.Forms.TextBox();
            this.textBoxPuertaDireccion = new System.Windows.Forms.TextBox();
            this.textBoxPisoDireccion = new System.Windows.Forms.TextBox();
            this.textBoxCodigoPostalDireccion = new System.Windows.Forms.TextBox();
            this.textBoxProvinciaDireccion = new System.Windows.Forms.TextBox();
            this.textBoxPaisDireccion = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(71, 363);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(266, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Location = new System.Drawing.Point(393, 363);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(268, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(71, 410);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(266, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(745, 448);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(151, 35);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "VALIDAR RESERVA";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(71, 436);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(266, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(71, 462);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(266, 21);
            this.comboBox3.TabIndex = 8;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(343, 410);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(343, 436);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown2.TabIndex = 10;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(343, 462);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown3.TabIndex = 11;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(408, 464);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Media Pension";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(534, 410);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(127, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Pension Completa";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(408, 436);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(109, 17);
            this.checkBox3.TabIndex = 14;
            this.checkBox3.Text = "Media Pension";
            this.checkBox3.UseVisualStyleBackColor = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.BackColor = System.Drawing.Color.Transparent;
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.Location = new System.Drawing.Point(534, 463);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(127, 17);
            this.checkBox4.TabIndex = 15;
            this.checkBox4.Text = "Pension Completa";
            this.checkBox4.UseVisualStyleBackColor = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.BackColor = System.Drawing.Color.Transparent;
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.Location = new System.Drawing.Point(408, 410);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(109, 17);
            this.checkBox5.TabIndex = 16;
            this.checkBox5.Text = "Media Pension";
            this.checkBox5.UseVisualStyleBackColor = false;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.Color.Transparent;
            this.checkBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.Location = new System.Drawing.Point(534, 436);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(127, 17);
            this.checkBox6.TabIndex = 17;
            this.checkBox6.Text = "Pension Completa";
            this.checkBox6.UseVisualStyleBackColor = false;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // DNI
            // 
            this.DNI.Location = new System.Drawing.Point(71, 111);
            this.DNI.Name = "DNI";
            this.DNI.Size = new System.Drawing.Size(166, 20);
            this.DNI.TabIndex = 18;
            this.DNI.Text = "NIF/DNI CLIENTE";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 37);
            this.label1.TabIndex = 21;
            this.label1.Text = "CREAR RESERVA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnBuscaCliente
            // 
            this.btnBuscaCliente.Location = new System.Drawing.Point(262, 108);
            this.btnBuscaCliente.Name = "btnBuscaCliente";
            this.btnBuscaCliente.Size = new System.Drawing.Size(75, 23);
            this.btnBuscaCliente.TabIndex = 22;
            this.btnBuscaCliente.Text = "Buscar";
            this.btnBuscaCliente.UseVisualStyleBackColor = true;
            // 
            // TextBoxNombre
            // 
            this.TextBoxNombre.Location = new System.Drawing.Point(71, 146);
            this.TextBoxNombre.Name = "TextBoxNombre";
            this.TextBoxNombre.Size = new System.Drawing.Size(193, 20);
            this.TextBoxNombre.TabIndex = 23;
            this.TextBoxNombre.Text = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "LLEGADA";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "SALIDA";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "HABITACIONES";
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(71, 221);
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(193, 20);
            this.textBoxCalle.TabIndex = 27;
            this.textBoxCalle.Text = "CALLE";
            // 
            // textBoxApellido1
            // 
            this.textBoxApellido1.Location = new System.Drawing.Point(270, 146);
            this.textBoxApellido1.Name = "textBoxApellido1";
            this.textBoxApellido1.Size = new System.Drawing.Size(197, 20);
            this.textBoxApellido1.TabIndex = 28;
            this.textBoxApellido1.Text = "APELLIDO 1";
            // 
            // textBoxApellido2
            // 
            this.textBoxApellido2.Location = new System.Drawing.Point(473, 146);
            this.textBoxApellido2.Name = "textBoxApellido2";
            this.textBoxApellido2.Size = new System.Drawing.Size(197, 20);
            this.textBoxApellido2.TabIndex = 29;
            this.textBoxApellido2.Text = "APELLIDO 2";
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(71, 183);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(193, 20);
            this.textBoxTelefono.TabIndex = 30;
            this.textBoxTelefono.Text = "TELEFONO";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(342, 183);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(328, 20);
            this.textBoxEmail.TabIndex = 31;
            this.textBoxEmail.Text = "EMAIL";
            // 
            // textBoxNumeroDireccion
            // 
            this.textBoxNumeroDireccion.Location = new System.Drawing.Point(274, 221);
            this.textBoxNumeroDireccion.Name = "textBoxNumeroDireccion";
            this.textBoxNumeroDireccion.Size = new System.Drawing.Size(63, 20);
            this.textBoxNumeroDireccion.TabIndex = 32;
            this.textBoxNumeroDireccion.Text = "NUMERO";
            // 
            // textBoxPuertaDireccion
            // 
            this.textBoxPuertaDireccion.Location = new System.Drawing.Point(365, 221);
            this.textBoxPuertaDireccion.Name = "textBoxPuertaDireccion";
            this.textBoxPuertaDireccion.Size = new System.Drawing.Size(63, 20);
            this.textBoxPuertaDireccion.TabIndex = 33;
            this.textBoxPuertaDireccion.Text = "PUERTA";
            // 
            // textBoxPisoDireccion
            // 
            this.textBoxPisoDireccion.Location = new System.Drawing.Point(454, 221);
            this.textBoxPisoDireccion.Name = "textBoxPisoDireccion";
            this.textBoxPisoDireccion.Size = new System.Drawing.Size(63, 20);
            this.textBoxPisoDireccion.TabIndex = 34;
            this.textBoxPisoDireccion.Text = "PISO";
            // 
            // textBoxCodigoPostalDireccion
            // 
            this.textBoxCodigoPostalDireccion.Location = new System.Drawing.Point(557, 221);
            this.textBoxCodigoPostalDireccion.Name = "textBoxCodigoPostalDireccion";
            this.textBoxCodigoPostalDireccion.Size = new System.Drawing.Size(113, 20);
            this.textBoxCodigoPostalDireccion.TabIndex = 35;
            this.textBoxCodigoPostalDireccion.Text = "CODIGO POSTAL";
            // 
            // textBoxProvinciaDireccion
            // 
            this.textBoxProvinciaDireccion.Location = new System.Drawing.Point(71, 260);
            this.textBoxProvinciaDireccion.Name = "textBoxProvinciaDireccion";
            this.textBoxProvinciaDireccion.Size = new System.Drawing.Size(266, 20);
            this.textBoxProvinciaDireccion.TabIndex = 36;
            this.textBoxProvinciaDireccion.Text = "PROVINCIA";
            // 
            // textBoxPaisDireccion
            // 
            this.textBoxPaisDireccion.Location = new System.Drawing.Point(404, 260);
            this.textBoxPaisDireccion.Name = "textBoxPaisDireccion";
            this.textBoxPaisDireccion.Size = new System.Drawing.Size(266, 20);
            this.textBoxPaisDireccion.TabIndex = 37;
            this.textBoxPaisDireccion.Text = "PAIS";
            // 
            // CrearReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(937, 525);
            this.Controls.Add(this.textBoxPaisDireccion);
            this.Controls.Add(this.textBoxProvinciaDireccion);
            this.Controls.Add(this.textBoxCodigoPostalDireccion);
            this.Controls.Add(this.textBoxPisoDireccion);
            this.Controls.Add(this.textBoxPuertaDireccion);
            this.Controls.Add(this.textBoxNumeroDireccion);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.textBoxApellido2);
            this.Controls.Add(this.textBoxApellido1);
            this.Controls.Add(this.textBoxCalle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBoxNombre);
            this.Controls.Add(this.btnBuscaCliente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DNI);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CrearReservaForm";
            this.Text = "ReservaForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.TextBox DNI;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscaCliente;
        private System.Windows.Forms.TextBox TextBoxNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCalle;
        private System.Windows.Forms.TextBox textBoxApellido1;
        private System.Windows.Forms.TextBox textBoxApellido2;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNumeroDireccion;
        private System.Windows.Forms.TextBox textBoxPuertaDireccion;
        private System.Windows.Forms.TextBox textBoxPisoDireccion;
        private System.Windows.Forms.TextBox textBoxCodigoPostalDireccion;
        private System.Windows.Forms.TextBox textBoxProvinciaDireccion;
        private System.Windows.Forms.TextBox textBoxPaisDireccion;
    }
}