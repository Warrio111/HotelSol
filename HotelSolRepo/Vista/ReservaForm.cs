using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

namespace HotelSolRepo.Vista
{
    public partial class ReservaForm : Form
    {
        private ReservaController reservaController = new ReservaController();
        private HotelDBEntities db = new HotelDBEntities();
        private List<object> datos;


        public ReservaForm(ref Type exportXmlWrapperType, Form formularioPadre)

        {
            InitializeComponent();
            this.Load += new EventHandler(this.ReservaForm_Load);
            btnConfirmar.Click += new EventHandler(this.RealizarReserva_Click);
          
            exportXmlWrapperType = typeof(ReservasListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }


        }
        private void LoginForm_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Cliente Validado.");
                return;
            }

            formPrincipal.MostrarFormulario(new LoginForm());
        }

        private void RegisterForm_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Cliente Validado.");
                return;
            }

            formPrincipal.MostrarFormulario(new RegisterForm());
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

        private void RealizarReserva_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (!formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Por favor, valide un Cliente para realizar una reserva.");
                return;
            }

            // Obtener detalles del cliente
            ClienteController clienteController = new ClienteController();
            var cliente = clienteController.ObtenerClientePorNIF(formPrincipal.AuthenticatedNIF);

            List<HabitacionesXmlWrapper> habitacionesSeleccionadas = new List<HabitacionesXmlWrapper>();
            List<ReservaHabitacionesXmlWrapper> reservaHabitaciones = new List<ReservaHabitacionesXmlWrapper>();

            if (comboBox1.SelectedItem != null)
            {
                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion1 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox1.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox1, checkBox2),
                    NumeroHabitaciones = (int)numericUpDown1.Value
                };
                habitacionesSeleccionadas.Add(habitacion1);

                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva1 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };

                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox1, checkBox2),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion1 },
                    Reservas = new List<ReservasXmlWrapper> { reserva1 }
                });
            }

            if (comboBox2.SelectedItem != null)
            {

                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion2 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox2.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox3, checkBox4),
                    NumeroHabitaciones = (int)numericUpDown2.Value
                };
                habitacionesSeleccionadas.Add(habitacion2);
                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva2 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };
                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox3, checkBox4),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion2 },
                    Reservas = new List<ReservasXmlWrapper> { reserva2 }
                });

            }

            if (comboBox3.SelectedItem != null)
            {
                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion3 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox3.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox5, checkBox6),
                    NumeroHabitaciones = (int)numericUpDown3.Value
                };
                habitacionesSeleccionadas.Add(habitacion3);
                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva3 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };
                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox5, checkBox6),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion3 },
                    Reservas = new List<ReservasXmlWrapper> { reserva3 }
                });
            }


            Type XmlWrapperType = typeof(ReservaHabitacionesXmlWrapper);
            ((FormPrincipal)this.ParentForm).OnXmlWrapperTypeChanged(XmlWrapperType);

            int empleadoID = formPrincipal.AuthenticatedEmployeeID;

            reservaController.GenerarReservaTemporalXml(reservaHabitaciones, empleadoID);


            formPrincipal.MostrarFormulario(new ServiciosExtraForm());
        }
        public ReservaHabitacionesListXmlWrapper RealizarExportDesdeReservas()
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (!formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Por favor, valide un Cliente para realizar una reserva.");
                return null;
            }
            List<HabitacionesXmlWrapper> habitacionesSeleccionadas = new List<HabitacionesXmlWrapper>();
            List<ReservaHabitacionesXmlWrapper> reservaHabitaciones = new List<ReservaHabitacionesXmlWrapper>();

            if (comboBox1.SelectedItem != null)
            {
                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion1 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox1.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox1, checkBox2),
                    NumeroHabitaciones = (int)numericUpDown1.Value
                };
                habitacionesSeleccionadas.Add(habitacion1);

                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva1 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };

                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox1, checkBox2),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion1 },
                    Reservas = new List<ReservasXmlWrapper> { reserva1 }
                });
            }

            if (comboBox2.SelectedItem != null)
            {

                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion2 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox2.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox3, checkBox4),
                    NumeroHabitaciones = (int)numericUpDown2.Value
                };
                habitacionesSeleccionadas.Add(habitacion2);
                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva2 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };
                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox3, checkBox4),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion2 },
                    Reservas = new List<ReservasXmlWrapper> { reserva2 }
                });

            }

            if (comboBox3.SelectedItem != null)
            {
                // Crear instancia de HabitacionesXmlWrapper y agregarla a la lista de habitaciones seleccionadas
                HabitacionesXmlWrapper habitacion3 = new HabitacionesXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox3.SelectedItem.ToString()),
                    Tipo = GetPensionType(checkBox5, checkBox6),
                    NumeroHabitaciones = (int)numericUpDown3.Value
                };
                habitacionesSeleccionadas.Add(habitacion3);
                // Crear instancia de ReservasXmlWrapper y agregarla a la lista de reservas en ReservaHabitacionesXmlWrapper
                ReservasXmlWrapper reserva3 = new ReservasXmlWrapper
                {
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = formPrincipal.AuthenticatedNIF,
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now
                };
                // Crear instancia de ReservaHabitacionesXmlWrapper y agregarla a la lista principal
                reservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox5, checkBox6),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacion3 },
                    Reservas = new List<ReservasXmlWrapper> { reserva3 }
                });
            }

            // Verificar si dateTimePicker1 y dateTimePicker2 no son nulos antes de acceder a sus propiedades
            if (dateTimePicker1 != null && dateTimePicker2 != null)
            {

                ReservasXmlWrapper reservasXmlWrapper = new ReservasXmlWrapper
                {
                    ReservaID = 1,
                    FechaInicio = dateTimePicker1.Value,
                    FechaFin = dateTimePicker2.Value,
                    NIF = ((FormPrincipal)this.ParentForm).AuthenticatedNIF, // Este valor debe venir del usuario autenticado
                    EstadoReserva = "Pendiente",
                    FechaCreacion = DateTime.Now,
                    //Habitaciones = habitacionesSeleccionadas
                };
                ((FormPrincipal)this.Owner).reservaHabitacionesXML.ReservaHabitaciones.Add(new ReservaHabitacionesXmlWrapper
                {
                    TipoPension = GetPensionType(checkBox1, checkBox2),
                    Habitaciones = new List<HabitacionesXmlWrapper> { habitacionesSeleccionadas[0] },
                    Reservas = new List<ReservasXmlWrapper> { reservasXmlWrapper }
                });
            }

            return ((FormPrincipal)this.Owner).reservaHabitacionesXML;
        }

        private void ComprobarDisponibilidad_Click(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            // Inicializar las listas
            List<string> tiposHabitacionesSeleccionadas = new List<string>();
            List<int> cantidades = new List<int>();

            // Verificar cada ComboBox y agregar el tipo de habitación y cantidad si se ha seleccionado algo
            if (comboBox1.SelectedItem != null)
            {
                tiposHabitacionesSeleccionadas.Add(comboBox1.SelectedItem.ToString());
                cantidades.Add((int)numericUpDown1.Value);
            }

            if (comboBox2.SelectedItem != null)
            {
                tiposHabitacionesSeleccionadas.Add(comboBox2.SelectedItem.ToString());
                cantidades.Add((int)numericUpDown2.Value);
            }

            if (comboBox3.SelectedItem != null)
            {
                tiposHabitacionesSeleccionadas.Add(comboBox3.SelectedItem.ToString());
                cantidades.Add((int)numericUpDown3.Value);
            }

            // Convertir tipos a IDs de habitación (este paso puede variar según su implementación)
            List<int> habitacionesSeleccionadas = tiposHabitacionesSeleccionadas.Select(tipo => ConvertToNumericType(tipo)).ToList();

            // Llamar al método para comprobar la disponibilidad
            bool estaDisponible = reservaController.ComprobarDisponibilidad(fechaInicio, fechaFin, habitacionesSeleccionadas, cantidades);

            // Mostrar el resultado
            if (estaDisponible)
            {
                MessageBox.Show("Las habitaciones seleccionadas están disponibles.");
            }
            else
            {
                MessageBox.Show("Alguna de las habitaciones seleccionadas no está disponible.");
            }

        }

        private int ConvertToNumericType(string tipoHabitacion)
        {
            switch (tipoHabitacion)
            {
                case "Sencilla":
                    return 1;
                case "Doble":
                    return 2;
                case "Suite":
                    return 3;
                default:
                    return 0;
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
    }
}





