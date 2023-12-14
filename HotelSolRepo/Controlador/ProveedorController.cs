using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    /*Este es el modelo de un proveedor
    namespace HotelSolRepo.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Proveedores
    {
        public string NIF { get; set; }
        public string Empresa { get; set; }
        public string Contacto { get; set; }
        public string CorreoElectronico { get; set; }
        public string TipoProveedor { get; set; }
        public string CondicionesDePago { get; set; }
        public Nullable<int> DireccionID { get; set; }
    
        public virtual Direcciones Direcciones { get; set; }
    }
}*/
    public class ProveedorController
    {
        // Metodo para registrar un proveedor
        public bool RegistrarProveedor(string nif, string empresa, string contacto, string correoElectronico, string tipoProveedor, string condicionesDePago, int direccionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedor = new Proveedores()
                {
                    NIF = nif,
                    Empresa = empresa,
                    Contacto = contacto,
                    CorreoElectronico = correoElectronico,
                    TipoProveedor = tipoProveedor,
                    CondicionesDePago = condicionesDePago,
                    DireccionID = direccionID
                };
                db.Proveedores.Add(proveedor);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para modificar un proveedor
        public bool ModificarProveedor(string nif, string empresa, string contacto, string correoElectronico, string tipoProveedor, string condicionesDePago, int direccionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedor = db.Proveedores.Find(nif);
                proveedor.Empresa = empresa;
                proveedor.Contacto = contacto;
                proveedor.CorreoElectronico = correoElectronico;
                proveedor.TipoProveedor = tipoProveedor;
                proveedor.CondicionesDePago = condicionesDePago;
                proveedor.DireccionID = direccionID;
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para eliminar un proveedor
        public bool EliminarProveedor(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedor = db.Proveedores.Find(nif);
                db.Proveedores.Remove(proveedor);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para obtener un proveedor
        public Proveedores ObtenerProveedor(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedor = db.Proveedores.Find(nif);
                return proveedor;
            }
        }
        // Metodo para obtener todos los proveedores
        public List<Proveedores> ObtenerProveedores()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedores = db.Proveedores.ToList();
                return proveedores;
            }
        }

        // Metodo para obtener los datos de un proveedor en formato XML
        public ProveedoresXmlWrapper ObtenerDatosXmlProveedor(string nifProveedor)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var proveedor = db.Proveedores.Find(nifProveedor);
                var direccion = db.Direcciones.Find(proveedor.DireccionID);
                var proveedorXml = new ProveedoresXmlWrapper()
                {
                    NIF = proveedor.NIF,
                    Empresa = proveedor.Empresa,
                    Contacto = proveedor.Contacto,
                    CorreoElectronico = proveedor.CorreoElectronico,
                    TipoProveedor = proveedor.TipoProveedor,
                    CondicionesDePago = proveedor.CondicionesDePago,
                    Direccion = new DireccionesXmlWrapper()
                    {
                        DireccionID = direccion.DireccionID,
                        Calle = direccion.Calle,
                        Numero = direccion.Numero,
                        Puerta = direccion.Puerta,
                        Provincia = direccion.Provincia,
                        CodigoPostal = direccion.CodigoPostal,
                        Pais = direccion.Pais
                    }
                };
                return proveedorXml;
            }
        }
    }
}
