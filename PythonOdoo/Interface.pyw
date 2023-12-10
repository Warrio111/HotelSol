# -*- coding: iso-8859-1 -*-
from datetime import date, datetime
import os
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

        # # Botón para seleccionar el archivo XML
        # ttk.Button(self.master, text="Seleccionar XML", command=self.select_xml_file).grid(row=4, column=0, columnspan=1, pady=10)
        # # Botón para seleccionar el archivo XML
        # ttk.Button(self.master, text="Seleccionar XML View", command=self.create_model).grid(row=4, column=1, columnspan=2, pady=10)

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
    
    def create_invoice_from_xml(self,odoo,path):
        # Obtener el string del XML
        xml_data = leer_xml(path)
        # Parsear el XML
        root = ET.fromstring(xml_data)

        # Obtener datos de la dirección del cliente
        direccion_data = {
            'x_DireccionID': int(root.find('Clientes/Cliente/Direcciones/Direccion/DireccionID').text),
            'x_Calle': root.find('Clientes/Cliente/Direcciones/Direccion/Calle').text,
            'x_Numero': root.find('Clientes/Cliente/Direcciones/Direccion/Numero').text,
            'x_Puerta': root.find('Clientes/Cliente/Direcciones/Direccion/Puerta').text,
            'x_Piso': root.find('Clientes/Cliente/Direcciones/Direccion/Piso').text,
            'x_CodigoPostal': root.find('Clientes/Cliente/Direcciones/Direccion/CodigoPostal').text,
            'x_Provincia': root.find('Clientes/Cliente/Direcciones/Direccion/Provincia').text,
            'x_Pais': root.find('Clientes/Cliente/Direcciones/Direccion/Pais').text,
        }
        #messagebox.showinfo("Exportar XML Direccion", direccion_data)
        # Crear la dirección en Odoo
        direccion_id = odoo.create('x_modulo.infraninjasdireccion', direccion_data)

        # Obtener datos del cliente
        cliente_data = {
            'x_NIF': root.find('Clientes/Cliente/NIF').text,
            'x_Nombre': root.find('Clientes/Cliente/Nombre').text,
            'x_PrimerApellido': root.find('Clientes/Cliente/PrimerApellido').text,
            'x_SegundoApellido': root.find('Clientes/Cliente/SegundoApellido').text,
            'x_CorreoElectronico': root.find('Clientes/Cliente/CorreoElectronico').text,
            'x_Telefono': root.find('Clientes/Cliente/Telefono').text,
            'x_DireccionID': int(root.find('Clientes/Cliente/Direcciones/Direccion/DireccionID').text),
        }
        #messagebox.showinfo("Exportar XML Cliente", cliente_data)
        # Crear el cliente en Odoo
        odoo.create('x_modulo.infraninjascliente', cliente_data)

        # Obtener el ID del cliente recién creado
        cliente_id = odoo.search('x_modulo.infraninjascliente', [('x_NIF', '=', cliente_data['x_NIF'])])
        ultimo_nif_insertado = ''
        # Verificar si se encontraron resultados antes de intentar obtener el último NIF
        if cliente_id:
            # Obtener el registro completo del cliente usando el ID
            cliente_info = odoo.read('x_modulo.infraninjascliente', ids=cliente_id, fields=['x_NIF'])

            # Obtener el último NIF insertado
            ultimo_nif_insertado = cliente_info[-1]['id']

            # Mostrar el último NIF insertado
            #messagebox.showinfo("Último NIF Insertado", ultimo_nif_insertado)
        else:
            # Manejar el caso en el que no se encontraron registros
            messagebox.showinfo("Error", "No se encontraron registros para el NIF insertado")

        
            # Obtener datos de la reserva
        reserva_data = {
            'x_ReservaID': int(root.find('Reservas/Reserva/ReservaID').text),
            'x_NIF': root.find('Reservas/Reserva/NIF').text,
            'x_EmpleadoID': int(root.find('Reservas/Reserva/EmpleadoID').text),
            'x_FechaInicio': root.find('Reservas/Reserva/FechaInicio').text,
            'x_FechaFin': root.find('Reservas/Reserva/FechaFin').text,
            'x_EstadoReserva': root.find('Reservas/Reserva/EstadoReserva').text,
            'x_CheckInConfirmado': root.find('Reservas/Reserva/CheckInConfirmado').text,
            'x_CheckOutConfirmado': root.find('Reservas/Reserva/CheckOutConfirmado').text,
            'x_FacturaID': int(root.find('Reservas/Reserva/FacturaID').text),
            'x_FechaCreacion': root.find('Reservas/Reserva/FechaCreacion').text,
            'x_TipoReserva': root.find('Reservas/Reserva/TipoReserva').text,
        }
        #messagebox.showinfo("Exportar XML Reserva", reserva_data)
        # Crear la reserva en Odoo y vincularla a la factura
        odoo.create('x_modulo.infraninjasreserva', reserva_data)

        # Obtener el ID de la reserva recién creada
        reserva_id = odoo.search('x_modulo.infraninjasreserva', [('x_ReservaID', '=', reserva_data['x_ReservaID'])])
        ultimo_reserva_id_insertado = 0
        # Verificar si se encontraron resultados antes de intentar obtener la última reserva
        if reserva_id:
            # Obtener el registro completo de la reserva usando el ID
            reserva_info = odoo.read('x_modulo.infraninjasreserva', ids=reserva_id, fields=['x_ReservaID'])

            # Obtener el último x_ReservaID insertado
            ultimo_reserva_id_insertado = reserva_info[-1]['id']

            # Mostrar el último x_ReservaID insertado
            #messagebox.showinfo("Último x_ReservaID Insertado", str(ultimo_reserva_id_insertado))
        else:
            # Manejar el caso en el que no se encontraron registros
            messagebox.showinfo("Error", "No se encontraron registros para el x_ReservaID insertado")

         # Obtener datos de la factura
        factura_data = {
            'x_FacturaID': int(root.find('FacturaID').text),
            'x_NIF': root.find('NIF').text,
            'x_EmpleadoID': int(root.find('EmpleadoID').text),
            'x_Detalles': root.find('Detalles').text,
            'x_Cargos': float(root.find('Cargos').text),
            'x_Impuestos': float(root.find('Impuestos').text),
            'x_Fecha': root.find('Fecha').text,
            'x_FechaCreacion': root.find('FechaCreacion').text,
            'x_TipoFactura': root.find('TipoFactura').text,
            'x_cliente_id': ultimo_nif_insertado,
            'x_reservas_ids': [(4, ultimo_reserva_id_insertado)],
        }
        #messagebox.showinfo("Exportar XML Factura", factura_data)
        # Crear la factura en Odoo y vincularla al cliente y la reserva
        odoo.create('x_modulo.infraninjasfactura', factura_data)
        messagebox.showinfo("Factura creada correctamente")
    def create_client_from_xml(self, odoo, path):
        # Obtener el string del XML
        xml_data = leer_xml(path)

        # Parsear el XML
        root = ET.fromstring(xml_data)

        # Obtener la lista de clientes
        clientes = root.findall('Clientes')

        for cliente in clientes:
            # Obtener datos del cliente
            cliente_data = {
                'x_NIF': cliente.find('NIF').text,
                'x_Nombre': cliente.find('Nombre').text,
                'x_PrimerApellido': cliente.find('PrimerApellido').text,
                'x_SegundoApellido': cliente.find('SegundoApellido').text,
                'x_CorreoElectronico': cliente.find('CorreoElectronico').text,
                'x_Telefono': cliente.find('Telefono').text,
                'x_DireccionID': int(cliente.find('DireccionID').text),
            }

            # Crear el cliente en Odoo
            odoo.create('x_modulo.infraninjascliente', cliente_data)

            # Obtener el ID del cliente recién creado
            cliente_id = odoo.search('x_modulo.infraninjascliente', [('x_NIF', '=', cliente_data['x_NIF'])])

            if cliente_id:
                # Obtener datos de la dirección del cliente
                direccion_data = {
                    'x_DireccionID': int(cliente.find('Direcciones/Direccion/DireccionID').text),
                    'x_Calle': cliente.find('Direcciones/Direccion/Calle').text,
                    'x_Numero': cliente.find('Direcciones/Direccion/Numero').text,
                    'x_Puerta': cliente.find('Direcciones/Direccion/Puerta').text,
                    'x_Piso': cliente.find('Direcciones/Direccion/Piso').text,
                    'x_CodigoPostal': cliente.find('Direcciones/Direccion/CodigoPostal').text,
                    'x_Provincia': cliente.find('Direcciones/Direccion/Provincia').text,
                    'x_Pais': cliente.find('Direcciones/Direccion/Pais').text,
                }

                # Crear la dirección en Odoo
                odoo.create('x_modulo.infraninjasdireccion', direccion_data)

                #messagebox.showinfo("Cliente y Dirección Creados", f"Cliente y dirección creados para NIF: {cliente_data['x_NIF']}")
            else:
                messagebox.showwarning("Error", f"No se pudo crear el cliente para NIF: {cliente_data['x_NIF']}")
    def create_reservations_from_xml(self, odoo, path):
        # Obtener el string del XML
        xml_data = leer_xml(path)
        # Parsear el XML
        root = ET.fromstring(xml_data)
        for cliente_elem in root.findall('.//Clientes'):
            nif = cliente_elem.find('NIF').text
            nombre = cliente_elem.find('Nombre').text
            primer_apellido = cliente_elem.find('PrimerApellido').text
            segundo_apellido = cliente_elem.find('SegundoApellido').text
            direccion_id = int(cliente_elem.find('Direcciones/Direccion/DireccionID').text)
            correo_electronico = cliente_elem.find('CorreoElectronico').text
            telefono = cliente_elem.find('Telefono').text
            cliente_data = {
                'x_NIF': nif,
                'x_Nombre': nombre,
                'x_PrimerApellido': primer_apellido,
                'x_SegundoApellido': segundo_apellido,
                'x_CorreoElectronico': correo_electronico,
                'x_Telefono': telefono,
                'x_DireccionID': direccion_id,
            }
            # Crear el cliente en Odoo
            odoo.create('x_modulo.infraninjascliente', cliente_data)
            # Obtener el ID del cliente recién creado
            cliente_id = odoo.search('x_modulo.infraninjascliente', [('x_NIF', '=', cliente_data['x_NIF'])])
            ultimo_nif_insertado = ''
            # Verificar si se encontraron resultados antes de intentar obtener el último NIF
            if cliente_id:
                # Obtener el registro completo del cliente usando el ID
                cliente_info = odoo.read('x_modulo.infraninjascliente', ids=cliente_id, fields=['x_NIF'])
                ultimo_nif_insertado = cliente_info[-1]['id']
                # Obtener datos de la dirección del cliente
                direccion_data = {
                    'x_DireccionID': int(cliente_elem.find('Direcciones/Direccion/DireccionID').text),
                    'x_Calle': cliente_elem.find('Direcciones/Direccion/Calle').text,
                    'x_Numero': cliente_elem.find('Direcciones/Direccion/Numero').text,
                    'x_Puerta': cliente_elem.find('Direcciones/Direccion/Puerta').text,
                    'x_Piso': cliente_elem.find('Direcciones/Direccion/Piso').text,
                    'x_CodigoPostal': cliente_elem.find('Direcciones/Direccion/CodigoPostal').text,
                    'x_Provincia': cliente_elem.find('Direcciones/Direccion/Provincia').text,
                    'x_Pais': cliente_elem.find('Direcciones/Direccion/Pais').text,
                }
                # Crear la dirección en Odoo
                odoo.create('x_modulo.infraninjasdireccion', direccion_data)
                #messagebox.showinfo("Cliente y Dirección Creados", f"Cliente y dirección creados para NIF: {cliente_data['x_NIF']}")
            else:
                messagebox.showwarning("Error", f"No se pudo crear el cliente para NIF: {cliente_data['x_NIF']}")
                
            for reserva_elem in cliente_elem.findall('.//Reservas/Reserva'):
                reserva_id = int(reserva_elem.find('ReservaID').text)
                nif = reserva_elem.find('NIF').text
                empleado_id = int(reserva_elem.find('EmpleadoID').text)
                fecha_inicio = reserva_elem.find('FechaInicio').text
                fecha_fin = reserva_elem.find('FechaFin').text
                estado_reserva = reserva_elem.find('EstadoReserva').text
                checkInConfirmado = reserva_elem.find('CheckInConfirmado').text
                checkOutConfirmado = reserva_elem.find('CheckOutConfirmado').text
                factura_id = int(reserva_elem.find('FacturaID').text)
                fecha_creacion = reserva_elem.find('FechaCreacion').text
                tipo_reserva = reserva_elem.find('TipoReserva').text
                
                reserva_info = {
                    'x_ReservaID': reserva_id,
                    'x_NIF': nif,
                    'x_EmpleadoID': empleado_id,
                    'x_FechaInicio': fecha_inicio,
                    'x_FechaFin': fecha_fin,
                    'x_EstadoReserva': estado_reserva,
                    'x_CheckInConfirmado': checkInConfirmado,
                    'x_CheckOutConfirmado': checkOutConfirmado,
                    'x_FacturaID': factura_id,
                    'x_FechaCreacion': fecha_creacion,
                    'x_TipoReserva': tipo_reserva,
                }
                # Crear la reserva en Odoo y vincularla a la factura
                odoo.create('x_modulo.infraninjasreserva', reserva_info)
                # Obtener el ID de la reserva recién creada
                reserva_id = odoo.search('x_modulo.infraninjasreserva', [('x_ReservaID', '=', reserva_info['x_ReservaID'])])
                ultimo_reserva_id_insertado = 0
                # Verificar si se encontraron resultados antes de intentar obtener la última reserva
                if reserva_id:
                    # Obtener el registro completo de la reserva usando el ID
                    reserva_info = odoo.read('x_modulo.infraninjasreserva', ids=reserva_id, fields=['x_ReservaID'])
                    # Obtener el último x_ReservaID insertado
                    ultimo_reserva_id_insertado = reserva_info[-1]['id']
                    # Mostrar el último x_ReservaID insertado
                    #messagebox.showinfo("Último x_ReservaID Insertado", str(ultimo_reserva_id_insertado))
                else:
                    # Manejar el caso en el que no se encontraron registros
                    messagebox.showinfo("Error", "No se encontraron registros para el x_ReservaID insertado")
                

                for factura_elem in cliente_elem.findall('.//Facturas/Factura'):
                    factura_id = int(factura_elem.find('FacturaID').text)
                    nif = factura_elem.find('NIF').text
                    empleado_id = int(factura_elem.find('EmpleadoID').text)
                    detalles = factura_elem.find('Detalles').text
                    cargos = float(factura_elem.find('Cargos').text)
                    impuestos = float(factura_elem.find('Impuestos').text)
                    fecha = factura_elem.find('Fecha').text
                    fecha_creacion = factura_elem.find('FechaCreacion').text
                    tipo_factura = factura_elem.find('TipoFactura').text
                    factura_info = {
                        'x_FacturaID': factura_id,
                        'x_NIF': nif,
                        'x_EmpleadoID': empleado_id,
                        'x_Detalles': detalles,
                        'x_Cargos': cargos,
                        'x_Impuestos': impuestos,
                        'x_Fecha': fecha,
                        'x_FechaCreacion': fecha_creacion,
                        'x_TipoFactura': tipo_factura,
                        'x_cliente_id': ultimo_nif_insertado,
                        'x_reservas_ids': [(4, ultimo_reserva_id_insertado)],
                    }
                    # Crear la factura en Odoo y vincularla al cliente y la reserva
                    odoo.create('x_modulo.infraninjasfactura', factura_info)
                    #messagebox.showinfo("Factura creada correctamente")


    def export_xml(self):
        # Implementa lógica para exportar XML
        path = self.select_xml_file()
        xml_data = leer_xml(path)
        odoo = OdooBot(self.odoo_host.get(), self.db_name.get(), self.odoo_user.get(), self.odoo_password.get(), False, False)

        if odoo.successful:
            messagebox.showinfo("Conexion Exitosa", odoo.status())
        else:
            messagebox.showerror("Error de Conexion", "Error al conectar con Odoo")

        # Obtén el nombre del documento desde la ruta del archivo
        document_name = os.path.basename(path)

        # Lógica para determinar qué función llamar según el nombre del documento
        if document_name == "facturaCliente.xml":
            self.create_invoice_from_xml(odoo, path)
        elif document_name == "obtenerClientes.xml":
            self.create_client_from_xml(odoo, path)
        elif document_name == "obtenerClientesConReservas.xml":
            self.create_reservations_from_xml(odoo, path)
        else:
            messagebox.showwarning("Advertencia", f"No se encontró una función asociada para el documento {document_name}")

        messagebox.showinfo("Exportar XML", xml_data)



    def import_xml(self):
        # Implementa lógica para importar XML
        messagebox.showinfo("Importar XML", "Logica para importar XML")

if __name__ == "__main__":
    root = tk.Tk()
    app = OdooApp(root)
    root.update() 
    root.mainloop()

