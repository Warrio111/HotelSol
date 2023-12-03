# ModeloOdoo.py
from odoo import models, fields, api
import xml.etree.ElementTree as ET
class Factura(models.Model):
    _name = 'modulo.infraninjasfactura'
    _description = 'Modelo para Facturas'

    FacturaID = fields.Integer(string='ID de Factura')
    NIF = fields.Char(string='NIF')
    EmpleadoID = fields.Integer(string='ID de Empleado')
    Detalles = fields.Char(string='Detalles')
    Cargos = fields.Float(string='Cargos')
    Impuestos = fields.Float(string='Impuestos')
    Fecha = fields.Date(string='Fecha')
    FechaCreacion = fields.Datetime(string='Fecha de Creación')
    TipoFactura = fields.Char(string='Tipo de Factura')

    # Relación con Reservas
    reservas_ids = fields.One2many('modulo.infraninjasreserva', 'factura_id', string='Reservas')
    # Relación con Cliente
    cliente_id = fields.Many2one('modulo.infraninjascliente', string='Cliente')

class Reserva(models.Model):
    _name = 'modulo.infraninjasreserva'
    _description = 'Modelo para Reservas'

    ReservaID = fields.Integer(string='ID de Reserva')
    NIF = fields.Char(string='NIF')
    EmpleadoID = fields.Integer(string='ID de Empleado')
    FechaInicio = fields.Date(string='Fecha de Inicio')
    FechaFin = fields.Date(string='Fecha de Fin')
    EstadoReserva = fields.Selection([('libre', 'Libre'), ('ocupada', 'Ocupada')], string='Estado de Reserva')
    CheckInConfirmado = fields.Boolean(string='Check-In Confirmado')
    CheckOutConfirmado = fields.Boolean(string='Check-Out Confirmado')
    FacturaID = fields.Integer(string='ID de Factura')
    FechaCreacion = fields.Datetime(string='Fecha de Creación')
    TipoReserva = fields.Char(string='Tipo de Reserva')

    # Relación con Factura
    factura_id = fields.Many2one('modulo.infraninjasfactura', string='Factura')

class Cliente(models.Model):
    _name = 'modulo.infraninjascliente'
    _description = 'Modelo para Clientes'

    NIF = fields.Char(string='NIF', required=True)
    Nombre = fields.Char(string='Nombre')
    PrimerApellido = fields.Char(string='Primer Apellido')
    SegundoApellido = fields.Char(string='Segundo Apellido')
    DireccionID = fields.Integer(string='ID de Dirección')
    CorreoElectronico = fields.Char(string='Correo Electrónico')
    Telefono = fields.Char(string='Teléfono')
    ProgramaFidelizacionID = fields.Integer(string='ID de Programa de Fidelización')
    Contraseña = fields.Char(string='Contraseña')

    # Relación con Direcciones
    direcciones_ids = fields.One2many('modulo.infraninjasdireccion', 'cliente_id', string='Direcciones')

class Direccion(models.Model):
    _name = 'modulo.infraninjasdireccion'
    _description = 'Modelo para Direcciones'

    DireccionID = fields.Integer(string='ID de Dirección')
    Calle = fields.Char(string='Calle')
    Numero = fields.Char(string='Número')
    Puerta = fields.Char(string='Puerta')
    Piso = fields.Char(string='Piso')
    CodigoPostal = fields.Char(string='Código Postal')
    Provincia = fields.Char(string='Provincia')
    Pais = fields.Char(string='País')

    # Relación con Cliente
    cliente_id = fields.Many2one('modulo.infraninjascliente', string='Cliente')
    # Crear vistas

class ModuloInfraninjasViews(models.Model):
    _name = 'modulo.infraninjas.views'

    @api.model
    def create_views(self):
        # Vista de lista de Facturas
        self.env['ir.ui.view'].create({
            'name': 'factura.tree',
            'model': 'modulo.infraninjasfactura',
            'arch': """
                <tree>
                    <field name="FacturaID"/>
                    <field name="NIF"/>
                    <field name="EmpleadoID"/>
                    <field name="Detalles"/>
                    <field name="Cargos"/>
                    <field name="Impuestos"/>
                    <field name="Fecha"/>
                    <field name="FechaCreacion"/>
                    <field name="TipoFactura"/>
                    <field name="reservas_ids" widget="many2many_tags" options="{'no_create': True}" />
                    <field name="cliente_id"/>
                </tree>
            """
        })

        # Vista de formulario de Facturas
        self.env['ir.ui.view'].create({
            'name': 'factura.form',
            'model': 'modulo.infraninjasfactura',
            'arch': """
                <form>
                    <group>
                        <field name="FacturaID"/>
                        <field name="NIF"/>
                        <field name="EmpleadoID"/>
                        <field name="Detalles"/>
                        <field name="Cargos"/>
                        <field name="Impuestos"/>
                        <field name="Fecha"/>
                        <field name="FechaCreacion"/>
                        <field name="TipoFactura"/>
                        <field name="reservas_ids" widget="many2many_tags" options="{'no_create': True}" />
                        <field name="cliente_id"/>
                    </group>
                </form>
            """
        })

def leer_xml(path):
    # Parsear el archivo XML
    tree = ET.parse(path, encoding='utf-8')
    root = tree.getroot()

    # Generar el string con todo el documento
    xml_string = ET.tostring(root, encoding='utf-8', errors='ignore').decode('utf-8')
    return xml_string

def create_invoice_from_xml(odoo,path):
        # Obtener el string del XML
        xml_data = leer_xml(path)
        print('Este es el XML Data',xml_data)
        # Parsear el XML
        root = ET.fromstring(xml_data)

        # Obtener datos de la dirección del cliente
        direccion_data = {
            'Calle': root.find('Clientes/Cliente/Direcciones/Direccion/Calle').text,
            'Numero': root.find('Clientes/Cliente/Direcciones/Direccion/Numero').text,
            'Puerta': root.find('Clientes/Cliente/Direcciones/Direccion/Puerta').text,
            'Piso': root.find('Clientes/Cliente/Direcciones/Direccion/Piso').text,
            'CodigoPostal': root.find('Clientes/Cliente/Direcciones/Direccion/CodigoPostal').text,
            'Provincia': root.find('Clientes/Cliente/Direcciones/Direccion/Provincia').text,
            'Pais': root.find('Clientes/Cliente/Direcciones/Direccion/Pais').text,
        }

        # Crear la dirección en Odoo
        direccion_id = odoo.create('modulo.infraninjasdireccion', direccion_data)

        # Obtener datos del cliente
        cliente_data = {
            'NIF': root.find('Clientes/Cliente/NIF').text,
            'Nombre': root.find('Clientes/Cliente/Nombre').text,
            'PrimerApellido': root.find('Clientes/Cliente/PrimerApellido').text,
            'SegundoApellido': root.find('Clientes/Cliente/SegundoApellido').text,
            'CorreoElectronico': root.find('Clientes/Cliente/CorreoElectronico').text,
            'Telefono': root.find('Clientes/Cliente/Telefono').text,
            'DireccionID': direccion_id,
        }

        # Crear el cliente en Odoo
        cliente_id = odoo.create('modulo.infraninjascliente', cliente_data)

        # Obtener datos de la reserva
        reserva_data = {
            'ReservaID': int(root.find('Reservas/Reserva/ReservaID').text),
            'NIF': root.find('Reservas/Reserva/NIF').text,
            'EmpleadoID': int(root.find('Reservas/Reserva/EmpleadoID').text),
            'FechaInicio': root.find('Reservas/Reserva/FechaInicio').text,
            'FechaFin': root.find('Reservas/Reserva/FechaFin').text,
            'EstadoReserva': root.find('Reservas/Reserva/EstadoReserva').text,
            'CheckInConfirmado': root.find('Reservas/Reserva/CheckInConfirmado').text,
            'CheckOutConfirmado': root.find('Reservas/Reserva/CheckOutConfirmado').text,
            'FacturaID': int(root.find('Reservas/Reserva/FacturaID').text),
            'FechaCreacion': root.find('Reservas/Reserva/FechaCreacion').text,
            'TipoReserva': root.find('Reservas/Reserva/TipoReserva').text,
        }

        # Crear la reserva en Odoo y vincularla a la factura
        reserva_id = odoo.create('modulo.infraninjasreserva', reserva_data)

        # Obtener datos de la factura
        factura_data = {
            'FacturaID': int(root.find('FacturaID').text),
            'NIF': root.find('NIF').text,
            'EmpleadoID': int(root.find('EmpleadoID').text),
            'Detalles': root.find('Detalles').text,
            'Cargos': float(root.find('Cargos').text),
            'Impuestos': float(root.find('Impuestos').text),
            'Fecha': root.find('Fecha').text,
            'FechaCreacion': root.find('FechaCreacion').text,
            'TipoFactura': root.find('TipoFactura').text,
            'Cliente': cliente_id,
            'Reservas': [(4, reserva_id)],
        }

        # Crear la factura en Odoo y vincularla al cliente y la reserva
        factura_id = odoo.create('modulo.infraninjasfactura', factura_data)
        print('Factura creada con ID', factura_id)