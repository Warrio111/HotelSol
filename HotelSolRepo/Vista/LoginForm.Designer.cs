namespace HotelSolRepo.Vista
{
    partial class LoginForm
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
            this.textBoxLoginNIF = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBoxLoginPass = new System.Windows.Forms.TextBox();
            this.btnLoginValidation = new System.Windows.Forms.Button();
            this.btnGoToReserva = new System.Windows.Forms.Button();
            this.mensaje = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLoginNIF
            // 
            this.textBoxLoginNIF.Location = new System.Drawing.Point(302, 84);
            this.textBoxLoginNIF.Name = "textBoxLoginNIF";
            this.textBoxLoginNIF.Size = new System.Drawing.Size(186, 20);
            this.textBoxLoginNIF.TabIndex = 0;
            this.textBoxLoginNIF.Text = "INTRODUZCA SU NIF/DNI";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBoxLoginPass
            // 
            this.textBoxLoginPass.Location = new System.Drawing.Point(302, 135);
            this.textBoxLoginPass.Name = "textBoxLoginPass";
            this.textBoxLoginPass.Size = new System.Drawing.Size(186, 20);
            this.textBoxLoginPass.TabIndex = 2;
            this.textBoxLoginPass.Text = "INTRODUZCA SU PASSWORD";
            // 
            // btnLoginValidation
            // 
            this.btnLoginValidation.Location = new System.Drawing.Point(353, 179);
            this.btnLoginValidation.Name = "btnLoginValidation";
            this.btnLoginValidation.Size = new System.Drawing.Size(75, 23);
            this.btnLoginValidation.TabIndex = 3;
            this.btnLoginValidation.Text = "Validar";
            this.btnLoginValidation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoginValidation.UseVisualStyleBackColor = true;
            // 
            // btnGoToReserva
            // 
            this.btnGoToReserva.Location = new System.Drawing.Point(535, 316);
            this.btnGoToReserva.Name = "btnGoToReserva";
            this.btnGoToReserva.Size = new System.Drawing.Size(75, 23);
            this.btnGoToReserva.TabIndex = 4;
            this.btnGoToReserva.Text = "Alta Usuario";
            this.btnGoToReserva.UseVisualStyleBackColor = true;
            // 
            // mensaje
            // 
            this.mensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mensaje.Enabled = false;
            this.mensaje.Location = new System.Drawing.Point(372, 319);
            this.mensaje.Name = "mensaje";
            this.mensaje.ReadOnly = true;
            this.mensaje.Size = new System.Drawing.Size(157, 13);
            this.mensaje.TabIndex = 5;
            this.mensaje.Text = "NO ESTAS DADO DE ALTA? >";
            this.mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mensaje);
            this.Controls.Add(this.btnGoToReserva);
            this.Controls.Add(this.btnLoginValidation);
            this.Controls.Add(this.textBoxLoginPass);
            this.Controls.Add(this.textBoxLoginNIF);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLoginNIF;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textBoxLoginPass;
        private System.Windows.Forms.Button btnLoginValidation;
        private System.Windows.Forms.Button btnGoToReserva;
        private System.Windows.Forms.TextBox mensaje;
    }
}