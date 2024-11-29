using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.Empleado;
using SharedModels.Dtos.Usuario;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository<Empleado> _repository;
        private readonly ILogger<EmpleadoController> _logger;

        public EmpleadoController(IEmpleadoRepository<Empleado> repository, ILogger<EmpleadoController> logger)
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
                _logger.LogInformation("Obteniendo todos los empleados");
                var employees = await _repository.GetAllAsync();

                var employeeDtos = employees.Select(employee => new EmpleadoDto
                {
                    IdEmployee = employee.IdEmployee,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    HireDate = employee.HireDate,
                    BirthDate = employee.BirthDate,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = employee.Department,
                    ReportsTo = employee.ReportsTo,
                    ModifiedDate = employee.ModifiedDate
                });

                return Ok(employeeDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener empleados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los empleados");
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
                _logger.LogInformation($"Obteniendo empleado con ID {id}");
                var employee = await _repository.GetByIdAsync(id);

                if (employee == null)
                {
                    return NotFound("Empleado no encontrado");
                }

                var employeeDto = new EmpleadoDto
                {
                    IdEmployee = employee.IdEmployee,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Title = employee.Title,
                    HireDate = employee.HireDate,
                    BirthDate = employee.BirthDate,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Department = employee.Department,
                    ReportsTo = employee.ReportsTo,
                    ModifiedDate = employee.ModifiedDate
                };

                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el empleado");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] EmpleadoCreateDto employeeDto)
        {
            if (employeeDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del empleado son inválidos");
            }

            try
            {
                var employee = new Empleado
                {
                    FirstName = employeeDto.FirstName,
                    LastName = employeeDto.LastName,
                    Title = employeeDto.Title,
                    HireDate = employeeDto.HireDate,
                    BirthDate = employeeDto.BirthDate,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                    Department = employeeDto.Department,
                    ReportsTo = employeeDto.ReportsTo,
                    ModifiedDate = DateTime.Now
                };

                var createdEmployeeId = await _repository.CreateAsync(employee);
                if (createdEmployeeId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdEmployeeId }, employee);
                }

                return BadRequest("No se pudo crear el empleado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el empleado");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] EmpleadoUpdateDto employeeDto)
        {
            if (employeeDto == null || id != employeeDto.IdEmployee || !ModelState.IsValid)
            {
                return BadRequest("Los datos del empleado son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando empleado con ID {id}");

                var existingEmployee = await _repository.GetByIdAsync(id);
                if (existingEmployee == null)
                {
                    _logger.LogWarning($"Empleado con ID {id} no encontrado.");
                    return NotFound("Empleado no encontrado.");
                }

                existingEmployee.FirstName = employeeDto.FirstName;
                existingEmployee.LastName = employeeDto.LastName;
                existingEmployee.Title = employeeDto.Title;
                existingEmployee.HireDate = employeeDto.HireDate;
                existingEmployee.BirthDate = employeeDto.BirthDate;
                existingEmployee.Email = employeeDto.Email;
                existingEmployee.Phone = employeeDto.Phone;
                existingEmployee.Department = employeeDto.Department;
                existingEmployee.ReportsTo = employeeDto.ReportsTo;
                existingEmployee.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingEmployee);
                if (updated)
                {
                    _logger.LogInformation($"Empleado con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el empleado.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el empleado");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando empleado con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Empleado no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el empleado");
            }
        }
    }
}
