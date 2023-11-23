using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
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
        private FacturaController facturaController = null;
        private ProgramaFidelizacionController programaFidelizacionController = null;
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
            facturaController = new FacturaController();
            programaFidelizacionController = new ProgramaFidelizacionController();
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
            textBoxNifClienteHistorial.Visible= false;
            textBoxNifClienteActualizar.Visible = false;
            buttonRealizarActualizarCliente.Visible = false;
            textBoxEliminarCliente.Visible = false;
            Registrar.Visible = false;
            webBrowser1.Visible = false;
            textBoxObtenerFacturaCliente.Visible = false;
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

            if (password == passwordCheck && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(nif) && !string.IsNullOrEmpty(calle))
            {
                bool resultadoCliente = clienteController.RegistrarCliente(nif, nombre, apellido1, apellido2, email, telefono, password, calle, numero, puerta, piso, codigoPostal, provincia, pais);
                bool resultadoDireccion = direccionController.RegistrarDireccion(calle, numero, puerta, piso, codigoPostal, provincia, pais);
                if (resultadoCliente && resultadoDireccion)
                {
                    MessageBox.Show("Cliente registrado con éxito.");
                    ClientForm_Load(null, null);
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
                                serializer.Serialize(stream, clienteXmlWrapper.GetType());
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

        // NavegacionLateral
        private void ObtenerClientePorNif_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            BuscadorCliente.Visible = true;
            BuscadorCliente.Text = "Introduzca el NIF del cliente";
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientForm.xslt");
        }

        // NavegacionLateral
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
        
        // NavegacionLateral
        private void ObtenerHistorialEstanciaCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            textBoxNifClienteHistorial.Visible = true;
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientReservaForm.xslt");

        }

        // NavegacionLateral
        private void ObtenerClientesConReservas_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            webBrowser1.Visible = true;
            webBrowser1.BringToFront();
            webBrowser1.Show();
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientListReservaForm.xslt");                                                                             
            List<Clientes> clientes = clienteController.GetClientesConReservas();
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

                // Obtener y mapear las facturas del cliente
                List<Facturas> facturas = facturaController.ObtenerFacturasCliente(cliente.NIF);
                clienteXmlWrapper.Facturas = facturas.Select(factura =>
                {
                    FacturasXmlWrapper facturaXmlWrapper = new FacturasXmlWrapper();
                    facturaXmlWrapper.FacturaID = factura.FacturaID;
                    facturaXmlWrapper.NIF = factura.NIF;
                    facturaXmlWrapper.EmpleadoID = factura.EmpleadoID;
                    facturaXmlWrapper.Detalles = factura.Detalles;
                    facturaXmlWrapper.Cargos = (float?)factura.Cargos;
                    facturaXmlWrapper.Impuestos = (float?)factura.Impuestos;
                    facturaXmlWrapper.Fecha = factura.Fecha;
                    facturaXmlWrapper.FechaCreacion = factura.FechaCreacion;
                    facturaXmlWrapper.TipoFactura = factura.TipoFactura;
                    return facturaXmlWrapper;
                }).ToList();

                // Obtener y mapear las reservas del cliente
                List<Reservas> reservas = clienteController.GetHistorialEstanciasCliente(cliente.NIF);
                clienteXmlWrapper.Reservas = reservas.Select(reserva =>
                {
                    ReservasXmlWrapper reservaXmlWrapper = new ReservasXmlWrapper();
                    reservaXmlWrapper.ReservaID = reserva.ReservaID;
                    reservaXmlWrapper.FechaInicio = reserva.FechaInicio;
                    reservaXmlWrapper.FechaFin = reserva.FechaFin;
                    reservaXmlWrapper.EstadoReserva = reserva.EstadoReserva;
                    reservaXmlWrapper.CheckInConfirmado = reserva.CheckInConfirmado;
                    reservaXmlWrapper.CheckOutConfirmado = reserva.CheckOutConfirmado;
                    reservaXmlWrapper.FechaCreacion = reserva.FechaCreacion;
                    reservaXmlWrapper.TipoReserva = reserva.TipoReserva;
                    reservaXmlWrapper.NIF = reserva.NIF;
                    reservaXmlWrapper.EmpleadoID = reserva.EmpleadoID;
                    reservaXmlWrapper.FacturaID = reserva.FacturaID;
                    return reservaXmlWrapper;
                }).ToList();

                // Obtener y mapear los programas de fidelización del cliente
                List<ProgramasFidelizacion> programasFidelizacion = programaFidelizacionController.ObtenerProgramasFidelizacionCliente(cliente.NIF);
                clienteXmlWrapper.ProgramasFidelizacion = programasFidelizacion.Select(programa =>
                {
                    ProgramasFidelizacionXmlWrapper programaXmlWrapper = new ProgramasFidelizacionXmlWrapper();
                    programaXmlWrapper.ProgramaFidelizacionID = programa.ProgramaFidelizacionID;
                    programaXmlWrapper.Nombre = programa.Nombre;
                    programaXmlWrapper.Puntos = programa.Puntos;
                    programaXmlWrapper.Beneficios = programa.Beneficios;
                    return programaXmlWrapper;
                }).ToList();
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
            textBoxNifClienteActualizar.Visible = true;
            buttonRealizarActualizarCliente.Visible = true;

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

        // NavegacionLateral
        private void EliminarCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null, null);
            textBoxEliminarCliente.Visible = true;
            textBoxEliminarCliente.Text = "Introduzca el NIF del cliente a eliminar";
            
        }

        // NavegacionLateral
        private void RealizarActualizarCliente_Click(object sender, EventArgs e)
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
                Clientes clientes = clienteController.ObtenerClientePorNIF(textBoxNIF.Text);
                clientes.NIF = nif;
                clientes.Nombre = nombre;
                clientes.PrimerApellido = apellido1;
                clientes.SegundoApellido = apellido2;
                clientes.Telefono = telefono;
                clientes.CorreoElectronico = email;
                clientes.Contraseña = password;
                bool resultadoCliente = clienteController.ActualizarCliente(clientes);
                bool resultadoDireccion = direccionController.ModificarDireccion((int)clientes.DireccionID, calle, numero, puerta, piso, codigoPostal, provincia, pais);
                if (resultadoCliente && resultadoDireccion)
                {
                    MessageBox.Show("Cliente actualizado con éxito.");
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
                    textBoxNifClienteActualizar.Visible = false;
                    buttonRealizarActualizarCliente.Visible = false;

                }
                else
                {
                    MessageBox.Show("Error en la actualización del cliente.");
                }
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden o faltan campos obligatorios.");
            }
}

        private void NifClienteActualizar_Click(object sender, EventArgs e)
        {
            Clientes clientes = clienteController.ObtenerClientePorNIF(textBoxNifClienteActualizar.Text);
            textBoxName.Text = clientes.Nombre;
            textBoxSurname1.Text = clientes.PrimerApellido;
            textBoxSurname2.Text = clientes.SegundoApellido;
            textBoxNIF.Text = clientes.NIF;
            textBoxTel.Text = clientes.Telefono;
            textBoxEmail.Text = clientes.CorreoElectronico;
            textBoxPsswd.Text = String.Empty;
            textBoxPsswdCheck.Text = String.Empty;
            Direcciones direcciones = direccionController.ObtenerDireccion((int)clientes.DireccionID);
            textBoxCalle.Text = direcciones.Calle;
            textBoxCalleNumero.Text = direcciones.Numero;
            textBoxPuerta.Text = direcciones.Puerta;
            textBoxPiso.Text = direcciones.Piso;
            textBoxCodigoPostal.Text = direcciones.CodigoPostal;
            textBoxProvincia.Text = direcciones.Provincia;
            textBoxPais.Text = direcciones.Pais;
        }

        private void NifClienteHistorial_DoubleClick(object sender, EventArgs e)
        {
            
            List<Reservas> reservasList = clienteController.GetHistorialEstanciasCliente(textBoxNifClienteHistorial.Text);
            if (reservasList != null)
            {
                ReservasListXmlWrapper reservasListXmlWrapper = new ReservasListXmlWrapper();
                reservasListXmlWrapper.Reservas = new List<ReservasXmlWrapper>();

                foreach (Reservas reserva in reservasList)
                {
                    ReservasXmlWrapper reservasXmlWrapper = new ReservasXmlWrapper();
                    reservasXmlWrapper.ReservaID = reserva.ReservaID;
                    reservasXmlWrapper.FechaInicio = reserva.FechaInicio;
                    reservasXmlWrapper.FechaFin = reserva.FechaFin;
                    reservasXmlWrapper.EstadoReserva = reserva.EstadoReserva;
                    reservasXmlWrapper.CheckInConfirmado = reserva.CheckInConfirmado;
                    reservasXmlWrapper.CheckOutConfirmado = reserva.CheckOutConfirmado;
                    reservasXmlWrapper.FechaCreacion = reserva.FechaCreacion;
                    reservasXmlWrapper.TipoReserva = reserva.TipoReserva;
                    reservasXmlWrapper.NIF = reserva.NIF;
                    reservasXmlWrapper.EmpleadoID = reserva.EmpleadoID;
                    reservasXmlWrapper.FacturaID = reserva.FacturaID;

                    reservasListXmlWrapper.Reservas.Add(reservasXmlWrapper);
                }
                XmlSerializer serializer = new XmlSerializer(reservasListXmlWrapper.GetType());
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
                                serializer.Serialize(stream, reservasListXmlWrapper);
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
                            ReservasListXmlWrapper reservasListXml = new ReservasListXmlWrapper();
                            reservasListXml.Reservas = new List<ReservasXmlWrapper>();

                            using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                            {
                                if (existingFileStream.Length != 0)
                                    // Deserializa los datos existentes desde el archivo
                                    reservasListXml = (ReservasListXmlWrapper)serializer.Deserialize(existingFileStream);
                            }

                            using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                            {
                                serializer.Serialize(stream, reservasListXml);
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
                            serializer.Serialize(stream, reservasListXmlWrapper.GetType());
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
        }

        private void textBoxEliminarCliente_Click(object sender, EventArgs e)
        {
           bool resultado = clienteController.EliminarCliente(textBoxEliminarCliente.Text);
            if (resultado)
            {
                MessageBox.Show("Cliente eliminado con éxito.");
                ClientForm_Load(null, null);
            }
            else
            {
                MessageBox.Show("Error en la eliminación del cliente.");
            }
        }
        // Navegacion Lateral
        private void ObtenerFacturaCliente_Click(object sender, EventArgs e)
        {
            ClientForm_Load(null,null);
            textBoxObtenerFacturaCliente.Visible = true;
            webBrowser1.Visible = true;
            xsltFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ClientFacturaForm.xslt");

        }

        private void ObtenerFacturaCliente_DoubleClick(object sender, EventArgs e)
        {
            string reservaID = textBoxObtenerFacturaCliente.Text;
            if (string.IsNullOrEmpty(reservaID))
            {
                MessageBox.Show("Introduzca el código de la reserva.");
                return;
            }
            Reservas reservas = reservaController.ObtenerReservaPorID(int.Parse(reservaID));
            Facturas facturas = facturaController.ObtenerFactura((int)(reservas.FacturaID));
            Clientes clientes = clienteController.ObtenerClientePorNIF(facturas.NIF);
            Direcciones direcciones = direccionController.ObtenerDireccion((int)clientes.DireccionID);
            
            if (facturas != null && clientes != null && direcciones != null && reservas != null)
            {
                FacturasXmlWrapper facturasXmlWrapper = new FacturasXmlWrapper();
                facturasXmlWrapper.FacturaID = facturas.FacturaID;
                facturasXmlWrapper.NIF = facturas.NIF;
                facturasXmlWrapper.EmpleadoID = facturas.EmpleadoID;
                facturasXmlWrapper.Detalles = facturas.Detalles;
                facturasXmlWrapper.Cargos = (float?)facturas.Cargos;
                facturasXmlWrapper.Impuestos = (float?)facturas.Impuestos;
                facturasXmlWrapper.Fecha = facturas.Fecha;
                facturasXmlWrapper.FechaCreacion = facturas.FechaCreacion;
                facturasXmlWrapper.TipoFactura = facturas.TipoFactura;

                // Obtener y mapear los clientes
                ClientesXmlWrapper clientesXmlWrapper = new ClientesXmlWrapper();
                clientesXmlWrapper.NIF = clientes.NIF;
                clientesXmlWrapper.Nombre = clientes.Nombre;
                clientesXmlWrapper.PrimerApellido = clientes.PrimerApellido;
                clientesXmlWrapper.SegundoApellido = clientes.SegundoApellido;
                clientesXmlWrapper.Contraseña = clientes.Contraseña;
                clientesXmlWrapper.CorreoElectronico = clientes.CorreoElectronico;
                clientesXmlWrapper.Telefono = clientes.Telefono;

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

                // Obtener y mapear las reservas
                ReservasXmlWrapper reservasXmlWrapper = new ReservasXmlWrapper();
                reservasXmlWrapper.ReservaID = reservas.ReservaID;
                reservasXmlWrapper.FechaInicio = reservas.FechaInicio;
                reservasXmlWrapper.FechaFin = reservas.FechaFin;
                reservasXmlWrapper.EstadoReserva = reservas.EstadoReserva;
                reservasXmlWrapper.CheckInConfirmado = reservas.CheckInConfirmado;
                reservasXmlWrapper.CheckOutConfirmado = reservas.CheckOutConfirmado;
                reservasXmlWrapper.FechaCreacion = reservas.FechaCreacion;
                reservasXmlWrapper.TipoReserva = reservas.TipoReserva;
                reservasXmlWrapper.NIF = reservas.NIF;
                reservasXmlWrapper.EmpleadoID = reservas.EmpleadoID;
                reservasXmlWrapper.FacturaID = reservas.FacturaID;

                clientesXmlWrapper.Direcciones = new List<DireccionesXmlWrapper>() { direccionesXmlWrapper };
                facturasXmlWrapper.Clientes = new List<ClientesXmlWrapper>() { clientesXmlWrapper };
                facturasXmlWrapper.Reservas = new List<ReservasXmlWrapper>() { reservasXmlWrapper };

                XmlSerializer serializer = new XmlSerializer(facturasXmlWrapper.GetType());
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
                                serializer.Serialize(stream, facturasXmlWrapper);
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

                            FacturasListXmlWrapper facturasList = new FacturasListXmlWrapper();
                            facturasList.Facturas = new List<FacturasXmlWrapper>();

                            using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
                            {
                                if (existingFileStream.Length != 0)
                                    // Deserializa los datos existentes desde el archivo
                                    facturasList = (FacturasListXmlWrapper)serializer.Deserialize(existingFileStream);
                            }

                            using (FileStream stream = new FileStream(rutaArchivoXml, FileMode.Create))
                            {
                                serializer.Serialize(stream, facturasList);
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
                            serializer.Serialize(stream, facturasXmlWrapper.GetType());
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
        }
    }
}
