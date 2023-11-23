<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>

	<xsl:template match="/FacturasXmlWrapper">
		<html>
			<head>
				<style>
					/* Estilos para la factura */
					body {
					font-family: Arial, sans-serif;
					}
					table {
					width: 100%;
					border-collapse: collapse;
					margin-bottom: 20px;
					}
					th, td {
					border: 1px solid #ddd;
					padding: 8px;
					text-align: left;
					}
					th {
					background-color: #f2f2f2;
					}
					h1, h2 {
					color: #333;
					}
				</style>
			</head>
			<body>
				<h1>Factura Hotel</h1>
				<table>
					<tr>
						<th>Factura ID</th>
						<td>
							<xsl:value-of select="FacturaID"/>
						</td>
					</tr>
					<tr>
						<th>NIF Cliente</th>
						<td>
							<xsl:value-of select="NIF"/>
						</td>
					</tr>
					<tr>
						<th>Empleado ID</th>
						<td>
							<xsl:value-of select="EmpleadoID"/>
						</td>
					</tr>
					<tr>
						<th>Detalles</th>
						<td>
							<xsl:value-of select="Detalles"/>
						</td>
					</tr>
					<tr>
						<th>Cargos</th>
						<td>
							<xsl:value-of select="Cargos"/>
						</td>
					</tr>
					<tr>
						<th>Impuestos</th>
						<td>
							<xsl:value-of select="Impuestos"/>
						</td>
					</tr>
					<tr>
						<th>Fecha</th>
						<td>
							<xsl:value-of select="Fecha"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Creación</th>
						<td>
							<xsl:value-of select="FechaCreacion"/>
						</td>
					</tr>
					<tr>
						<th>Tipo Factura</th>
						<td>
							<xsl:value-of select="TipoFactura"/>
						</td>
					</tr>
				</table>

				<h2>Reserva</h2>
				<table>
					<tr>
						<th>Reserva ID</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/ReservaID"/>
						</td>
					</tr>
					<tr>
						<th>NIF Cliente</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Empleado ID</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/EmpleadoID"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Inicio</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/FechaInicio"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Fin</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/FechaFin"/>
						</td>
					</tr>
					<tr>
						<th>Estado Reserva</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/EstadoReserva"/>
						</td>
					</tr>
					<tr>
						<th>CheckIn Confirmado</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/CheckInConfirmado"/>
						</td>
					</tr>
					<tr>
						<th>CheckOut Confirmado</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/CheckOutConfirmado"/>
						</td>
					</tr>
					<tr>
						<th>Factura ID</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/FacturaID"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Creación</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/FechaCreacion"/>
						</td>
					</tr>
					<tr>
						<th>Tipo Reserva</th>
						<td>
							<xsl:value-of select="Reservas/Reserva/TipoReserva"/>
						</td>
					</tr>
				</table>

				<h2>Cliente</h2>
				<table>
					<tr>
						<th>NIF</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Nombre</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/Nombre"/>
						</td>
					</tr>
					<tr>
						<th>Primer Apellido</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/PrimerApellido"/>
						</td>
					</tr>
					<tr>
						<th>Segundo Apellido</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/SegundoApellido"/>
						</td>
					</tr>
					<tr>
						<th>Correo Electrónico</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/CorreoElectronico"/>
						</td>
					</tr>
					<tr>
						<th>Teléfono</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/Telefono"/>
						</td>
					</tr>

					<tr>
						<th>Dirección</th>
						<td>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Calle"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Numero"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Puerta"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Piso"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/CodigoPostal"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Provincia"/>
							<xsl:text>, </xsl:text>
							<xsl:value-of select="Clientes/Cliente/Direcciones/Direccion/Pais"/>
						</td>
					</tr>

				</table>

			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
