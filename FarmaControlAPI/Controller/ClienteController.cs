using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Cliente;
using SharedModels.Dtos.Cliente;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICLienteRepository<Client> _repository;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(ICLienteRepository<Client> repository, ILogger<ClienteController> logger)
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
                _logger.LogInformation("Obteniendo todos los clientes");
                var customers = await _repository.GetAllAsync();

                var customerDtos = customers.Select(customer => new ClienteDto
                {
                    IdCustomer = customer.IdCustomer,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    RegistrationDate = customer.RegistrationDate
                });

                return Ok(customerDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener clientes: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los clientes");
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
                _logger.LogInformation($"Obteniendo cliente con ID {id}");
                var customer = await _repository.GetByIdAsync(id);

                if (customer == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                var customerDto = new ClienteDto
                {
                    IdCustomer = customer.IdCustomer,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    RegistrationDate = customer.RegistrationDate
                };

                return Ok(customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener cliente con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el cliente");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ClienteCreateDto customerDto)
        {
            if (customerDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del cliente son inválidos");
            }

            try
            {
                // Primero, se convierte el DTO a la entidad Client
                var customer = new Client
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Phone = customerDto.Phone,
                    RegistrationDate = DateTime.Now
                };

                // Llamamos al repositorio para crear el cliente
                var createdCustomerId = await _repository.CreateAsync(customer);

                if (createdCustomerId > 0)
                {
                    // Asignamos el Id generado por la base de datos al objeto cliente
                    customer.IdCustomer = createdCustomerId;

                    // Devolvemos el cliente con el ID asignado
                    return CreatedAtAction(nameof(GetById), new { id = createdCustomerId }, customer);
                }

                return BadRequest("No se pudo crear el cliente");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear cliente: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el cliente");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteUpdateDto customerDto)
        {
            if (customerDto == null || id != customerDto.IdCustomer || !ModelState.IsValid)
            {
                return BadRequest("Los datos del cliente son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando cliente con ID {id}");

                var existingCustomer = await _repository.GetByIdAsync(id);
                if (existingCustomer == null)
                {
                    _logger.LogWarning($"Cliente con ID {id} no encontrado.");
                    return NotFound("Cliente no encontrado.");
                }

                existingCustomer.FirstName = customerDto.FirstName;
                existingCustomer.LastName = customerDto.LastName;
                existingCustomer.Phone = customerDto.Phone;

                var updated = await _repository.UpdateAsync(existingCustomer);
                if (updated)
                {
                    _logger.LogInformation($"Cliente con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el cliente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar cliente: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el cliente");
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
                _logger.LogInformation($"Eliminando cliente con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Cliente no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar cliente con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el cliente");
            }
        }
    }
}
