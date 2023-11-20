using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HotelSolRepo.Vista
{
    public partial class ExportarForm : Form
    {
        private Type exportXmlWrapperType;
        public ExportarForm(Type exportXmlWrapperType)
        {
            InitializeComponent();
            this.exportXmlWrapperType = exportXmlWrapperType;
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {
            
        }
        public void ExportarDatosToXml(Form dataForm)
        {
            if (exportXmlWrapperType == null)
            {
                MessageBox.Show("Seleccione un tipo de XMLWrapper antes de exportar.");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(exportXmlWrapperType);
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Guardar archivo XML",
                FileName = "datos.xml" // Puedes cambiar el nombre de archivo predeterminado
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivoXml = saveFileDialog.FileName;
                object serializeXMLWrapperType = null;
                if (File.Exists(rutaArchivoXml))
                {
                    // El archivo existe, pregunta al usuario si desea sobrescribir o añadir datos
                    var result = MessageBox.Show("El archivo ya existe. ¿Desea sobrescribirlo?", "Confirmar acción", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Cancel)
                    {
                        // El usuario canceló la operación
                        return;
                    }
                    else if (result == DialogResult.Yes)
                    {
                        // El usuario desea Sobrescribir el archivo existente
                        if (dataForm is CrearReservaForm)
                        {
                            CrearReservaForm reservaForm = (CrearReservaForm)dataForm;

                            ReservaHabitacionesListXmlWrapper reservaHabitacionesList = new ReservaHabitacionesListXmlWrapper();
                            reservaHabitacionesList.ReservaHabitaciones = new List<ReservaHabitacionesXmlWrapper>();
                            List<ReservaHabitacionesXmlWrapper> reservaHabitaciones = reservaForm.RealizarExportDesdeReservas().ReservaHabitaciones;
                            reservaHabitacionesList.ReservaHabitaciones.Add(reservaHabitaciones.Last());

                            using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                            {
                                serializer.Serialize(stream, reservaHabitacionesList);
                            }

                            MessageBox.Show("Exportación exitosa.");
                            return;

                        }
                    }
                    else if (result == DialogResult.No)
                    {
                        // Conecpto de LIFO (Last In First Out) para añadir datos al archivo existente
                        // Aplicamos LIFO a las reservasList 
                        // El usuario desea añadir datos al archivo donde corresponda
                        if (dataForm is CrearReservaForm)
                        {
                            CrearReservaForm reservaForm = (CrearReservaForm)dataForm;

                            ReservaHabitacionesListXmlWrapper reservaHabitacionesList = new ReservaHabitacionesListXmlWrapper();
                            reservaHabitacionesList.ReservaHabitaciones = new List<ReservaHabitacionesXmlWrapper>();

                            using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                            {
                                if(existingFileStream.Length!= 0)
                                // Deserializa los datos existentes desde el archivo
                                 reservaHabitacionesList = (ReservaHabitacionesListXmlWrapper)serializer.Deserialize(existingFileStream);
                            }

                            // Obtener la lista de reservas desde reservaForm
                            List<ReservaHabitacionesXmlWrapper> reservaHabitaciones = reservaForm.RealizarExportDesdeReservas().ReservaHabitaciones;
                            reservaHabitacionesList.ReservaHabitaciones.Add(reservaHabitaciones.Last());

                            using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                            {
                                serializer.Serialize(stream, reservaHabitacionesList);
                            }

                            MessageBox.Show("Exportación exitosa.");
                            return;

                        }
                    }
                }
                else
                {
                    // El archivo no existe, simplemente guarda los datos
                    if (dataForm is CrearReservaForm)
                    {
                        CrearReservaForm reservaForm = (CrearReservaForm)dataForm;
                        // Aquí creamos una instancia del tipo exportXmlWrapperType
                        serializeXMLWrapperType = Activator.CreateInstance(exportXmlWrapperType);
                        foreach (PropertyInfo propertyInfo in exportXmlWrapperType.GetProperties())
                        {
                            PropertyInfo sourceProperty = reservaForm.RealizarExportDesdeReservas().GetType().GetProperty(propertyInfo.Name);
                            if (sourceProperty != null)
                            {
                                object value = sourceProperty.GetValue(reservaForm.RealizarExportDesdeReservas());
                                propertyInfo.SetValue(serializeXMLWrapperType, value);
                            }
                        }
                    }

                }
                try
                {
                    using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                    {
                        // Serializa los datos y escribe el archivo XML
                        serializer.Serialize(stream, serializeXMLWrapperType);
                    }
                    MessageBox.Show("Exportación exitosa.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar los datos: " + ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Exportación cancelada.");
            }
            
        }

    }
}
