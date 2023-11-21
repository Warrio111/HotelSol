using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HotelSolRepo.Vista
{
    public partial class CrearReservaForm : Form
    {
        private readonly ReservaController reservaController = new ReservaController();
        private readonly ClienteController clienteController = new ClienteController();
        private readonly HabitacionController habitacionController = new HabitacionController();
        private readonly HotelDBEntities db = new HotelDBEntities();
        private string AuthenticatedClientNIF { get; set; }
        private int AuthenticatedEmployeeID { get; set; }

        // Constructor que recibe el tipo de exportación XML y el formulario principal
        public CrearReservaForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            SuscribirEventos();
            exportXmlWrapperType = typeof(ReservasListXmlWrapper);
            this.Owner = formularioPadre;
            EstablecerInteraccionConFormPrincipal();

            // Establecer el ID del empleado autenticado desde el formulario principal
            if (Owner is FormPrincipal principal)
            {
                AuthenticatedEmployeeID = principal.AuthenticatedEmployeeID;
            }
        }

        // Método para suscribir eventos a los controles
        private void SuscribirEventos()
        {
            this.Load += new EventHandler(ReservaForm_Load);
            btnConfirmar.Click += new EventHandler(ValidarYCrearReserva);
            btnBuscaCliente.Click += new EventHandler(BuscarCliente_Click);
            // Aquí puedes añadir otros suscriptores a eventos según sea necesario
        }

        // Método para establecer la interacción con FormPrincipal
        private void EstablecerInteraccionConFormPrincipal()
        {
            if (this.Owner is FormPrincipal formPrincipal)
            {
                formPrincipal.OnPrincipalFormCalled(this);
            }
        }

        // Evento Load del formulario
        private void ReservaForm_Load(object sender, EventArgs e)
        {
            CargarTiposDeHabitacion();
        }

        // Método para cargar tipos de habitaciones en los ComboBox
        private void CargarTiposDeHabitacion()
        {
            var tiposHabitaciones = db.Habitaciones.Select(h => h.Tipo).Distinct().ToList();
            foreach (var tipo in tiposHabitaciones)
            {
                comboBox1.Items.Add(tipo);
                comboBox2.Items.Add(tipo);
                comboBox3.Items.Add(tipo);
            }
        }

        // Método para validar y crear la reserva
        private void ValidarYCrearReserva(object sender, EventArgs e)
        {
            if (EsClienteNoAutenticado())
            {
                MostrarMensaje("Cliente no autenticado. Por favor, valide un cliente.");
                return;
            }

            if (!ComprobarDisponibilidad())
            {
                MostrarMensaje("No hay disponibilidad para las habitaciones seleccionadas.");
                return;
            }

        }

        // Método para verificar si un cliente está autenticado
        private bool EsClienteNoAutenticado()
        {
            bool noAutenticado = string.IsNullOrEmpty(AuthenticatedClientNIF);
            btnConfirmar.Enabled = !noAutenticado;
            return noAutenticado;
        }

        // Método para mostrar mensajes al usuario
        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        // Método para comprobar la disponibilidad de las habitaciones
        private bool ComprobarDisponibilidad()
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            List<int> habitacionesSeleccionadas = ObtenerHabitacionesSeleccionadas();
            List<int> cantidades = ObtenerCantidadesSeleccionadas();

            return reservaController.ComprobarDisponibilidad(fechaInicio, fechaFin, habitacionesSeleccionadas, cantidades);
        }

        // Método para obtener las habitaciones seleccionadas
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

        // Método para obtener las cantidades seleccionadas
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

      
        // Aqui, método para realizar la exportación de las reservas a un archivo XML usando XmlController
       

        // Evento Click para buscar un cliente por NIF
        private void BuscarCliente_Click(object sender, EventArgs e)
        {
            string nif = DNI.Text;
            var cliente = clienteController.ObtenerClientePorNIF(nif);

            if (cliente != null)
            {
                AutenticarYActualizarCliente(cliente);
            }
            else
            {
                MostrarMensaje("Cliente no encontrado. Por favor, verifique el NIF/DNI.");
                AuthenticatedClientNIF = null;
                btnConfirmar.Enabled = false;
            }
        }

        // Método para autenticar y actualizar los datos del cliente en la interfaz
        private void AutenticarYActualizarCliente(Clientes cliente)
        {
            AuthenticatedClientNIF = cliente.NIF;
            ActualizarCamposCliente(cliente);
            MostrarMensaje("Cliente autenticado con éxito.");
            btnConfirmar.Enabled = true;
        }

        private void ActualizarCamposCliente(Clientes cliente)
        {
            TextBoxNombre.Text = cliente.Nombre;
            textBoxApellido1.Text = cliente.PrimerApellido;
            textBoxApellido2.Text = cliente.SegundoApellido;
            textBoxTelefono.Text = cliente.Telefono;
            textBoxEmail.Text = cliente.CorreoElectronico;

            // Dado que existe una relación de clave foránea entre Clientes y Direcciones
            var direccionId = cliente.DireccionID;
            if (direccionId.HasValue)
            {
                // Obtener la dirección del cliente
                var direccion = db.Direcciones.FirstOrDefault(d => d.DireccionID == direccionId.Value);
                if (direccion != null)
                {
                    textBoxCalle.Text = direccion.Calle;
                    textBoxNumeroDireccion.Text = direccion.Numero;
                    textBoxPuertaDireccion.Text = direccion.Puerta;
                    textBoxPisoDireccion.Text = direccion.Piso;
                    textBoxCodigoPostalDireccion.Text = direccion.CodigoPostal;
                    textBoxProvinciaDireccion.Text = direccion.Provincia;
                    textBoxPaisDireccion.Text = direccion.Pais;
                }
            }
        }

        // Método para convertir el tipo de habitación a un tipo numérico
        private int ConvertToNumericType(string tipoHabitacion)
        {
            switch (tipoHabitacion)
            {
                case "Sencilla": return 1;
                case "Doble": return 2;
                case "Suite": return 3;
                default: return 0;
            }
        }

        // Método para obtener el tipo de pensión en base a los CheckBox seleccionados
        private string GetPensionType(CheckBox mediaPension, CheckBox pensionCompleta)
        {
            if (mediaPension.Checked)
                return "Media Pension";
            else if (pensionCompleta.Checked)
                return "Pension Completa";
            else
                return "Sin Pension";
        }
    }
}








