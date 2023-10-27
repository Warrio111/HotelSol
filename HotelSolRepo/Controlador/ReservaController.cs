using HotelSolRepo.Modelo;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace HotelSolRepo.Controlador
{
    public class ReservaController
    {
        private string rutaArchivoXml = @"ruta\al\archivo\reservas.xml";

        // Método para comprobar disponibilidad de habitaciones
        public bool ComprobarDisponibilidad(DateTime fechaInicio, DateTime fechaFin)
        {
            // Implementar lógica para comprobar disponibilidad en la base de datos
            using (HotelDBEntities db = new HotelDBEntities())
            {
                // Consulta la base de datos para verificar la disponibilidad de habitaciones
                // Implementa tu lógica aquí
                return true; // Devuelve true si hay disponibilidad, de lo contrario false
            }
        }

        // Método para hacer una nueva reserva desde datos XML
        public bool HacerReservaDesdeXml(string xmlReserva)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ReservasXmlWrapper)); // Usar la clase wrapper de Reservas
                using (StringReader reader = new StringReader(xmlReserva))
                {
                    ReservasXmlWrapper nuevaReserva = (ReservasXmlWrapper)serializer.Deserialize(reader);

                    using (HotelDBEntities db = new HotelDBEntities())
                    {
                        // Añade la nueva reserva a la base de datos
                        Reservas reserva = new Reservas
                        {
                            NIF = nuevaReserva.NIF,
                            HabitacionID = nuevaReserva.HabitacionID,
                            FechaInicio = nuevaReserva.FechaInicio,
                            FechaFin = nuevaReserva.FechaFin,
                            OpcionesPension = nuevaReserva.OpcionesPension,
                            Estado = nuevaReserva.Estado,
                            FechaCreacion = DateTime.Now, // Puedes establecer la fecha de creación actual
                            TipoReserva = nuevaReserva.TipoReserva
                        };

                        db.Reservas.Add(reserva);
                        db.SaveChanges();
                    }

                    return true; // La reserva se realizó con éxito
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones si la deserialización falla
                Console.WriteLine("Error al deserializar la reserva desde XML: " + ex.Message);
                return false; // La reserva no se pudo realizar
            }
        }


        // Método para actualizar información de una reserva en la base de datos
        public void ActualizarReserva(Reservas reservaActualizada)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var reservaExistente = db.Reservas.FirstOrDefault(r => r.ReservaID == reservaActualizada.ReservaID);
                if (reservaExistente != null)
                {
                    reservaExistente.FechaInicio = reservaActualizada.FechaInicio;
                    reservaExistente.FechaFin = reservaActualizada.FechaFin;
                    reservaExistente.OpcionesPension = reservaActualizada.OpcionesPension;
                    reservaExistente.Estado = reservaActualizada.Estado;
                    // Actualiza otros campos aquí
                    db.SaveChanges();
                }
            }
        }
    }
}
