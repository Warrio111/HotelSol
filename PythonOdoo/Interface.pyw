# -*- coding: iso-8859-1 -*-
import tkinter as tk
from tkinter import ttk
from tkinter import filedialog, messagebox
import xml.etree.ElementTree as ET
from XmlRead import leer_xml
from odoo_xmlrpc_wrapper import Bot as OdooBot
class OdooApp:
    def __init__(self, master):
        self.master = master
        self.master.title("Interfaz Odoo Hotel Sol")
        self.master.geometry("800x600")
        self.master.resizable(False, False)

        # Variables para almacenar la informacion de conexión
        self.odoo_host = tk.StringVar()
        self.db_name = tk.StringVar()
        self.odoo_user = tk.StringVar()
        self.odoo_password = tk.StringVar()

        # Etiquetas y campos de entrada para la información de conexión
        ttk.Label(self.master, text="Odoo Host:").grid(row=0, column=0, padx=10, pady=10)
        ttk.Entry(self.master, textvariable=self.odoo_host).grid(row=0, column=1, padx=10, pady=10)

        ttk.Label(self.master, text="Nombre de la Base de Datos:").grid(row=1, column=0, padx=10, pady=10)
        ttk.Entry(self.master, textvariable=self.db_name).grid(row=1, column=1, padx=10, pady=10)

        ttk.Label(self.master, text="Usuario Odoo:").grid(row=2, column=0, padx=10, pady=10)
        ttk.Entry(self.master, textvariable=self.odoo_user).grid(row=2, column=1, padx=10, pady=10)

        ttk.Label(self.master, text="Contrasena Odoo:").grid(row=3, column=0, padx=10, pady=10)
        ttk.Entry(self.master, textvariable=self.odoo_password, show='*').grid(row=3, column=1, padx=10, pady=10)

        # Botón para seleccionar el archivo XML
        ttk.Button(self.master, text="Seleccionar XML", command=self.select_xml_file).grid(row=4, column=0, columnspan=1, pady=10)
        # Botón para seleccionar el archivo XML
        ttk.Button(self.master, text="Seleccionar XML View", command=self.create_model).grid(row=4, column=1, columnspan=2, pady=10)

        # Botones de exportar e importar XML
        ttk.Button(self.master, text="Exportar XML", command=self.export_xml).grid(row=5, column=0, pady=10)
        ttk.Button(self.master, text="Importar XML", command=self.import_xml).grid(row=5, column=1, pady=10)

    def select_xml_file(self):
        # Abre el file picker para seleccionar el archivo XML
        file_path = filedialog.askopenfilename(filetypes=[("XML files", "*.xml")])
        if file_path:
            print("Archivo XML seleccionado:", file_path)
            messagebox.showinfo("Archivo XML Seleccionado", f"Archivo XML seleccionado: {file_path}")
            return file_path

    def export_xml(self):
        # Implementa lógica para exportar XML
        path = self.select_xml_file()
        xml_data=leer_xml(path)
        odoo = OdooBot(self.odoo_host.get(), self.db_name.get(), self.odoo_user.get(), self.odoo_password.get(),False,False)
        if odoo.successful:
            messagebox.showinfo("Conexion Exitosa", odoo.status())
        else:
            messagebox.showerror("Error de Conexion", "Error al conectar con Odoo")
            
        #ModuloInfraninjasViews.create_invoice_from_xml(odoo,self.select_xml_file)
        messagebox.showinfo("Exportar XML", xml_data)


    def import_xml(self):
        # Implementa lógica para importar XML
        messagebox.showinfo("Importar XML", "Logica para importar XML")
    
    def create_model(self):
        odoo = OdooBot(self.odoo_host.get(), self.db_name.get(), self.odoo_user.get(), self.odoo_password.get(),False,False)
        # Definir la información del modelo
        model_data_direccion = {
            "name": "Direccion",
            "model": "modulo.infraninjasdireccion",
            "description": "Modelo para gestionar direcciones",
            "arch": """
                <data>
                    <!-- Campos del modelo -->
                    <field name="Calle" type="char" string="Calle"/>
                    <field name="Numero" type="char" string="Numero"/>
                    <field name="Puerta" type="char" string="Puerta"/>
                    <field name="Piso" type="char" string="Piso"/>
                    <field name="CodigoPostal" type="char" string="Codigo Postal"/>
                    <field name="Provincia" type="char" string="Provincia"/>
                    <field name="Pais" type="char" string="Pais"/>
                </data>
            """,
        }
        odoo.create('ir.model', model_data_direccion)
        model_data_cliente = {
            "name": "Cliente",
            "model": "modulo.infraninjascliente",
            "description": "Modelo para gestionar clientes",
            "arch": """
                <data>
                    <!-- Campos del modelo -->
                    <field name="NIF" type="char" string="NIF"/>
                    <field name="Nombre" type="char" string="Nombre"/>
                    <field name="PrimerApellido" type="char" string="Primer Apellido"/>
                    <field name="SegundoApellido" type="char" string="Segundo Apellido"/>
                    <field name="CorreoElectronico" type="char" string="Correo Electronico"/>
                    <field name="Telefono" type="char" string="Telefono"/>
                    <field name="DireccionID" type="many2one" relation="modulo.infraninjasdireccion" string="Direccion"/>
                </data>
            """,
        }
        odoo.create('ir.model', model_data_cliente)
        model_data_reserva = {
            "name": "Reserva",
            "model": "modulo.infraninjasreserva",
            "description": "Modelo para gestionar reservas",
            "arch": """
                <data>
                    <!-- Campos del modelo -->
                    <field name="ReservaID" type="integer" string="ID de Reserva"/>
                    <field name="NIF" type="char" string="NIF"/>
                    <field name="EmpleadoID" type="integer" string="ID de Empleado"/>
                    <field name="FechaInicio" type="date" string="Fecha de Inicio"/>
                    <field name="FechaFin" type="date" string="Fecha de Fin"/>
                    <field name="EstadoReserva" type="selection" string="Estado de Reserva" selection="[('pendiente', 'Pendiente'), ('confirmada', 'Confirmada'), ('cancelada', 'Cancelada')]"/>
                    <field name="CheckInConfirmado" type="boolean" string="Check-In Confirmado"/>
                    <field name="CheckOutConfirmado" type="boolean" string="Check-Out Confirmado"/>
                    <field name="FacturaID" type="integer" string="ID de Factura"/>
                    <field name="FechaCreacion" type="datetime" string="Fecha de Creación"/>
                    <field name="TipoReserva" type="char" string="Tipo de Reserva"/>
                </data>
            """,
        }
        odoo.create('ir.model', model_data_reserva)
        model_data_factura = {
            "name": "Factura",
            "model": "modulo.infraninjasfactura",
            "description": "Modelo para gestionar facturas",
            "arch": """
                <data>
                    <!-- Campos del modelo -->
                    <field name="FacturaId" type="char" string="ID de Factura"/>
                    <field name="Nif" type="char" string="NIF"/>
                    <field name="EmpleadoID" type="integer" string="ID de Empleado"/>
                    <field name="Detalles" type="text" string="Detalles"/>
                    <field name="Cargos" type="float" string="Cargos"/>
                    <field name="Impuestos" type="float" string="Impuestos"/>
                    <field name="Fecha" type="date" string="Fecha"/>
                    <field name="FechaCreacion" type="datetime" string="Fecha de Creación"/>
                    <field name="TipoFactura" type="selection" string="Tipo de Factura" selection="[('simple', 'Simple'), ('estancia', 'Estancia')]"/>
                    <field name="reservas_ids" type="many2many" relation="modulo.infraninjasreserva" string="Reservas"/>
                    <field name="cliente_id" type="many2one" relation="modulo.infraninjascliente" string="Cliente"/>
                </data>
            """,
        }
        odoo.create('ir.model', model_data_factura)
    
    def create_invoice_from_xml(odoo,path):
        # Obtener el string del XML
        xml_data = leer_xml(path)
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

if __name__ == "__main__":
    root = tk.Tk()
    app = OdooApp(root)
    root.update() 
    root.mainloop()

