using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace HotelSolRepo.Vista
{
    public partial class ClienteForm : Form
    {
        private DataGridView dataGrid;
        private ClienteController clienteController = null;
        private HabitacionController habitacionController = null;
        private DireccionController direccionController = null;
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
            this.Load += new EventHandler(ClienteForm_Load);

            exportXmlWrapperType = typeof(ClientesListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
            }

        }

        private void ClienteForm_Load(object sender, EventArgs e)
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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string nif = NIF.Text;
            string password = Pass.Text;

            if (clienteController.AutenticarUsuario(nif, password))
            {
                // Establecer la propiedad IsAuthenticated en true y almacenar el NIF autenticado
                FormPrincipal parentForm = (FormPrincipal)this.ParentForm;
                parentForm.IsAuthenticated = true;
                parentForm.AuthenticatedNIF = nif;  // Almacenar el NIF del usuario autenticado

                MessageBox.Show("Cliente validado.");
                parentForm.OnPrincipalFormCalled(this);
                BuscadorCliente.Visible = true;
                webBrowser1.Visible = true;
                webBrowser1.BringToFront();
                NIF.Visible = false;
                Pass.Visible = false;
                Login.Visible = false;
                Register.Visible = false;
                
                
            }
            else
            {
                MessageBox.Show("Validacion fallida. Verifique sus credenciales.");
            }

            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Login Form fields
            NIF.Visible = false;
            Pass.Visible = false;
            Login.Visible = false;
            Register.Visible = false;

            //Register Form fields
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

            //Buscador Cliente Form fields
            BuscadorCliente.Visible = false;

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

                    //Login Form fields
                    NIF.Visible = true;
                    Pass.Visible = true;
                    Login.Visible = true;
                    Register.Visible = true;
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
            // Elimina el DataGridView actual si existe
            if (dataGrid != null)
            {
                this.Controls.Remove(dataGrid);
                dataGrid.Dispose();
            }

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

        private void ClientForm_Load(object sender, EventArgs e)
        {
            if (((FormPrincipal)this.Owner).IsAuthenticated)
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
                BuscadorCliente.Visible = true;
                BuscadorCliente.Show();
                BuscadorCliente.BringToFront();
                webBrowser1.Visible = false;

            }
            else
            {
                NIF.Visible = true;
                Pass.Visible = true;
                Login.Visible = true;
                Register.Visible = true;
            }
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
                        // Crea el DataGridView
                        dataGrid = new DataGridView
                        {
                            Name = "DataGridViewCliente",
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                            AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                            AutoSize = true,
                            Size = new System.Drawing.Size(951, 452),
                            Location = new System.Drawing.Point(50, 90),
                            Dock = DockStyle.None
                        };

                        // Si los datos son de tipo ReservasListXmlWrapper, extrae la lista de Reservas
                        if (xmlWrapperType == typeof(ReservasListXmlWrapper))
                        {
                            ReservasListXmlWrapper reservasList = (ReservasListXmlWrapper)data[0];
                            data = reservasList.Reservas;
                        }
                        // Si los datos son de tipo ReservaHabitacionesListXmlWrapper, extrae la lista de ReservasHabitaciones
                        else if (xmlWrapperType == typeof(ReservaHabitacionesListXmlWrapper))
                        {
                            ReservaHabitacionesListXmlWrapper reservasHabitacionesList = (ReservaHabitacionesListXmlWrapper)data[0];
                            data = reservasHabitacionesList.ReservaHabitaciones;
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
                fileDialog.ShowDialog();
                xsltFile = fileDialog.FileName;
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

    }
}
