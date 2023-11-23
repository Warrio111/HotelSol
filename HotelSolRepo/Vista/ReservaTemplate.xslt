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

				
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>




