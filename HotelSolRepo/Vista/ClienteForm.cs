using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelSolRepo.Vista
{
    public partial class ClienteForm : Form
    {
        private DataGridView dataGrid;
        private ClienteController clienteController = null;
        private HabitacionController habitacionController = null;
        private DireccionController direccionController = null;
        private ReservaController reservaController = null;
        private string rutaArchivoXml = String.Empty;
        private string xsltFile = String.Empty;

        public ClienteForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            // Elimina el DataGridView actual si existe
            if (dataGrid != null)
            {
                this.Controls.Remove(dataGrid);
                dataGrid.Dispose();
            }
            clienteController = new ClienteController();
            habitacionController = new HabitacionController();
            direccionController = new DireccionController();
            reservaController = new ReservaController();
            this.Load += new EventHandler(ClientForm_Load);

            exportXmlWrapperType = typeof(ClientesListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }

        }
        public void UpdateWebBrowserContent()
        {
            if (File.Exists(rutaArchivoXml))
            {
                string xmlContent = File.ReadAllText(rutaArchivoXml);
                string htmlContent = ConvertXmlToHtml(xmlContent);
                webBrowser1.DocumentText = htmlContent;
            }
        }
        private string ConvertXmlToHtml(string xmlContent)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlContent);

                XslCompiledTransform xslt = new XslCompiledTransform();
                FileDialog fileDialog = new OpenFileDialog
                {
                    Filter = "XSLT files (*.xslt)|*.xslt",
                    Title = "Selecciona un archivo XSLT",
                    RestoreDirectory = true
                };
                xslt.Load(xsltFile);

                StringWriter sw = new StringWriter();
                XmlTextWriter writer = new XmlTextWriter(sw);

                xslt.Transform(xmlDoc, null, writer);

                return sw.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al transformar XML a HTML: " + ex.Message);
                return string.Empty;
            }
        }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            textBoxName.Visible = false;
            textBoxSurname1.Visible = false;
            textBoxSurname2.Visible = false;
            textBoxNIF.Visible = false;
            textBoxTel.Visible = false;
            textBoxEmail.Visible = false;
            textBoxPsswd.Visible = false;
            textBoxPsswdCheck.Visible = false;
            textBoxCalle.Visible = false;
            textBoxCalleNumero.Visible = false;
            textBoxPuerta.Visible = false;
            textBoxPiso.Visible = false;
            textBoxCodigoPostal.Visible = false;
            textBoxProvincia.Visible = false;
            textBoxPais.Visible = false;
            BuscadorCliente.Visible = false;
            webBrowser1.Visible = false;
            buttonObtenerClientePorNif.Visible = true;
            buttonObtenerClientes.Visible = true;
            buttonObtenerHistorialEstanciaCliente.Visible = true;
            buttonObtenerClientesConReservas.Visible = true;
            buttonRegistrarCliente.Visible = true;
            buttonActualizarCliente.Visible = true;
            buttonEliminarCliente.Visible = true;
        }

        private void registrarButton_Click(object sender, EventArgs e)
        {
            string nombre = textBoxName.Text;
            string apellido1 = textBoxSurname1.Text;
            string apellido2 = textBoxSurname2.Text;
            string nif = textBoxNIF.Text;
            string telefono = textBoxTel.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPsswd.Text;
            string passwordCheck = textBoxPsswdCheck.Text;
            string calle = textBoxCalle.Text;
            string numero = textBoxCalleNumero.Text;
            string puerta = textBoxPuerta.Text;
            string piso = textBoxPiso.Text;
            string codigoPostal = textBoxCodigoPostal.Text;
            string provincia = textBoxProvincia.Text;
            string pais = textBoxPais.Text;

            if (password == passwordCheck && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(nif))
            {
                bool resultado = clienteController.RegistrarCliente(nif, nombre, apellido1, apellido2, email, telefono, password, calle, numero, puerta, piso, codigoPostal, provincia, pais);
                if (resultado)
                {
                    MessageBox.Show("Cliente registrado con éxito.");
                    //Register Form fields
                    textBoxName.Visible = false;
                    textBoxSurname1.Visible = false;
                    textBoxSurname2.Visible = false;
                    textBoxNIF.Visible = false;
                    textBoxTel.Visible = false;
                    textBoxEmail.Visible = false;
                    textBoxPsswd.Visible = false;
                    textBoxPsswdCheck.Visible = false;
                    textBoxCalle.Visible = false;
                    textBoxCalleNumero.Visible = false;
                    textBoxPuerta.Visible = false;
                    textBoxPiso.Visible = false;
                    textBoxCodigoPostal.Visible = false;
                    textBoxProvincia.Visible = false;
                    textBoxPais.Visible = false;
                    Registrar.Visible = false;

                    //Buscador Cliente Form fields
                    BuscadorCliente.Visible = false;

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

        private void buscadorDoubleClick_button(object sender, EventArgs e)
        {
            string nifCliente = BuscadorCliente.Text;
            try
            {
                Clientes cliente = clienteController.ObtenerClientePorNIF(nifCliente);
                Direcciones direcciones = direccionController.ObtenerDireccion((int)cliente.DireccionID);
                if (cliente != null && direcciones != null)
                {
                    ClientesXmlWrapper clienteXmlWrapper = new ClientesXmlWrapper();
                    clienteXmlWrapper.NIF = cliente.NIF;
                    clienteXmlWrapper.Nombre = cliente.Nombre;
                    clienteXmlWrapper.PrimerApellido = cliente.PrimerApellido;
                    clienteXmlWrapper.SegundoApellido = cliente.SegundoApellido;
                    clienteXmlWrapper.Contraseña = cliente.Contraseña;
                    clienteXmlWrapper.CorreoElectronico = cliente.CorreoElectronico;
                    clienteXmlWrapper.Telefono = cliente.Telefono;

                    // Obtener y mapear las direcciones
                    DireccionesXmlWrapper direccionesXmlWrapper = new DireccionesXmlWrapper();
                    direccionesXmlWrapper.DireccionID = direcciones.DireccionID;
                    direccionesXmlWrapper.Calle = direcciones.Calle;
                    direccionesXmlWrapper.Numero = direcciones.Numero;
                    direccionesXmlWrapper.Puerta = direcciones.Puerta;
                    direccionesXmlWrapper.Piso = direcciones.Piso;
                    direccionesXmlWrapper.CodigoPostal = direcciones.CodigoPostal;
                    direccionesXmlWrapper.Provincia = direcciones.Provincia;
                    direccionesXmlWrapper.Pais = direcciones.Pais;
                    clienteXmlWrapper.Direcciones = new List<DireccionesXmlWrapper>() { direccionesXmlWrapper };
                    XmlSerializer serializer = new XmlSerializer(clienteXmlWrapper.GetType());
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "XML files (*.xml)|*.xml",
                        Title = "Guardar archivo XML",
                        FileName = "datos.xml" // Este es nombre por defecto
                    };
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        rutaArchivoXml = saveFileDialog.FileName;
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
                                using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                                {
                                    serializer.Serialize(stream, clienteXmlWrapper);
                                }

                                MessageBox.Show("Exportación exitosa.");
                                UpdateWebBrowserContent();

                                return;
                            }
                            else if (result == DialogResult.No)
                            {
                                // Conecpto de LIFO (Last In First Out) para añadir datos al archivo existente
                                // Aplicamos LIFO a las reservasList 
                                // El usuario desea añadir datos al archivo donde corresponda

                                ClientesListXmlWrapper clientesList = new ClientesListXmlWrapper();
                                clientesList.Clientes = new List<ClientesXmlWrapper>();

                                using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                                {
                                    if (existingFileStream.Length != 0)
                                        // Deserializa los datos existentes desde el archivo
                                        clientesList = (ClientesListXmlWrapper)serializer.Deserialize(existingFileStream);
                                }

                                using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                                {
                                    serializer.Serialize(stream, clientesList);
                                }
                                MessageBox.Show("Exportación exitosa.");
                                UpdateWebBrowserContent();
                                return;


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
                            UpdateWebBrowserContent();

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
            catch
            {
                MessageBox.Show("No se ha encontrado el cliente.");
            }
        }

        private void ObtenerClientePorNif_(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            BuscadorCliente.Visible = true;
            BuscadorCliente.Text = "Introduzca el NIF del cliente";
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientForm.xslt");

        }

        private void ObtenerClientes_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientListForm.xslt");
            List<Clientes> clientes = clienteController.ObtenerClientes();
            ClientesListXmlWrapper clientesList = new ClientesListXmlWrapper();
            clientesList.Clientes = new List<ClientesXmlWrapper>();
            foreach (Clientes cliente in clientes)
            {
                Direcciones direcciones = direccionController.ObtenerDireccion((int)cliente.DireccionID);
                ClientesXmlWrapper clienteXmlWrapper = new ClientesXmlWrapper();
                clienteXmlWrapper.NIF = cliente.NIF;
                clienteXmlWrapper.Nombre = cliente.Nombre;
                clienteXmlWrapper.PrimerApellido = cliente.PrimerApellido;
                clienteXmlWrapper.SegundoApellido = cliente.SegundoApellido;
                clienteXmlWrapper.Contraseña = cliente.Contraseña;
                clienteXmlWrapper.CorreoElectronico = cliente.CorreoElectronico;
                clienteXmlWrapper.Telefono = cliente.Telefono;

                // Obtener y mapear las direcciones
                DireccionesXmlWrapper direccionesXmlWrapper = new DireccionesXmlWrapper();
                direccionesXmlWrapper.DireccionID = direcciones.DireccionID;
                direccionesXmlWrapper.Calle = direcciones.Calle;
                direccionesXmlWrapper.Numero = direcciones.Numero;
                direccionesXmlWrapper.Puerta = direcciones.Puerta;
                direccionesXmlWrapper.Piso = direcciones.Piso;
                direccionesXmlWrapper.CodigoPostal = direcciones.CodigoPostal;
                direccionesXmlWrapper.Provincia = direcciones.Provincia;
                direccionesXmlWrapper.Pais = direcciones.Pais;
                clienteXmlWrapper.Direcciones = new List<DireccionesXmlWrapper>() { direccionesXmlWrapper };
                clientesList.Clientes.Add(clienteXmlWrapper);
            }
            XmlSerializer serializer = new XmlSerializer(clientesList.GetType());
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                Title = "Guardar archivo XML",
                FileName = "datos.xml" // Este es nombre por defecto
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                rutaArchivoXml = saveFileDialog.FileName;
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
                        using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                        {
                            serializer.Serialize(stream, clientesList);
                        }

                        MessageBox.Show("Exportación exitosa.");
                        UpdateWebBrowserContent();

                        return;
                    }
                    else if (result == DialogResult.No)
                    {
                        // Conecpto de LIFO (Last In First Out) para añadir datos al archivo existente
                        // Aplicamos LIFO a las reservasList 
                        // El usuario desea añadir datos al archivo donde corresponda

                        ClientesListXmlWrapper clientesList2 = new ClientesListXmlWrapper();
                        clientesList2.Clientes = new List<ClientesXmlWrapper>();

                        using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                        {
                            if (existingFileStream.Length != 0)
                                // Deserializa los datos existentes desde el archivo
                                clientesList2 = (ClientesListXmlWrapper)serializer.Deserialize(existingFileStream);
                        }

                        using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                        {
                            serializer.Serialize(stream, clientesList2);
                        }
                        MessageBox.Show("Exportación exitosa.");
                        UpdateWebBrowserContent();
                        return;
                    }
                }
                try
                {
                    using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                    {
                        // Serializa los datos y escribe el archivo XML
                        serializer.Serialize(stream, clientesList.GetType());
                    }
                    MessageBox.Show("Exportación exitosa.");
                    UpdateWebBrowserContent();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar los datos: " + ex.Message);
                }
            }
        }

        private void ObtenerHistorialEstanciaCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();

        }

        private void ObtenerClientesConReservas_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();

        }

        private void ActualizarCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            textBoxName.Visible = true;
            textBoxSurname1.Visible = true;
            textBoxSurname2.Visible = true;
            textBoxNIF.Visible = true;
            textBoxTel.Visible = true;
            textBoxEmail.Visible = true;
            textBoxPsswd.Visible = true;
            textBoxPsswdCheck.Visible = true;
            textBoxCalle.Visible = true;
            textBoxCalleNumero.Visible = true;
            textBoxPuerta.Visible = true;
            textBoxPiso.Visible = true;
            textBoxCodigoPostal.Visible = true;
            textBoxProvincia.Visible = true;
            textBoxPais.Visible = true;
            BuscadorCliente.Visible = true;
            webBrowser1.Visible = true;

        }

        // NavegacionLateral
        private void RegistrarCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            textBoxName.Visible = true;
            textBoxSurname1.Visible = true;
            textBoxSurname2.Visible = true;
            textBoxNIF.Visible = true;
            textBoxTel.Visible = true;
            textBoxEmail.Visible = true;
            textBoxPsswd.Visible = true;
            textBoxPsswdCheck.Visible = true;
            textBoxCalle.Visible = true;
            textBoxCalleNumero.Visible = true;
            textBoxPuerta.Visible = true;
            textBoxPiso.Visible = true;
            textBoxCodigoPostal.Visible = true;
            textBoxProvincia.Visible = true;
            textBoxPais.Visible = true;
            Registrar.Visible = true;
        }

        private void EliminarCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);

        }
    }
}
