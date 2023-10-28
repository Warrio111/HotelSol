using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using HotelSolRepo.Vista;  

namespace HotelSolRepo.Vista
{
    public partial class ReservaForm : Form
    {
        private List<object> datos;

        public ReservaForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            // Conecte los controladores de eventos
            btnLoginMenu.Click += BtnAbrirLoginForm_Click;
            brnRegisterMenu.Click += BtnAbrirRegisterForm_Click;
            exportXmlWrapperType = typeof(ReservasXmlWrapper);
            // Suscríbete al evento ExportarXMLClick del formulario principal si es válido y de tipo FormPrincipal.
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
            datos.HabitacionID = 2; // Ejemplo: Asigna el valor correcto
            datos.Estado = "Activa"; // Ejemplo: Asigna el valor correcto

            return datos;

            return datos;
        }


        private void BtnAbrirLoginForm_Click(object sender, EventArgs e)
        {

            ((FormPrincipal)this.ParentForm).MostrarFormulario(new LoginForm());

        }

        private void BtnAbrirRegisterForm_Click(object sender, EventArgs e)
        {
            ((FormPrincipal)this.ParentForm).MostrarFormulario(new RegisterForm());
        }

        private void RealizarReserva_Click(object sender, EventArgs e)
        {
            FormPrincipal formPrincipal = (FormPrincipal)this.ParentForm;
            if (!formPrincipal.IsAuthenticated)
            {
                MessageBox.Show("Por favor, autentíquese para realizar una reserva.");
                return;
            }

            Type XmlWrapperType = typeof(ReservasXmlWrapper);
            ((FormPrincipal)this.Owner).OnXmlWrapperTypeChanged(XmlWrapperType);
            ReservaController reservaController = new ReservaController();
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "XML files (*.xml)|*.xml" };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            reservaController.HacerReservaDesdeXml(openFileDialog.FileName);
        }


    }
}
