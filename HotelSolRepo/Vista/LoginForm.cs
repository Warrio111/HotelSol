using System;
using System.Windows.Forms;
using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;

namespace HotelSolRepo.Vista
{
    public partial class LoginForm : Form
    {
        private ClienteController clienteController = new ClienteController();

        public LoginForm()
        {
            InitializeComponent();
            btnLoginValidation.Click += BtnLoginValidation_Click;
            btnGoToReserva.Click += BtnGoToReserva_Click;
        }

        private void BtnLoginValidation_Click(object sender, EventArgs e)
        {
            string nif = textBoxLoginNIF.Text;
            string password = textBoxLoginPass.Text;

            if (clienteController.AutenticarUsuario(nif, password))
            {
                // Establecer la propiedad IsAuthenticated en true y almacenar el NIF autenticado
                FormPrincipal parentForm = (FormPrincipal)this.ParentForm;
                parentForm.IsAuthenticated = true;
                parentForm.AuthenticatedNIF = nif;  // Almacenar el NIF del usuario autenticado

                MessageBox.Show("Inicio de sesión exitoso.");
                Type exportXmlWrapperType = typeof(LoginForm);
                parentForm.MostrarFormulario(new ReservaForm(ref exportXmlWrapperType,parentForm)); // Redirigir al formulario de reserva
                this.Close(); // Cerrar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Inicio de sesión fallido. Verifique sus credenciales.");
            }
        }

        private void BtnGoToReserva_Click(object sender, EventArgs e)
        {
            ((FormPrincipal)this.ParentForm).MostrarFormulario(new RegisterForm());
        }
    }
}