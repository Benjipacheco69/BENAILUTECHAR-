using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configuración de OpenAPI
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Prueba de conexión con SQL Server
app.MapGet("/api/conexion", async () =>
{
    var connectionString = builder.Configuration
        .GetConnectionString("ConexionSQL");

    try
    {
        using var conexion = new SqlConnection(connectionString);
        await conexion.OpenAsync();

        return Results.Ok(new
        {
            mensaje = "Conexión con SQL Server exitosa",
            baseDatos = conexion.Database
        });
    }
    catch (Exception)
    {
        return Results.Problem(
            title: "Error de conexión con SQL Server",
            detail: "No se pudo establecer la conexión. Verifica la configuración local."
        );
    }
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
