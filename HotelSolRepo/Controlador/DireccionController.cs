using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    public class DireccionController
    {
        public bool RegistrarDireccion(string calle, string numero, string puerta, string piso, string codigoPostal, string provincia, string pais)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                // Obtener la última DireccionID de la tabla Direcciones
                var ultimaDireccion = db.Direcciones.OrderByDescending(d => d.DireccionID).FirstOrDefault();

                var nuevaDireccion = new Direcciones
                {
                    DireccionID = ultimaDireccion != null ? ultimaDireccion.DireccionID + 1 : 1,
                    Calle = calle,
                    Numero = numero,
                    Puerta = puerta,
                    Piso = piso,
                    CodigoPostal = codigoPostal,
                    Provincia = provincia,
                    Pais = pais
                };

                db.Direcciones.Add(nuevaDireccion);
                db.SaveChanges();
                return true;
            }
        }
        public bool ModificarDireccion(int direccionID, string calle, string numero, string puerta, string piso, string codigoPostal, string provincia, string pais)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var direccion = db.Direcciones.FirstOrDefault(d => d.DireccionID == direccionID);
                if (direccion != null)
                {
                    direccion.Calle = calle;
                    direccion.Numero = numero;
                    direccion.Puerta = puerta;
                    direccion.Piso = piso;
                    direccion.CodigoPostal = codigoPostal;
                    direccion.Provincia = provincia;
                    direccion.Pais = pais;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool EliminarDireccion(int direccionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var direccion = db.Direcciones.FirstOrDefault(d => d.DireccionID == direccionID);
                if (direccion != null)
                {
                    db.Direcciones.Remove(direccion);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Direcciones ObtenerDireccion(int direccionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Direcciones.FirstOrDefault(d => d.DireccionID == direccionID);
            }
        }

        public List<Direcciones> ObtenerDirecciones()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Direcciones.ToList();
            }
        }

        public List<Direcciones> ObtenerDirecciones(string calle, string numero, string puerta, string piso, string codigoPostal, string provincia, string pais)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Direcciones.Where(d => d.Calle.Contains(calle) &&
                                            d.Numero.Contains(numero) &&
                                            d.Puerta.Contains(puerta) &&
                                            d.Piso.Contains(piso) &&
                                            d.CodigoPostal.Contains(codigoPostal) &&
                                            d.Provincia.Contains(provincia) &&
                                            d.Pais.Contains(pais)).ToList();
            }
        }
    }
}
