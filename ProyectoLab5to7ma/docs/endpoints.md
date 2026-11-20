# Endpoints de la API

## 1. ¿Qué es un endpoint?

Un endpoint es una dirección de la API que permite realizar una operación mediante una solicitud HTTP.

En este proyecto vamos a utilizar los métodos GET, POST, PUT, PATCH y DELETE.

## 2. Endpoints del sistema

| Método | Ruta | Función |
|---|---|---|
| POST | `/api/envios` | Registrar un envío. |
| GET | `/api/envios` | Listar todos los envíos. |
| GET | `/api/envios/{id}` | Consultar un envío por su ID. |
| GET | `/api/envios/{id}/cotizacion` | Obtener el costo y tiempo estimado. |
| PUT | `/api/envios/{id}` | Actualizar los datos de un envío. |
| PATCH | `/api/envios/{id}/estado` | Cambiar el estado de un envío. |
| DELETE | `/api/envios/{id}` | Eliminar un envío. |

## 3. Métodos HTTP

- **GET:** se utiliza para consultar información.
- **POST:** se utiliza para crear un nuevo envío.
- **PUT:** se utiliza para actualizar los datos de un envío.
- **PATCH:** se utiliza para modificar una parte de la información, como el estado.
- **DELETE:** se utiliza para eliminar un envío.

## 4. Ejemplo de funcionamiento

Si queremos consultar el envío con ID 5, realizamos una solicitud GET a:

`/api/envios/5`

La API buscará ese envío y devolverá sus datos si existe.

## 5. Conclusión

Estos endpoints serán los principales puntos de acceso al sistema. A través de ellos se podrán realizar las operaciones necesarias para administrar los envíos.