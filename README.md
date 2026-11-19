# APIDemoLab - Code First (Semana 13)

API REST en ASP.NET Core (.NET 8) con Entity Framework Core Code First y SQL Server.

## Modelo
`Grade` 1 - N `Student` 1 - N `Enrollment` N - 1 `Course`

## Requisitos
- Visual Studio 2022 con la carga de trabajo **ASP.NET y desarrollo web**
- SQL Server Express (instancia `SQLEXPRESS01`; si cambias de PC, ajusta el nombre del servidor en la cadena de conexion)

## Puesta en marcha
1. Revisar la cadena de conexion en `APIDemoLab/appsettings.json` (usa autenticacion de Windows).
2. En la Consola del Administrador de paquetes (proyecto predeterminado `APIDemoLab`):
   ```
   Add-Migration InitialCreate
   Update-Database
   ```
3. Opcional: ejecutar `Database/datos_de_prueba.sql` en SSMS para tener datos.
4. Ejecutar el proyecto (F5): se abre Swagger en `/swagger`.

## Endpoints
| Metodo | Ruta | Descripcion |
|---|---|---|
| GET / POST | `api/Grades` | Listar activos / crear |
| GET / PUT / DELETE | `api/Grades/{id}` | Obtener / actualizar / eliminacion logica |
| GET / POST | `api/Courses` | Listar activos / crear |
| GET / PUT / DELETE | `api/Courses/{id}` | Obtener / actualizar / eliminacion logica |
