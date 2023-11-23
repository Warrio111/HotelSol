using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelSolRepo.Controlador
{
    public class HabitacionController
    {

        public List<Habitaciones> ObtenerHabitaciones()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.ToList();
            }
        }
        public Habitaciones ObtenerDetallesHabitacion(int id)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.FirstOrDefault(h => h.HabitacionID == id);
            }
        } 
        public List<Habitaciones> ObtenerHabitacionesDisponibles()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.EstadoActual == "Disponible").ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesOcupadas()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.EstadoActual == "Ocupada").ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesEnMantenimiento()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.EstadoActual == "Mantenimiento").ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesPorTipo(string tipo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.Tipo == tipo).ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesPorTipoDisponibles(string tipo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.Tipo == tipo && h.EstadoActual == "Disponible").ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesPorTipoOcupadas(string tipo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.Tipo == tipo && h.EstadoActual == "Ocupada").ToList();
            }
        }
        public List<Habitaciones> ObtenerHabitacionesPorTipoEnMantenimiento(string tipo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.Tipo == tipo && h.EstadoActual == "Mantenimiento").ToList();
            }
        }
        public Habitaciones ObtenerHabitacionPorID(int id)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.FirstOrDefault(h => h.HabitacionID == id);
            }
        }
        public Habitaciones ObtenerHabitacionPorCodigo(string codigo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.FirstOrDefault(h => h.CodigoHabitacion == codigo);
            }
        }
        public bool CrearHabitacion(Habitaciones habitacion)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.CodigoHabitacion == habitacion.CodigoHabitacion);
                if (habitacionExistente == null)
                {
                    db.Habitaciones.Add(habitacion);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool EditarHabitacion(Habitaciones habitacion)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.HabitacionID == habitacion.HabitacionID);
                if (habitacionExistente != null)
                {
                    habitacionExistente.Tipo = habitacion.Tipo;
                    habitacionExistente.Caracteristicas = habitacion.Caracteristicas;
                    habitacionExistente.Tarifa = habitacion.Tarifa;
                    habitacionExistente.EstadoActual = habitacion.EstadoActual;
                    habitacionExistente.Ocupado_desde = habitacion.Ocupado_desde;
                    habitacionExistente.Ocupado_hasta = habitacion.Ocupado_hasta;
                    habitacionExistente.CodigoHabitacion = habitacion.CodigoHabitacion;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool EliminarHabitacion(int id)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.HabitacionID == id);
                if (habitacionExistente != null)
                {
                    db.Habitaciones.Remove(habitacionExistente);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CambiarEstadoHabitacion(int id, string estado, DateTime? fechaInicio, DateTime? fechaFin)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.HabitacionID == id);
                if (habitacionExistente != null)
                {
                    habitacionExistente.EstadoActual = estado;
                    habitacionExistente.Ocupado_desde = fechaInicio;
                    habitacionExistente.Ocupado_hasta = fechaFin;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CambiarEstadoHabitacion(string codigo, string estado)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.CodigoHabitacion == codigo);
                if (habitacionExistente != null)
                {
                    habitacionExistente.EstadoActual = estado;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CambiarEstadoHabitacion(int id, string estado, DateTime desde, DateTime hasta)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.HabitacionID == id);
                if (habitacionExistente != null)
                {
                    habitacionExistente.EstadoActual = estado;
                    habitacionExistente.Ocupado_desde = desde;
                    habitacionExistente.Ocupado_hasta = hasta;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CambiarEstadoHabitacion(string codigo, string estado, DateTime desde, DateTime hasta)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.CodigoHabitacion == codigo);
                if (habitacionExistente != null)
                {
                    habitacionExistente.EstadoActual = estado;
                    habitacionExistente.Ocupado_desde = desde;
                    habitacionExistente.Ocupado_hasta = hasta;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
        public bool CambiarEstadoHabitacion(int habitacionID,string estadoActual)
        {             
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionExistente = db.Habitaciones.FirstOrDefault(h => h.HabitacionID == habitacionID);
                if (habitacionExistente != null)
                {
                    habitacionExistente.EstadoActual = estadoActual;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public Habitaciones ObtenerUltimaHabitacion()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.OrderByDescending(h => h.HabitacionID).FirstOrDefault();
            }
        }

        // Metodo para Obtener la primera habitacion disponible de un tipo especifico
        public Habitaciones ObtenerPrimeraHabitacionDisponible(string tipo)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Habitaciones.Where(h => h.Tipo == tipo && h.EstadoActual == "Disponible").FirstOrDefault();
            }
        }
        // Metodo que resetea de estadoActual de todas las habitaciones que estan en Temporal a Disponible
        public void ResetearHabitacionesTemporales()
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var habitacionesTemporales = db.Habitaciones.Where(h => h.EstadoActual == "Temporal").ToList();
                foreach (var habitacion in habitacionesTemporales)
                {
                    habitacion.EstadoActual = "Disponible";
                    db.SaveChanges();
                }
            }
        }
        // Metodo que devuelve la habitacion gracias a la entrada de el ID de la reserva y lo hace buscando en ReservaHabitaciones
        public Habitaciones ObtenerHabitacionPorReservaID(int reservaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var reservaHabitacion = db.ReservaHabitaciones.FirstOrDefault(r => r.ReservaID == reservaID);
                if (reservaHabitacion != null)
                {
                    return db.Habitaciones.Where(h => h.HabitacionID == reservaHabitacion.HabitacionID).FirstOrDefault();
                }
                return null;
            }
        }
    }
}
