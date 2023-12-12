namespace HotelSolRepo.Vista
{
    partial class ComprasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonRegistrarProducto = new System.Windows.Forms.Button();
            this.buttonVerProveedores = new System.Windows.Forms.Button();
            this.buttonRegistrarProveedor = new System.Windows.Forms.Button();
            this.buttonRegistrarServicio = new System.Windows.Forms.Button();
            this.buttonVerServicios = new System.Windows.Forms.Button();
            this.buttonVerProductos = new System.Windows.Forms.Button();
            this.buttonComprarProducto = new System.Windows.Forms.Button();
            this.buttonVerFacturas = new System.Windows.Forms.Button();
            this.textBoxNombreProducto = new System.Windows.Forms.TextBox();
            this.textBoxPrecioProducto = new System.Windows.Forms.TextBox();
            this.textBoxCantidadProducto = new System.Windows.Forms.TextBox();
            this.textBoxNombreServicio = new System.Windows.Forms.TextBox();
            this.textBoxPrecioServicio = new System.Windows.Forms.TextBox();
            this.textBoxCantidadServicio = new System.Windows.Forms.TextBox();
            this.textBoxNIFProveedor = new System.Windows.Forms.TextBox();
            this.textBoxEmpresaProveedor = new System.Windows.Forms.TextBox();
            this.textBoxContactoProveedor = new System.Windows.Forms.TextBox();
            this.textBoxCorreoProveedor = new System.Windows.Forms.TextBox();
            this.textBoxTipoProveedor = new System.Windows.Forms.TextBox();
            this.textBoxCondicionesPagoProveedor = new System.Windows.Forms.TextBox();
            this.buttonConfirmarOperacion = new System.Windows.Forms.Button();
            this.textBoxIDUsuario = new System.Windows.Forms.TextBox();
            this.textBoxIDComprar = new System.Windows.Forms.TextBox();
            this.dataGridViewTodo = new System.Windows.Forms.DataGridView();
            this.hotelDBDataSet2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDBDataSet2 = new HotelSolRepo.HotelDBDataSet2();
            this.serviciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturasTableAdapter = new HotelSolRepo.HotelDBDataSet2TableAdapters.FacturasTableAdapter();
            this.productosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productosTableAdapter = new HotelSolRepo.HotelDBDataSet2TableAdapters.ProductosTableAdapter();
            this.serviciosTableAdapter = new HotelSolRepo.HotelDBDataSet2TableAdapters.ServiciosTableAdapter();
            this.proveedoresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.proveedoresTableAdapter = new HotelSolRepo.HotelDBDataSet2TableAdapters.ProveedoresTableAdapter();
            this.buttonContratarServicio = new System.Windows.Forms.Button();
            this.textBoxIDServicioContratar = new System.Windows.Forms.TextBox();
            this.textBoxIDusuarioServicio = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTodo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegistrarProducto
            // 
            this.buttonRegistrarProducto.Location = new System.Drawing.Point(1014, 432);
            this.buttonRegistrarProducto.Name = "buttonRegistrarProducto";
            this.buttonRegistrarProducto.Size = new System.Drawing.Size(168, 59);
            this.buttonRegistrarProducto.TabIndex = 6;
            this.buttonRegistrarProducto.Text = "Registrar Producto";
            this.buttonRegistrarProducto.UseVisualStyleBackColor = true;
            this.buttonRegistrarProducto.Click += new System.EventHandler(this.buttonRegistrarProducto_Click);
            // 
            // buttonVerProveedores
            // 
            this.buttonVerProveedores.Location = new System.Drawing.Point(1014, 367);
            this.buttonVerProveedores.Name = "buttonVerProveedores";
            this.buttonVerProveedores.Size = new System.Drawing.Size(168, 59);
            this.buttonVerProveedores.TabIndex = 5;
            this.buttonVerProveedores.Text = "Ver Proveedores";
            this.buttonVerProveedores.UseVisualStyleBackColor = true;
            this.buttonVerProveedores.Click += new System.EventHandler(this.buttonVerProveedores_Click);
            // 
            // buttonRegistrarProveedor
            // 
            this.buttonRegistrarProveedor.Location = new System.Drawing.Point(1014, 302);
            this.buttonRegistrarProveedor.Name = "buttonRegistrarProveedor";
            this.buttonRegistrarProveedor.Size = new System.Drawing.Size(168, 59);
            this.buttonRegistrarProveedor.TabIndex = 4;
            this.buttonRegistrarProveedor.Text = "Registrar Proveedor";
            this.buttonRegistrarProveedor.UseVisualStyleBackColor = true;
            this.buttonRegistrarProveedor.Click += new System.EventHandler(this.buttonRegistrarProveedor_Click);
            // 
            // buttonRegistrarServicio
            // 
            this.buttonRegistrarServicio.Location = new System.Drawing.Point(1014, 562);
            this.buttonRegistrarServicio.Name = "buttonRegistrarServicio";
            this.buttonRegistrarServicio.Size = new System.Drawing.Size(168, 59);
            this.buttonRegistrarServicio.TabIndex = 8;
            this.buttonRegistrarServicio.Text = "Registrar Servicio";
            this.buttonRegistrarServicio.UseVisualStyleBackColor = true;
            this.buttonRegistrarServicio.Click += new System.EventHandler(this.buttonRegistrarServicio_Click);
            // 
            // buttonVerServicios
            // 
            this.buttonVerServicios.Location = new System.Drawing.Point(1014, 627);
            this.buttonVerServicios.Name = "buttonVerServicios";
            this.buttonVerServicios.Size = new System.Drawing.Size(168, 59);
            this.buttonVerServicios.TabIndex = 9;
            this.buttonVerServicios.Text = "Ver Servicios";
            this.buttonVerServicios.UseVisualStyleBackColor = true;
            this.buttonVerServicios.Click += new System.EventHandler(this.buttonVerServicios_Click);
            // 
            // buttonVerProductos
            // 
            this.buttonVerProductos.Location = new System.Drawing.Point(1014, 497);
            this.buttonVerProductos.Name = "buttonVerProductos";
            this.buttonVerProductos.Size = new System.Drawing.Size(168, 59);
            this.buttonVerProductos.TabIndex = 11;
            this.buttonVerProductos.Text = "Ver Productos";
            this.buttonVerProductos.UseVisualStyleBackColor = true;
            this.buttonVerProductos.Click += new System.EventHandler(this.buttonVerProductos_Click);
            // 
            // buttonComprarProducto
            // 
            this.buttonComprarProducto.Location = new System.Drawing.Point(1188, 302);
            this.buttonComprarProducto.Name = "buttonComprarProducto";
            this.buttonComprarProducto.Size = new System.Drawing.Size(168, 59);
            this.buttonComprarProducto.TabIndex = 10;
            this.buttonComprarProducto.Text = "ComprarProducto";
            this.buttonComprarProducto.UseVisualStyleBackColor = true;
            this.buttonComprarProducto.Click += new System.EventHandler(this.buttonComprarProducto_Click);
            // 
            // buttonVerFacturas
            // 
            this.buttonVerFacturas.Location = new System.Drawing.Point(1188, 432);
            this.buttonVerFacturas.Name = "buttonVerFacturas";
            this.buttonVerFacturas.Size = new System.Drawing.Size(168, 59);
            this.buttonVerFacturas.TabIndex = 13;
            this.buttonVerFacturas.Text = "Ver Facturas";
            this.buttonVerFacturas.UseVisualStyleBackColor = true;
            this.buttonVerFacturas.Click += new System.EventHandler(this.buttonVerFacturas_Click);
            // 
            // textBoxNombreProducto
            // 
            this.textBoxNombreProducto.Location = new System.Drawing.Point(27, 43);
            this.textBoxNombreProducto.Name = "textBoxNombreProducto";
            this.textBoxNombreProducto.Size = new System.Drawing.Size(150, 22);
            this.textBoxNombreProducto.TabIndex = 0;
            this.textBoxNombreProducto.Text = "Nombre";
            this.textBoxNombreProducto.Visible = false;
            // 
            // textBoxPrecioProducto
            // 
            this.textBoxPrecioProducto.Location = new System.Drawing.Point(27, 73);
            this.textBoxPrecioProducto.Name = "textBoxPrecioProducto";
            this.textBoxPrecioProducto.Size = new System.Drawing.Size(150, 22);
            this.textBoxPrecioProducto.TabIndex = 1;
            this.textBoxPrecioProducto.Text = "Precio";
            this.textBoxPrecioProducto.Visible = false;
            // 
            // textBoxCantidadProducto
            // 
            this.textBoxCantidadProducto.Location = new System.Drawing.Point(27, 103);
            this.textBoxCantidadProducto.Name = "textBoxCantidadProducto";
            this.textBoxCantidadProducto.Size = new System.Drawing.Size(150, 22);
            this.textBoxCantidadProducto.TabIndex = 2;
            this.textBoxCantidadProducto.Text = "Cantidad";
            this.textBoxCantidadProducto.Visible = false;
            // 
            // textBoxNombreServicio
            // 
            this.textBoxNombreServicio.Location = new System.Drawing.Point(27, 43);
            this.textBoxNombreServicio.Name = "textBoxNombreServicio";
            this.textBoxNombreServicio.Size = new System.Drawing.Size(150, 22);
            this.textBoxNombreServicio.TabIndex = 0;
            this.textBoxNombreServicio.Text = "Nombre Servicio";
            this.textBoxNombreServicio.Visible = false;
            // 
            // textBoxPrecioServicio
            // 
            this.textBoxPrecioServicio.Location = new System.Drawing.Point(27, 73);
            this.textBoxPrecioServicio.Name = "textBoxPrecioServicio";
            this.textBoxPrecioServicio.Size = new System.Drawing.Size(150, 22);
            this.textBoxPrecioServicio.TabIndex = 1;
            this.textBoxPrecioServicio.Text = "Precio Servicio";
            this.textBoxPrecioServicio.Visible = false;
            // 
            // textBoxCantidadServicio
            // 
            this.textBoxCantidadServicio.Location = new System.Drawing.Point(27, 103);
            this.textBoxCantidadServicio.Name = "textBoxCantidadServicio";
            this.textBoxCantidadServicio.Size = new System.Drawing.Size(150, 22);
            this.textBoxCantidadServicio.TabIndex = 2;
            this.textBoxCantidadServicio.Text = "Cantidad Servicio";
            this.textBoxCantidadServicio.Visible = false;
            // 
            // textBoxNIFProveedor
            // 
            this.textBoxNIFProveedor.Location = new System.Drawing.Point(200, 43);
            this.textBoxNIFProveedor.Name = "textBoxNIFProveedor";
            this.textBoxNIFProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxNIFProveedor.TabIndex = 17;
            this.textBoxNIFProveedor.Text = "NIF";
            this.textBoxNIFProveedor.Visible = false;
            // 
            // textBoxEmpresaProveedor
            // 
            this.textBoxEmpresaProveedor.Location = new System.Drawing.Point(200, 73);
            this.textBoxEmpresaProveedor.Name = "textBoxEmpresaProveedor";
            this.textBoxEmpresaProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxEmpresaProveedor.TabIndex = 18;
            this.textBoxEmpresaProveedor.Text = "Empresa";
            this.textBoxEmpresaProveedor.Visible = false;
            // 
            // textBoxContactoProveedor
            // 
            this.textBoxContactoProveedor.Location = new System.Drawing.Point(373, 43);
            this.textBoxContactoProveedor.Name = "textBoxContactoProveedor";
            this.textBoxContactoProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxContactoProveedor.TabIndex = 19;
            this.textBoxContactoProveedor.Text = "Contacto";
            this.textBoxContactoProveedor.Visible = false;
            // 
            // textBoxCorreoProveedor
            // 
            this.textBoxCorreoProveedor.Location = new System.Drawing.Point(373, 73);
            this.textBoxCorreoProveedor.Name = "textBoxCorreoProveedor";
            this.textBoxCorreoProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxCorreoProveedor.TabIndex = 20;
            this.textBoxCorreoProveedor.Text = "CorreoElectronico";
            this.textBoxCorreoProveedor.Visible = false;
            // 
            // textBoxTipoProveedor
            // 
            this.textBoxTipoProveedor.Location = new System.Drawing.Point(200, 101);
            this.textBoxTipoProveedor.Name = "textBoxTipoProveedor";
            this.textBoxTipoProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxTipoProveedor.TabIndex = 21;
            this.textBoxTipoProveedor.Text = "TipoProveedor";
            this.textBoxTipoProveedor.Visible = false;
            // 
            // textBoxCondicionesPagoProveedor
            // 
            this.textBoxCondicionesPagoProveedor.Location = new System.Drawing.Point(373, 101);
            this.textBoxCondicionesPagoProveedor.Name = "textBoxCondicionesPagoProveedor";
            this.textBoxCondicionesPagoProveedor.Size = new System.Drawing.Size(150, 22);
            this.textBoxCondicionesPagoProveedor.TabIndex = 22;
            this.textBoxCondicionesPagoProveedor.Text = "CondicionesDePago";
            this.textBoxCondicionesPagoProveedor.Visible = false;
            // 
            // buttonConfirmarOperacion
            // 
            this.buttonConfirmarOperacion.Location = new System.Drawing.Point(27, 133);
            this.buttonConfirmarOperacion.Name = "buttonConfirmarOperacion";
            this.buttonConfirmarOperacion.Size = new System.Drawing.Size(150, 30);
            this.buttonConfirmarOperacion.TabIndex = 3;
            this.buttonConfirmarOperacion.Text = "Confirmar Operación";
            this.buttonConfirmarOperacion.Visible = false;
            this.buttonConfirmarOperacion.Click += new System.EventHandler(this.buttonConfirmarOperacion_Click);
            // 
            // textBoxIDUsuario
            // 
            this.textBoxIDUsuario.Location = new System.Drawing.Point(27, 43);
            this.textBoxIDUsuario.Name = "textBoxIDUsuario";
            this.textBoxIDUsuario.Size = new System.Drawing.Size(100, 22);
            this.textBoxIDUsuario.TabIndex = 14;
            this.textBoxIDUsuario.Text = "IDUsuario";
            this.textBoxIDUsuario.Visible = false;
            // 
            // textBoxIDComprar
            // 
            this.textBoxIDComprar.Location = new System.Drawing.Point(27, 73);
            this.textBoxIDComprar.Name = "textBoxIDComprar";
            this.textBoxIDComprar.Size = new System.Drawing.Size(100, 22);
            this.textBoxIDComprar.TabIndex = 15;
            this.textBoxIDComprar.Text = "ID a comprar";
            this.textBoxIDComprar.Visible = false;
            // 
            // dataGridViewTodo
            // 
            this.dataGridViewTodo.AutoGenerateColumns = false;
            this.dataGridViewTodo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTodo.DataSource = this.hotelDBDataSet2BindingSource;
            this.dataGridViewTodo.Location = new System.Drawing.Point(61, 210);
            this.dataGridViewTodo.Name = "dataGridViewTodo";
            this.dataGridViewTodo.RowHeadersWidth = 51;
            this.dataGridViewTodo.RowTemplate.Height = 24;
            this.dataGridViewTodo.Size = new System.Drawing.Size(806, 531);
            this.dataGridViewTodo.TabIndex = 16;
            // 
            // hotelDBDataSet2BindingSource
            // 
            this.hotelDBDataSet2BindingSource.DataSource = this.hotelDBDataSet2;
            this.hotelDBDataSet2BindingSource.Position = 0;
            // 
            // hotelDBDataSet2
            // 
            this.hotelDBDataSet2.DataSetName = "HotelDBDataSet2";
            this.hotelDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serviciosBindingSource
            // 
            this.serviciosBindingSource.DataMember = "Servicios";
            this.serviciosBindingSource.DataSource = this.hotelDBDataSet2BindingSource;
            // 
            // facturasBindingSource
            // 
            this.facturasBindingSource.DataMember = "Facturas";
            this.facturasBindingSource.DataSource = this.hotelDBDataSet2BindingSource;
            // 
            // facturasTableAdapter
            // 
            this.facturasTableAdapter.ClearBeforeFill = true;
            // 
            // productosBindingSource
            // 
            this.productosBindingSource.DataMember = "Productos";
            this.productosBindingSource.DataSource = this.hotelDBDataSet2BindingSource;
            // 
            // productosTableAdapter
            // 
            this.productosTableAdapter.ClearBeforeFill = true;
            // 
            // serviciosTableAdapter
            // 
            this.serviciosTableAdapter.ClearBeforeFill = true;
            // 
            // proveedoresBindingSource
            // 
            this.proveedoresBindingSource.DataMember = "Proveedores";
            this.proveedoresBindingSource.DataSource = this.hotelDBDataSet2BindingSource;
            // 
            // proveedoresTableAdapter
            // 
            this.proveedoresTableAdapter.ClearBeforeFill = true;
            // 
            // buttonContratarServicio
            // 
            this.buttonContratarServicio.Location = new System.Drawing.Point(1188, 367);
            this.buttonContratarServicio.Name = "buttonContratarServicio";
            this.buttonContratarServicio.Size = new System.Drawing.Size(168, 59);
            this.buttonContratarServicio.TabIndex = 23;
            this.buttonContratarServicio.Text = "ContratarServicio";
            this.buttonContratarServicio.UseVisualStyleBackColor = true;
            this.buttonContratarServicio.Click += new System.EventHandler(this.buttonContratarServicio_Click);
            // 
            // textBoxIDServicioContratar
            // 
            this.textBoxIDServicioContratar.Location = new System.Drawing.Point(27, 75);
            this.textBoxIDServicioContratar.Name = "textBoxIDServicioContratar";
            this.textBoxIDServicioContratar.Size = new System.Drawing.Size(100, 22);
            this.textBoxIDServicioContratar.TabIndex = 25;
            this.textBoxIDServicioContratar.Text = "ID a contratar";
            this.textBoxIDServicioContratar.Visible = false;
            // 
            // textBoxIDusuarioServicio
            // 
            this.textBoxIDusuarioServicio.Location = new System.Drawing.Point(27, 45);
            this.textBoxIDusuarioServicio.Name = "textBoxIDusuarioServicio";
            this.textBoxIDusuarioServicio.Size = new System.Drawing.Size(100, 22);
            this.textBoxIDusuarioServicio.TabIndex = 24;
            this.textBoxIDusuarioServicio.Text = "IDUsuario";
            this.textBoxIDusuarioServicio.Visible = false;
            // 
            // ComprasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1359, 777);
            this.Controls.Add(this.textBoxIDServicioContratar);
            this.Controls.Add(this.textBoxIDusuarioServicio);
            this.Controls.Add(this.buttonContratarServicio);
            this.Controls.Add(this.dataGridViewTodo);
            this.Controls.Add(this.textBoxIDComprar);
            this.Controls.Add(this.textBoxIDUsuario);
            this.Controls.Add(this.textBoxNombreProducto);
            this.Controls.Add(this.textBoxPrecioProducto);
            this.Controls.Add(this.textBoxCantidadProducto);
            this.Controls.Add(this.textBoxNombreServicio);
            this.Controls.Add(this.textBoxPrecioServicio);
            this.Controls.Add(this.textBoxCantidadServicio);
            this.Controls.Add(this.buttonConfirmarOperacion);
            this.Controls.Add(this.buttonVerFacturas);
            this.Controls.Add(this.buttonVerProductos);
            this.Controls.Add(this.buttonComprarProducto);
            this.Controls.Add(this.buttonVerServicios);
            this.Controls.Add(this.buttonRegistrarServicio);
            this.Controls.Add(this.buttonRegistrarProducto);
            this.Controls.Add(this.buttonVerProveedores);
            this.Controls.Add(this.buttonRegistrarProveedor);
            this.Controls.Add(this.textBoxNIFProveedor);
            this.Controls.Add(this.textBoxEmpresaProveedor);
            this.Controls.Add(this.textBoxContactoProveedor);
            this.Controls.Add(this.textBoxCorreoProveedor);
            this.Controls.Add(this.textBoxTipoProveedor);
            this.Controls.Add(this.textBoxCondicionesPagoProveedor);
            this.Name = "ComprasForm";
            this.Text = "ComprasForm";
            this.Load += new System.EventHandler(this.ComprasForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTodo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedoresBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegistrarProducto;
        private System.Windows.Forms.Button buttonVerProveedores;
        private System.Windows.Forms.Button buttonRegistrarProveedor;
        private System.Windows.Forms.Button buttonRegistrarServicio;
        private System.Windows.Forms.Button buttonVerServicios;
        private System.Windows.Forms.Button buttonVerProductos;
        private System.Windows.Forms.Button buttonComprarProducto;
        private System.Windows.Forms.Button buttonVerFacturas;
        private System.Windows.Forms.TextBox textBoxNombreProducto;
        private System.Windows.Forms.TextBox textBoxPrecioProducto;
        private System.Windows.Forms.TextBox textBoxCantidadProducto;

        private System.Windows.Forms.TextBox textBoxNombreServicio;
        private System.Windows.Forms.TextBox textBoxPrecioServicio;
        private System.Windows.Forms.TextBox textBoxCantidadServicio;

        private System.Windows.Forms.Button buttonConfirmarOperacion;
        private System.Windows.Forms.TextBox textBoxIDUsuario;
        private System.Windows.Forms.TextBox textBoxIDComprar;
        private System.Windows.Forms.TextBox textBoxNIFProveedor;
        private System.Windows.Forms.TextBox textBoxEmpresaProveedor;
        private System.Windows.Forms.TextBox textBoxContactoProveedor;
        private System.Windows.Forms.TextBox textBoxCorreoProveedor;
        private System.Windows.Forms.TextBox textBoxTipoProveedor;
        private System.Windows.Forms.TextBox textBoxCondicionesPagoProveedor;
        private System.Windows.Forms.DataGridView dataGridViewTodo;
        private System.Windows.Forms.BindingSource hotelDBDataSet2BindingSource;
        private HotelDBDataSet2 hotelDBDataSet2;
        private System.Windows.Forms.BindingSource facturasBindingSource;
        private HotelDBDataSet2TableAdapters.FacturasTableAdapter facturasTableAdapter;
        private System.Windows.Forms.BindingSource productosBindingSource;
        private HotelDBDataSet2TableAdapters.ProductosTableAdapter productosTableAdapter;
        private System.Windows.Forms.BindingSource serviciosBindingSource;
        private HotelDBDataSet2TableAdapters.ServiciosTableAdapter serviciosTableAdapter;
        private System.Windows.Forms.BindingSource proveedoresBindingSource;
        private HotelDBDataSet2TableAdapters.ProveedoresTableAdapter proveedoresTableAdapter;
        private System.Windows.Forms.Button buttonContratarServicio;
        private System.Windows.Forms.TextBox textBoxIDServicioContratar;
        private System.Windows.Forms.TextBox textBoxIDusuarioServicio;
    }
}