namespace FarmaControlAPI.Controller
{
    using FarmaControlAPI.Repository;
    using Microsoft.AspNetCore.Mvc;
    using SharedModels;
    using SharedModels.Dtos.Usuario;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository<Usuario> _repository;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(IUsuarioRepository<Usuario> repository, ILogger<UsuarioController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                _logger.LogInformation("Obteniendo todos los usuarios");
                var users = await _repository.GetAllAsync();

                var userDtos = users.Select(user => new UsuarioDto
                {
                    IdUser = user.IdUser,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    IdEmployee = user.IdEmployee,
                    Role = user.Role,
                    CreatedDate = user.CreatedDate,
                    ModifiedDate = user.ModifiedDate
                });
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los usuarios: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los usuarios");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                _logger.LogInformation($"Obteniendo usuario con ID {id}");
                var user = await _repository.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound("Usuario no encontrado");
                }
                var userDto = new UsuarioDto
                {
                    IdUser = user.IdUser,
                    Username = user.Username,
                    PasswordHash = user.PasswordHash,
                    IdEmployee = user.IdEmployee,
                    Role = user.Role,
                    CreatedDate = user.CreatedDate,
                    ModifiedDate = user.ModifiedDate
                };

                return Ok(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener usuario con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el usuario");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsuarioUpdateDto userDto)
        {
            if (userDto == null || id != userDto.IdUser || !ModelState.IsValid)
            {
                return BadRequest("Los datos del usuario son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando usuario con ID {id}");

                var existingUser = await _repository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning($"Usuario con ID {id} no encontrado.");
                    return NotFound("Usuario no encontrado.");
                }

                existingUser.Username = userDto.Username;
                existingUser.PasswordHash = userDto.PasswordHash;
                existingUser.IdEmployee = userDto.IdEmployee;
                existingUser.Role = userDto.Role;
                existingUser.ModifiedDate = DateTime.Now; // Actualizamos la fecha de modificación

                var updated = await _repository.UpdateAsync(existingUser);
                if (updated)
                {
                    _logger.LogInformation($"Usuario con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el usuario.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar usuario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el usuario");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDto userDto)
        {
            if (userDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del usuario son inválidos");
            }

            try
            {
                var employeeExists = await _repository.EmployeeExistAsync(userDto.IdEmployee);
                if (employeeExists)
                {
                    return BadRequest("Ya existe un usuario con este Id_Employee.");
                }

                var user = new Usuario
                {
                    Username = userDto.Username,
                    PasswordHash = userDto.PasswordHash,
                    IdEmployee = userDto.IdEmployee,
                    Role = userDto.Role,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

                var createdUserId = await _repository.CreateAsync(user);
                if (createdUserId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdUserId }, user);
                }

                return BadRequest("No se pudo crear el usuario");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear usuario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el usuario");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando usuario con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent(); 
                }
                return NotFound("Usuario no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar usuario con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el usuario");
            }
        }
    }
}
