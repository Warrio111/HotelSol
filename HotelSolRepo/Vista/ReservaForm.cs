using System;
using System.Windows.Forms;
using HotelSolRepo.Vista;  

namespace HotelSolRepo.Vista
{
    public partial class ReservaForm : Form
    {
        public ReservaForm()
        {
            InitializeComponent();
            // Conecte los controladores de eventos
            btnLoginMenu.Click += BtnAbrirLoginForm_Click;
            brnRegisterMenu.Click += BtnAbrirRegisterForm_Click;
        }

        private void BtnAbrirLoginForm_Click(object sender, EventArgs e)
        {
           
            ((FormPrincipal)this.ParentForm).MostrarFormulario(new LoginForm());
        }

        private void BtnAbrirRegisterForm_Click(object sender, EventArgs e)
        {
           
            ((FormPrincipal)this.ParentForm).MostrarFormulario(new RegisterForm());
        }
    }
}
