<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html"/>
	<xsl:template match="/">
		<html>
			<head>
				<style>
					body {
					font-family: Arial, sans-serif;
					}
					h1, h2 {
					color: #333366;
					}
					table {
					border-collapse: collapse;
					margin-bottom: 20px;
					}
					th, td {
					border: 1px solid #ccc;
					padding: 8px;
					text-align: left;
					}
					th {
					background-color: #f2f2f2;
					}
				</style>
			</head>
			<body>
				<h1>Reserva</h1>
				<table>
					<tr>
						<th>NIF</th>
						<td>
							<xsl:value-of select="Reservas/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Inicio</th>
						<td>
							<xsl:value-of select="Reservas/FechaInicio"/>
						</td>
					</tr>
					<tr>
						<th>Fecha Fin</th>
						<td>
							<xsl:value-of select="Reservas/FechaFin"/>
						</td>
					</tr>
					<tr>
						<th>Estado</th>
						<td>
							<xsl:value-of select="Reservas/Estado"/>
						</td>
					</tr>
				</table>
				<h2>Habitaciones</h2>
				<table>
					<tr>
						<th>ID Habitacion</th>
						<th>Tipo Pension</th>
						<th>Numero Habitaciones</th>
					</tr>
					<xsl:for-each select="Reservas/Habitaciones/Habitacion">
						<tr>
							<td>
								<xsl:value-of select="HabitacionID"/>
							</td>
							<td>
								<xsl:value-of select="TipoPension"/>
							</td>
							<td>
								<xsl:value-of select="NumeroHabitaciones"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>

