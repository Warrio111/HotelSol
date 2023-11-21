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

                MessageBox.Show("Cliente validado.");
                Type exportXmlWrapperType = typeof(LoginForm);
                parentForm.MostrarFormulario(new CrearReservaForm(ref exportXmlWrapperType,parentForm)); // Redirigir al formulario de reserva
                this.Close(); // Cerrar el formulario de inicio de sesión
            }
            else
            {
                MessageBox.Show("Validacion fallida. Verifique sus credenciales.");
            }
        }

        private void BtnGoToReserva_Click(object sender, EventArgs e)
        {
            ((FormPrincipal)this.ParentForm).MostrarFormulario(new RegisterForm());
        }

        private void textBoxLoginNIF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}