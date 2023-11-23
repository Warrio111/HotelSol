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
				<xsl:for-each select="ReservasListXmlWrapper/Reserva ">
					<h1>Detalles del Estancia del Cliente</h1>
					<!-- Tabla para información general del cliente -->
					<table>
						<tr>
							<th>ReservaID</th>
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
							<th>EmpleadoID</th>
							<td>
								<xsl:value-of select="EmpleadoID"/>
							</td>
						</tr>
						<tr>
							<th>FechaInicio</th>
							<td>
								<xsl:value-of select="FechaInicio"/>
							</td>
						</tr>
						<tr>
							<th>FechaFin</th>
							<td>
								<xsl:value-of select="FechaFin"/>
							</td>
						</tr>
						<tr>
							<th>EstadoReserva</th>
							<td>
								<xsl:value-of select="EstadoReserva"/>
							</td>
						</tr>
						<tr>
							<th>CheckInConfirmado</th>
							<td>
								<xsl:value-of select="CheckInConfirmado"/>
							</td>
						</tr>
						<tr>
							<th>CheckOutConfirmado</th>
							<td>
								<xsl:value-of select="CheckOutConfirmado"/>
							</td>
						</tr>
						<tr>
							<th>FacturaID</th>
							<td>
								<xsl:value-of select="FacturaID"/>
							</td>
						</tr>
						<tr>
							<th>FechaCreacion</th>
							<td>
								<xsl:value-of select="FechaCreacion"/>
							</td>
						</tr>
						<tr>
							<th>TipoReserva</th>
							<td>
								<xsl:value-of select="TipoReserva"/>
							</td>
						</tr>
					</table>
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
