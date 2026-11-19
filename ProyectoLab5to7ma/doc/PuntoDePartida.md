# Punto de partida del proyecto

## 1. Descripción del proyecto

Este proyecto consiste en desarrollar una API para gestionar envíos. La idea es continuar con el trabajo realizado anteriormente, pero ahora permitiendo realizar las operaciones mediante solicitudes HTTP.

La API permitirá registrar envíos, consultar la información, obtener cotizaciones, actualizar datos, cambiar estados y eliminar envíos.

## 2. Objetivo

El objetivo es aprender a desarrollar una API utilizando C# y .NET 10, conectada a una base de datos MySQL.

También se busca aplicar los conocimientos adquiridos anteriormente sobre programación orientada a objetos, interfaces, servicios y persistencia de datos.

## 3. Tecnologías que se utilizarán

- **C#:** lenguaje de programación.
- **.NET 10:** plataforma para desarrollar la API.
- **Minimal API:** para crear los endpoints.
- **MySQL:** para almacenar la información.
- **Dapper:** para realizar consultas a la base de datos.
- **Swagger:** para probar y visualizar los endpoints.
- **xUnit:** para realizar pruebas.

## 4. Funcionamiento general

El sistema trabajará con envíos que tendrán información como el peso, la distancia, el destino, la modalidad y el estado.

Se utilizarán dos modalidades:

- **Estándar:** tiene un costo menor y un tiempo de entrega mayor.
- **Express:** tiene un costo mayor y un tiempo de entrega menor.

Cada envío tendrá un estado que permitirá conocer en qué parte del proceso se encuentra.

## 5. Operaciones principales

La API deberá permitir realizar las siguientes operaciones:

1. Registrar un envío.
2. Listar todos los envíos.
3. Consultar un envío por su identificador.
4. Obtener la cotización de un envío.
5. Actualizar los datos de un envío.
6. Cambiar el estado de un envío.
7. Eliminar un envío.

## 6. Organización inicial

El proyecto se organizará separando las responsabilidades para que el código sea más fácil de entender y mantener.

Se utilizarán carpetas para la API, la lógica de la aplicación, la persistencia de datos, las pruebas, los scripts SQL y la documentación.

## 7. Conclusión

Este proyecto permitirá aplicar los conocimientos de programación y bases de datos en un sistema que utiliza una API para gestionar envíos. Además, servirá para aprender cómo se comunican las aplicaciones mediante HTTP y cómo se trabaja con una base de datos desde una API.