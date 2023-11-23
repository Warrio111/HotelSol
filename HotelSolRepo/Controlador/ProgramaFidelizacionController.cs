using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{

    public class ProgramaFidelizacionController
    {
        // Metodo para registrar un nuevo programa de fidelizacion
        public bool RegistrarProgramaFidelizacion(string nombre, int puntos, string beneficios)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                //Obtener el ultimo ProgramaFidelizacionID de la tabla ProgramasFidelizacion
                var ultimoProgramaFidelizacion = db.ProgramasFidelizacion.OrderByDescending(p => p.ProgramaFidelizacionID).FirstOrDefault();

                var nuevoProgramaFidelizacion = new ProgramasFidelizacion
                {
                    ProgramaFidelizacionID = ultimoProgramaFidelizacion != null ? ultimoProgramaFidelizacion.ProgramaFidelizacionID + 1 : 1,
                    Nombre = nombre,
                    Puntos = puntos,
                    Beneficios = beneficios
                };

                db.ProgramasFidelizacion.Add(nuevoProgramaFidelizacion);
                db.SaveChanges();
                return true;
            }
        }
        // Metodo para modificar un programa de fidelizacion
        public bool ModificarProgramaFidelizacion(int programaFidelizacionID, string nombre, int puntos, string beneficios)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                ProgramasFidelizacion programasFidelizacion = new ProgramasFidelizacion
                {
                    ProgramaFidelizacionID = programaFidelizacionID,
                    Nombre = nombre,
                    Puntos = puntos,
                    Beneficios = beneficios
                };
                if (programasFidelizacion != null)
                {
                    var programaFidelizacionExistente = db.ProgramasFidelizacion.FirstOrDefault(p => p.ProgramaFidelizacionID == programaFidelizacionID);
                    programaFidelizacionExistente.ProgramaFidelizacionID = programasFidelizacion.ProgramaFidelizacionID;
                    programaFidelizacionExistente.Nombre = programasFidelizacion.Nombre;
                    programaFidelizacionExistente.Puntos = programasFidelizacion.Puntos;
                    programaFidelizacionExistente.Beneficios = programasFidelizacion.Beneficios;
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Metodo para eliminar un programa de fidelizacion
        public bool EliminarProgramaFidelizacion(int programaFidelizacionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var programaFidelizacion = db.ProgramasFidelizacion.FirstOrDefault(p => p.ProgramaFidelizacionID == programaFidelizacionID);
                if (programaFidelizacion != null)
                {
                    db.ProgramasFidelizacion.Remove(programaFidelizacion);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Metodo para obtener un programa de fidelizacion
        public ProgramasFidelizacion ObtenerProgramaFidelizacion(int programaFidelizacionID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.ProgramasFidelizacion.FirstOrDefault(p => p.ProgramaFidelizacionID == programaFidelizacionID);
            }
        }
        // Metodo para obtener todos los programas de fidelizacion
        public List<ProgramasFidelizacion> ObtenerProgramasFidelizacion()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.ProgramasFidelizacion.ToList();
            }
        }
        // Metodo para obtener los programas de fidelizacion de un cliente
        public List<ProgramasFidelizacion> ObtenerProgramasFidelizacionCliente(string nif)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.ProgramasFidelizacion.Where(p => p.Clientes.Any(c => c.NIF == nif)).ToList();
            }
        }
    }
}
