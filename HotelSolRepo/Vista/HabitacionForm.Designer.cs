namespace HotelSolRepo.Vista
{
    partial class HabitacionForm
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
            this.dataGridViewHabitaciones = new System.Windows.Forms.DataGridView();
            this.habitacionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caracteristicasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tarifaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoActualDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocupadodesdeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ocupadohastaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoHabitacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDBDataSet = new HotelSolRepo.HotelDBDataSet();
            this.habitacionesTableAdapter = new HotelSolRepo.HotelDBDataSetTableAdapters.HabitacionesTableAdapter();
            this.buttonRegistrarIncidencia = new System.Windows.Forms.Button();
            this.buttonVerIncidencia = new System.Windows.Forms.Button();
            this.buttonVerHabitaciones = new System.Windows.Forms.Button();
            this.dataGridViewIncidencias = new System.Windows.Forms.DataGridView();
            this.incidenciaIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaReporteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitacionIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incidenciasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDBDataSet1 = new HotelSolRepo.HotelDBDataSet1();
            this.hotelDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hotelDBDataSetBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.incidenciasTableAdapter = new HotelSolRepo.HotelDBDataSet1TableAdapters.IncidenciasTableAdapter();
            this.buttonEnviarMensajeIncidencia = new System.Windows.Forms.Button();
            this.labelMensajeIncidencia = new System.Windows.Forms.Label();
            this.labelHabitacionIDIncidencia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidenciasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSetBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHabitaciones
            // 
            this.dataGridViewHabitaciones.AutoGenerateColumns = false;
            this.dataGridViewHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.habitacionIDDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.caracteristicasDataGridViewTextBoxColumn,
            this.tarifaDataGridViewTextBoxColumn,
            this.estadoActualDataGridViewTextBoxColumn,
            this.ocupadodesdeDataGridViewTextBoxColumn,
            this.ocupadohastaDataGridViewTextBoxColumn,
            this.codigoHabitacionDataGridViewTextBoxColumn});
            this.dataGridViewHabitaciones.DataSource = this.habitacionesBindingSource;
            this.dataGridViewHabitaciones.Location = new System.Drawing.Point(81, 144);
            this.dataGridViewHabitaciones.Name = "dataGridViewHabitaciones";
            this.dataGridViewHabitaciones.RowHeadersWidth = 51;
            this.dataGridViewHabitaciones.RowTemplate.Height = 24;
            this.dataGridViewHabitaciones.Size = new System.Drawing.Size(740, 387);
            this.dataGridViewHabitaciones.TabIndex = 0;
            this.dataGridViewHabitaciones.Visible = false;
            // 
            // habitacionIDDataGridViewTextBoxColumn
            // 
            this.habitacionIDDataGridViewTextBoxColumn.DataPropertyName = "HabitacionID";
            this.habitacionIDDataGridViewTextBoxColumn.HeaderText = "HabitacionID";
            this.habitacionIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.habitacionIDDataGridViewTextBoxColumn.Name = "habitacionIDDataGridViewTextBoxColumn";
            this.habitacionIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.habitacionIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.Width = 125;
            // 
            // caracteristicasDataGridViewTextBoxColumn
            // 
            this.caracteristicasDataGridViewTextBoxColumn.DataPropertyName = "Caracteristicas";
            this.caracteristicasDataGridViewTextBoxColumn.HeaderText = "Caracteristicas";
            this.caracteristicasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.caracteristicasDataGridViewTextBoxColumn.Name = "caracteristicasDataGridViewTextBoxColumn";
            this.caracteristicasDataGridViewTextBoxColumn.Width = 125;
            // 
            // tarifaDataGridViewTextBoxColumn
            // 
            this.tarifaDataGridViewTextBoxColumn.DataPropertyName = "Tarifa";
            this.tarifaDataGridViewTextBoxColumn.HeaderText = "Tarifa";
            this.tarifaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tarifaDataGridViewTextBoxColumn.Name = "tarifaDataGridViewTextBoxColumn";
            this.tarifaDataGridViewTextBoxColumn.Width = 125;
            // 
            // estadoActualDataGridViewTextBoxColumn
            // 
            this.estadoActualDataGridViewTextBoxColumn.DataPropertyName = "EstadoActual";
            this.estadoActualDataGridViewTextBoxColumn.HeaderText = "EstadoActual";
            this.estadoActualDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.estadoActualDataGridViewTextBoxColumn.Name = "estadoActualDataGridViewTextBoxColumn";
            this.estadoActualDataGridViewTextBoxColumn.Width = 125;
            // 
            // ocupadodesdeDataGridViewTextBoxColumn
            // 
            this.ocupadodesdeDataGridViewTextBoxColumn.DataPropertyName = "Ocupado_desde";
            this.ocupadodesdeDataGridViewTextBoxColumn.HeaderText = "Ocupado_desde";
            this.ocupadodesdeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ocupadodesdeDataGridViewTextBoxColumn.Name = "ocupadodesdeDataGridViewTextBoxColumn";
            this.ocupadodesdeDataGridViewTextBoxColumn.Width = 125;
            // 
            // ocupadohastaDataGridViewTextBoxColumn
            // 
            this.ocupadohastaDataGridViewTextBoxColumn.DataPropertyName = "Ocupado_hasta";
            this.ocupadohastaDataGridViewTextBoxColumn.HeaderText = "Ocupado_hasta";
            this.ocupadohastaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.ocupadohastaDataGridViewTextBoxColumn.Name = "ocupadohastaDataGridViewTextBoxColumn";
            this.ocupadohastaDataGridViewTextBoxColumn.Width = 125;
            // 
            // codigoHabitacionDataGridViewTextBoxColumn
            // 
            this.codigoHabitacionDataGridViewTextBoxColumn.DataPropertyName = "CodigoHabitacion";
            this.codigoHabitacionDataGridViewTextBoxColumn.HeaderText = "CodigoHabitacion";
            this.codigoHabitacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.codigoHabitacionDataGridViewTextBoxColumn.Name = "codigoHabitacionDataGridViewTextBoxColumn";
            this.codigoHabitacionDataGridViewTextBoxColumn.Width = 125;
            // 
            // habitacionesBindingSource
            // 
            this.habitacionesBindingSource.DataMember = "Habitaciones";
            this.habitacionesBindingSource.DataSource = this.hotelDBDataSet;
            // 
            // hotelDBDataSet
            // 
            this.hotelDBDataSet.DataSetName = "HotelDBDataSet";
            this.hotelDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // habitacionesTableAdapter
            // 
            this.habitacionesTableAdapter.ClearBeforeFill = true;
            // 
            // buttonRegistrarIncidencia
            // 
            this.buttonRegistrarIncidencia.Location = new System.Drawing.Point(1128, 321);
            this.buttonRegistrarIncidencia.Name = "buttonRegistrarIncidencia";
            this.buttonRegistrarIncidencia.Size = new System.Drawing.Size(168, 59);
            this.buttonRegistrarIncidencia.TabIndex = 1;
            this.buttonRegistrarIncidencia.Text = "Registrar Incidencia";
            this.buttonRegistrarIncidencia.UseVisualStyleBackColor = true;
            this.buttonRegistrarIncidencia.Click += new System.EventHandler(this.buttonRegistrarIncidencia_click);
            // 
            // buttonVerIncidencia
            // 
            this.buttonVerIncidencia.Location = new System.Drawing.Point(1128, 386);
            this.buttonVerIncidencia.Name = "buttonVerIncidencia";
            this.buttonVerIncidencia.Size = new System.Drawing.Size(168, 59);
            this.buttonVerIncidencia.TabIndex = 2;
            this.buttonVerIncidencia.Text = "Ver Incidencia";
            this.buttonVerIncidencia.UseVisualStyleBackColor = true;
            this.buttonVerIncidencia.Click += new System.EventHandler(this.buttonVerIncidencia_click);
            // 
            // buttonVerHabitaciones
            // 
            this.buttonVerHabitaciones.Location = new System.Drawing.Point(1128, 451);
            this.buttonVerHabitaciones.Name = "buttonVerHabitaciones";
            this.buttonVerHabitaciones.Size = new System.Drawing.Size(168, 59);
            this.buttonVerHabitaciones.TabIndex = 3;
            this.buttonVerHabitaciones.Text = "Ver Habitaciones";
            this.buttonVerHabitaciones.UseVisualStyleBackColor = true;
            this.buttonVerHabitaciones.Click += new System.EventHandler(this.buttonVerHabitaciones_click);
            // 
            // dataGridViewIncidencias
            // 
            this.dataGridViewIncidencias.AutoGenerateColumns = false;
            this.dataGridViewIncidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncidencias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.incidenciaIDDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.fechaReporteDataGridViewTextBoxColumn,
            this.habitacionIDDataGridViewTextBoxColumn1});
            this.dataGridViewIncidencias.DataSource = this.incidenciasBindingSource;
            this.dataGridViewIncidencias.Location = new System.Drawing.Point(81, 144);
            this.dataGridViewIncidencias.Name = "dataGridViewIncidencias";
            this.dataGridViewIncidencias.RowHeadersWidth = 51;
            this.dataGridViewIncidencias.RowTemplate.Height = 24;
            this.dataGridViewIncidencias.Size = new System.Drawing.Size(740, 387);
            this.dataGridViewIncidencias.TabIndex = 4;
            this.dataGridViewIncidencias.Visible = false;
            // 
            // incidenciaIDDataGridViewTextBoxColumn
            // 
            this.incidenciaIDDataGridViewTextBoxColumn.DataPropertyName = "IncidenciaID";
            this.incidenciaIDDataGridViewTextBoxColumn.HeaderText = "IncidenciaID";
            this.incidenciaIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.incidenciaIDDataGridViewTextBoxColumn.Name = "incidenciaIDDataGridViewTextBoxColumn";
            this.incidenciaIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.incidenciaIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaReporteDataGridViewTextBoxColumn
            // 
            this.fechaReporteDataGridViewTextBoxColumn.DataPropertyName = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.HeaderText = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaReporteDataGridViewTextBoxColumn.Name = "fechaReporteDataGridViewTextBoxColumn";
            this.fechaReporteDataGridViewTextBoxColumn.Width = 125;
            // 
            // habitacionIDDataGridViewTextBoxColumn1
            // 
            this.habitacionIDDataGridViewTextBoxColumn1.DataPropertyName = "HabitacionID";
            this.habitacionIDDataGridViewTextBoxColumn1.HeaderText = "HabitacionID";
            this.habitacionIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.habitacionIDDataGridViewTextBoxColumn1.Name = "habitacionIDDataGridViewTextBoxColumn1";
            this.habitacionIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // incidenciasBindingSource
            // 
            this.incidenciasBindingSource.DataMember = "Incidencias";
            this.incidenciasBindingSource.DataSource = this.hotelDBDataSet1;
            // 
            // hotelDBDataSet1
            // 
            this.hotelDBDataSet1.DataSetName = "HotelDBDataSet1";
            this.hotelDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // hotelDBDataSetBindingSource
            // 
            this.hotelDBDataSetBindingSource.DataSource = this.hotelDBDataSet;
            this.hotelDBDataSetBindingSource.Position = 0;
            // 
            // hotelDBDataSetBindingSource1
            // 
            this.hotelDBDataSetBindingSource1.DataSource = this.hotelDBDataSet;
            this.hotelDBDataSetBindingSource1.Position = 0;
            // 
            // incidenciasTableAdapter
            // 
            this.incidenciasTableAdapter.ClearBeforeFill = true;
            // 
            // buttonEnviarMensajeIncidencia
            // 
            this.buttonEnviarMensajeIncidencia.Location = new System.Drawing.Point(652, 68);
            this.buttonEnviarMensajeIncidencia.Name = "buttonEnviarMensajeIncidencia";
            this.buttonEnviarMensajeIncidencia.Size = new System.Drawing.Size(142, 38);
            this.buttonEnviarMensajeIncidencia.TabIndex = 5;
            this.buttonEnviarMensajeIncidencia.Text = "Enviar mensaje";
            this.buttonEnviarMensajeIncidencia.UseVisualStyleBackColor = true;
            this.buttonEnviarMensajeIncidencia.Visible = false;
            this.buttonEnviarMensajeIncidencia.Click += new System.EventHandler(this.buttonEnviarMensageIncidencia_click);
            // 
            // labelMensajeIncidencia
            // 
            this.labelMensajeIncidencia.AutoSize = true;
            this.labelMensajeIncidencia.Location = new System.Drawing.Point(331, 79);
            this.labelMensajeIncidencia.Name = "labelMensajeIncidencia";
            this.labelMensajeIncidencia.Size = new System.Drawing.Size(286, 20);
            this.labelMensajeIncidencia.TabIndex = 6;
            this.labelMensajeIncidencia.Text = "Introduce El mensaje de la incidencia";
            this.labelMensajeIncidencia.Visible = false;
            // 
            // labelHabitacionIDIncidencia
            // 
            this.labelHabitacionIDIncidencia.AutoSize = true;
            this.labelHabitacionIDIncidencia.Location = new System.Drawing.Point(125, 79);
            this.labelHabitacionIDIncidencia.Name = "labelHabitacionIDIncidencia";
            this.labelHabitacionIDIncidencia.Size = new System.Drawing.Size(179, 16);
            this.labelHabitacionIDIncidencia.TabIndex = 7;
            this.labelHabitacionIDIncidencia.Text = "Introduce el ID de Habitacion";
            this.labelHabitacionIDIncidencia.Visible = false;
            // 
            // HabitacionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelSolRepo.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1229, 602);
            this.Controls.Add(this.labelHabitacionIDIncidencia);
            this.Controls.Add(this.labelMensajeIncidencia);
            this.Controls.Add(this.buttonEnviarMensajeIncidencia);
            this.Controls.Add(this.buttonVerHabitaciones);
            this.Controls.Add(this.buttonVerIncidencia);
            this.Controls.Add(this.buttonRegistrarIncidencia);
            this.Controls.Add(this.dataGridViewIncidencias);
            this.Controls.Add(this.dataGridViewHabitaciones);
            this.Name = "HabitacionForm";
            this.Text = "HabitacionForm";
            this.Load += new System.EventHandler(this.HabitacionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.habitacionesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncidencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.incidenciasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hotelDBDataSetBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHabitaciones;
        private HotelDBDataSet hotelDBDataSet;
        private System.Windows.Forms.BindingSource habitacionesBindingSource;
        private HotelDBDataSetTableAdapters.HabitacionesTableAdapter habitacionesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitacionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caracteristicasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tarifaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoActualDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocupadodesdeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ocupadohastaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoHabitacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonRegistrarIncidencia;
        private System.Windows.Forms.Button buttonVerIncidencia;
        private System.Windows.Forms.Button buttonVerHabitaciones;
        private System.Windows.Forms.DataGridView dataGridViewIncidencias;
        private System.Windows.Forms.BindingSource hotelDBDataSetBindingSource;
        private System.Windows.Forms.BindingSource hotelDBDataSetBindingSource1;
        private HotelDBDataSet1 hotelDBDataSet1;
        private System.Windows.Forms.BindingSource incidenciasBindingSource;
        private HotelDBDataSet1TableAdapters.IncidenciasTableAdapter incidenciasTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn incidenciaIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaReporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitacionIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button buttonEnviarMensajeIncidencia;
        private System.Windows.Forms.Label labelMensajeIncidencia;
        private System.Windows.Forms.Label labelHabitacionIDIncidencia;
    }
}