
using ejemploApi.Domain.Models;
using ejemploApi.Repository;
using ejemploApi.Service;
using ejemploApi.Service.ServiceImplement;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Leer la cadena de conexion desde la variable de entorno
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                    ?? builder.Configuration.GetConnectionString("DefaultConnection");

// Agregar el DbContext y configurar la cadena de conexion
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUsuariosService, UsuariosSevice>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
