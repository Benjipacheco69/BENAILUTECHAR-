using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace SistemaAsistenciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcacionesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MarcacionesController(IConfiguration configuration) => _configuration = configuration;

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] MarcacionRequest datos)
        {
            if (datos == null || string.IsNullOrWhiteSpace(datos.CI) || (datos.Tipo != "ENTRADA" && datos.Tipo != "SALIDA"))
                return BadRequest(new { mensaje = "Debe indicar un CI y un tipo válido" });
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();
            string consultaTrabajador = @"SELECT IdTrabajador FROM Trabajadores WHERE CI = @CI AND Estado = 1";
            using SqlCommand buscar = new SqlCommand(consultaTrabajador, conexion);
            buscar.Parameters.AddWithValue("@CI", datos.CI);
            object? resultado = await buscar.ExecuteScalarAsync();
            if (resultado == null) return NotFound(new { mensaje = "Trabajador no encontrado o desactivado" });
            int idTrabajador = Convert.ToInt32(resultado);
            string consultaUltima = @"SELECT TOP 1 Tipo FROM Marcaciones WHERE IdTrabajador = @Id AND CAST(FechaHora AS DATE) = CAST(GETDATE() AS DATE) ORDER BY FechaHora DESC, IdMarcacion DESC";
            using SqlCommand ultima = new SqlCommand(consultaUltima, conexion);
            ultima.Parameters.AddWithValue("@Id", idTrabajador);
            object? ultimoTipo = await ultima.ExecuteScalarAsync();
            if (ultimoTipo == null && datos.Tipo != "ENTRADA")
                return BadRequest(new { mensaje = "La primera marcación del día debe ser ENTRADA" });
            if (ultimoTipo != null && ultimoTipo.ToString() == datos.Tipo)
                return BadRequest(new { mensaje = "La marcación debe alternar entre ENTRADA y SALIDA" });
            string insertar = @"INSERT INTO Marcaciones (IdTrabajador, FechaHora, Tipo) VALUES (@Id, GETDATE(), @Tipo)";
            using SqlCommand comando = new SqlCommand(insertar, conexion);
            comando.Parameters.AddWithValue("@Id", idTrabajador);
            comando.Parameters.AddWithValue("@Tipo", datos.Tipo);
            await comando.ExecuteNonQueryAsync();
            return Ok(new { mensaje = "Marcación registrada correctamente", ci = datos.CI, tipo = datos.Tipo });
        }

        [HttpGet]
        public async Task<IActionResult> Todas(DateTime? fecha)
        {
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();
            string consulta = @"SELECT T.CI, T.Nombres, T.Apellidos, M.FechaHora, M.Tipo FROM Marcaciones M INNER JOIN Trabajadores T ON M.IdTrabajador = T.IdTrabajador WHERE (@Fecha IS NULL OR (M.FechaHora >= @Inicio AND M.FechaHora < @Fin)) ORDER BY M.FechaHora DESC";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha.HasValue ? fecha.Value.Date : DBNull.Value;
            comando.Parameters.Add("@Inicio", SqlDbType.DateTime2).Value = fecha.HasValue ? fecha.Value.Date : DBNull.Value;
            comando.Parameters.Add("@Fin", SqlDbType.DateTime2).Value = fecha.HasValue ? fecha.Value.Date.AddDays(1) : DBNull.Value;
            using SqlDataReader lector = await comando.ExecuteReaderAsync();
            var registros = new List<object>();
            while (await lector.ReadAsync())
                registros.Add(new { ci = lector["CI"], nombres = lector["Nombres"], apellidos = lector["Apellidos"], fechaHora = lector["FechaHora"], tipo = lector["Tipo"] });
            return Ok(registros);
        }

        [HttpGet("reporte")]
        public async Task<IActionResult> Reporte(DateTime? fechaInicio, DateTime? fechaFin)
        {
            if (!fechaInicio.HasValue || !fechaFin.HasValue || fechaInicio.Value.Date > fechaFin.Value.Date)
                return BadRequest(new { mensaje = "Debe indicar un periodo válido" });
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();
            string consulta = @"SELECT T.CI, T.Nombres, T.Apellidos, SUM(CASE WHEN M.Tipo = 'ENTRADA' THEN 1 ELSE 0 END) AS TotalEntradas, SUM(CASE WHEN M.Tipo = 'SALIDA' THEN 1 ELSE 0 END) AS TotalSalidas, COUNT(M.IdMarcacion) AS TotalMarcaciones FROM Trabajadores T LEFT JOIN Marcaciones M ON T.IdTrabajador = M.IdTrabajador AND M.FechaHora >= @Inicio AND M.FechaHora < @Fin GROUP BY T.CI, T.Nombres, T.Apellidos ORDER BY T.Apellidos, T.Nombres";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.Add("@Inicio", SqlDbType.DateTime2).Value = fechaInicio.Value.Date;
            comando.Parameters.Add("@Fin", SqlDbType.DateTime2).Value = fechaFin.Value.Date.AddDays(1);
            using SqlDataReader lector = await comando.ExecuteReaderAsync();
            var reporte = new List<object>();
            while (await lector.ReadAsync())
                reporte.Add(new { ci = lector["CI"], nombres = lector["Nombres"], apellidos = lector["Apellidos"], totalEntradas = lector["TotalEntradas"], totalSalidas = lector["TotalSalidas"], totalMarcaciones = lector["TotalMarcaciones"] });
            return Ok(reporte);
        }

        [HttpGet("{ci}")]
        public async Task<IActionResult> Historial(string ci)
        {
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();
            string consulta = @"SELECT T.CI, T.Nombres, T.Apellidos, M.FechaHora, M.Tipo FROM Marcaciones M INNER JOIN Trabajadores T ON M.IdTrabajador = T.IdTrabajador WHERE T.CI = @CI ORDER BY M.FechaHora DESC";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@CI", ci);
            using SqlDataReader lector = await comando.ExecuteReaderAsync();
            var registros = new List<object>();
            while (await lector.ReadAsync())
                registros.Add(new { ci = lector["CI"], nombres = lector["Nombres"], apellidos = lector["Apellidos"], fechaHora = lector["FechaHora"], tipo = lector["Tipo"] });
            return Ok(registros);
        }
    }

    public class MarcacionRequest
    {
        public string CI { get; set; } = "";
        public string Tipo { get; set; } = "";
    }
}