using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SistemaAsistenciaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrabajadoresController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TrabajadoresController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // REGISTRAR TRABAJADOR
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] TrabajadorRequest trabajador)
        {
            if (trabajador == null ||
                string.IsNullOrWhiteSpace(trabajador.CI) ||
                string.IsNullOrWhiteSpace(trabajador.Nombres) ||
                string.IsNullOrWhiteSpace(trabajador.Apellidos))
                return BadRequest(new { mensaje = "Todos los campos son obligatorios" });

            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            try
            {
                using SqlConnection conexion = new SqlConnection(cadena);
                await conexion.OpenAsync();

                string consulta = @"
                    INSERT INTO Trabajadores (CI, Nombres, Apellidos)
                    OUTPUT INSERTED.IdTrabajador
                    VALUES (@CI, @Nombres, @Apellidos)";
                using SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CI", trabajador.CI);
                comando.Parameters.AddWithValue("@Nombres", trabajador.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", trabajador.Apellidos);

                int id = Convert.ToInt32(await comando.ExecuteScalarAsync());
                return Ok(new { mensaje = "Trabajador registrado correctamente", idTrabajador = id });
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                return Conflict(new { mensaje = "Ya existe un trabajador con ese CI" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "No se pudo registrar el trabajador" });
            }
        }

        // BUSCAR TRABAJADOR POR CI
        [HttpGet("{ci}")]
        public async Task<IActionResult> Buscar(string ci)
        {
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();

            string consulta = @"
                SELECT IdTrabajador, CI, Nombres, Apellidos
                FROM Trabajadores WHERE CI = @CI AND Estado = 1";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@CI", ci);
            using SqlDataReader lector = await comando.ExecuteReaderAsync();

            if (!await lector.ReadAsync())
                return NotFound(new { mensaje = "Trabajador no encontrado" });

            return Ok(new {
                idTrabajador = lector["IdTrabajador"], ci = lector["CI"],
                nombres = lector["Nombres"], apellidos = lector["Apellidos"]
            });
        }

        // LISTAR TRABAJADORES
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();

            string consulta = @"
                SELECT IdTrabajador, CI, Nombres, Apellidos, Estado
                FROM Trabajadores ORDER BY Apellidos, Nombres";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            using SqlDataReader lector = await comando.ExecuteReaderAsync();

            var trabajadores = new List<object>();
            while (await lector.ReadAsync())
            {
                trabajadores.Add(new {
                    idTrabajador = lector["IdTrabajador"], ci = lector["CI"],
                    nombres = lector["Nombres"], apellidos = lector["Apellidos"],
                    estado = lector["Estado"]
                });
            }
            return Ok(trabajadores);
        }

        // MODIFICAR TRABAJADOR
        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] TrabajadorRequest trabajador)
        {
            if (trabajador == null ||
                string.IsNullOrWhiteSpace(trabajador.CI) ||
                string.IsNullOrWhiteSpace(trabajador.Nombres) ||
                string.IsNullOrWhiteSpace(trabajador.Apellidos))
                return BadRequest(new { mensaje = "Todos los campos son obligatorios" });

            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            try
            {
                using SqlConnection conexion = new SqlConnection(cadena);
                await conexion.OpenAsync();

                string consulta = @"
                    UPDATE Trabajadores
                    SET CI = @CI, Nombres = @Nombres, Apellidos = @Apellidos
                    WHERE IdTrabajador = @Id";
                using SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Id", id);
                comando.Parameters.AddWithValue("@CI", trabajador.CI);
                comando.Parameters.AddWithValue("@Nombres", trabajador.Nombres);
                comando.Parameters.AddWithValue("@Apellidos", trabajador.Apellidos);

                int filas = await comando.ExecuteNonQueryAsync();
                if (filas == 0)
                    return NotFound(new { mensaje = "Trabajador no encontrado" });

                return Ok(new { mensaje = "Trabajador actualizado correctamente" });
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                return Conflict(new { mensaje = "Ya existe otro trabajador con ese CI" });
            }
            catch (Exception)
            {
                return StatusCode(500, new { mensaje = "No se pudo modificar el trabajador" });
            }
        }

        // DESACTIVAR TRABAJADOR SIN ELIMINAR SU HISTORIAL
        [HttpPatch("{id}/desactivar")]
        public async Task<IActionResult> Desactivar(int id)
        {
            string cadena = _configuration.GetConnectionString("ConexionSQL")!;
            using SqlConnection conexion = new SqlConnection(cadena);
            await conexion.OpenAsync();

            string consulta = @"
                UPDATE Trabajadores SET Estado = 0
                WHERE IdTrabajador = @Id AND Estado = 1";
            using SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@Id", id);

            int filas = await comando.ExecuteNonQueryAsync();
            if (filas == 0)
                return NotFound(new { mensaje = "Trabajador no encontrado o ya está desactivado" });

            return Ok(new { mensaje = "Trabajador desactivado correctamente" });
        }
    }

    public class TrabajadorRequest
    {
        public string CI { get; set; } = "";
        public string Nombres { get; set; } = "";
        public string Apellidos { get; set; } = "";
    }
}