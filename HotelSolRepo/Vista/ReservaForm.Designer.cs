namespace HotelSolRepo.Vista
{
    partial class ReservaForm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnCheckAvaliable = new System.Windows.Forms.Button();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.btnLoginMenu = new System.Windows.Forms.Button();
            this.brnRegisterMenu = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(88, 95);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(269, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(88, 150);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(269, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(88, 206);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // btnCheckAvaliable
            // 
            this.btnCheckAvaliable.Location = new System.Drawing.Point(88, 266);
            this.btnCheckAvaliable.Name = "btnCheckAvaliable";
            this.btnCheckAvaliable.Size = new System.Drawing.Size(128, 22);
            this.btnCheckAvaliable.TabIndex = 3;
            this.btnCheckAvaliable.Text = "Comprobar";
            this.btnCheckAvaliable.UseVisualStyleBackColor = true;
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // btnLoginMenu
            // 
            this.btnLoginMenu.Location = new System.Drawing.Point(568, 25);
            this.btnLoginMenu.Name = "btnLoginMenu";
            this.btnLoginMenu.Size = new System.Drawing.Size(75, 23);
            this.btnLoginMenu.TabIndex = 4;
            this.btnLoginMenu.Text = "Login";
            this.btnLoginMenu.UseVisualStyleBackColor = true;
            // 
            // brnRegisterMenu
            // 
            this.brnRegisterMenu.Location = new System.Drawing.Point(672, 25);
            this.brnRegisterMenu.Name = "brnRegisterMenu";
            this.brnRegisterMenu.Size = new System.Drawing.Size(75, 23);
            this.brnRegisterMenu.TabIndex = 5;
            this.brnRegisterMenu.Text = "Registro";
            this.brnRegisterMenu.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(568, 402);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(159, 59);
            this.btnConfirmar.TabIndex = 6;
            this.btnConfirmar.Text = "Confirmar Reserva";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // ReservaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 520);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.brnRegisterMenu);
            this.Controls.Add(this.btnLoginMenu);
            this.Controls.Add(this.btnCheckAvaliable);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReservaForm";
            this.Text = "ReservaForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnCheckAvaliable;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.Button btnLoginMenu;
        private System.Windows.Forms.Button brnRegisterMenu;
        private System.Windows.Forms.Button btnConfirmar;
    }
}