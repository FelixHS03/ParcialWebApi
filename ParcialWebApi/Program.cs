using Microsoft.EntityFrameworkCore;
using ParcialWebApi.Data;
using ParcialWebApi.Interfaces;
using ParcialWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Cadena de conexión (desde appsettings.json)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registrar DbContext con SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// 3. Registrar servicios propios (DI)
builder.Services.AddScoped<IFechaService, FechaService>();

// 4. Controllers y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Middleware de Swagger (solo dev)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// 6. Endpoints de controllers
app.MapControllers();

app.Run();
