using HotelSolRepo.Controlador;
using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public ComprasForm(ref Type exportXmlWrapperType, Form formularioPadre)
        {
            InitializeComponent();
            clienteController = new ClienteController();
            habitacionController = new HabitacionController();
            direccionController = new DireccionController();
            reservaController = new ReservaController();
            facturaController = new FacturaController();
            incidenciaController = new IncidenciaController();
            programaFidelizacionController = new ProgramaFidelizacionController();
            this.Load += new EventHandler(ComprasForm_Load);

            exportXmlWrapperType = typeof(FacturasListXmlWrapper);
            this.Owner = formularioPadre;
            if (this.Owner is FormPrincipal formPrincipal)
            {
                ((FormPrincipal)this.Owner).OnPrincipalFormCalled(this);
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
            textBoxNombreProducto.Text = "Nombre Producto";
            textBoxPrecioProducto.Visible = true;
            textBoxNombreProducto.Text = "Precio Producto";
            textBoxCantidadProducto.Visible = true;
            textBoxNombreProducto.Text = "Cantidad Producto";
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

                // Realizar las operaciones necesarias con los datos del proveedor
                // ...

                // Limpiar o realizar otras acciones después de la operación
            }
            else if (textBoxNombreProducto.Visible)
            {
                // Realizar operación para el registro de producto
                string nombreProducto = textBoxNombreProducto.Text;
                string precioProducto = textBoxPrecioProducto.Text;
                string cantidadProducto = textBoxCantidadProducto.Text;

                // Realizar las operaciones necesarias con los datos del producto
                // ...

                // Limpiar o realizar otras acciones después de la operación
            }
            else if (textBoxNombreServicio.Visible)
            {
                // Realizar operación para el registro de servicio
                string nombreServicio = textBoxNombreServicio.Text;
                string precioServicio = textBoxPrecioServicio.Text;
                string cantidadServicio = textBoxCantidadServicio.Text;

                // Realizar las operaciones necesarias con los datos del servicio
                // ...

                // Limpiar o realizar otras acciones después de la operación
            }
            else if (textBoxIDComprar.Visible)
            {
                // Realizar operación para la compra de producto
                string idProducto = textBoxIDComprar.Text;
                string idUsuario = textBoxIDUsuario.Text;

                // Realizar las operaciones necesarias para la compra del producto
                // ...

                // Limpiar o realizar otras acciones después de la operación
            }
        }

        
    }
}
