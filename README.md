# Proyecto ASP.NET Core MVC

## Índice

- [Descripción](#descripción)
- [Características](#características)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Requisitos](#requisitos)
- [Configuración](#configuración)
- [Uso](#uso)
  - [Sistema de Login](#sistema-de-login)
  - [Gestión de Usuarios](#gestión-de-usuarios)
- [Contribuciones](#contribuciones)


## Descripción

Este proyecto consiste en una aplicación web desarrollada con ASP.NET Core MVC que permite la gestión de usuarios a través de un sistema de autenticación. La aplicación se conecta a una base de datos MySQL utilizando Entity Framework Core.

## Características

- **Sistema de Login**: Los usuarios pueden iniciar sesión utilizando su `nombre_usuario` y `password`.
- **Listado de Usuarios**: Una vez autenticado, el usuario puede ver un listado de todos los usuarios en la base de datos.
- **CRUD de Usuarios**: Funcionalidades para crear, leer, actualizar y eliminar usuarios en la base de datos.

## Estructura del Proyecto

El proyecto tiene la siguiente estructura:

- **Controllers**
  - `AccesoController.cs`: Controlador para la autenticación de usuarios.
  - `UsuariosController.cs`: Controlador para la gestión de usuarios.
- **Data**
  - `AppDBContext.cs`: Contexto de la base de datos.
- **Migrations**
  - `primera_migracion.cs`, `appDBContextModelSnapshot.cs`: Archivos de migración de Entity Framework.
- **Models**
  - `Usuario.cs`: Modelo que representa a un usuario.
- **ViewModels**
  - `LoginVM.cs`, `UsuarioVM.cs`: Modelos para las vistas de login y gestión de usuarios.
- **Views**
  - `Acceso`
    - `Login.cshtml`, `Registrarse.cshtml`: Vistas para la autenticación.
  - `Usuarios`
    - `Index.cshtml`, `Create.cshtml`, `Edit.cshtml`, `Delete.cshtml`: Vistas para la gestión de usuarios.
  - `Shared`
    - `_Layout.cshtml`, `_ValidationScripts.cshtml`, `Error.cshtml`: Vistas compartidas.
  - `_ViewImports.cshtml`, `_ViewStart.cshtml`: Configuraciones de vistas.
- **Root**
  - `appsettings.json`: Configuraciones de la aplicación.
  - `Program.cs`: Configuración y arranque de la aplicación.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL](https://www.mysql.com/downloads/) o [Microsoft SQL Server Manager Studio](https://www.microsoft.com/es-cl/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)

## Configuración

1. Clonar el repositorio:
    ```sh
    git clone https://github.com/usuario/proyecto-aspnet-core-mvc.git
    ```
2. Configurar la cadena de conexión a la base de datos en `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "CadenaSQL": "Server=localhost;Database=nombre_base_datos;User=root;Password=root;"
      }
    }
    ```
3. Ejecutar las migraciones de Entity Framework para crear la base de datos:
    ```sh
    dotnet ef database update
    ```
4. Ejecutar la aplicación:
    ```sh
    dotnet run
    ```

## Uso

### Sistema de Login

1. Acceder a la vista de login (`/Acceso/Login`).
2. Ingresar `nombre_usuario` y `password`.
3. Si las credenciales son correctas, se redirigirá al listado de usuarios.

### Gestión de Usuarios

- **Ver Usuarios**: Acceder a `/Usuarios/Index`.
- **Agregar Usuario**: Hacer clic en el botón "Agregar Usuario" y llenar el formulario.
- **Editar Usuario**: Hacer clic en "Editar" junto al usuario correspondiente.
- **Eliminar Usuario**: Hacer clic en "Eliminar" junto al usuario correspondiente.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, envía un pull request o abre un issue para discutir los cambios propuestos.

