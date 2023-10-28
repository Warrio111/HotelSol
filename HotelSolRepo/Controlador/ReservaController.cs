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


        // Comprobación de disponibilidad de habitaciones (implementación simulada)
        public bool ComprobarDisponibilidad(DateTime fechaInicio, DateTime fechaFin, List<int> habitacionesSeleccionadas, List<int> cantidades)
        {
            using (HotelDBEntities db = new HotelDBEntities())
            {
                // Obtener habitaciones ocupadas para el rango de fechas y tipos de habitación seleccionados
                var habitacionesOcupadas = db.Habitaciones.Where(h => habitacionesSeleccionadas.Contains(h.HabitacionID) &&
                    ((h.Ocupado_desde >= fechaInicio && h.Ocupado_desde <= fechaFin) ||
                    (h.Ocupado_hasta >= fechaInicio && h.Ocupado_hasta <= fechaFin) ||
                    (h.Ocupado_desde <= fechaInicio && h.Ocupado_hasta >= fechaFin))
                ).ToList();

                // Agrupar habitaciones ocupadas por su tipo (ID)
                var habitacionesOcupadasAgrupadas = habitacionesOcupadas.GroupBy(h => h.HabitacionID).ToDictionary(g => g.Key, g => g.Count());

                // Verificar si hay suficientes habitaciones de cada tipo disponibles
                for (int i = 0; i < habitacionesSeleccionadas.Count; i++)
                {
                    int tipoHabitacion = habitacionesSeleccionadas[i];
                    int cantidadNecesaria = cantidades[i];

                    // Obtener la cantidad de habitaciones ocupadas de este tipo, si hay alguna
                    int cantidadOcupada = habitacionesOcupadasAgrupadas.ContainsKey(tipoHabitacion) ? habitacionesOcupadasAgrupadas[tipoHabitacion] : 0;

                    // Obtener el total de habitaciones de este tipo en la base de datos
                    int cantidadTotal = db.Habitaciones.Count(h => h.HabitacionID == tipoHabitacion);

                    // Verificar si hay suficientes habitaciones disponibles de este tipo
                    if (cantidadTotal - cantidadOcupada < cantidadNecesaria)
                    {
                        return false;
                    }
                }

                return true;
            }
        }


        // Crear reserva desde datos XML
        public bool HacerReservaDesdeXml(string xmlReserva)
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
                            Estado = nuevaReserva.Estado, // Inicialmente se establece como "Pendiente"
                            FechaCreacion = DateTime.Now
                        };

                        db.Reservas.Add(reserva);

                        // Añadir las habitaciones y las opciones de pensión a la reserva
                        foreach (var habitacion in nuevaReserva.Habitaciones)
                        {
                            ReservaHabitaciones reservaHabitacion = new ReservaHabitaciones
                            {
                                ReservaID = reserva.ReservaID,
                                HabitacionID = habitacion.HabitacionID,
                                TipoPension = habitacion.TipoPension
                            };

                            db.ReservaHabitaciones.Add(reservaHabitacion);
                        }

                        db.SaveChanges();

                        // Cambiar el estado a "Confirmada"
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
        public void GenerarReservaTemporalXml(ReservasXmlWrapper reservaTemporal)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ReservasXmlWrapper));
                using (StringWriter writer = new StringWriter())
                {
                    serializer.Serialize(writer, reservaTemporal);
                    string xmlReservaTemporal = writer.ToString();

                    // Guardar la cadena XML en un archivo temporal
                    File.WriteAllText(rutaArchivoXml, xmlReservaTemporal);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al generar la reserva temporal en XML: " + ex.Message);
            }
        }

        public void ConfirmarReserva()
        {
            if (File.Exists(rutaArchivoXml))
            {
                string xmlReserva = File.ReadAllText(rutaArchivoXml);
                if (HacerReservaDesdeXml(xmlReserva))
                {
                    MessageBox.Show("Reserva confirmada y almacenada en la base de datos.");
                    // Implementar la lógica para eliminar o mover el archivo XML temporal
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

                    // Implemente la lógica para actualizar las habitaciones y las opciones de pensión aquí

                    db.SaveChanges();
                }
            }
        }
    }
}


