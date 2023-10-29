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
				<h1>Detalles de la Reserva</h1>
				<!-- Tabla para información general de la reserva -->
				<table>
					<tr>
						<th>Nombre del Cliente</th>
						<td>
							<xsl:value-of select="Reservas/ClienteNombre"/>
						</td>
					</tr>
					<tr>
						<th>NIF</th>
						<td>
							<xsl:value-of select="Reservas/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Teléfono</th>
						<td>
							<xsl:value-of select="Reservas/Telefono"/>
						</td>
					</tr>
					<tr>
						<th>Correo</th>
						<td>
							<xsl:value-of select="Reservas/Correo"/>
						</td>
					</tr>
					<!-- ... (otros campos) -->
				</table>

				<!-- Tabla para detalles de las habitaciones reservadas -->
				<h2>Habitaciones Reservadas</h2>
				<table>
					<tr>
						<th>ID Habitación</th>
						<th>Tipo</th>
						<th>Tipo de Pensión</th>
						<th>Número de Habitaciones</th>
						<th>Precio Unitario</th>
					</tr>
					<xsl:for-each select="Reservas/Habitaciones/Habitacion">
						<tr>
							<td>
								<xsl:value-of select="HabitacionID"/>
							</td>
							<td>
								<xsl:value-of select="Tipo"/>
							</td>
							<td>
								<xsl:value-of select="TipoPension"/>
							</td>
							<td>
								<xsl:value-of select="NumeroHabitaciones"/>
							</td>
							<td>
								<xsl:value-of select="PrecioUnitario"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>



