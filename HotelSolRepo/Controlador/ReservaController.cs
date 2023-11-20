using HotelSolRepo.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HotelSolRepo.Controlador
{
    public class ReservaController
    {
        private string rutaArchivoXml = @"E:\backup\Academico\UOC\FP\Tercer Semestre\Técnicas de persistencia de datos con .NET\HotelSolRepo\HotelSolRepo\XMLs\reservas.xml";
        private Reservas reserva;


        // Comprobación de disponibilidad de habitaciones 
        public bool ComprobarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, List<int> tiposHabitacionesSeleccionadas, List<int> cantidades)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                for (int i = 0; i < tiposHabitacionesSeleccionadas.Count; i++)
                {
                    int tipoHabitacionSeleccionada = tiposHabitacionesSeleccionadas[i];
                    string tipoHabitacion = null;

                    // Convertir el valor numérico a la cadena correspondiente del tipo de habitación
                    switch (tipoHabitacionSeleccionada)
                    {
                        case 1:
                            tipoHabitacion = "Sencilla";
                            break;
                        case 2:
                            tipoHabitacion = "Doble";
                            break;
                        case 3:
                            tipoHabitacion = "Suite";
                            break;
                        default:
                            return false; // Tipo de habitación no reconocido
                    }

                    int cantidadNecesaria = cantidades[i];

                    // Obtener el total de habitaciones de este tipo en la base de datos
                    int cantidadTotal = db.Habitaciones.Count(h => h.Tipo == tipoHabitacion);

                    // Obtener habitaciones ocupadas para el rango de fechas y tipos de habitación seleccionados
                    int habitacionesOcupadas = db.Habitaciones.Count(h => h.Tipo == tipoHabitacion &&
                        ((h.Ocupado_desde >= fechaInicio && h.Ocupado_desde <= fechaFin) ||
                        (h.Ocupado_hasta >= fechaInicio && h.Ocupado_hasta <= fechaFin) ||
                        (h.Ocupado_desde <= fechaInicio && h.Ocupado_hasta >= fechaFin))
                    );

                    // Verificar si hay suficientes habitaciones disponibles de este tipo
                    if (cantidadTotal - habitacionesOcupadas < cantidadNecesaria)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        // Crear reserva desde datos XML
        public bool HacerReservaDesdeXml(string xmlReserva, int empleadoID)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ReservasXmlWrapper));
                using (StringReader reader = new StringReader(xmlReserva))
                {
                    ReservasXmlWrapper nuevaReserva = (ReservasXmlWrapper)serializer.Deserialize(reader);
                    using (HotelDBEntities db = new HotelDBEntities())
                    {
                        Reservas reserva = new Reservas
                        {
                            NIF = nuevaReserva.NIF,
                            FechaInicio = nuevaReserva.FechaInicio,
                            FechaFin = nuevaReserva.FechaFin,
                            Estado = nuevaReserva.EstadoReserva,
                            FechaCreacion = nuevaReserva.FechaCreacion,  // Utilizar la fecha de creación deserializada
                            EmpleadoID = empleadoID  // Utilizar el ID del empleado proporcionado
                        };

                        db.Reservas.Add(reserva);
                        db.SaveChanges();

                        foreach (var habitacion in nuevaReserva.Habitaciones)
                        {
                            ReservaHabitaciones reservaHabitacion = new ReservaHabitaciones
                            {
                                ReservaID = reserva.ReservaID,
                                HabitacionID = habitacion.HabitacionID,
                                TipoPension = habitacion.Tipo
                            };

                            db.ReservaHabitaciones.Add(reservaHabitacion);
                        }

                        db.SaveChanges();

                        reserva.Estado = "Confirmada";
                        db.SaveChanges();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al deserializar la reserva desde XML: " + ex.Message);
                return false;
            }
        }

        // Generar archivo XML para reserva temporal
        public void GenerarReservaTemporalXml(ReservasXmlWrapper reservaTemporal, int empleadoID)
        {
            reservaTemporal.EmpleadoID = empleadoID;
            reservaTemporal.FechaCreacion = DateTime.Now;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ReservasXmlWrapper));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, reservaTemporal);
                    string xmlReservaTemporal = writer.ToString();
                    File.WriteAllText(rutaArchivoXml, xmlReservaTemporal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la reserva temporal en XML: " + ex.Message);
            }
        }

        public void ConfirmarReserva(int empleadoID)
        {
            if (File.Exists(rutaArchivoXml))
            {
                string xmlReserva = File.ReadAllText(rutaArchivoXml);
                if (HacerReservaDesdeXml(xmlReserva, empleadoID))
                {
                    MessageBox.Show("Reserva confirmada y almacenada en la base de datos.");
                }
                else
                {
                    MessageBox.Show("Error al confirmar la reserva.");
                }
            }
        }

        // Actualizar reserva existente
        public void ActualizarReserva(Reservas reservaActualizada)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                var reservaExistente = db.Reservas.FirstOrDefault(r => r.ReservaID == reservaActualizada.ReservaID);
                if (reservaExistente != null)
                {
                    reservaExistente.FechaInicio = reservaActualizada.FechaInicio;
                    reservaExistente.FechaFin = reservaActualizada.FechaFin;
                    reservaExistente.Estado = reservaActualizada.Estado;


                    db.SaveChanges();
                }
            }
        }

        public void ModificarReserva(int reservaId, DateTime nuevaFechaLlegada, DateTime nuevaFechaSalida)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    reserva.FechaInicio = nuevaFechaLlegada;
                    reserva.FechaFin = nuevaFechaSalida;
                    db.SaveChanges();
                }
            }
        }

        public void CancelarReserva(int reservaId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    db.Reservas.Remove(reserva);
                    db.SaveChanges();
                }
            }
        }

        public void RegistrarLlegadaCliente(int reservaId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    reserva.FechaInicio = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public void RegistrarSalidaCliente(int reservaId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    reserva.FechaFin = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }

        public List<Reservas> GetReservas()
        {
               using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Reservas.ToList();
            }
        }

        // Obtener una reserva específica por ID
        public Reservas ObtenerReservaPorID(int reservaID)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                return db.Reservas.FirstOrDefault(r => r.ReservaID == reservaID);
            }
        }

    }
}

