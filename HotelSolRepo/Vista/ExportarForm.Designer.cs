﻿namespace HotelSolRepo.Vista
{
    partial class ExportarForm
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
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.SuspendLayout();
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Location = new System.Drawing.Point(75, 42);
            this.printPreviewControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(541, 379);
            this.printPreviewControl1.TabIndex = 0;
            this.printPreviewControl1.Click += new System.EventHandler(this.printPreviewControl1_Click);
            // 
            // ExportarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 486);
            this.Controls.Add(this.printPreviewControl1);
            this.Name = "ExportarForm";
            this.Text = "ExportarForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
    }
}