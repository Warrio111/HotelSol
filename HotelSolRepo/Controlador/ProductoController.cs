using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    /*
     Este es el modelo de un producto
namespace HotelSolRepo.Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Productos
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> FacturaID { get; set; }
    
        public virtual Facturas Facturas { get; set; }
    }
}
    */
    public class ProductoController
    {
        // Metodo para registrar un producto
        public bool RegistrarProducto(string nombre, decimal precio, int cantidad)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var producto = new Productos()
                {
                    Nombre = nombre,
                    Precio = precio,
                    Cantidad = cantidad,
                };
                db.Productos.Add(producto);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para modificar un producto
        public bool ModificarProducto(int productoID, string nombre, decimal precio, int cantidad, int facturaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var producto = db.Productos.Find(productoID);
                producto.Nombre = nombre;
                producto.Precio = precio;
                producto.Cantidad = cantidad;
                producto.FacturaID = facturaID;
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para eliminar un producto
        public bool EliminarProducto(int productoID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var producto = db.Productos.Find(productoID);
                db.Productos.Remove(producto);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para obtener un producto
        public Productos ObtenerProducto(int productoID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var producto = db.Productos.Find(productoID);
                return producto;
            }
        }
        // Metodo para obtener todos los productos
        public List<Productos> ObtenerProductos()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var productos = db.Productos.ToList();
                return productos;
            }
        }

        // Metodo para obtener los datos de un producto en formato XML
        public ProductosXmlWrapper ObtenerDatosXmlProducto(int idProducto)
        {
               using (HotelDBEntities db = new HotelDBEntities())
            {
                    var producto = db.Productos.Find(idProducto);
                    var productoXml = new ProductosXmlWrapper()
                    {
                        ProductoID = producto.ProductoID,
                        Nombre = producto.Nombre,
                        Precio = producto.Precio,
                        Cantidad = producto.Cantidad,
                        FacturaID = producto.FacturaID
                    };
                    return productoXml;
                }
        }
    }
}
