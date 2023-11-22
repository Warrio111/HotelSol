using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    public class FacturaController
    {
        //Metodo para registrar una nueva factura
        public bool RegistrarFactura(string nif, int empleadoID, string detalles, double cargos, double impuestos, DateTime fecha, DateTime fechaCreacion, string tipoFactura)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                //Obtener la ultima FacturaID de la tabla Facturas
                var ultimaFactura = db.Facturas.OrderByDescending(f => f.FacturaID).FirstOrDefault();

                var nuevaFactura = new Facturas
                {
                    FacturaID = ultimaFactura != null ? ultimaFactura.FacturaID + 1 : 1,
                    NIF = nif,
                    EmpleadoID = empleadoID,
                    Detalles = detalles,
                    Cargos = cargos,
                    Impuestos = impuestos,
                    Fecha = fecha,
                    FechaCreacion = fechaCreacion,
                    TipoFactura = tipoFactura
                };

                db.Facturas.Add(nuevaFactura);
                db.SaveChanges();
                return true;

            }
        }
        //Metodo para modificar una factura
        public bool ModificarFactura(int facturaID, string nif, int empleadoID, string detalles, double cargos, double impuestos, DateTime fecha, DateTime fechaCreacion, string tipoFactura)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Facturas facturas = new Facturas
                {
                    FacturaID = facturaID,
                    NIF = nif,
                    EmpleadoID = empleadoID,
                    Detalles = detalles,
                    Cargos = cargos,
                    Impuestos = impuestos,
                    Fecha = fecha,
                    FechaCreacion = fechaCreacion,
                    TipoFactura = tipoFactura
                };
                if (facturas != null)
                {
                    var facturaExistente = db.Facturas.FirstOrDefault(f => f.FacturaID == facturaID);
                    facturaExistente.FacturaID = facturas.FacturaID;
                    facturaExistente.NIF = facturas.NIF;
                    facturaExistente.EmpleadoID = facturas.EmpleadoID;
                    facturaExistente.Detalles = facturas.Detalles;
                    facturaExistente.Cargos = facturas.Cargos;
                    facturaExistente.Impuestos = facturas.Impuestos;
                    facturaExistente.Fecha = facturas.Fecha;
                    facturaExistente.FechaCreacion = facturas.FechaCreacion;
                    facturaExistente.TipoFactura = facturas.TipoFactura;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Metodo para eliminar una factura
        public bool EliminarFactura(int facturaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var factura = db.Facturas.FirstOrDefault(f => f.FacturaID == facturaID);
                if (factura != null)
                {
                    db.Facturas.Remove(factura);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        //Metodo para obtener una factura
        public Facturas ObtenerFactura(int facturaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.FirstOrDefault(f => f.FacturaID == facturaID);
            }
        }
        //Metodo para obtener todas las facturas
        public List<Facturas> ObtenerFacturas()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.ToList();
            }
        }
        //Metodo para obtener todas las facturas de un cliente
        public List<Facturas> ObtenerFacturasCliente(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.NIF == nif).ToList();
            }
        }
        //Metodo para obtener todas las facturas de un empleado
        public List<Facturas> ObtenerFacturasEmpleado(int empleadoID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.EmpleadoID == empleadoID).ToList();
            }
        }
        //Metodo para obtener todas las facturas de un cliente en un rango de fechas
        public List<Facturas> ObtenerFacturasClienteFecha(string nif, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.NIF == nif && f.Fecha >= fechaInicio && f.Fecha <= fechaFin).ToList();
            }
        }
        //Metodo para obtener todas las facturas de un empleado en un rango de fechas
        public List<Facturas> ObtenerFacturasEmpleadoFecha(int empleadoID, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.EmpleadoID == empleadoID && f.Fecha >= fechaInicio && f.Fecha <= fechaFin).ToList();
            }
        }
        //Metodo para obtener todas las facturas de un cliente en un rango de fechas
        public List<Facturas> ObtenerFacturasClienteFechaCreacion(string nif, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.NIF == nif && f.FechaCreacion >= fechaInicio && f.FechaCreacion <= fechaFin).ToList();
            }
        }
        //Metodo para obtener todas las facturas de un empleado en un rango de fechas
        public List<Facturas> ObtenerFacturasEmpleadoFechaCreacion(int empleadoID, DateTime fechaInicio, DateTime fechaFin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Facturas.Where(f => f.EmpleadoID == empleadoID && f.FechaCreacion >= fechaInicio && f.FechaCreacion <= fechaFin).ToList();
            }
        }

    }
}
