using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HotelSolRepo.Vista
{
    public partial class ImportarForm : Form
    {
        private DataGridView dataGrid;
        public ImportarForm()
        {
            InitializeComponent();
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
        }

        public void SubscribeToXmlWrapperTypeChange(FormPrincipal activeForm)
        {
            // Suscríbete al evento XmlWrapperTypeChanged del formulario ReservaForm
            activeForm.XmlWrapperTypeChanged += (xmlWrapperType) => {
                // Aquí puedes cargar los datos en el DataGridView según el tipo de XMLWrapper
                LoadDataToGrid(xmlWrapperType);
            };
        }

        public void LoadDataToGrid(Type xmlWrapperType)
        {
            if (xmlWrapperType == null)
            {
                MessageBox.Show("Seleccione un tipo de archivo");
                return;
            }
            XmlSerializer serializer = new XmlSerializer(xmlWrapperType);
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Selecciona un archivo XML de reserva",
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    // Utiliza reflexión para crear una lista en tiempo de ejecución
                    Type listType = typeof(List<>).MakeGenericType(xmlWrapperType);
                    IList data = (IList)Activator.CreateInstance(listType);

                    try
                    {
                        // Deserializa los datos y agrega cada elemento a la lista
                        while (stream.Position < stream.Length)
                        {
                            var item = serializer.Deserialize(stream);
                            data.Add(item);
                        }
                        dataGrid = new DataGridView
                        {
                            Name = "dataGrid",
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                            Dock = DockStyle.Fill
                        };
                       

                        dataGrid.DataSource = data;
                        this.Controls.Add(dataGrid);
                        dataGrid.BringToFront();
                        dataGrid.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar el archivo XML: " + ex.Message);
                        return;
                    }

                    
                }
            }

        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
            LoadDataToGrid(selectedClassType);
        }
    }
}
