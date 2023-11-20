using HotelSolRepo.Modelo;
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
            comboBox1.Items.Add("ReservasListXmlWrapper");
            comboBox1.Items.Add("ClientesListXmlWrapper");
            comboBox1.Items.Add("FacturasListXmlWrapper");
            comboBox1.Items.Add("EmpleadosListXmlWrapper");
            comboBox1.Items.Add("HabitacionesListXmlWrapper");
            comboBox1.Items.Add("HabitacionesSencillasXmlWrapper");
            comboBox1.Items.Add("HabitacionesDoblesXmlWrapper");
            comboBox1.Items.Add("HabitacionesSuiteXmlWrapper");
            comboBox1.Items.Add("ProgramasFidelizacionListXmlWrapper");
            comboBox1.Items.Add("TareasEmpleadosListXmlWrapper");
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

                        // Si los datos son de tipo ReservasListXmlWrapper, extrae la lista de Reservas
                        if (xmlWrapperType == typeof(ReservasListXmlWrapper))
                        {
                            ReservasListXmlWrapper reservasList = (ReservasListXmlWrapper)data[0];
                            data = reservasList.Reservas;
                        }
                        // Si los datos son de tipo ClientesListXmlWrapper, extrae la lista de Clientes
                        else if (xmlWrapperType == typeof(ClientesListXmlWrapper))
                        {
                            ClientesListXmlWrapper clientesList = (ClientesListXmlWrapper)data[0];
                            data = clientesList.Clientes;
                        }
                        // Si los datos son de tipo FacturasListXmlWrapper, extrae la lista de Facturas
                        else if (xmlWrapperType == typeof(FacturasListXmlWrapper))
                        {
                            FacturasListXmlWrapper facturasList = (FacturasListXmlWrapper)data[0];
                            data = facturasList.Facturas;
                        }
                        // Si los datos son de tipo EmpleadosListXmlWrapper, extrae la lista de Empleados
                        else if (xmlWrapperType == typeof(EmpleadosListXmlWrapper))
                        {
                            EmpleadosListXmlWrapper empleadosList = (EmpleadosListXmlWrapper)data[0];
                            data = empleadosList.Empleados;
                        }
                        // Si los datos son de tipo HabitacionesListXmlWrapper, extrae la lista de Habitaciones
                        else if (xmlWrapperType == typeof(HabitacionesListXmlWrapper))
                        {
                            HabitacionesListXmlWrapper habitacionesList = (HabitacionesListXmlWrapper)data[0];
                            data = habitacionesList.Habitaciones;
                        }
                        else if (xmlWrapperType == typeof(HabitacionesSencillasXmlWrapper)) 
                        { 
                            HabitacionesSencillasXmlWrapper habitacionesSencillasList = (HabitacionesSencillasXmlWrapper)data[0];
                        }
                        // Si los datos son de tipo HabitacionesDoblesXmlWrapper, extrae la lista de HabitacionesDobles
                        else if (xmlWrapperType == typeof(HabitacionesDoblesXmlWrapper))
                        {
                            HabitacionesDoblesXmlWrapper habitacionesDoblesList = (HabitacionesDoblesXmlWrapper)data[0];
                        }
                        // Si los datos son de tipo HabitacionesSuiteXmlWrapper, extrae la lista de HabitacionesSuite
                        else if (xmlWrapperType == typeof(HabitacionesSuiteXmlWrapper))
                        {
                            HabitacionesSuiteXmlWrapper habitacionesSuiteList = (HabitacionesSuiteXmlWrapper)data[0];
                        }
                        // Si los datos son de tipo ProgramasFidelizacionListXmlWrapper, extrae la lista de ProgramasFidelizacion
                        else if (xmlWrapperType == typeof(ProgramasFidelizacionListXmlWrapper))
                        {
                            ProgramasFidelizacionListXmlWrapper programasFidelizacionList = (ProgramasFidelizacionListXmlWrapper)data[0];
                            data = programasFidelizacionList.ProgramasFidelizacion;
                        }
                        // Si los datos son de tipo TareasEmpleadosListXmlWrapper, extrae la lista de TareasEmpleados
                        else if (xmlWrapperType == typeof(TareasEmpleadosListXmlWrapper))
                        {
                            TareasEmpleadosListXmlWrapper tareasEmpleadosList = (TareasEmpleadosListXmlWrapper)data[0];
                            data = tareasEmpleadosList.TareasEmpleados;
                        }

                        // Crea el DataGridView
                        dataGrid = new DataGridView
                        {
                            Name = "dataGrid",
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                            Dock = DockStyle.Fill
                        };

                        // Asigna la lista de datos al DataGridView
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
