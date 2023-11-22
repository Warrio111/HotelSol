using HotelSolRepo.Controlador;
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Forms;

namespace HotelSolRepo.Modelo
{
    public partial class GenerarReserva : Form
    {
        private string rutaArchivoXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "reserva_temporal.xml");
        private string rutaXslt = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "ReservaTemplate.xslt");

        public GenerarReserva()
        {
            InitializeComponent();
            this.Load += GenerarReserva_Load;
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
    }
}




