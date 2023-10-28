using HotelSolRepo.Controlador;
using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Windows.Forms;

namespace HotelSolRepo.Modelo
{
    public partial class ServiciosExtraForm : Form
    {
        private string rutaArchivoXml = @"E:\backup\Academico\UOC\FP\Tercer Semestre\Técnicas de persistencia de datos con .NET\HotelSolRepo\HotelSolRepo\XMLs\reservas.xml";

        public ServiciosExtraForm()
        {
            InitializeComponent();
            btnConfirmar.Click += BtnConfirmar_Click;
            this.Load += ServiciosExtraForm_Load;
        }

        private void ServiciosExtraForm_Load(object sender, EventArgs e)
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
                xslt.Load(@"E:\backup\Academico\UOC\FP\Tercer Semestre\Técnicas de persistencia de datos con .NET\HotelSolRepo\HotelSolRepo\Vista\ReservaTemplate.xslt");

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

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            ReservaController reservaController = new ReservaController();
            reservaController.ConfirmarReserva();
        }
    }
}


