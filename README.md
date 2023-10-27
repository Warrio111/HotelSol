# HotelSolRepo
# Sistema de Gestión Hotelera - Proyecto .NET

Este proyecto se centra en el desarrollo de una aplicación de gestión hotelera en el entorno .NET. A continuación, se describen los detalles y cómo trabajar en este proyecto de manera colaborativa en GitHub.

## Descripción del Proyecto

En esta primera etapa, estamos diseñando la funcionalidad y la interfaz gráfica de la aplicación. El objetivo principal es crear una herramienta que permita gestionar los datos de clientes, tipos de habitaciones, disponibilidad de habitaciones y reservas en un hotel. Esto incluye la gestión de usuarios con diferentes roles, como administrador y recepcionista.

### Requerimientos Principales

- Registro de datos de clientes.
- Gestión de tipos de habitaciones (individual, doble, cuádruple, suite, etc.).
- Control de la disponibilidad de habitaciones según el calendario.
- Realización de reservas por parte de los clientes.
- Administración de tipo de alojamiento (media pensión, pensión completa, todo incluido).
- Variabilidad de precios según la temporada (alta, media, baja).

### Funcionalidades Adicionales

- Consulta de listado de clientes con reservas.
- Seguimiento de llegadas y salidas de clientes.
- Gestión de incidencias en caso de ausencia de clientes.
- Modificación y cancelación de reservas.
- Consulta de historial de estancias para clientes.
- Facturación de alojamiento y servicios adicionales.
- Posibilidad de aplicar descuentos a clientes VIP.
- Otras funcionalidades personalizadas según las necesidades.

## Flujo de Trabajo en GitHub

### 1. Clonar el Repositorio

Primero, clona el repositorio desde la rama principal (master) a tu máquina local.

```bash
git clone https://github.com/mratomo/HotelSolRepo.git
cd HotelSOLInfraNinjas
```
### 2. Actualizar la Rama master
Asegúrate de tener la última versión de la rama master antes de empezar a trabajar en tu desarrollo.

```bash

git checkout master
git pull origin master
```
### 3. Crear una Rama de Desarrollo
Para cualquier nuevo desarrollo en la aplicación, crea una nueva rama de desarrollo desde master. Asegúrate de darle un nombre descriptivo, por ejemplo, dev/nueva-funcionalidad.

```bash

git checkout -b dev/nueva-funcionalidad
```
### 4. Trabajar en tu Desarrollo
Realiza tus cambios y desarrollos en esta nueva rama. Asegúrate de escribir pruebas unitarias asociadas y verificar que todo funcione correctamente.

### 5. Actualizar desde master
Antes de finalizar tu desarrollo, asegúrate de estar al día con la rama master.

```bash
git checkout master
git pull origin master
```
### 6. Hacer un Merge de master a tu Rama de Desarrollo
Integra cualquier cambio nuevo de master en tu rama de desarrollo antes de finalizar.

```bash

git checkout dev/nueva-funcionalidad
git merge master
```
Resuelve cualquier conflicto si es necesario.

### 7. Enviar una Solicitud de Extracción (Pull Request)
Cuando tu desarrollo esté completo y funcionando correctamente, sube tu rama de desarrollo a GitHub y crea una Solicitud de Extracción (Pull Request) hacia la rama master. Asigna a Robert Benavides como revisor o Pablo Rodriguéz.

### 8. Revisión y Aprobación
Robert Benavides o Pablo Rodríguez revisará tu código y, una vez aprobado, se fusionará con la rama master.

# Contacto
Si tienes alguna pregunta o necesitas ayuda, no dudes en ponerte en contacto con el equipo de desarrollo.

Este flujo de trabajo te ayudará a mantener un proyecto ordenado y colaborativo, asegurando que todos los cambios se integren correctamente y que la rama master siempre esté en buen estado.
