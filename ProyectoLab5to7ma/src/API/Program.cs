using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Persistencia.Conexion;
using Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddScoped<IDBConnectionFactory, ConexionAdministrador>();
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<ServicioEnvio>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// GET: listar envios
app.MapGet("/api/envios", (ServicioEnvio servicio) =>
{
    var envios = servicio.ListarEnvios();
    return Results.Ok(envios);
});

// GET: obtener un envio por ID
app.MapGet("/api/envios/{id}", (int id, ServicioEnvio servicio) =>
{
    var envio = servicio.ObtenerEnvioPorId(id);

    if (envio == null)
    {
        return Results.NotFound("No se encontró el envío.");
    }

    return Results.Content(envio, "application/json");
});

// POST: registrar un envio
app.MapPost("/api/envios", (RegistrarEnvioRequest solicitud, ServicioEnvio servicio) =>
{
    servicio.RegistrarEnvio(
        solicitud.IdCliente,
        solicitud.IdOrigen,
        solicitud.IdDestino,
        solicitud.Peso,
        solicitud.Alto,
        solicitud.Ancho,
        solicitud.Largo,
        solicitud.Distancia,
        solicitud.Modalidad
    );

    return Results.Ok("Envio registrado correctamente");
});

app.Run();

public record RegistrarEnvioRequest(
    int IdCliente,
    int IdOrigen,
    int IdDestino,
    double Peso,
    double Alto,
    double Ancho,
    double Largo,
    double Distancia,
    string Modalidad
);
