# WebAPI-Gestion-de-Usuarios
> Trabajo para el profesor @jonathanvgms *jonathan velazquez*

## Contexto
La empresa ABC posee múltiples aplicaciones web en donde cada una de ella gestiona sus usuarios de forma local e independiente. Se busca unificar los usuarios de todas las aplicaciones para que un único usuario pueda acceder a cada una de las aplicaciones con la misma credenciales.

## Datos
Nuestro especialista en datos representó mediante el siguiente diagrama como se almacenarán los datos en la base de datos, la cual se realizará con Postgres. 

![image 549VT2](https://github.com/user-attachments/assets/52bdcc5f-413a-469f-8026-787f98e8a36e)

## Aplicación
Nuestro analista de sistemas llegó a conclusión para esta primera etapa del desarrollo se debe realizar una Web API con persistencia de datos, dejando para una próxima etapa la realización de un frontend.

Por lo cual especifica por cada entidad que endpoints se deben confeccionar y su comportamiento esperado, especificado en las siguientes tablas.

![Captura de pantalla de 2024-09-13 14-30-46](https://github.com/user-attachments/assets/06e7db56-164a-4f5a-914d-236f180761c7)

![Captura de pantalla de 2024-09-13 14-31-22](https://github.com/user-attachments/assets/8984267d-dfb5-400b-9eac-24ff1d1ab3c9)

> [!IMPORTANT]
> Además, se debe poder asignar y desasignar un rol a un usuario y un usuario a un rol.

![Captura de pantalla de 2024-09-13 14-31-38](https://github.com/user-attachments/assets/09f220c3-3507-4a6d-a3b4-c7e0fd8e05ac)

## En base a los requerimientos se pide:

1. Crear el proyecto de Web API en .NET o Nodejs
2. Crear las entidades correspondientes que modelan los objetos del dominio del requerimiento
3. Crear los controladores con endpoints para las acciones descritas en la tabla para cada uno de los objetos de dominio
4. Verificar el correcto funcionamiento de cada endpoint desde Swagger
5. Realizar pruebas de integración (desde el archivo *.http):
   * Agregar y eliminar roles a usuarios
   * Agregar y eliminar usuarios  a roles
6. Subir código fuente del proyecto web a un repositorio github (se debe entregar únicamente el enlace al repositorio)
