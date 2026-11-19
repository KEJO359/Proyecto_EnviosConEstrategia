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

También se utilizarán las modalidades `EnvioEstandar` y `EnvioExpress`, que tendrán diferentes formas de calcular el costo y el tiempo de entrega.

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

## 3. Estados del envío

Inicialmente se propone utilizar los siguientes estados:

- `PENDIENTE`: el envío fue registrado.
- `DESPACHADO`: el envío salió para su entrega.
- `ENTREGADO`: el envío llegó a su destino.

La idea es que los estados sigan un orden y no se pueda pasar directamente de pendiente a entregado.

## 4. Responsabilidades del sistema

El sistema tendrá diferentes partes:

- **API:** recibe las solicitudes HTTP y devuelve las respuestas.
- **Aplicación:** contiene la lógica y las reglas del sistema.
- **Persistencia:** se encarga de comunicarse con MySQL.
- **Tests:** contiene las pruebas para comprobar el funcionamiento.

## 5. Base de datos

Se utilizará MySQL para guardar los envíos y sus datos.

También se trabajará con distintos usuarios de base de datos, uno administrador y otro con permisos solamente de lectura.

## 6. Conclusión

Este modelo inicial sirve como una guía para comenzar el desarrollo. Durante el proyecto se podrán realizar ajustes según las necesidades de la API y los requisitos de la consigna.