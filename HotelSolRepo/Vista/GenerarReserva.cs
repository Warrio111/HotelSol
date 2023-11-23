using HotelSolRepo.Controlador;
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Forms;
using System.Xml.Serialization;
using RestSharp.Serializers;
using System.Linq;

namespace HotelSolRepo.Modelo
{
    public partial class GenerarReserva : Form
    {
        private string rutaArchivoXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "reserva_temporal.xml");
        private string rutaXslt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ReservaTemplate.xslt");
        private ReservaController reservaController = null;
        private FacturaController facturaController = null;
        private HabitacionController habitacionController = null;
        public GenerarReserva()
        {
            InitializeComponent();
            this.Load += GenerarReserva_Load;
            reservaController = new ReservaController();
            facturaController = new FacturaController();
            habitacionController = new HabitacionController();

        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            TransformarYMostrarXML();
        }

        private void TransformarYMostrarXML()
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
                xslt.Load(rutaXslt);

                using (StringWriter sw = new StringWriter())
                using (XmlTextWriter writer = new XmlTextWriter(sw))
                {
                    xslt.Transform(xmlDoc, null, writer);
                    return sw.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al transformar XML a HTML: " + ex.Message);
                return string.Empty;
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Deserializamos el archivo XML para obtener todos los datos de la reservaCompleta
            XmlSerializer serializer = new XmlSerializer(typeof(ReservaCompletaXmlWrapper));
            ReservaCompletaXmlWrapper reservaCompleta = null;
            using (FileStream existingFileStream = new FileStream(rutaArchivoXml, FileMode.Open))
            {
                reservaCompleta = (ReservaCompletaXmlWrapper)serializer.Deserialize(existingFileStream);
            }

            int empleadoID = 0;
            if (reservaCompleta.Reserva.EmpleadoID != null)
            { empleadoID = (int)reservaCompleta.Reserva.EmpleadoID; }
            if(facturaController.RegistrarFactura(reservaCompleta.Factura.NIF, (int)reservaCompleta.Factura.EmpleadoID, reservaCompleta.Factura.Detalles, (double)reservaCompleta.Factura.Cargos, (double)reservaCompleta.Factura.Impuestos, (DateTime)reservaCompleta.Factura.Fecha, (DateTime)reservaCompleta.Factura.FechaCreacion, reservaCompleta.Factura.TipoFactura))
            { 
                if(reservaController.RegistrarReserva(reservaCompleta.Reserva.NIF, empleadoID, (DateTime)reservaCompleta.Reserva.FechaInicio, (DateTime)reservaCompleta.Reserva.FechaFin, "Ocupada", null, null, facturaController.ObtenerUltimaFactura(), (DateTime)reservaCompleta.Reserva.FechaCreacion, "Estancia"))
                {
                    int reservaID = reservaController.ObtenerUltimaReserva().ReservaID;
                    using (HotelDBEntities db = new HotelDBEntities())
                    {
                        // Crear registro en ReservaHabitaciones con estos campos [ReservaID],[HabitacionID],[TipoPension],[FechaInicio],[FechaFin],[Precio]
                        foreach (var reservaHabitacion in reservaCompleta.ReservaHabitaciones)
                        {
                            if (reservaHabitacion.HabitacionID != null)
                            {
                                db.ReservaHabitaciones.Add(new ReservaHabitaciones
                                {
                                    ReservaHabitacionID = reservaHabitacion.ReservaHabitacionID,
                                    ReservaID = reservaID,
                                    HabitacionID = reservaHabitacion.HabitacionID,
                                    TipoPension = reservaHabitacion.TipoPension,
                                    FechaInicio = reservaHabitacion.FechaInicio,
                                    FechaFin = reservaHabitacion.FechaFin,
                                    Precio = reservaHabitacion.Precio
                                });
                                db.SaveChanges();
                            }
                        }
                    }
                    bool resultadoCambioEstadoHabitacion = false;
                    foreach (var reservaHabitacion in reservaCompleta.ReservaHabitaciones)
                    {
                        if (reservaHabitacion.HabitacionID != null)
                        {
                            resultadoCambioEstadoHabitacion = habitacionController.CambiarEstadoHabitacion((int)reservaHabitacion.HabitacionID, reservaCompleta.Reserva.EstadoReserva, reservaCompleta.Reserva.FechaInicio, reservaCompleta.Reserva.FechaFin);
                        }
                    }
                    if (resultadoCambioEstadoHabitacion)
                    {
                        MessageBox.Show("Reserva realizada correctamente");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al realizar la reserva");
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Error al registrar la reserva");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error al registrar la factura");
                this.Close();
            }
           
            

        }
    }
}




