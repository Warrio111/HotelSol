<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>
	<xsl:template match="/">
		<html>
			<head>
				<style>
					body { font-family: Arial, sans-serif; }
					table { width: 100%; border-collapse: collapse; }
					th, td { border: 1px solid #ddd; padding: 8px; }
					th { background-color: #f2f2f2; }
				</style>
			</head>
			<body>
				<h1>Detalles de la Reserva</h1>
				<!-- Tabla para información general del cliente -->
				<table>
					<tr>
						<th>Nombre del Cliente</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Cliente/Nombre"/>
						</td>
					</tr>
					<tr>
						<th>NIF</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Cliente/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Teléfono</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Cliente/Telefono"/>
						</td>
					</tr>
					<tr>
						<th>Correo Electrónico</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Cliente/CorreoElectronico"/>
						</td>
					</tr>
					<!-- Detalles de la dirección -->
					<tr>
						<th>Calle</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Calle"/>
						</td>
					</tr>
					<tr>
						<th>Número</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Numero"/>
						</td>
					</tr>
					<tr>
						<th>Puerta</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Puerta"/>
						</td>
					</tr>
					<tr>
						<th>Piso</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Piso"/>
						</td>
					</tr>
					<tr>
						<th>Código Postal</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/CodigoPostal"/>
						</td>
					</tr>
					<tr>
						<th>Provincia</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Provincia"/>
						</td>
					</tr>
					<tr>
						<th>País</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Direccion/Pais"/>
						</td>
					</tr>
				</table>

				<!-- Tabla para detalles de las habitaciones reservadas -->
				<h2>Habitaciones Reservadas</h2>
				<table>
					<tr>
						<th>ID Habitación</th>
						<th>Tipo de Pensión</th>
						<th>Fecha Inicio</th>
						<th>Fecha Fin</th>
					
					</tr>
					<xsl:for-each select="ReservaCompletaXmlWrapper/ReservaHabitaciones/ReservaHabitacionesXmlWrapper">
						<tr>
							<td>
								<xsl:value-of select="HabitacionID"/>
							</td>
							<td>
								<xsl:value-of select="TipoPension"/>
							</td>
							<td>
								<xsl:value-of select="FechaInicio"/>
							</td>
							<td>
								<xsl:value-of select="FechaFin"/>
							</td>
						
							
						</tr>
					</xsl:for-each>
				</table>
				<!-- Tabla para detalles de la factura -->
				<h2>Detalles de la Factura</h2>
				<table>
					<tr>
						<th>ID de Factura</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Factura/FacturaID"/>
						</td>
					</tr>
					<tr>
						<th>Detalles</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Factura/Detalles"/>
						</td>
					</tr>
					<tr>
						<th>Cargos</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Factura/Cargos"/>
						</td>
					</tr>
					<tr>
						<th>Impuestos</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Factura/Impuestos"/>
						</td>
					</tr>
					<tr>
						<th>Fecha</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Factura/Fecha"/>
						</td>
					</tr>
				</table>

				<h2>Reserva</h2>
				<table>
					<tr>
						<th>Reserva ID</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/ReservaID"/>
						</td>
					</tr>
					<tr>
						<th>NIF Cliente</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Empleado ID</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/EmpleadoID"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Inicio</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/FechaInicio"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Fin</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/FechaFin"/>
						</td>
					</tr>
					<tr>
						<th>Estado Reserva</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/EstadoReserva"/>
						</td>
					</tr>
					<tr>
						<th>CheckIn Confirmado</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/CheckInConfirmado"/>
						</td>
					</tr>
					<tr>
						<th>CheckOut Confirmado</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/CheckOutConfirmado"/>
						</td>
					</tr>
					<tr>
						<th>Factura ID</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/FacturaID"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Creación</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/FechaCreacion"/>
						</td>
					</tr>
					<tr>
						<th>Tipo Reserva</th>
						<td>
							<xsl:value-of select="ReservaCompletaXmlWrapper/Reserva/TipoReserva"/>
						</td>
					</tr>
				</table>
				
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>




