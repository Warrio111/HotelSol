using HotelSolRepo.Modelo;
using HotelSolRepo.Vista;
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
        //private string rutaArchivoXml = @"E:\backup\Academico\UOC\FP\Tercer Semestre\Técnicas de persistencia de datos con .NET\HotelSolRepo\HotelSolRepo\XMLs\reservas.xml";
        private string rutaArchivoXml = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Vista", "reserva_temporal.xml");
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

       public bool HacerReservaDesdeXml(string xmlReserva, int empleadoID)
{
    try
    {
        // Deserializar XML a la clase ReservaHabitacionesXmlListWrapper
        XmlSerializer serializer = new XmlSerializer(typeof(ReservaHabitacionesListXmlWrapper));
        ReservaHabitacionesListXmlWrapper reservasHabitacionesListWrapper;
        using (StringReader reader = new StringReader(xmlReserva))
        {
            reservasHabitacionesListWrapper = (ReservaHabitacionesListXmlWrapper)serializer.Deserialize(reader);
        }

        using (HotelDBEntities db = new HotelDBEntities())
        {
            // Procesar cada asociación de reserva con habitación
            foreach (var reservaHabitacionXml in reservasHabitacionesListWrapper.ReservaHabitaciones)
            {
                // Aquí, busca o crea la reserva y la habitación correspondiente en la base de datos
                // Nota: Es posible que necesites ajustar esta lógica según tu modelo y reglas de negocio
                Reservas reserva = db.Reservas.Find(reservaHabitacionXml.ReservaID);
                Habitaciones habitacion = db.Habitaciones.Find(reservaHabitacionXml.HabitacionID);

                if (reserva != null && habitacion != null)
                {
                    ReservaHabitaciones nuevaReservaHabitacion = new ReservaHabitaciones
                    {
                        ReservaID = reserva.ReservaID,
                        HabitacionID = habitacion.HabitacionID,
                        TipoPension = reservaHabitacionXml.TipoPension,
                        FechaInicio = reservaHabitacionXml.FechaInicio,
                        FechaFin = reservaHabitacionXml.FechaFin,
                        Precio = reservaHabitacionXml.Precio
                    };

                    db.ReservaHabitaciones.Add(nuevaReservaHabitacion);
                }

                // Confirmar la reserva y guardar los cambios
                if (reserva != null)
                {
                    reserva.EstadoReserva = "Confirmada";
                }
            }

            db.SaveChanges(); // Guardar todos los cambios al final
        }

        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error al deserializar la reserva desde XML: " + ex.Message);
        return false;
    }
}
        /*
        // Generar archivo XML para reserva temporal
        public void GenerarReservaTemporalXml(List<ReservaHabitacionesXmlWrapper> reservasTemporales, int empleadoID)
        {
            try
            {
                foreach (var reservaTemporal in reservasTemporales)
                {
                    foreach (var reserva in reservaTemporal.Reservas)
                    {
                        reserva.EmpleadoID = empleadoID;
                        reserva.FechaCreacion = DateTime.Now;
                    }

                    XmlSerializer serializer = new XmlSerializer(typeof(ReservaHabitacionesXmlWrapper));
                    using (StringWriter writer = new StringWriter())
                    {
                        serializer.Serialize(writer, reservaTemporal);
                        string xmlReservaTemporal = writer.ToString();
                        File.WriteAllText(rutaArchivoXml, xmlReservaTemporal);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la reserva temporal en XML: " + ex.Message);
            }
        }
        */
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
                    reservaExistente.EstadoReserva = reservaActualizada.EstadoReserva;


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
        // Este metodo tiene que convertirse en Check-IN
        public void RegistrarLlegadaCliente(int reservaId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    reserva.CheckInConfirmado = DateTime.Now;
                    db.SaveChanges();
                }
            }
        }
        // Este metodo tiene que convertirse en Check-OUT
        public void RegistrarSalidaCliente(int reservaId)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                Reservas reserva = db.Reservas.Find(reservaId);
                if (reserva != null)
                {
                    reserva.CheckOutConfirmado = DateTime.Now;
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

