using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    /*
     Este es el modelo de un Servicio:
     namespace HotelSolRepo.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Servicios
    {
        public int ServicioID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> FacturaID { get; set; }
    
        public virtual Facturas Facturas { get; set; }
    }
}
    */
    public class ServicioController
    {
        // Metodo para registrar un servicio
        public bool RegistrarServicio(string nombre, decimal precio, int cantidad)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var servicio = new Servicios()
                {
                    Nombre = nombre,
                    Precio = precio,
                    Cantidad = cantidad,
                };
                db.Servicios.Add(servicio);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para modificar un servicio
        public bool ModificarServicio(int servicioID, string nombre, decimal precio, int cantidad, int facturaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var servicio = db.Servicios.Find(servicioID);
                servicio.Nombre = nombre;
                servicio.Precio = precio;
                servicio.Cantidad = cantidad;
                servicio.FacturaID = facturaID;
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para eliminar un servicio
        public bool EliminarServicio(int servicioID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var servicio = db.Servicios.Find(servicioID);
                db.Servicios.Remove(servicio);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para obtener un servicio
        public Servicios ObtenerServicio(int servicioID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var servicio = db.Servicios.Find(servicioID);
                return servicio;
            }
        }
        // Metodo para obtener todos los servicios
        public List<Servicios> ObtenerServicios()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var servicios = db.Servicios.ToList();
                return servicios;
            }
        }

    }
}
