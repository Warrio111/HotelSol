using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace HotelSolRepo.Vista
{
    public partial class CrearReservaForm : Form
    {
        private ReservaController reservaController = new ReservaController();
        private HotelDBEntities db = new HotelDBEntities();
        private string AuthenticatedClientNIF { get; set; }

        public CrearReservaForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            this.Load += new EventHandler(this.ReservaForm_Load);
            btnConfirmar.Click += new EventHandler(this.ValidarYCrearReserva);
            btnBuscaCliente.Click += new EventHandler(this.BuscarCliente_Click);

            exportXmlWrapperType = typeof(ReservasListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }
        }

        private void ReservaForm_Load(object sender, EventArgs e)
        {
            var tiposHabitaciones = db.Habitaciones.Select(h => h.Tipo).Distinct().ToList();
            foreach (var tipo in tiposHabitaciones)
            {
                comboBox1.Items.Add(tipo);
                comboBox2.Items.Add(tipo);
                comboBox3.Items.Add(tipo);
            }
        }

        private void ValidarYCrearReserva(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AuthenticatedClientNIF))
            {
                MessageBox.Show("Cliente no autenticado. Por favor, valide un cliente.");
                btnConfirmar.Enabled = false;
                return;
            }

            if (!ComprobarDisponibilidad())
            {
                MessageBox.Show("No hay disponibilidad para las habitaciones seleccionadas.");
                btnConfirmar.Enabled = false;
                return;
            }

            GenerarReservaTemporal();
        }

        private bool ComprobarDisponibilidad()
        {
            // Lógica para comprobar la disponibilidad
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            List<int> habitacionesSeleccionadas = ObtenerHabitacionesSeleccionadas();
            List<int> cantidades = ObtenerCantidadesSeleccionadas();

            return reservaController.ComprobarDisponibilidad(fechaInicio, fechaFin, habitacionesSeleccionadas, cantidades);
        }

        private List<int> ObtenerHabitacionesSeleccionadas()
        {
            List<int> habitacionesSeleccionadas = new List<int>();
            if (comboBox1.SelectedItem != null)
            {
                habitacionesSeleccionadas.Add(ConvertToNumericType(comboBox1.SelectedItem.ToString()));
            }
            if (comboBox2.SelectedItem != null)
            {
                habitacionesSeleccionadas.Add(ConvertToNumericType(comboBox2.SelectedItem.ToString()));
            }
            if (comboBox3.SelectedItem != null)
            {
                habitacionesSeleccionadas.Add(ConvertToNumericType(comboBox3.SelectedItem.ToString()));
            }
            return habitacionesSeleccionadas;
        }

        private List<int> ObtenerCantidadesSeleccionadas()
        {
            List<int> cantidades = new List<int>();
            if (comboBox1.SelectedItem != null)
            {
                cantidades.Add((int)numericUpDown1.Value);
            }
            if (comboBox2.SelectedItem != null)
            {
                cantidades.Add((int)numericUpDown2.Value);
            }
            if (comboBox3.SelectedItem != null)
            {
                cantidades.Add((int)numericUpDown3.Value);
            }
            return cantidades;
        }

        private void GenerarReservaTemporal()
        {
            // Lógica para generar la reserva temporal
            MessageBox.Show("Reserva temporal creada con éxito.");
        }

        private void BuscarCliente_Click(object sender, EventArgs e)
        {
            string nif = DNI.Text;
            ClienteController clienteController = new ClienteController();
            var cliente = clienteController.ObtenerClientePorNIF(nif);

            if (cliente != null)
            {
                AuthenticatedClientNIF = cliente.NIF;
                ActualizarCamposCliente(cliente);
                MessageBox.Show("Cliente autenticado con éxito.");
                btnConfirmar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado. Por favor, verifique el NIF/DNI.");
                AuthenticatedClientNIF = null;
                btnConfirmar.Enabled = false;
            }
        }

        private void ActualizarCamposCliente(Clientes cliente)
        {
            TextBoxNombre.Text = cliente.Nombre;
            textBoxApellido1.Text = cliente.Apellido1;
            textBoxApellido2.Text = cliente.Apellido2;
            textBoxTelefono.Text = cliente.Telefono;
            textBoxEmail.Text = cliente.CorreoElectronico;
        }

        private int ConvertToNumericType(string tipoHabitacion)
        {
            // Convertir tipo de habitación a su respectivo ID numérico
            switch (tipoHabitacion)
            {
                case "Sencilla": return 1;
                case "Doble": return 2;
                case "Suite": return 3;
                default: return 0;
            }
        }
        private string GetPensionType(CheckBox mediaPension, CheckBox pensionCompleta)
        {
            if (mediaPension.Checked)
                return "Media Pension";
            else if (pensionCompleta.Checked)
                return "Pension Completa";
            else
                return "Sin Pension";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}





