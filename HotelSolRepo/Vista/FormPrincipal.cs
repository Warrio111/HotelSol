using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSolRepo.Vista
{
    public partial class FormPrincipal : Form
    {
        public bool IsAuthenticated { get; set; } // Propiedad para saber si el usuario está autenticado
        private Type exportXmlWrapperType; // Almacena el tipo de XMLWrapper para exportación
        private Form exportCallerForm; // Almacena el formulario que llama a FormPrincipal
        public event Action<Type> XmlWrapperTypeChanged; // Evento personalizado
        public event Action<Form> CallerPrincipal; // Evento personalizado
        public string AuthenticatedNIF { get; set; } // Propiedad para almacenar el NIF del usuario autenticado
        public int AuthenticatedEmployeeID { get; set; } // Propiedad para almacenar el ID del empleado autenticado
        public ReservaHabitacionesListXmlWrapper reservaHabitacionesXML = new ReservaHabitacionesListXmlWrapper();
        public FormPrincipal()
        {
            InitializeComponent();

            ConectarControladoresEventos();  // Conecta los controladores de eventos
            IsAuthenticated = false; // Inicialmente, el usuario no está autenticado
            AuthenticatedNIF = string.Empty; // Inicialmente, no hay NIF autenticado
            // Suscribe el manejador de eventos para el cambio de tipo XMLWrapper
            XmlWrapperTypeChanged += (xmlWrapperType) =>
            {
                exportXmlWrapperType = xmlWrapperType;
            };
            CallerPrincipal += (callerForm) =>
            {
                exportCallerForm = callerForm;
            };
            reservaHabitacionesXML.ReservaHabitaciones = new List<ReservaHabitacionesXmlWrapper>();
            ShowEmployeeLogin(); // Solicitar autenticación del empleado al iniciar el programa
        }


        public void OnXmlWrapperTypeChanged(Type xmlWrapperType)
        {
            XmlWrapperTypeChanged?.Invoke(xmlWrapperType);
        }
        public void OnPrincipalFormCalled(Form callerForm)
        {
            CallerPrincipal?.Invoke(callerForm);
        }
        private void ConectarControladoresEventos()
        {
            btnNuevaReserva.Click += BtnNuevaReserva_Click;
            btnGestionClientes.Click += BtnGestionClientes_Click;
      
        }

        private void BtnNuevaReserva_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new CrearReservaForm(ref exportXmlWrapperType,this));
        }

        public void MostrarFormulario(Form formulario)
        {
            // Configuracion de las propiedades del formulario para que pueda incrustarse en el panel

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

        private void ShowEmployeeLogin()
        {
            using (SystemLogin loginForm = new SystemLogin())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    AuthenticatedEmployeeID = loginForm.AuthenticatedEmployeeID;
                    // Podemos asumir que si llegamos a este punto, el empleado está autenticado
                }
                else
                {
                    // Cerrar la aplicación si la autenticación del empleado falla
                    Application.Exit();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnNuevaReserva_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnGestionClientes_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new ClienteForm(ref exportXmlWrapperType, this));
        }

        private void buttonOdoo_click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "python";
                start.Arguments = "\"C:\\Grado Superior\\002_Tercer Semestre\\(P) Técnicas de persistencia de datos con .NET y\\Hotel\\PythonOdoo\\Interface.pyw\"";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;
                start.CreateNoWindow = true;

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                    }

                    using (StreamReader reader = process.StandardError)
                    {
                        string result = reader.ReadToEnd();
                        Console.Write(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
