
Tarea
---
1. Crear la base de datos y todos los objetos que creas necesarios para que la aplicación funciones.
2. Insertar una cantidad mínima de datos para poder probar la aplicación.
3. Desarrollar una aplicación web, en un repositorio público, utilizando una herramienta de versionado como
github/bitbucket/etc, que responda a los requisitos descriptos por el cliente.
4. Entregar un diagrama de entidad relación de las tablas planteadas (DER)


Detalles
---
1. Creación de base de datos: realizada mediante Entity Framework, en la solución provista se encuentran los detalles de las entidades en la carpeta Model
2. La cantidad minima de datos se encuentran en el archivo DataInitializer.cs en la carpeta Data
4. DER: 

![DER](https://github.com/rodrigoep94/Solucion-origin/blob/master/DER.PNG)

Instrucciones e información adicional:
---
Versión de .netcore utilizada: 2.2
Versión de Angular utilizada: 8
Base de datos utilizada: SQL Server mediante Entity Framework

Para que la solución migre automáticamente la base de datos e inicialice los mismos, cambiar en el archivo appsettings.json la linea datacontext, poner el nombre de la base de datos a utilizar donde dice "CAMBIARDB", si la misma tuviese usuario para ingresar, agregarlo en la misma linea.

Luego de este paso, iniciar la solución, este inicio hará que se inicialice la base de datos, se carguen los datos, se compile la versión de Angular y levante el backend

Estructura de carpetas
---
* ClientApp : Aplicación web
* Controller: Servicios a consumir
* Interfaces: Interfaces de los repositorios
* Business: Repositorios para acceder a la DB
* Model: Clases de modelo utilizadas para manejar la BD
