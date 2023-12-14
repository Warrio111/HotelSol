using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HotelSolRepo.Vista
{
    public partial class ComprasForm : Form
    {
        private ClienteController clienteController;
        private HabitacionController habitacionController;
        private DireccionController direccionController;
        private ReservaController reservaController;
        private FacturaController facturaController;
        private ProgramaFidelizacionController programaFidelizacionController;
        private IncidenciaController incidenciaController;
        private ServicioController servicioController;
        private ProductoController productoController;
        private ProveedorController proveedorController;
        private int AuthenticatedEmployeeID { get; set; }
        public ComprasForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            clienteController = new ClienteController();
            habitacionController = new HabitacionController();
            direccionController = new DireccionController();
            reservaController = new ReservaController();
            facturaController = new FacturaController();
            incidenciaController = new IncidenciaController();
            servicioController = new ServicioController();
            productoController = new ProductoController();
            proveedorController = new ProveedorController();
            programaFidelizacionController = new ProgramaFidelizacionController();
            this.Load += new EventHandler(ComprasForm_Load);

            exportXmlWrapperType = typeof(FacturasListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
                AuthenticatedEmployeeID = formPrincipal.AuthenticatedEmployeeID;
            }

        }

        private void ComprasForm_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet2.Proveedores' Puede moverla o quitarla según sea necesario.
            this.proveedoresTableAdapter.Fill(this.hotelDBDataSet2.Proveedores);
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet2.Servicios' Puede moverla o quitarla según sea necesario.
            this.serviciosTableAdapter.Fill(this.hotelDBDataSet2.Servicios);
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet2.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.hotelDBDataSet2.Productos);
            // TODO: esta línea de código carga datos en la tabla 'hotelDBDataSet2.Facturas' Puede moverla o quitarla según sea necesario.
            this.facturasTableAdapter.Fill(this.hotelDBDataSet2.Facturas);
            textBoxNombreProducto.Visible = false;
            textBoxPrecioProducto.Visible = false;
            textBoxCantidadProducto.Visible = false;
            buttonConfirmarOperacion.Visible = false;
            textBoxNombreServicio.Visible = false;
            textBoxPrecioServicio.Visible = false;
            textBoxCantidadServicio.Visible = false;
            textBoxNIFProveedor.Visible = false;
            textBoxEmpresaProveedor.Visible = false;
            textBoxContactoProveedor.Visible = false;
            textBoxCorreoProveedor.Visible = false;
            textBoxTipoProveedor.Visible = false;
            textBoxCondicionesPagoProveedor.Visible = false;
            textBoxIDComprar.Visible = false;
            textBoxIDUsuario.Visible = false;
            textBoxIDServicioContratar.Visible = false;
            textBoxIDusuarioServicio.Visible = false;
            buttonConfirmarOperacion.Location = new System.Drawing.Point(27, 133);


        }

        private void buttonRegistrarProveedor_Click(object sender, EventArgs e)
        {
            ComprasForm_Load(sender, e);
            buttonConfirmarOperacion.Location = new System.Drawing.Point(133, 133);
            // Mostrar los controles necesarios para registrar proveedores
            textBoxNIFProveedor.Visible = true;
            textBoxEmpresaProveedor.Visible = true;
            textBoxContactoProveedor.Visible = true;
            textBoxCorreoProveedor.Visible = true;
            textBoxTipoProveedor.Visible = true;
            textBoxCondicionesPagoProveedor.Visible = true;
            // Mostrar el botón de confirmar operación
            buttonConfirmarOperacion.Visible = true;
        }

        private void buttonRegistrarProducto_Click(object sender, EventArgs e)
        {
            ComprasForm_Load(sender, e);
            textBoxNombreProducto.Visible = true;
            textBoxPrecioProducto.Visible = true;
            textBoxCantidadProducto.Visible = true;
            buttonConfirmarOperacion.Visible = true;
        }

        private void buttonRegistrarServicio_Click(object sender, EventArgs e)
        {
            ComprasForm_Load(sender, e);
            textBoxNombreServicio.Text = "Nombre Servicio";
            textBoxNombreServicio.Visible = true;
            textBoxPrecioServicio.Text = "Precio Servicio";
            textBoxPrecioServicio.Visible = true;
            textBoxCantidadServicio.Text = "Cantidad Servicio";
            textBoxCantidadServicio.Visible = true;
            buttonConfirmarOperacion.Visible = true;
        }

        private void buttonVerServicios_Click(object sender, EventArgs e)
        {
            try
            {
                this.serviciosTableAdapter.Fill(this.hotelDBDataSet2.Servicios);
                this.dataGridViewTodo.DataSource = this.hotelDBDataSet2.Servicios;
                this.dataGridViewTodo.AutoGenerateColumns = true;
                this.dataGridViewTodo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los servicios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonVerFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                this.facturasTableAdapter.Fill(this.hotelDBDataSet2.Facturas);
                this.dataGridViewTodo.DataSource = this.hotelDBDataSet2.Facturas;
                this.dataGridViewTodo.AutoGenerateColumns = true;
                this.dataGridViewTodo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonVerProductos_Click(object sender, EventArgs e)
        {
            try
            {
                this.productosTableAdapter.Fill(this.hotelDBDataSet2.Productos);
                this.dataGridViewTodo.DataSource = this.hotelDBDataSet2.Productos;
                this.dataGridViewTodo.AutoGenerateColumns = true;
                this.dataGridViewTodo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonVerProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                this.proveedoresTableAdapter.Fill(this.hotelDBDataSet2.Proveedores);
                this.dataGridViewTodo.DataSource = this.hotelDBDataSet2.Proveedores;
                this.dataGridViewTodo.AutoGenerateColumns = true;
                this.dataGridViewTodo.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonComprarProducto_Click(object sender, EventArgs e)
        {
            ComprasForm_Load(sender, e);
            textBoxIDComprar.Visible = true;
            textBoxIDComprar.Text = "ID Producto";
            textBoxIDUsuario.Visible = true;
            textBoxIDUsuario.Text = "ID Usuario";
            buttonConfirmarOperacion.Visible = true;
        }
        private void buttonContratarServicio_Click(object sender, EventArgs e)
        {
            ComprasForm_Load(sender, e);
            textBoxIDServicioContratar.Visible = true;
            textBoxIDusuarioServicio.Visible = true;
            buttonConfirmarOperacion.Visible = true;
        }

        private void buttonConfirmarOperacion_Click(object sender, EventArgs e)
        {
            // Lógica para confirmar la operación con los datos ingresados en los TextBox
            // Puedes acceder a los valores con textBoxNombreProducto.Text, textBoxPrecioProducto.Text y textBoxCantidadProducto.Text
            // Realiza las operaciones necesarias aquí
            // Verificar qué controles están visibles
            if (textBoxNIFProveedor.Visible)
            {
                // Realizar operación para el registro de proveedor
                string nifProveedor = textBoxNIFProveedor.Text;
                string empresaProveedor = textBoxEmpresaProveedor.Text;
                string contactoProveedor = textBoxContactoProveedor.Text;
                string correoProveedor = textBoxCorreoProveedor.Text;
                string tipoProveedor = textBoxTipoProveedor.Text;
                string condicionesPagoProveedor = textBoxCondicionesPagoProveedor.Text;
                proveedorController.RegistrarProveedor(nifProveedor, empresaProveedor, contactoProveedor, correoProveedor, tipoProveedor, condicionesPagoProveedor, 1);
                GenerarXmlTemporalProveedor(nifProveedor);
            }
            else if (textBoxNombreProducto.Visible)
            {
                // Realizar operación para el registro de producto
                string nombreProducto = textBoxNombreProducto.Text;
                string precioProductoStr = textBoxPrecioProducto.Text;
                string cantidadProductoStr = textBoxCantidadProducto.Text;

                // Convertir los valores a tipos adecuados
                if (decimal.TryParse(precioProductoStr, out decimal precioProducto) &&
                    int.TryParse(cantidadProductoStr, out int cantidadProducto))
                {
                    // Realizar operaciones con los valores convertidos
                    productoController.RegistrarProducto(nombreProducto, precioProducto, cantidadProducto);
                    GenerarXmlTemporalProducto(nombreProducto);
                }


            }
            else if (textBoxNombreServicio.Visible)
            {
                // Realizar operación para el registro de servicio
                string nombreServicio = textBoxNombreServicio.Text;
                string precioServicioStr = textBoxPrecioServicio.Text;
                string cantidadServicioStr = textBoxCantidadServicio.Text;

                // Convertir los valores a tipos adecuados
                if (decimal.TryParse(precioServicioStr, out decimal precioServicio) &&
                    int.TryParse(cantidadServicioStr, out int cantidadServicio))
                {
                    // Realizar operaciones con los valores convertidos
                    int ultimaFactura = facturaController.ObtenerUltimaFactura() + 1;

                    // Asegúrate de ajustar esta línea si la función RegistrarServicio espera un valor de tipo decimal y un valor de tipo int
                    servicioController.RegistrarServicio(nombreServicio, precioServicio, cantidadServicio);
                    GenerarXmlTemporalServicio(nombreServicio);
                }

            }
            else if (textBoxIDComprar.Visible)
            {
                // Realizar operación para la compra de producto
                //Solo se mantiene el ultimo ID de la factura en la tabla de productos
                //Se estima que solo se hacen compras unitarias
                string idProducto = textBoxIDComprar.Text;
                string idUsuario = textBoxIDUsuario.Text;
                Productos producto = productoController.ObtenerProducto(int.Parse(idProducto));
               
                // Realizar operaciones con los valores convertidos
                facturaController.RegistrarFactura(idUsuario, AuthenticatedEmployeeID, producto.Nombre, (double)(producto.Precio), 0, DateTime.Now, DateTime.Now, "Producto");
                int ultimaFactura = facturaController.ObtenerUltimaFactura();
                productoController.ModificarProducto(producto.ProductoID, producto.Nombre, producto.Precio, producto.Cantidad - 1, ultimaFactura);
                GenerarXmlTemporalProducto(idProducto);

            }
            else if(textBoxIDServicioContratar.Visible)
            {
                // Realizar operación para la compra de servicio
                //Solo se mantiene el ultimo ID de la factura en la tabla de servicios
                //Se estima que solo se hacen compras unitarias
                string idServicio = textBoxIDServicioContratar.Text;
                string idUsuario = textBoxIDusuarioServicio.Text;
                Servicios servicios = servicioController.ObtenerServicio(int.Parse(idServicio));
                facturaController.RegistrarFactura(idUsuario, AuthenticatedEmployeeID, servicios.Nombre, (double)(servicios.Precio), 0, DateTime.Now, DateTime.Now, "Servicio");
                int ultimaFactura = facturaController.ObtenerUltimaFactura();
                servicioController.ModificarServicio(servicios.ServicioID, servicios.Nombre, servicios.Precio, servicios.Cantidad - 1, ultimaFactura);
                GenerarXmlTemporalServicio(idServicio);
            }
            else
            {
                // No hay operación para realizar
            }
        }
        // Métodos para generar XML temporal para cada tipo de entidad
        private void GenerarXmlTemporalProveedor(string nifProveedor)
        {
            ProveedoresXmlWrapper proveedorXml = proveedorController.ObtenerDatosXmlProveedor(nifProveedor);
            GenerarXmlTemporal(proveedorXml, "proveedor_temporal.xml");
        }

        private void GenerarXmlTemporalProducto(string nombreProducto)
        {
            ProductosXmlWrapper productoXml = productoController.ObtenerDatosXmlProducto(int.Parse(nombreProducto));
            GenerarXmlTemporal(productoXml, "producto_temporal.xml");
        }

        private void GenerarXmlTemporalServicio(string nombreServicio)
        {
            ServiciosXmlWrapper servicioXml = servicioController.ObtenerDatosXmlServicio(int.Parse(nombreServicio));
            GenerarXmlTemporal(servicioXml, "servicio_temporal.xml");
        }

        private void GenerarXmlTemporal(object data, string fileName)
        {
            // Lógica para serializar el objeto y guardarlo en un archivo temporal
            // Utiliza la clase XmlSerializer para convertir el objeto a XML
            XmlSerializer serializer = new XmlSerializer(data.GetType());
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", fileName);
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                serializer.Serialize(writer, data);
            }

            MessageBox.Show($"XML temporal creado y guardado en {filepath}");
        }
    }
}
