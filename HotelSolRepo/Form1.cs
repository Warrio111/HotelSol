using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HotelSolRepo.Modelo;

namespace HotelSolRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                // Carga todos los clientes con sus programas de fidelización relacionados
                var clientes = db.Clientes
                                 .Include("ProgramasFidelizacion")
                                 .Include("Facturas")
                                 .Include("Reservas")
                                 .ToList();

                // Cree una proyección de los datos que quiere mostrar
                var vistaClientes = clientes.Select(c => new
                {
                    c.NIF,
                    c.Nombre,
                    c.CorreoElectronico,
                    c.Telefono,
                    c.Reservas,
                    c.Facturas,
                    Fidelizacion = c.ProgramasFidelizacion.Nombre  // Muestre el nombre en lugar del ID 
                }).ToList();

                dataClientesGrid.DataSource = vistaClientes;
            }
        }

    }
}

