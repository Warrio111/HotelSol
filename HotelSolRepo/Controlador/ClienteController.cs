using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HotelSolRepo.Modelo;

namespace HotelSolRepo.Controlador
{
    public class ClienteController
    {
        // Método para hashear la contraseña
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Método para autenticar un usuario
        public bool AutenticarUsuario(string nif, string password)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                string hashedPassword = HashPassword(password);
                var cliente = db.Clientes.FirstOrDefault(c => c.NIF == nif && c.Contraseña == hashedPassword);
                return cliente != null;
            }
        }

        // Método para registrar un nuevo cliente
        public bool RegistrarCliente(string nif, string nombre, string primerapellido, string segundoapellido, string correoElectronico, string telefono, string password, string calle, string numero, string puerta, string piso, string codigoPostal, string provincia, string pais)
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

                string hashedPassword = HashPassword(password);

                var nuevoCliente = new Clientes
                {
                    NIF = nif,
                    Nombre = nombre,
                    PrimerApellido = primerapellido,
                    SegundoApellido = segundoapellido,
                    CorreoElectronico = correoElectronico,
                    Telefono = telefono,
                    Contraseña = hashedPassword,
                    DireccionID = nuevaDireccion.DireccionID  // Asignar la nueva dirección al cliente
                };
                return AgregarCliente(nuevoCliente);
                
            }
        }


        // Agrega un nuevo cliente al sistema
        public bool AgregarCliente(Clientes nuevoCliente)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                db.Clientes.Add(nuevoCliente);
                db.SaveChanges();
                return true;
            }
        }
        // Actualiza la información de un cliente existente
        public bool ActualizarCliente(Clientes clienteActualizado)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var clienteExistente = db.Clientes.FirstOrDefault(c => c.NIF == clienteActualizado.NIF);
                if (clienteExistente != null)
                {
                    clienteExistente.Nombre = clienteActualizado.Nombre;
                    clienteExistente.CorreoElectronico = clienteActualizado.CorreoElectronico;
                    clienteExistente.Telefono = clienteActualizado.Telefono;
                    // Actualizar otros campos aquí, pendiente de implementar...
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Elimina un cliente del sistema
        public bool EliminarCliente(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var clienteExistente = db.Clientes.FirstOrDefault(c => c.NIF == nif);
                if (clienteExistente != null)
                {
                    db.Clientes.Remove(clienteExistente);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Obtiene un cliente específico por NIF
        public Clientes ObtenerClientePorNIF(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Clientes.FirstOrDefault(c => c.NIF == nif);
            }
        }
        // Obtiene una lista de todos los clientes
        public List<Clientes> ObtenerClientes()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Clientes.ToList();
            }
        }

        // Obtiene Estancias de un cliente específico por NIF
        public List<Reservas> GetHistorialEstanciasCliente(string clienteId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Reservas.Where(r => r.Clientes.NIF == clienteId).ToList();
            }
        }
        public List<Clientes> GetClientesConReservas()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Clientes.Where(c => c.Reservas.Any()).ToList();
            }
        }



    }
}

