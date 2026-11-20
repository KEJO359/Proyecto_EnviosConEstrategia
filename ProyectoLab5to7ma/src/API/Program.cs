
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Persistencia.Conexion;
using Persistencia.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDBConnectionFactory, ConexionAdministrador>();
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<ServicioEnvio>();

// Estrategias de cotización
builder.Services.AddScoped<IEstrategiaCotizacion, EstrategiaEstandar>();
builder.Services.AddScoped<IEstrategiaCotizacion, EstrategiaExpress>();
builder.Services.AddScoped<IEstrategiaCotizacion, EstrategiaPrioritaria>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// GET: listar envíos
app.MapGet("/api/envios", (ServicioEnvio servicio) =>
{
    var envios = servicio.ListarEnvios();
    return Results.Ok(envios);
});

// GET: obtener un envío por ID
app.MapGet("/api/envios/{id}", (int id, ServicioEnvio servicio) =>
{
    var envio = servicio.ObtenerEnvioPorId(id);

    if (envio == null)
    {
        return Results.NotFound("No se encontró el envío.");
    }

    return Results.Content(envio, "application/json");
});

// GET: obtener cotización de un envío
app.MapGet("/api/envios/{id}/cotizacion", (int id, ServicioEnvio servicio) =>
{
    var cotizacion = servicio.ObtenerCotizacion(id);

    if (cotizacion == null)
    {
        return Results.NotFound("No se encontró el envío.");
    }

    return Results.Ok(cotizacion);
});

// POST: registrar un envío
app.MapPost("/api/envios", (RegistrarEnvioRequest solicitud, ServicioEnvio servicio) =>
{
    try
    {
        int idEnvio = servicio.RegistrarEnvio(
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

        var envio = servicio.ObtenerEnvioPorId(idEnvio);

        return Results.Created(
            $"/api/envios/{idEnvio}",
            System.Text.Json.JsonSerializer.Deserialize<System.Text.Json.JsonElement>(envio!)
        );
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// PUT: actualizar un envío
app.MapPut("/api/envios/{id}", (
    int id,
    ActualizarEnvioRequest solicitud,
    ServicioEnvio servicio) =>
{
    try
    {
        bool actualizado = servicio.ActualizarEnvio(
            id,
            solicitud.Modalidad,
            solicitud.PesoKg,
            solicitud.DistanciaKm,
            solicitud.Calle,
            solicitud.DireccionPostal,
            solicitud.Localidad
        );

        if (!actualizado)
        {
            return Results.NotFound("No se encontró el envío.");
        }

        var envio = servicio.ObtenerEnvioPorId(id);

        return Results.Content(envio!, "application/json");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// PATCH: cambiar estado de un envío
app.MapPatch("/api/envios/{id}/estado", (
    int id,
    CambiarEstadoRequest solicitud,
    ServicioEnvio servicio) =>
{
    try
    {
        servicio.CambiarEstado(id, solicitud.Estado);

        return Results.Ok("Estado actualizado correctamente.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

// DELETE: cancelar un envío
app.MapDelete("/api/envios/{id}", (int id, ServicioEnvio servicio) =>
{
    var envio = servicio.ObtenerEnvioPorId(id);

    if (envio == null)
    {
        return Results.NotFound("No se encontró el envío.");
    }

    try
    {
        servicio.Cancelar(id);
        return Results.NoContent();
    }
    catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
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

public record ActualizarEnvioRequest(
    string Modalidad,
    double PesoKg,
    double DistanciaKm,
    string Calle,
    string DireccionPostal,
    string Localidad
);

public record CambiarEstadoRequest(string Estado);
