using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/api/conexion", async () =>
{
    var connectionString = builder.Configuration.GetConnectionString("ConexionSQL");
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
            detail = "No se pudo establecer conexión con SQL Server. Revise la configuración local.",
            title = "Error de conexión con SQL Server"
        );
    }
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();