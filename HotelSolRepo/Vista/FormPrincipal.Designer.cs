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
            this.btnExportarXML = new System.Windows.Forms.Button();
            this.btnImportarXML = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnNuevaReserva
            // 
            this.btnNuevaReserva.Location = new System.Drawing.Point(12, 12);
            this.btnNuevaReserva.Name = "btnNuevaReserva";
            this.btnNuevaReserva.Size = new System.Drawing.Size(173, 51);
            this.btnNuevaReserva.TabIndex = 0;
            this.btnNuevaReserva.Text = "NuevaReserva";
            this.btnNuevaReserva.UseVisualStyleBackColor = true;
            // 
            // btnExportarXML
            // 
            this.btnExportarXML.Location = new System.Drawing.Point(12, 84);
            this.btnExportarXML.Name = "btnExportarXML";
            this.btnExportarXML.Size = new System.Drawing.Size(173, 51);
            this.btnExportarXML.TabIndex = 1;
            this.btnExportarXML.Text = "ExportarXML";
            this.btnExportarXML.UseVisualStyleBackColor = true;
            // 
            // btnImportarXML
            // 
            this.btnImportarXML.Location = new System.Drawing.Point(12, 157);
            this.btnImportarXML.Name = "btnImportarXML";
            this.btnImportarXML.Size = new System.Drawing.Size(173, 51);
            this.btnImportarXML.TabIndex = 2;
            this.btnImportarXML.Text = "ImportarXML";
            this.btnImportarXML.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(191, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 648);
            this.panel1.TabIndex = 4;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnImportarXML);
            this.Controls.Add(this.btnExportarXML);
            this.Controls.Add(this.btnNuevaReserva);
            this.IsMdiContainer = true;
            this.Name = "FormPrincipal";
            this.Text = "FormPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNuevaReserva;
        private System.Windows.Forms.Button btnExportarXML;
        private System.Windows.Forms.Button btnImportarXML;
        private System.Windows.Forms.Panel panel1;
    }
}