using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;

namespace HotelSolRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Paso 1: Llena el ComboBox con las clases modelo XML Wrapper
            comboBox1.Items.Add("");
            comboBox1.Items.Add("ImportExportXML");
            
            comboBox1.SelectedIndex = 0;
        }
        private OpenFileDialog openFileDialog1;
        private Stack<Form> formStack = new Stack<Form>();
        private void Form1_Load(object sender, EventArgs e)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                // Carga todos los clientes con sus programas de fidelización relacionados
                var clientes = db.Clientes
                                 .Include("ProgramasFidelizacion")
                                 .Include("Facturas")
                                 .Include("Reservas")
                                 .ToList();

                // Cree una proyección de los datos que quiere mostrar
                var vistaClientes = clientes.Select(c => new
                {
                    c.NIF,
                    c.Nombre,
                    c.CorreoElectronico,
                    c.Telefono,
                    c.Reservas,
                    c.Facturas,
                    Fidelizacion = c.ProgramasFidelizacion.Nombre  // Muestre el nombre en lugar del ID 
                }).ToList();

                dataClientesGrid.DataSource = vistaClientes;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Obtener el XML de reserva desde un campo de entrada o archivo
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.Title = "Selecciona un archivo XML de reserva";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                // Llamar a ReservaController para crear una reserva desde XML
                ReservaController reservaController = new ReservaController();
                reservaController.HacerReservaDesdeXml(filePath);

                // Actualizar la vista o mostrar un mensaje de éxito
                ActualizarVista();
            }
            else
            {
                MessageBox.Show("El XML de reserva está vacío o no es válido.");
            }
        }
        private void ActualizarVista()
        {
            // Implementa la lógica para actualizar la vista, por ejemplo, mostrar una lista de reservas en un DataGridView
            // Utiliza ReservaController para obtener datos de la base de datos y mostrarlos en la vista
        }
        private void MostrarFormulario(Form form)
        {
            // Oculta el formulario actual
            if(form!=null)
            {
                if(formStack.Count>0)
                {
                    Form formActual = formStack.Peek();
                    formActual.Hide();
                }
                formStack.Push(form);
                form.Show();
            }
            
        }
        private void btnActualizarReserva_Click(object sender, EventArgs e)
        {
            // Obtener el XML de reserva actualizada desde un campo de entrada o archivo
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "XML Files|*.xml";
            openFileDialog1.Title = "Selecciona un archivo XML de reserva";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Llamar a ReservaController para actualizar una reserva desde XML
                string filePath = openFileDialog1.FileName;
                ReservaController reservaController = new ReservaController();
                reservaController.HacerReservaDesdeXml(filePath);

                // Actualizar la vista o mostrar un mensaje de éxito
                ActualizarVista();
            }
            else
            {
                MessageBox.Show("El XML de reserva está vacío o no es válido.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Selecting Form View, be carefull deleting Form1 while stop App");
            string selectedClassName = comboBox1.SelectedItem.ToString();
            Type selectedClassType = Type.GetType("HotelSolRepo.Vista." + selectedClassName);
            if (selectedClassType == null)
            {
                Console.WriteLine("No se pudo encontrar la clase: " + selectedClassName + " Seguramente estas pasandole el Formulario principal");
                return;
            }
                
            var selectedInstance = Activator.CreateInstance(selectedClassType);
            MostrarFormulario((Form)selectedInstance);
        }
    }
}

