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
            this.checkBoxMediaPensionCombo3 = new System.Windows.Forms.CheckBox();
            this.checkBoxPensionCompletaCombo1 = new System.Windows.Forms.CheckBox();
            this.checkBoxMediaPensionCombo2 = new System.Windows.Forms.CheckBox();
            this.checkBoxPensionCompletaCombo3 = new System.Windows.Forms.CheckBox();
            this.checkBoxMediaPensionCombo1 = new System.Windows.Forms.CheckBox();
            this.checkBoxPensionCompletaCombo2 = new System.Windows.Forms.CheckBox();
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
            // checkBoxMediaPensionCombo3
            // 
            this.checkBoxMediaPensionCombo3.AutoSize = true;
            this.checkBoxMediaPensionCombo3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxMediaPensionCombo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMediaPensionCombo3.Location = new System.Drawing.Point(408, 464);
            this.checkBoxMediaPensionCombo3.Name = "checkBoxMediaPensionCombo3";
            this.checkBoxMediaPensionCombo3.Size = new System.Drawing.Size(109, 17);
            this.checkBoxMediaPensionCombo3.TabIndex = 12;
            this.checkBoxMediaPensionCombo3.Text = "Media Pension";
            this.checkBoxMediaPensionCombo3.UseVisualStyleBackColor = false;
            // 
            // checkBoxPensionCompletaCombo1
            // 
            this.checkBoxPensionCompletaCombo1.AutoSize = true;
            this.checkBoxPensionCompletaCombo1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPensionCompletaCombo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPensionCompletaCombo1.Location = new System.Drawing.Point(534, 410);
            this.checkBoxPensionCompletaCombo1.Name = "checkBoxPensionCompletaCombo1";
            this.checkBoxPensionCompletaCombo1.Size = new System.Drawing.Size(127, 17);
            this.checkBoxPensionCompletaCombo1.TabIndex = 13;
            this.checkBoxPensionCompletaCombo1.Text = "Pension Completa";
            this.checkBoxPensionCompletaCombo1.UseVisualStyleBackColor = false;
            // 
            // checkBoxMediaPensionCombo2
            // 
            this.checkBoxMediaPensionCombo2.AutoSize = true;
            this.checkBoxMediaPensionCombo2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxMediaPensionCombo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMediaPensionCombo2.Location = new System.Drawing.Point(408, 436);
            this.checkBoxMediaPensionCombo2.Name = "checkBoxMediaPensionCombo2";
            this.checkBoxMediaPensionCombo2.Size = new System.Drawing.Size(109, 17);
            this.checkBoxMediaPensionCombo2.TabIndex = 14;
            this.checkBoxMediaPensionCombo2.Text = "Media Pension";
            this.checkBoxMediaPensionCombo2.UseVisualStyleBackColor = false;
            // 
            // checkBoxPensionCompletaCombo3
            // 
            this.checkBoxPensionCompletaCombo3.AutoSize = true;
            this.checkBoxPensionCompletaCombo3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPensionCompletaCombo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPensionCompletaCombo3.Location = new System.Drawing.Point(534, 463);
            this.checkBoxPensionCompletaCombo3.Name = "checkBoxPensionCompletaCombo3";
            this.checkBoxPensionCompletaCombo3.Size = new System.Drawing.Size(127, 17);
            this.checkBoxPensionCompletaCombo3.TabIndex = 15;
            this.checkBoxPensionCompletaCombo3.Text = "Pension Completa";
            this.checkBoxPensionCompletaCombo3.UseVisualStyleBackColor = false;
            // 
            // checkBoxMediaPensionCombo1
            // 
            this.checkBoxMediaPensionCombo1.AutoSize = true;
            this.checkBoxMediaPensionCombo1.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxMediaPensionCombo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxMediaPensionCombo1.Location = new System.Drawing.Point(408, 410);
            this.checkBoxMediaPensionCombo1.Name = "checkBoxMediaPensionCombo1";
            this.checkBoxMediaPensionCombo1.Size = new System.Drawing.Size(109, 17);
            this.checkBoxMediaPensionCombo1.TabIndex = 16;
            this.checkBoxMediaPensionCombo1.Text = "Media Pension";
            this.checkBoxMediaPensionCombo1.UseVisualStyleBackColor = false;
            // 
            // checkBoxPensionCompletaCombo2
            // 
            this.checkBoxPensionCompletaCombo2.AutoSize = true;
            this.checkBoxPensionCompletaCombo2.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxPensionCompletaCombo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPensionCompletaCombo2.Location = new System.Drawing.Point(534, 436);
            this.checkBoxPensionCompletaCombo2.Name = "checkBoxPensionCompletaCombo2";
            this.checkBoxPensionCompletaCombo2.Size = new System.Drawing.Size(127, 17);
            this.checkBoxPensionCompletaCombo2.TabIndex = 17;
            this.checkBoxPensionCompletaCombo2.Text = "Pension Completa";
            this.checkBoxPensionCompletaCombo2.UseVisualStyleBackColor = false;
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
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "LLEGADA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(390, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "SALIDA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(68, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
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
            this.Controls.Add(this.checkBoxPensionCompletaCombo2);
            this.Controls.Add(this.checkBoxMediaPensionCombo1);
            this.Controls.Add(this.checkBoxPensionCompletaCombo3);
            this.Controls.Add(this.checkBoxMediaPensionCombo2);
            this.Controls.Add(this.checkBoxPensionCompletaCombo1);
            this.Controls.Add(this.checkBoxMediaPensionCombo3);
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
        private System.Windows.Forms.CheckBox checkBoxMediaPensionCombo3;
        private System.Windows.Forms.CheckBox checkBoxPensionCompletaCombo1;
        private System.Windows.Forms.CheckBox checkBoxMediaPensionCombo2;
        private System.Windows.Forms.CheckBox checkBoxPensionCompletaCombo3;
        private System.Windows.Forms.CheckBox checkBoxMediaPensionCombo1;
        private System.Windows.Forms.CheckBox checkBoxPensionCompletaCombo2;
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