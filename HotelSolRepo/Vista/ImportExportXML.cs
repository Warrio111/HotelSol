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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    
}
