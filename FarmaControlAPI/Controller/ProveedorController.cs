using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.Compras;
using SharedModels.Dtos.Proveedor;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorRepository<Proveedor> _repository;
        private readonly ILogger<ProveedorController> _logger;

        public ProveedorController(IProveedorRepository<Proveedor> repository, ILogger<ProveedorController> logger)
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
                _logger.LogInformation("Obteniendo todos los proveedores");
                var proveedores = await _repository.GetAllAsync();

                var proveedorDtos = proveedores.Select(proveedor => new ProveedorDto
                {
                    IdSupplier = proveedor.IdSupplier,
                    SupplierName = proveedor.SupplierName,
                    ContactName = proveedor.ContactName,
                    ContactTitle = proveedor.ContactTitle,
                    Phone = proveedor.Phone,
                    Email = proveedor.Email,
                    Address = proveedor.Address,
                    City = proveedor.City,
                    Country = proveedor.Country,
                    PostalCode = proveedor.PostalCode,
                    ModifiedDate = proveedor.ModifiedDate
                });

                return Ok(proveedorDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener proveedores: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los proveedores");
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
                _logger.LogInformation($"Obteniendo proveedor con ID {id}");
                var proveedor = await _repository.GetByIdAsync(id);

                if (proveedor == null)
                {
                    return NotFound("Proveedor no encontrado");
                }

                var proveedorDto = new ProveedorDto
                {
                    IdSupplier = proveedor.IdSupplier,
                    SupplierName = proveedor.SupplierName,
                    ContactName = proveedor.ContactName,
                    ContactTitle = proveedor.ContactTitle,
                    Phone = proveedor.Phone,
                    Email = proveedor.Email,
                    Address = proveedor.Address,
                    City = proveedor.City,
                    Country = proveedor.Country,
                    PostalCode = proveedor.PostalCode,
                    ModifiedDate = proveedor.ModifiedDate
                };

                return Ok(proveedorDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener proveedor con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el proveedor");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProveedorCreateDto proveedorDto)
        {
            if (proveedorDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del proveedor son inválidos");
            }

            try
            {
                var proveedor = new Proveedor
                {
                    SupplierName = proveedorDto.SupplierName,
                    ContactName = proveedorDto.ContactName,
                    ContactTitle = proveedorDto.ContactTitle,
                    Phone = proveedorDto.Phone,
                    Email = proveedorDto.Email,
                    Address = proveedorDto.Address,
                    City = proveedorDto.City,
                    Country = proveedorDto.Country,
                    PostalCode = proveedorDto.PostalCode,
                    ModifiedDate = DateTime.Now
                };

                var createdProveedorId = await _repository.CreateAsync(proveedor);
                if (createdProveedorId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdProveedorId }, proveedor);
                }

                return BadRequest("No se pudo crear el proveedor");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear proveedor: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el proveedor");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProveedorUpdateDto proveedorDto)
        {
            if (proveedorDto == null || id != proveedorDto.IdSupplier || !ModelState.IsValid)
            {
                return BadRequest("Los datos del proveedor son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando proveedor con ID {id}");

                var existingProveedor = await _repository.GetByIdAsync(id);
                if (existingProveedor == null)
                {
                    _logger.LogWarning($"Proveedor con ID {id} no encontrado.");
                    return NotFound("Proveedor no encontrado.");
                }

                existingProveedor.SupplierName = proveedorDto.SupplierName;
                existingProveedor.ContactName = proveedorDto.ContactName;
                existingProveedor.ContactTitle = proveedorDto.ContactTitle;
                existingProveedor.Phone = proveedorDto.Phone;
                existingProveedor.Email = proveedorDto.Email;
                existingProveedor.Address = proveedorDto.Address;
                existingProveedor.City = proveedorDto.City;
                existingProveedor.Country = proveedorDto.Country;
                existingProveedor.PostalCode = proveedorDto.PostalCode;
                existingProveedor.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingProveedor);
                if (updated)
                {
                    _logger.LogInformation($"Proveedor con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el proveedor.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar proveedor: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el proveedor");
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
                _logger.LogInformation($"Eliminando proveedor con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Proveedor no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar proveedor con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el proveedor");
            }
        }
    }
}
