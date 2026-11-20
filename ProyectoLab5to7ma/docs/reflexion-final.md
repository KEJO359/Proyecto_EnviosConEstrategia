# Reflexión final del proyecto

## 1. Comparación entre el modelo inicial y el resultado final

Al comenzar el proyecto, se había planteado desarrollar una API sencilla para gestionar envíos, con dos modalidades: estándar y express.

Durante el desarrollo, el sistema fue tomando una forma más completa. Se incorporaron diferentes endpoints para registrar, consultar, actualizar, cotizar y eliminar envíos, además de modificar sus estados.

También se trabajó con MySQL para almacenar la información y con Swagger para probar las operaciones de la API.

## 2. Decisiones que cambiaron durante el desarrollo

**Primera decisión: organización del proyecto.**

Inicialmente se tenía una idea general de cómo separar las responsabilidades. Durante el desarrollo se organizó el sistema en proyectos diferentes, como API, Aplicación, Persistencia y Tests. Esto permitió mantener el código más ordenado y separar la lógica de las operaciones HTTP y el acceso a la base de datos.

**Segunda decisión: seguridad de las conexiones.**

Al principio, las credenciales de MySQL estaban escritas directamente en el código. Después se decidió utilizar variables de entorno para guardar las cadenas de conexión. De esta manera, las credenciales no quedan expuestas directamente en los archivos del proyecto.

## 3. Dificultad encontrada

Una de las dificultades fue configurar correctamente la conexión entre la API y MySQL, especialmente al trabajar con diferentes usuarios y permisos.

También fue necesario revisar las respuestas HTTP y probar los endpoints para comprobar que cada operación funcionara correctamente.

Estas dificultades se fueron resolviendo mediante pruebas y revisiones del código.

## 4. Mejoras posibles

Una mejora que se podría realizar en el futuro sería agregar autenticación y autorización para controlar quién puede utilizar las diferentes operaciones de la API.

También se podrían incorporar nuevas modalidades de envío y más funcionalidades para ampliar el sistema.

## 5. Conclusión personal

Este proyecto permitió aplicar conocimientos de C#, .NET, MySQL y programación orientada a objetos en un sistema más completo.

Además, permitió aprender cómo funciona una API, cómo se comunica con una base de datos y cómo se pueden probar sus operaciones mediante HTTP y Swagger.

Considero que fue una experiencia útil para comprender mejor el desarrollo de aplicaciones y la importancia de organizar correctamente el código.