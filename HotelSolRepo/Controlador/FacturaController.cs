using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using IronPython.Hosting;
using System.IO;

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

        // Metodo para obtener la ultima factura
        public int ObtenerUltimaFactura()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var ultimaFactura = db.Facturas.OrderByDescending(f => f.FacturaID).FirstOrDefault();
                return ultimaFactura.FacturaID;
            }
        }
        public double ObtenerPrecioTemporada(DateTime fechaInicio, DateTime fechaFin, string TipoDePension, int cantidad)
        {
            int precio = 0;
            switch (fechaInicio.Month)
            {
                case 1:
                case 2:
                case 3:
                case 11:
                case 12:
                    precio = 100;
                    break;

                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    precio = 300;
                    break;

                default:
                    precio = 200;
                    break;
            }

            if (TipoDePension == "Pension Completa")
            {
                precio += 50;
            }

            int dias = (fechaFin - fechaInicio).Days != 0 ? (fechaFin - fechaInicio).Days : 1;
            return (precio * cantidad) * dias;
        }

        // Metodo para llamar a script de python y generar la factura en odoo
        public void GenerarFacturaOdoo(string facturaxmldata)
        {
            // Configuracion del motor IronPython
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            // Importar el modulo de odoo
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PythonOdoo", "odoo_xmlrpc_wrapper.py");
            // Parámetros que deseas pasar al script
            string[] scriptArgs = { "host=192.168.1.53:8069", "db=infraninjas", "userlogin=infraninjas@gmail.com", "password=12345aA" };

            // Ejecutar el script con argumentos
            engine.GetSysModule().SetVariable("argv", scriptArgs);
            scope.Engine.ExecuteFile(rutaArchivo);
            // Obtener la clase Odoo
            dynamic bot = scope.GetVariable("Bot");
            // Llamar a la función con los datos XML
            bot.create_invoice_from_xml(facturaxmldata);
        }
    }
}
