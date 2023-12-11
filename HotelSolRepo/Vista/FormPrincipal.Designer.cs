namespace HotelSolRepo.Vista
{
    partial class FormPrincipal
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
            this.btnNuevaReserva = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.buttonOdoo = new System.Windows.Forms.Button();
            this.buttonGestionHabitaciones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnNuevaReserva.Location = new System.Drawing.Point(1, 367);
            this.btnNuevaReserva.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(165, 98);
            this.btnNuevaReserva.TabIndex = 0;
            this.btnNuevaReserva.Text = "Gestion Reservas";
            this.btnNuevaReserva.UseVisualStyleBackColor = true;
            this.btnNuevaReserva.Click += new System.EventHandler(this.btnNuevaReserva_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BackgroundImage = global::HotelSolRepo.Properties.Resources.logo;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(175, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1429, 812);
            this.panel1.TabIndex = 4;
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnGestionClientes.Location = new System.Drawing.Point(1, 95);
            this.btnGestionClientes.Margin = new System.Windows.Forms.Padding(4);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Size = new System.Drawing.Size(165, 100);
            this.btnGestionClientes.TabIndex = 7;
            this.btnGestionClientes.Text = "Gestion de Clientes";
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            this.btnGestionClientes.Click += new System.EventHandler(this.BtnGestionClientes_Click);
            // 
            // buttonOdoo
            // 
            this.buttonOdoo.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonOdoo.Location = new System.Drawing.Point(1, 495);
            this.buttonOdoo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOdoo.Name = "buttonOdoo";
            this.buttonOdoo.Size = new System.Drawing.Size(165, 100);
            this.buttonOdoo.TabIndex = 9;
            this.buttonOdoo.Text = "Gestion de Odoo";
            this.buttonOdoo.UseVisualStyleBackColor = true;
            this.buttonOdoo.Click += new System.EventHandler(this.buttonOdoo_click);
            // 
            // buttonGestionHabitaciones
            // 
            this.buttonGestionHabitaciones.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            this.buttonGestionHabitaciones.Location = new System.Drawing.Point(1, 230);
            this.buttonGestionHabitaciones.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGestionHabitaciones.Name = "buttonGestionHabitaciones";
            this.buttonGestionHabitaciones.Size = new System.Drawing.Size(165, 100);
            this.buttonGestionHabitaciones.TabIndex = 11;
            this.buttonGestionHabitaciones.Text = "Gestion de Habitaciones";
            this.buttonGestionHabitaciones.UseVisualStyleBackColor = true;
            this.buttonGestionHabitaciones.Click += new System.EventHandler(this.buttonGestionHabitaciones_click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1604, 812);
            this.Controls.Add(this.buttonGestionHabitaciones);
            this.Controls.Add(this.buttonOdoo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGestionClientes);
            this.Controls.Add(this.btnNuevaReserva);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Button buttonOdoo;
        private System.Windows.Forms.Button buttonGestionHabitaciones;
    }
}