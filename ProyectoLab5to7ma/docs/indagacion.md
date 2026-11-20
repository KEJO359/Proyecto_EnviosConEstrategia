# Indagación del proyecto

## 1. Introducción

Durante el desarrollo del proyecto fue necesario investigar diferentes herramientas y conceptos para poder transformar el sistema de gestión de envíos en una API utilizando C# y .NET 10.

La investigación permitió comprender cómo funcionan las solicitudes HTTP, cómo se organizan los endpoints y cómo se conecta una API con una base de datos MySQL.

## 2. Minimal API y HTTP

Se investigó el funcionamiento de Minimal API en .NET 10.

Minimal API permite crear endpoints de manera sencilla, sin necesidad de utilizar controladores. Cada endpoint representa una operación que puede realizar el sistema.

También se investigaron los principales métodos HTTP:

- **GET:** permite consultar información.
- **POST:** permite registrar un nuevo envío.
- **PUT:** permite actualizar los datos de un envío.
- **PATCH:** permite modificar el estado de un envío.
- **DELETE:** permite eliminar un envío.

Además, se estudiaron los códigos de respuesta HTTP, como:

- **200 OK:** la operación se realizó correctamente.
- **201 Created:** se creó un nuevo recurso.
- **204 No Content:** la operación se realizó correctamente y no devuelve contenido.
- **400 Bad Request:** los datos enviados no son válidos.
- **404 Not Found:** el recurso solicitado no existe.

## 3. Conexión con MySQL y usuarios

Se investigó cómo conectar la API con MySQL utilizando Dapper y MySqlConnector.

También se trabajó con diferentes usuarios de base de datos para separar los permisos:

- **Administrador:** permite realizar operaciones de lectura y escritura.
- **Usuario de lectura:** permite consultar información sin modificar los datos.

Las cadenas de conexión se configuraron mediante variables de entorno para evitar escribir las credenciales directamente en el código.

## 4. DTO y servicios

Se investigó el uso de DTO (Data Transfer Objects) para definir los datos que recibe y devuelve la API.

Esto permite separar la información que se utiliza internamente de la información que se intercambia mediante solicitudes HTTP.

También se trabajó con servicios para mantener las reglas de negocio separadas de los endpoints. De esta manera, la API se encarga de recibir las solicitudes y los servicios de ejecutar la lógica correspondiente.

## 5. Program.cs y Swagger

Se investigó cómo configurar la API desde el archivo `Program.cs`.

En este archivo se registran los servicios necesarios, las dependencias y los endpoints que estarán disponibles.

También se utilizó Swagger para visualizar y probar las operaciones de la API sin tener que utilizar una aplicación externa.

## 6. Validaciones y manejo de errores

Durante el desarrollo se trabajó con validaciones para evitar registrar envíos con información incorrecta.

Por ejemplo, se controla que el peso y la distancia sean mayores que cero y que la modalidad corresponda a una de las opciones permitidas.

También se investigó cómo devolver respuestas HTTP adecuadas cuando ocurre un error, como un envío inexistente o una solicitud con datos inválidos.

## 7. Pruebas y copias de seguridad

Se utilizaron pruebas con xUnit para comprobar el funcionamiento de los servicios.

Además, se investigó cómo generar una copia de seguridad de MySQL mediante un archivo SQL que contiene la estructura y los datos de la base de datos.

Esto permite recuperar la información del sistema si fuera necesario.

## 8. Conclusión

La investigación permitió comprender mejor cómo funciona una API y cómo se relacionan sus diferentes partes.

También ayudó a tomar decisiones sobre la organización del proyecto, la conexión con MySQL, la validación de datos, el manejo de errores y la seguridad de las conexiones.