# ProyectoProductoMVC

Este es un proyecto de ejemplo utilizando el patrón Modelo-Vista-Controlador (MVC) en .NET para implementar funcionalidades CRUD (Crear, Leer, Actualizar, Eliminar) con una base de datos SQL Server.

## Requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versión 6.0 o superior)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) (opcional, pero recomendado)

## Configuración e Instalación

### Clonar el Repositorio

```sh
git clone https://github.com/AlexWill27/ProyectoProductoMVC.git
cd ProyectoProductoMVC
```

### Configurar la Base de Datos

1. Crea una nueva base de datos en SQL Server.
2. Actualiza la cadena de conexión en `appsettings.json` con los detalles de tu base de datos:

    ```json
    "ConnectionStrings": {
        "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_user;Password=your_password;"
    }
    ```

### Ejecutar Migraciones

Aplica las migraciones para crear las tablas necesarias en la base de datos:

```sh
dotnet ef database update
```

### Ejecutar la Aplicación

Inicia la aplicación con el siguiente comando:

```sh
dotnet run
```

## Uso

Una vez que la aplicación esté en funcionamiento, puedes acceder a ella en `http://localhost:5000`. La aplicación proporciona interfaces para realizar operaciones CRUD en la base de datos.

## Estructura del Proyecto

- **Controllers/**: Controladores de MVC.
- **Models/**: Modelos de datos.
- **Views/**: Vistas de Razor.
- **Data/**: Contexto de la base de datos y migraciones.

## Contribuciones

Las contribuciones son bienvenidas. Por favor, abre un issue o crea un pull request para contribuir.

## Licencia

Este proyecto está bajo la Licencia MIT. Mira el archivo [LICENSE](LICENSE) para más detalles.

