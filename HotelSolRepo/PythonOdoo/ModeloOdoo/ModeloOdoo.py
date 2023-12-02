# ModeloOdoo.py

from odoo import models, fields, api

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
