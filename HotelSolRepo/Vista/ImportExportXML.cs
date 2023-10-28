using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HotelSolRepo.Vista
{
    public partial class ImportExportXML : Form
    {
        public ImportExportXML()
        {
            InitializeComponent();
            // Paso 1: Llena el ComboBox con las clases modelo XML Wrapper
            comboBox1.Items.Add("");
            comboBox1.Items.Add("ReservasXmlWrapper");
            comboBox1.Items.Add("ClientesXmlWrapper");
            comboBox1.Items.Add("FacturasXmlWrapper");
            comboBox1.Items.Add("EmpleadosXmlWrapper");
            comboBox1.Items.Add("HabitacionesSencillasXmlWrapper");
            comboBox1.Items.Add("HabitacionesDoblesXmlWrapper");
            comboBox1.Items.Add("HabitacionesSuiteXmlWrapper");
            comboBox1.Items.Add("HabitacionesXmlWrapper");
            comboBox1.Items.Add("ProgramasFidelizacionXmlWrapper");
            comboBox1.Items.Add("TareasEmpleadosXmlWrapper");

            // Por defecto, selecciona la primera clase en el ComboBox
            comboBox1.SelectedIndex = 0;
        }
        private DataGridView dataGrid;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Paso 2: Implementa la lógica para exportar datos de la clase seleccionada

            string selectedClassName = comboBox1.SelectedItem.ToString();
            Type selectedClassType = Type.GetType("HotelSolRepo.Modelo." + selectedClassName);

            if (selectedClassType != null)
            {
                // Crea una instancia de la clase seleccionada (por ejemplo, ReservasXmlWrapper)
                var selectedInstance = Activator.CreateInstance(selectedClassType);

                // Implementa la lógica para llenar los datos en la instancia de la clase
                // Puedes tener un método ObtenerDatosDesdeInterfaz que llene los datos en la instancia
                ObtenerDatosDesdeInterfaz(selectedInstance);
                // Luego, sigue con la lógica de serialización y exportación
                // ...

                // Ejemplo de serialización (ten en cuenta que necesitas llenar los datos en la instancia)
                XmlSerializer serializer = new XmlSerializer(selectedClassType);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Archivos XML (*.xml)|*.xml";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaArchivoXml = saveFileDialog.FileName;

                        try
                        {
                            using (StreamWriter writer = new StreamWriter(rutaArchivoXml))
                            {
                                serializer.Serialize(writer, selectedInstance);
                                MessageBox.Show("Datos exportados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al exportar los datos a XML: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        
        }

        private void ObtenerDatosDesdeInterfaz(object selectedInstance)
        {
            if (selectedInstance == null)
            {
                throw new ArgumentNullException(nameof(selectedInstance));
            }

            // Verifica el tipo de instancia seleccionada
            if (selectedInstance is ReservasXmlWrapper)
            {
                ReservasXmlWrapper reserva = (ReservasXmlWrapper)selectedInstance;

                // Llena las propiedades de ReservasXmlWrapper con valores hardcoded
                reserva.ReservaID = 1;
                reserva.NIF = "12345678H";
                reserva.HabitacionID = 123; // Puedes cambiar el valor
                reserva.FechaInicio = DateTime.Now; // Puedes establecer una fecha específica
                reserva.FechaFin = DateTime.Now.AddDays(7); // Puedes establecer una fecha específica
                reserva.OpcionesPension = "Completa";
                reserva.Estado = "Activa";
                reserva.FechaCreacion = DateTime.Now;
                reserva.TipoReserva = "Vacaciones";
            }
            else if (selectedInstance is ClientesXmlWrapper)
            {
                ClientesXmlWrapper cliente = (ClientesXmlWrapper)selectedInstance;

                // Llena las propiedades de ClientesXmlWrapper con los valores de los controles en tu formulario
                cliente.NIF = "12345678H"; // Ejemplo: Obtener el valor desde un TextBox
                cliente.Nombre = "Robert"; // Ejemplo: Obtener el valor desde un TextBox
                                                        // Continúa llenando las propiedades de acuerdo a tu formulario
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Selecting XML Source, be carefull deleting Form1 while stop App");
            // Elimina el DataGridView actual si existe
            if (dataGrid != null)
            {
                this.Controls.Remove(dataGrid);
                dataGrid.Dispose();
            }

            string selectedClassName = comboBox1.SelectedItem.ToString();
            Type selectedClassType = Type.GetType("HotelSolRepo.Modelo." + selectedClassName);
            if (selectedClassType == null)
            {
                Console.WriteLine("No se pudo encontrar la clase: " + selectedClassName + " Seguramente estas pasandole el Formulario principal");
                return;
            }
            dataGrid = new DataGridView();
            dataGrid.Name = "dataGrid";
            dataGrid.Location = new Point(250, 96);
            dataGrid.Size = new Size(640, 480);
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.AutoGenerateColumns = true;
            this.Controls.Add(dataGrid);
        }
    }

    
}
