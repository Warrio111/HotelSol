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
    public partial class FormPrincipal : Form
    {
        public bool IsAuthenticated { get; set; } // Propiedad para saber si el usuario está autenticado
        private Type exportXmlWrapperType; // Almacena el tipo de XMLWrapper para exportación
        private Form callerForm; // Almacena el formulario que llama a FormPrincipal
        public event Action<Type> XmlWrapperTypeChanged; // Evento personalizado
        public event Action<Form> CallerPrincipal;
        public string AuthenticatedNIF { get; set; } // Propiedad para almacenar el NIF del usuario autenticado
        public ReservasListXmlWrapper reservasXML = new ReservasListXmlWrapper();
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
            reservasXML.Reservas = new List<ReservasXmlWrapper>();
        }


        public void OnXmlWrapperTypeChanged(Type xmlWrapperType)
        {
            XmlWrapperTypeChanged?.Invoke(xmlWrapperType);
        }
        public void OnPrincipalFormCalled(Form callerForm)
        {
            CallerPrincipal?.Invoke(callerForm);
            this.callerForm = callerForm;
        }
        private void ConectarControladoresEventos()
        {
            btnNuevaReserva.Click += BtnNuevaReserva_Click;
            btnExportarXML.Click += BtnExportarXML_Click;
            btnImportarXML.Click += BtnImportarXML_Click;
        }

        private void BtnNuevaReserva_Click(object sender, EventArgs e)
        {
            MostrarFormulario(new ReservaForm(ref exportXmlWrapperType,this));
        }

        private void BtnExportarXML_Click(object sender, EventArgs e)
        {
            //if(!IsAuthenticated)
            //{
            //    MessageBox.Show("Por favor, autentíquese para exportar datos.");
            //    return;
            //}
            if(null!=exportXmlWrapperType)
            {
                ExportarForm exportarForm = new ExportarForm(exportXmlWrapperType);
                
                if (exportarForm != null)
                {
                    exportarForm.ExportarDatosToXml(this.callerForm);
                }
                //MostrarFormulario(exportarForm);
                return;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un tipo de archivo.");
            }
        }

        private void BtnImportarXML_Click(object sender, EventArgs e)
        {
            ImportarForm importarForm = new ImportarForm();
            FormPrincipal activeForm = ActiveForm as FormPrincipal;
            if (activeForm != null)
            {
                importarForm.SubscribeToXmlWrapperTypeChange(activeForm);
            }
            MostrarFormulario(importarForm);
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
    }
}
