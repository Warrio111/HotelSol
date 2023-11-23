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
				<h1>Detalles del Cliente</h1>
				<!-- Tabla para información general del cliente -->
				<table>
					<tr>
						<th>NIF</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/NIF"/>
						</td>
					</tr>
					<tr>
						<th>Nombre</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Nombre"/>
						</td>
					</tr>
					<tr>
						<th>Primer Apellido</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/PrimerApellido"/>
						</td>
					</tr>
					<tr>
						<th>Segundo Apellido</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/SegundoApellido"/>
						</td>
					</tr>
					<tr>
						<th>Correo Electrónico</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/CorreoElectronico"/>
						</td>
					</tr>
					<tr>
						<th>Teléfono</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Telefono"/>
						</td>
					</tr>
				</table>

				<!-- Tabla para detalles de la dirección -->
				<h2>Dirección</h2>
				<table>
					<tr>
						<th>Dirección ID</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/DireccionID"/>
						</td>
					</tr>
					<tr>
						<th>Calle</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Calle"/>
						</td>
					</tr>
					<tr>
						<th>Número</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Numero"/>
						</td>
					</tr>
					<tr>
						<th>Puerta</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Puerta"/>
						</td>
					</tr>
					<tr>
						<th>Piso</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Piso"/>
						</td>
					</tr>
					<tr>
						<th>Código Postal</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/CodigoPostal"/>
						</td>
					</tr>
					<tr>
						<th>Provincia</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Provincia"/>
						</td>
					</tr>
					<tr>
						<th>País</th>
						<td>
							<xsl:value-of select="ClientesXmlWrapper/Direcciones/Direccion/Pais"/>
						</td>
					</tr>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>
