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
					<h2>Dirección</h2>
					<xsl:for-each select="Direcciones/Direccion">
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
				</xsl:for-each>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
