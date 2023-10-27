using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HotelSolRepo.Vista
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            ConectarControladoresEventos();  // Conecta los controladores de eventos

        }

        private void ConectarControladoresEventos()
        {
            btnNuevaReserva.Click += BtnNuevaReserva_Click;
            btnExportarXML.Click += BtnExportarXML_Click;
            btnImportarXML.Click += BtnImportarXML_Click;
        }

        private void BtnNuevaReserva_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new ReservaForm());
        }

        private void BtnExportarXML_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new ExportarForm());
        }

        private void BtnImportarXML_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new ImportarForm());
        }

        public void MostrarFormulario(Form formulario)
        {
            // Configura las propiedades del formulario para que pueda incrustarse en el panel

            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;

            // Limpia el panel y agrega el nuevo formulario
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(formulario);

            // Muestra el formulario
            formulario.BringToFront();
            formulario.Show();
        }
    }
}