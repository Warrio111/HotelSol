using System;
using System.Windows.Forms;
using HotelSolRepo.Controlador;
namespace HotelSolRepo.Vista
{
    public partial class RegisterForm : Form
    {
        private ClienteController clienteController = new ClienteController();

        public RegisterForm()
        {
            InitializeComponent();
            this.btnRegisterValidation.Click += new System.EventHandler(this.btnRegisterValidation_Click);
        }

        private void btnRegisterValidation_Click(object sender, EventArgs e)
        {
            string nombre = textBoxName.Text;
            string apellido1 = textBoxSurname1.Text;
            string apellido2 = textBoxSurname2.Text;
            string nif = textBoxNIF.Text;
            string telefono = textBoxTel.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPsswd.Text;
            string passwordCheck = textBoxPsswdCheck.Text;

            if (password == passwordCheck && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(nif))
            {
                bool resultado = clienteController.RegistrarCliente(nif, nombre + " " + apellido1 + " " + apellido2, email, telefono, password);
                if (resultado)
                {
                    MessageBox.Show("Cliente registrado con éxito.");
                    ((FormPrincipal)this.ParentForm).MostrarFormulario(new LoginForm()); // Redirigir al formulario de inicio de sesión
                    this.Close(); // Cerrar el formulario de registro
                }
                else
                {
                    MessageBox.Show("Error en el registro del cliente.");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden o faltan campos obligatorios.");
            }
        }
    }
}