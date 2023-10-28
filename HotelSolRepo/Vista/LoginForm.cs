using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                ((FormPrincipal)this.ParentForm).IsAuthenticated = true;
                MessageBox.Show("Inicio de sesión exitoso.");
                Type exportXmlWrapperType = typeof(LoginForm);
                ((FormPrincipal)this.ParentForm).MostrarFormulario(new ReservaForm(ref exportXmlWrapperType,(FormPrincipal)this.ParentForm)); // Redirigir al formulario de reserva
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