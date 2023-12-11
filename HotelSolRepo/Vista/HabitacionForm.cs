using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
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
    public partial class HabitacionForm : Form
    {
        private ClienteController clienteController;
        private HabitacionController habitacionController;
        private DireccionController direccionController;
        private ReservaController reservaController;
        private FacturaController facturaController;
        private ProgramaFidelizacionController programaFidelizacionController;
        private IncidenciaController incidenciaController;
        public HabitacionForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            clienteController = new ClienteController();
            habitacionController = new HabitacionController();
            direccionController = new DireccionController();
            reservaController = new ReservaController();
            facturaController = new FacturaController();
            incidenciaController = new IncidenciaController();
            programaFidelizacionController = new ProgramaFidelizacionController();
            this.Load += new EventHandler(HabitacionForm_Load);

            exportXmlWrapperType = typeof(HabitacionesListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }
        }

        private void HabitacionForm_Load(object sender, EventArgs e)
        {
            textBoxIDHabitacionIncidencia.Visible = false;
            textBoxIncidenciaMensaje.Visible = false;
            buttonEnviarMensajeIncidencia.Visible = false;
            dataGridViewIncidencias.Visible = false;
            dataGridViewHabitaciones.Visible = false;
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet1.Incidencias' Puede moverla o quitarla según sea necesario.
            this.incidenciasTableAdapter.Fill(this.hotelDBDataSet1.Incidencias);
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet.Habitaciones' Puede moverla o quitarla según sea necesario.
            this.habitacionesTableAdapter.Fill(this.hotelDBDataSet.Habitaciones);
            
        }
        private void textBoxIncidenciaMensaje_TextChanged(object sender, EventArgs e)
        {
            // Ajusta automáticamente la altura del TextBox según el contenido
            int lineas = textBoxIncidenciaMensaje.GetLineFromCharIndex(textBoxIncidenciaMensaje.TextLength) + 1;
            int alturaLinea = textBoxIncidenciaMensaje.Font.Height;
            int nuevaAltura = textBoxIncidenciaMensaje.Margin.Top + alturaLinea * (lineas + 2);  // Se suma 2 para proporcionar algún espacio adicional
            textBoxIncidenciaMensaje.Height = nuevaAltura;
        }
        private void buttonRegistrarIncidencia_click(object sender, EventArgs e)
        {
            textBoxIDHabitacionIncidencia.Visible = true;
            textBoxIncidenciaMensaje.Visible = true;
            buttonEnviarMensajeIncidencia.Visible = true;
        }

        private void buttonVerIncidencia_click(object sender, EventArgs e)
        {
            HabitacionForm_Load(sender, e);
            dataGridViewIncidencias.Visible = true;
        }

        private void buttonVerHabitaciones_click(object sender, EventArgs e)
        {
            HabitacionForm_Load(sender, e);
            dataGridViewHabitaciones.Visible = true;
        }

        private void buttonEnviarMensageIncidencia_click(object sender, EventArgs e)
        {
            string habitacionIDText = textBoxIDHabitacionIncidencia.Text;
            string mensaje = textBoxIncidenciaMensaje.Text;

            if (!string.IsNullOrEmpty(habitacionIDText) && !string.IsNullOrEmpty(mensaje))
            {
                if (int.TryParse(habitacionIDText, out int habitacionID))
                {
                    bool result = incidenciaController.RegistrarIncidencia(habitacionID, mensaje);
                    MessageBox.Show(result ? "Incidencia registrada correctamente" : "Error al registrar la incidencia");
                }
                else
                {
                    MessageBox.Show("El ID de la habitación debe ser un número válido");
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar todos los campos de forma correcta");
            }
        }
    }
}
