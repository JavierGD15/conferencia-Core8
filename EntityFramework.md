# Presentación sobre Entity Framework con SQL Server y .NET 8

## Introducción a Entity Framework y .NET 8
- **Entity Framework Core (EF Core)** es un ORM (Object-Relational Mapper) para .NET que permite a los desarrolladores trabajar con bases de datos mediante objetos de C#.
- **SQL Server** es un potente sistema de gestión de bases de datos relacional desarrollado por Microsoft.
- **.NET 8** es la última versión del framework de desarrollo de Microsoft, optimizado para alto rendimiento y escalabilidad.

## Ventajas de Usar Entity Framework con SQL Server en .NET 8
- **Desarrollo más rápido**: Reduce la necesidad de escribir consultas SQL manualmente.
- **Abstracción de la base de datos**: Facilita el cambio de proveedor de base de datos sin alterar el código de la aplicación.
- **Compatibilidad con LINQ**: Permite consultas con una sintaxis intuitiva en C#.
- **Soporte para migraciones**: Facilita la evolución del esquema de la base de datos.
- **Integración con ASP.NET Core**: Ideal para el desarrollo de aplicaciones web y API.

## Configuración de Entity Framework en un Proyecto .NET 8
### 1. Instalación de Entity Framework Core
Ejecutar en la consola de comandos:
```sh
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 2. Configurar el Contexto de Base de Datos
Crear una clase `ApplicationDbContext`:
```csharp
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Product> Products { get; set; }
}
```

### 3. Configurar la Conexión a SQL Server
En `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=MyDatabase;User Id=sa;Password=MyPassword;"
  }
}
```

En `Program.cs`:
```csharp
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.Run();
```

## Manejo de Migraciones
### 1. Crear una Migración
```sh
    dotnet ef migrations add InitialCreate
```

### 2. Aplicar la Migración
```sh
    dotnet ef database update
```

## CRUD con Entity Framework Core
### 1. Definir una Entidad
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```

### 2. Crear un Servicio para Acceso a Datos
```csharp
public class ProductService
{
    private readonly ApplicationDbContext _context;
    public ProductService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts() => await _context.Products.ToListAsync();

    public async Task AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }
}
```

## Mejoras en Entity Framework Core 8
- **Mejoras en el rendimiento de consultas y trazabilidad**.
- **Soporte para JSON en SQL Server**.
- **Mejoras en la configuración de relaciones y optimización de transacciones**.
- **Mejoras en el manejo de transacciones y concurrencia**.

## Conclusiones
- **Entity Framework Core con SQL Server y .NET 8** ofrece una solución poderosa y flexible para el desarrollo de aplicaciones escalables.
- **Permite un desarrollo más eficiente** gracias a la integración con LINQ y el soporte para migraciones automáticas.
- **La nueva versión de EF Core mejora el rendimiento y la compatibilidad con SQL Server**.

