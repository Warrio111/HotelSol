<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>
	<xsl:template match="/">
		<html>
			<head>
				<style>
					/* Estilos para la tabla y los elementos del cuerpo */
					body {
					font-family: Arial, sans-serif;
					}
					table {
					width: 100%;
					border-collapse: collapse;
					}
					th, td {
					border: 1px solid #ddd;
					padding: 8px;
					}
					th {
					background-color: #f2f2f2;
					}
				</style>
			</head>
			<body>
				<xsl:for-each select="ClientesListXmlWrapper/Clientes">
					<h1>Detalles del Cliente</h1>
					<!-- Tabla para información general del cliente -->
					<table>
						<tr>
							<th>NIF</th>
							<td>
								<xsl:value-of select="NIF"/>
							</td>
						</tr>
						<tr>
							<th>Nombre</th>
							<td>
								<xsl:value-of select="Nombre"/>
							</td>
						</tr>
						<tr>
							<th>Primer Apellido</th>
							<td>
								<xsl:value-of select="PrimerApellido"/>
							</td>
						</tr>
						<tr>
							<th>Segundo Apellido</th>
							<td>
								<xsl:value-of select="SegundoApellido"/>
							</td>
						</tr>
						<tr>
							<th>Correo Electrónico</th>
							<td>
								<xsl:value-of select="CorreoElectronico"/>
							</td>
						</tr>
						<tr>
							<th>Teléfono</th>
							<td>
								<xsl:value-of select="Telefono"/>
							</td>
						</tr>
					</table>

					<!-- Tabla para detalles de la dirección -->
					<xsl:for-each select="Direcciones/Direccion">
						<h2>Dirección</h2>
						<table>
							<tr>
								<th>Dirección ID</th>
								<td>
									<xsl:value-of select="DireccionID"/>
								</td>
							</tr>
							<tr>
								<th>Calle</th>
								<td>
									<xsl:value-of select="Calle"/>
								</td>
							</tr>
							<tr>
								<th>Número</th>
								<td>
									<xsl:value-of select="Numero"/>
								</td>
							</tr>
							<tr>
								<th>Puerta</th>
								<td>
									<xsl:value-of select="Puerta"/>
								</td>
							</tr>
							<tr>
								<th>Piso</th>
								<td>
									<xsl:value-of select="Piso"/>
								</td>
							</tr>
							<tr>
								<th>Código Postal</th>
								<td>
									<xsl:value-of select="CodigoPostal"/>
								</td>
							</tr>
							<tr>
								<th>Provincia</th>
								<td>
									<xsl:value-of select="Provincia"/>
								</td>
							</tr>
							<tr>
								<th>País</th>
								<td>
									<xsl:value-of select="Pais"/>
								</td>
							</tr>
						</table>
					</xsl:for-each>
					<!-- Tabla para Programa de Fidelización -->
					<xsl:for-each select="ProgramaFidelizacion">
						<h2>Programa de Fidelización</h2>
					
						<table>
							<tr>
								<th>Programa Fidelización ID</th>
								<td>
									<xsl:value-of select="ProgramaFidelizacionID"/>
								</td>
							</tr>
							<tr>
								<th>Nombre</th>
								<td>
									<xsl:value-of select="Nombre"/>
								</td>
							</tr>
							<tr>
								<th>Puntos</th>
								<td>
									<xsl:value-of select="Puntos"/>
								</td>
							</tr>
							<tr>
								<th>Beneficios</th>
								<td>
									<xsl:value-of select="Beneficios"/>
								</td>
							</tr>
						</table>
					</xsl:for-each>
					<!-- Tabla para Reservas -->
					<xsl:for-each select="Reservas/Reserva">
						<h2>Reservas</h2>
					
						<table>
							<tr>
								<th>Reserva ID</th>
								<td>
									<xsl:value-of select="ReservaID"/>
								</td>
							</tr>
							<tr>
								<th>NIF</th>
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
								<th>Fecha Inicio</th>
								<td>
									<xsl:value-of select="FechaInicio"/>
								</td>
							</tr>
							<tr>
								<th>Fecha Fin</th>
								<td>
									<xsl:value-of select="FechaFin"/>
								</td>
							</tr>
							<tr>
								<th>Estado Reserva</th>
								<td>
									<xsl:value-of select="EstadoReserva"/>
								</td>
							</tr>
							<tr>
								<th>CheckIn Confirmado</th>
								<td>
									<xsl:value-of select="CheckInConfirmado"/>
								</td>
							</tr>
							<tr>
								<th>CheckOut Confirmado</th>
								<td>
									<xsl:value-of select="CheckOutConfirmado"/>
								</td>
							</tr>
							<tr>
								<th>Factura ID</th>
								<td>
									<xsl:value-of select="FacturaID"/>
								</td>
							</tr>
							<tr>
								<th>Fecha Creación</th>
								<td>
									<xsl:value-of select="FechaCreacion"/>
								</td>
							</tr>
							<tr>
								<th>Tipo Reserva</th>
								<td>
									<xsl:value-of select="TipoReserva"/>
								</td>
							</tr>
						</table>
					</xsl:for-each>
					<!-- Tabla para Facturas -->
					<xsl:for-each select="Facturas/Factura">
						<h2>Facturas</h2>
					
						<table>
							<tr>
								<th>Factura ID</th>
								<td>
									<xsl:value-of select="FacturaID"/>
								</td>
							</tr>
							<tr>
								<th>NIF</th>
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
					</xsl:for-each>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
