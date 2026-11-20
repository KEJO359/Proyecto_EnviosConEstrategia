# Modelo inicial del sistema

## 1. Entidades principales

El sistema va a trabajar principalmente con la entidad `Envio`.

Cada envío tendrá los siguientes datos:

- Identificador.
- Peso del paquete.
- Distancia.
- Destino.
- Modalidad.
- Estado.

También se utilizarán las modalidades `EnvioEstandar` y `EnvioExpress`, que tendrán diferentes formas de calcular el costo y el tiempo estimado de entrega.

## 2. Modalidades de envío

**Envío estándar**

- Costo base: $1.000.
- Costo por kilogramo: $200.
- Costo por kilómetro: $10.
- Tiempo estimado: 5 días.

**Envío express**

- Costo base: $2.000.
- Costo por kilogramo: $350.
- Costo por kilómetro: $20.
- Tiempo estimado: 2 días.

Cada modalidad tendrá su propio cálculo de cotización, evitando mezclar las reglas de una modalidad con las de otra.

## 3. Estados del envío

Inicialmente se propone utilizar los siguientes estados:

- `PENDIENTE`: el envío fue registrado.
- `DESPACHADO`: el envío salió para su entrega.
- `ENTREGADO`: el envío llegó a su destino.
- `CANCELADO`: el envío fue cancelado.

La idea es que los estados sigan un orden y no se pueda pasar directamente de pendiente a entregado. También se deberán respetar las restricciones para evitar modificar un envío que ya fue entregado o cancelado.

## 4. Responsabilidades del sistema

El sistema tendrá diferentes partes:

- **API:** recibe las solicitudes HTTP y devuelve las respuestas correspondientes.
- **Aplicación:** contiene la lógica y las reglas del sistema.
- **Persistencia:** se encarga de comunicarse con MySQL y acceder a los datos.
- **Tests:** contiene las pruebas para comprobar el funcionamiento de la aplicación.

Esta separación permite organizar el código y mantener cada responsabilidad en su lugar.

## 5. Base de datos

Se utilizará MySQL para guardar los envíos y sus datos relacionados.

También se trabajará con distintos usuarios de base de datos: uno administrador, con permisos para realizar modificaciones, y otro usuario de lectura, que tendrá permisos limitados para consultar la información.

## 6. Conclusión

Este modelo inicial sirve como una guía para comenzar el desarrollo. Durante el proyecto se podrán realizar ajustes según las necesidades de la API y los requisitos de la consigna.