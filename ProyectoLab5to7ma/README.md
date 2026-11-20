# Proyecto de gestión de envíos mediante una API

## Descripción

Este proyecto consiste en una API REST desarrollada con .NET 10 y Minimal API para gestionar envíos. Utiliza MySQL como base de datos y permite registrar, consultar, actualizar, cancelar y cambiar el estado de los envíos.

## Tecnologías utilizadas

- C#
- .NET 10
- Minimal API
- MySQL
- Dapper
- Swagger
- xUnit

## Requisitos

- .NET 10 SDK
- MySQL Server 8.0 o superior
- Visual Studio Code o Visual Studio
- MySQL Workbench (opcional)

## Estructura del proyecto

- `src/`: contiene la solución y los proyectos de la aplicación.
- `scripts/`: contiene los scripts SQL para crear la base de datos, los procedimientos y los usuarios.
- `pruebas/`: contiene las solicitudes HTTP para probar la API.
- `backup/`: contiene una copia de seguridad de la base de datos.

## Instalación de la base de datos

La base de datos utilizada se llama `DB_JoacoEnvios`.

Para instalarla:

1. Abrir MySQL Workbench.
2. Conectarse al servidor MySQL.
3. Abrir el archivo `scripts/install.sql`.
4. Ejecutar el script completo.

El archivo `install.sql` ejecuta los siguientes scripts en orden:

1. `DDL.sql`: crea la base de datos y las tablas.
2. `SP.sql`: crea los procedimientos almacenados.
3. `ESTADISTICAS.sql`: crea el procedimiento de estadísticas.
4. `USUARIOS.sql`: crea los usuarios y asigna sus permisos.

## Backup de la base de datos

El archivo `backup/envios.sql` contiene una copia de la estructura de las tablas y sus datos de ejemplo.

## Ejecutar la API

Desde una terminal ubicada en la carpeta principal del proyecto, ejecutar:

```bash
dotnet run --project src/API/API.csproj
```

La API se ejecutará localmente.

## Swagger

Con la API en ejecución, abrir Swagger desde el navegador:

`http://localhost:5283/swagger`

Desde allí se pueden consultar y probar los endpoints disponibles.

## Pruebas HTTP

El archivo `pruebas/envios.http` contiene solicitudes para probar las operaciones de la API.

Se puede ejecutar desde Visual Studio Code utilizando la extensión REST Client.

## Pruebas automatizadas

Para ejecutar las pruebas del proyecto:

```bash
dotnet test src/Solucion.slnx
```

## Restaurar el backup

Para restaurar la base de datos:

1. Abrir MySQL Workbench.
2. Abrir el archivo `backup/envios.sql`.
3. Ejecutar el script completo.
4. Ejecutar los scripts `SP.sql`, `ESTADISTICAS.sql` y `USUARIOS.sql` para recuperar los procedimientos y usuarios.

**Importante:** el backup contiene las tablas y sus datos, pero no incluye los procedimientos almacenados ni los usuarios de MySQL.

## Seguridad

Las credenciales de conexión deben configurarse mediante variables de entorno. No se deben publicar contraseñas reales en el repositorio.
