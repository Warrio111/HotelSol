// NO SE AJUSTA AL MVC PERO NO ME DA TIEMPO A REFACTORIZAR. 

using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace HotelSolRepo.Vista
{
    public partial class CrearReservaForm : Form
    {
        private readonly ReservaController reservaController = new ReservaController();
        private readonly ClienteController clienteController = new ClienteController();
        //private readonly HabitacionController habitacionController = new HabitacionController();
        private readonly HotelDBEntities db = new HotelDBEntities();
        private string AuthenticatedClientNIF { get; set; }
        private int AuthenticatedEmployeeID { get; set; }

   

        public CrearReservaForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            SuscribirEventos();
           
            exportXmlWrapperType = typeof(ReservasListXmlWrapper);
            this.Owner = formularioPadre;
            EstablecerInteraccionConFormPrincipal();

            if (Owner is FormPrincipal principal)
            {
                AuthenticatedEmployeeID = principal.AuthenticatedEmployeeID;
            }
        }

        private void SuscribirEventos()
        {
            this.Load += new EventHandler(ReservaForm_Load);
            btnConfirmar.Click += new EventHandler(ValidarYCrearReserva);
            btnBuscaCliente.Click += new EventHandler(BuscarCliente_Click);
        }

        private void EstablecerInteraccionConFormPrincipal()
        {
            if (this.Owner is FormPrincipal formPrincipal)
            {
                formPrincipal.OnPrincipalFormCalled(this);
            }
        }

        private void ReservaForm_Load(object sender, EventArgs e)
        {
            CargarTiposDeHabitacion();
        }

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

            string pensionHabitacion1 = GetPensionType(checkBoxMediaPensionCombo1, checkBoxPensionCompletaCombo1);
            string pensionHabitacion2 = GetPensionType(checkBoxMediaPensionCombo2, checkBoxPensionCompletaCombo2);
            string pensionHabitacion3 = GetPensionType(checkBoxMediaPensionCombo3, checkBoxPensionCompletaCombo3);

            // Llamada al método CrearReservaTemporal
            CrearReservaTemporal();

            // Abrir el formulario GenerarReserva
            AbrirGenerarReserva();
        }

        private void AbrirGenerarReserva()
        {
            if (this.Owner is FormPrincipal principalForm)
            {
                GenerarReserva generarReservaForm = new GenerarReserva();
                principalForm.MostrarFormulario(generarReservaForm);
            }
            else
            {
                MessageBox.Show("Error: No se pudo abrir el formulario GenerarReserva.");
            }
        }


        private bool EsClienteNoAutenticado()
        {
            return string.IsNullOrEmpty(AuthenticatedClientNIF);
        }

        private void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private bool ComprobarDisponibilidad()
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            List<int> habitacionesSeleccionadas = ObtenerHabitacionesSeleccionadas();
            List<int> cantidades = ObtenerCantidadesSeleccionadas();

            return reservaController.ComprobarDisponibilidad(fechaInicio, fechaFin, habitacionesSeleccionadas, cantidades);
        }

        private List<int> ObtenerHabitacionesSeleccionadas()
        {
            return new List<int>
            {
                comboBox1.SelectedItem != null ? ConvertToNumericType(comboBox1.SelectedItem.ToString()) : 0,
                comboBox2.SelectedItem != null ? ConvertToNumericType(comboBox2.SelectedItem.ToString()) : 0,
                comboBox3.SelectedItem != null ? ConvertToNumericType(comboBox3.SelectedItem.ToString()) : 0
            }.Where(h => h != 0).ToList();
        }

        private List<int> ObtenerCantidadesSeleccionadas()
        {
            return new List<int>
            {
                comboBox1.SelectedItem != null ? (int)numericUpDown1.Value : 0,
                comboBox2.SelectedItem != null ? (int)numericUpDown2.Value : 0,
                comboBox3.SelectedItem != null ? (int)numericUpDown3.Value : 0
            }.Where(c => c != 0).ToList();
        }
     

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

        private void CrearReservaTemporal()
        {
            // Crear el objeto Cliente con los datos del formulario
            ClientesXmlWrapper clienteXml = new ClientesXmlWrapper
            {
                NIF = AuthenticatedClientNIF,
                Nombre = TextBoxNombre.Text,
                PrimerApellido = textBoxApellido1.Text,
                SegundoApellido = textBoxApellido2.Text,
                CorreoElectronico = textBoxEmail.Text,
                Telefono = textBoxTelefono.Text
                // Añadir más detalles del cliente si es necesario
            };

            // Crear el objeto Dirección con los datos del formulario
            DireccionesXmlWrapper direccionXml = new DireccionesXmlWrapper
            {
                Calle = textBoxCalle.Text,
                Numero = textBoxNumeroDireccion.Text,
                Puerta = textBoxPuertaDireccion.Text,
                Piso = textBoxPisoDireccion.Text,
                CodigoPostal = textBoxCodigoPostalDireccion.Text,
                Provincia = textBoxProvinciaDireccion.Text,
                Pais = textBoxPaisDireccion.Text
            };

            // Crear objetos de habitaciones asociadas a la reserva
            List<ReservaHabitacionesXmlWrapper> habitacionesReservadas = new List<ReservaHabitacionesXmlWrapper>();
            var tiposPensiones = new List<string>
    {
        GetPensionType(checkBoxMediaPensionCombo1, checkBoxPensionCompletaCombo1),
        GetPensionType(checkBoxMediaPensionCombo2, checkBoxPensionCompletaCombo2),
        GetPensionType(checkBoxMediaPensionCombo3, checkBoxPensionCompletaCombo3)
    };

            var habitacionesSeleccionadas = ObtenerHabitacionesSeleccionadas();
            for (int i = 0; i < habitacionesSeleccionadas.Count; i++)
            {
                habitacionesReservadas.Add(new ReservaHabitacionesXmlWrapper
                {
                    HabitacionID = habitacionesSeleccionadas[i],
                    TipoPension = tiposPensiones[i],
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value
                    // Añadir más campos si es necesario
                });
            }

            // Crear el objeto contenedor con todos los objetos relacionados
            ReservaCompletaXmlWrapper reservaCompleta = new ReservaCompletaXmlWrapper
            {
                Cliente = clienteXml,
                Direccion = direccionXml,
                ReservaHabitaciones = habitacionesReservadas,
                Reserva = new ReservasXmlWrapper
                {
                    EmpleadoID = AuthenticatedEmployeeID,
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    EstadoReserva = "Temporal",
                    NIF = clienteXml.NIF
                }
            };

            // Serializar a XML y guardar en archivo
            XmlSerializer serializer = new XmlSerializer(typeof(ReservaCompletaXmlWrapper));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, reservaCompleta);
            string xmlReserva = writer.ToString();
             
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "reserva_temporal.xml");
            File.Create(rutaArchivo).Close();
            File.WriteAllText(rutaArchivo, xmlReserva);

            MessageBox.Show("Reserva completa creada y guardada en " + rutaArchivo);
        }


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

        private string GetPensionType(CheckBox mediaPension, CheckBox pensionCompleta)
        {
            if (mediaPension.Checked)
                return "Media Pension";
            if (pensionCompleta.Checked)
                return "Pension Completa";
            return "Sin Pension";
        }
    }
}








