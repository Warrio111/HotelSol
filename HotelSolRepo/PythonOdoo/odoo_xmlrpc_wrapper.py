import xmlrpc.client
import xml.etree.ElementTree as ET

class Bot:
    """
    A bot class to rule them all.
    """

    def __init__(
        self,
        host: str = None,
        db: str = None,
        userlogin: str = None,
        password: str = None,
        secured: bool = True,
        test: bool = False,
    ) -> None:
        """
        Bot instance initializer: If test = True other arguments muted. For http:// secured = False

        Args:
            host (str, optional): The host 'odoo.yourhost.com'. Defaults to None.
            db (str, optional): Database to login. Defaults to None.
            userlogin (str, optional): Login string. Defaults to None.
            password (str, optional): Password. Defaults to None.
            secured (bool, optional): http:// or https://. Defaults to True.
            test (bool, optional): To use Odoo's own test servers. Defaults to False.
        """
        self.__test_info = (
            xmlrpc.client.ServerProxy("https://demo.odoo.com/start").start()
            if test
            else "Not Test"
        )
        self.HOST = self.__test_info["host"][8:] if test else host
        self.URL = (
            f"https://{self.HOST}/xmlrpc/2"
            if secured
            else f"http://{self.HOST}/xmlrpc/2"
        )
        self.DB = self.__test_info["database"] if test else db
        self.USERLOGIN = self.__test_info["user"] if test else userlogin
        self.__PASSWORD = self.__test_info["password"] if test else password
        self.model = None
        self.__common = xmlrpc.client.ServerProxy(f"{self.URL}/common")
        self.version = self.__common.version()
        self.uid = self.__common.authenticate(
            self.DB, self.USERLOGIN, self.__PASSWORD, {}
        )
        if not self.uid:
            raise Exception(
                f"Wrong one ({self.HOST}, {self.DB}, {self.USERLOGIN}, PASSWORD)"
            )
        self.__orm = xmlrpc.client.ServerProxy(f"{self.URL}/object")
        self.profile = self.read("res.users", ids=self.uid, fields=["name"])[0]
        self.name = self.profile["name"]
        self.successful = True
        if self.successful:
            print(self.status)

    def satus(self) -> str:
        return f"Successfully Logged\nName: {self.name}\nDB: {self.DB}\nHOST: {self.HOST}\nVERSION: {self.version['server_version']}"

    def search_read(
        self,
        model: str = None,
        constraints: list = None,
        fields: list = None,
        limit: int = None,
    ) -> list:
        """
        Searches with constraints amd reads the results fields.

        Args:
            model (str, optional): Model name. Defaults to None.
            constraints (list, optional): Search constraints. Defaults to None.
            fields (list, optional): Desired fields to read. Defaults to ["name"].
            limit (int, optional): Result limit. Defaults to None.

        Returns:
            list: A list of results as dicts with desired fields.
        """
        if model:
            self.model = model
        if fields is None:
            fields = ["name"]
        if constraints is None:
            constraints = [[]]
        else:
            constraints = [constraints]
        return self.__orm.execute_kw(
            self.DB,
            self.uid,
            self.__PASSWORD,
            self.model,
            "search_read",
            constraints,
            {"fields": fields} if limit is None else {"fields": fields, "limit": limit},
        )

    def search(
        self,
        model: str = None,
        constraints: list = None,
        offset: int = None,
        limit: int = None,
    ) -> list:
        """
        Searches with constraints and returns results ids.

        Args:
            model (str, optional): Model name. Defaults to None.
            constraints (list, optional): Search constraints. Defaults to None.
            offset (int, optional): Offset. Defaults to None.
            limit (int, optional): Result limit. Defaults to None.

        Returns:
            list: A list of record ids as integers.
        """
        if model:
            self.model = model
        if constraints is None:
            constraints = [[]]
        else:
            constraints = [constraints]
        return self.__orm.execute_kw(
            self.DB,
            self.uid,
            self.__PASSWORD,
            self.model,
            "search",
            constraints,
            {"offset": offset, "limit": limit}
            if offset and limit
            else {"offset": offset}
            if offset
            else {"limit": limit}
            if limit
            else {},
        )

    def count(self, model: str = None, constraints: list = None) -> int:
        """
        Length of records with constraints.

        Args:
            model (str, optional): Model name. Defaults to None.
            constraints (list, optional): Search constraints. Defaults to None.

        Returns:
            int: Count of records.
        """
        return len(self.search(model, constraints))

    def read(self, model: str = None, ids: list = None, fields: list = None) -> list:
        """
        Reads ids with desired fields.

        Args:
            model (str, optional): Model name. Defaults to None.
            ids (list, optional): List of ids to read. Defaults to None.
            fields (list, optional): Desired fields to read. Defaults to None.

        Returns:
            list: A list of results as dicts with desired fields.
        """
        if model:
            self.model = model
        return self.__orm.execute_kw(
            self.DB,
            self.uid,
            self.__PASSWORD,
            self.model,
            "read",
            [ids],
            {"fields": fields} if fields else {},
        )

    def delete(self, model: str = None, ids: list = None) -> None:
        """
        ID list to delete.

        Args:
            model (str, optional): Model name. Defaults to None.
            ids (list, optional): List of ids to delete. Defaults to None.
        """
        if model:
            self.model = model
        self.__orm.execute_kw(
            self.DB,
            self.uid,
            self.__PASSWORD,
            self.model,
            "unlink",
            [ids] if isinstance(ids, list) else [[ids]],
        )

    def create(self, model: str = None, the_obj: dict = None) -> None:
        """
        Creates new record.

        Args:
            model (str, optional): Model name. Defaults to None.
            the_obj (dict, optional): The object as dict to create. Defaults to None.

        Raises:
            ValueError: No Object
        """
        if the_obj is None:
            raise ValueError("No Object")
        if model:
            self.model = model
        self.__orm.execute_kw(
            self.DB, self.uid, self.__PASSWORD, self.model, "create", [the_obj]
        )

    def update(
        self, model: str = None, the_id: int = None, the_obj: dict = None
    ) -> None:
        """
        Updates a record.

        Args:
            model (str, optional): Model name. Defaults to None.
            the_id (int, optional): The id as integer of the record. Defaults to None.
            the_obj (dict, optional): The object as dict to update. Defaults to None.

        Raises:
            ValueError: No ID
            ValueError: No Object
        """
        if id is None:
            raise ValueError("No ID")
        if the_obj is None:
            raise ValueError("No Object")
        if model:
            self.model = model
        self.__orm.execute_kw(
            self.DB, self.uid, self.__PASSWORD, self.model, "write", [[the_id], the_obj]
        )

    def get_fields(self, model: str = None, attributes: list = None) -> dict:
        """
        Model fields with desired infos.

        Args:
            model (str, optional): Model name. Defaults to None.
            attributes (list, optional): Desired attributes of the fields. Defaults to None.

        Returns:
            dict: Fields of the model.
        """
        if model:
            self.model = model
        return self.__orm.execute_kw(
            self.DB,
            self.uid,
            self.__PASSWORD,
            self.model,
            "fields_get",
            [],
            {"attributes": attributes} if attributes else {},
        )

    def custom(self, model: str = None, command: str = None, att=[[]]):
        """
        Triggering a method remotely.

        Args:
            model (str): Model name.
            command (str): Your custom command's name.
            att (list, optional): Sends attributes your custom method.

        Returns:
            Your method's return.
        """
        if model:
            self.model = model
        return self.__orm.execute_kw(
            self.DB, self.uid, self.__PASSWORD, self.model, command, att
        )
    
    def create_invoice_from_xml(self, xml_data):
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
        direccion_id = self.create('infraninjasDireccion', direccion_data)

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
        cliente_id = self.create('infraninjasCliente', cliente_data)

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
        reserva_id = self.create('infraninjasReserva', reserva_data)

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
        factura_id = self.create('infraninjasFactura', factura_data)
        print('Factura creada con ID', factura_id)

