using System;
using System.Linq;
using System.Windows.Forms;
using HotelSolRepo.Modelo;  // Asegúrese de que este sea el espacio de nombres correcto para su entidad de base de datos

namespace HotelSolRepo.Vista
{
    public partial class SystemLogin : Form
    {
        public int AuthenticatedEmployeeID { get; private set; }
        public string AuthenticatedEmployeeName { get; private set; }

        public SystemLogin()
        {
            InitializeComponent();
            this.btnLoginEmployee.Click += new System.EventHandler(this.btnLoginEmployee_Click);
        }

        private void btnLoginEmployee_Click(object sender, EventArgs e)
        {
            string enteredName = this.textBoxNameEmployee.Text;
            int enteredID;
            if (int.TryParse(this.textBoxIdEmployee.Text, out enteredID))
            {
                using (HotelDBEntities db = new HotelDBEntities())
                {
                    var employee = db.Empleados.FirstOrDefault(emp => emp.EmpleadoID == enteredID && emp.Nombre == enteredName);
                    if (employee != null)
                    {
                        AuthenticatedEmployeeID = enteredID;
                        AuthenticatedEmployeeName = enteredName;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Empleado no encontrado o los detalles son incorrectos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, introduzca un ID de empleado válido.");
            }
        }
    }
}
