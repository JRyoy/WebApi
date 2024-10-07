using Api.Migraciones;
using Api.Migraciones.ServiceManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios y configuración de base de datos
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicacionDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// Registrar servicios a través de ServiceManager
builder.Services.AddServiceManager();  // Llamar al método para agregar servicios

var app = builder.Build();

// Configuración de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Agregar Swagger para documentación (si estás en desarrollo)
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();  // Mapear controladores
});

app.Run();
