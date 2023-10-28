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
            btnCheckAvaliable.Click += new EventHandler(this.ComprobarDisponibilidad_Click);
            btnLoginMenu.Click += new EventHandler(this.LoginForm_Click);
            btnRegisterMenu.Click += new EventHandler(this.RegisterForm_Click);
            exportXmlWrapperType = typeof(ReservasXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }
        }

        public ReservasXmlWrapper RealizarExportDesdeReservas()
        {

            ReservasXmlWrapper datos = new ReservasXmlWrapper();

            // Verifica si dateTimePicker1 tiene un valor seleccionado
            if (dateTimePicker1.Value != null)
            {
                datos.FechaInicio = dateTimePicker1.Value;
            }

            // Verifica si dateTimePicker2 tiene un valor seleccionado
            if (dateTimePicker2.Value != null)
            {
                datos.FechaFin = dateTimePicker2.Value;
            }

            // Verifica si comboBox1 tiene un elemento seleccionado
            if (comboBox1.SelectedItem != null)
            {
                datos.OpcionesPension = comboBox1.SelectedItem.ToString();
            }

            // Asigna los valores a las propiedades de ReservasXmlWrapper
            datos.ReservaID = 1; // Ejemplo: Asigna el valor correcto
            datos.NIF = "123456789"; // Ejemplo: Asigna el valor correcto
            datos.Estado = "Activa"; // Ejemplo: Asigna el valor correcto

            return datos;
        }
        private void LoginForm_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Ya está autenticado.");
                return;
            }

            formPrincipal.MostrarFormulario(new LoginForm());
        }

        private void RegisterForm_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Ya está autenticado.");
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
                MessageBox.Show("Por favor, autentíquese para realizar una reserva.");
                return;
            }

            List<HabitacionXmlWrapper> habitacionesSeleccionadas = new List<HabitacionXmlWrapper>();

            if (comboBox1.SelectedItem != null)
            {
                habitacionesSeleccionadas.Add(new HabitacionXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox1.SelectedItem.ToString()),
                    TipoPension = GetPensionType(checkBox1, checkBox2),
                    NumeroHabitaciones = (int)numericUpDown1.Value
                });
            }

            if (comboBox2.SelectedItem != null)
            {
                habitacionesSeleccionadas.Add(new HabitacionXmlWrapper
                {
                    HabitacionID = ConvertToNumericType(comboBox2.SelectedItem.ToString()),
                    TipoPension = GetPensionType(checkBox3, checkBox4),
                    NumeroHabitaciones = (int)numericUpDown2.Value
                });
            }

    if (comboBox3.SelectedItem != null)
    {
        habitacionesSeleccionadas.Add(new HabitacionXmlWrapper
        {
            HabitacionID = ConvertToNumericType(comboBox3.SelectedItem.ToString()),
            TipoPension = GetPensionType(checkBox5, checkBox6),
            NumeroHabitaciones = (int)numericUpDown3.Value
        });
    }

    ReservasXmlWrapper reserva = new ReservasXmlWrapper
    {
        FechaInicio = dateTimePicker1.Value,
        FechaFin = dateTimePicker2.Value,
        NIF = ((FormPrincipal)this.ParentForm).AuthenticatedNIF, // Este valor debe venir del usuario autenticado
        Estado = "Pendiente",
        FechaCreacion = DateTime.Now,
        Habitaciones = habitacionesSeleccionadas
    };
    Type XmlWrapperType = typeof(ReservasXmlWrapper);
    ((FormPrincipal)this.ParentForm).OnXmlWrapperTypeChanged(XmlWrapperType);
    reservaController.GenerarReservaTemporalXml(reserva);
    ((FormPrincipal)this.ParentForm).MostrarFormulario(new ServiciosExtraForm());
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
    }
}





