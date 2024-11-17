using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.Inventario;

namespace FarmaControlAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioRepository<Inventario> _repository;
        private readonly ILogger<InventarioController> _logger;

        public InventarioController(IInventarioRepository<Inventario> repository, ILogger<InventarioController> logger)
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
                _logger.LogInformation("Obteniendo todos los inventarios.");
                var inventories = await _repository.GetAllAsync();

                var inventoryDtos = inventories.Select(inventory => new InventorioDto
                {
                    IdInventory = inventory.IdInventory,
                    IdProduct = inventory.IdProduct,
                    Quantity = inventory.Quantity,
                    DateReceived = inventory.DateReceived,
                    ModifiedDate = inventory.ModifiedDate
                });

                return Ok(inventoryDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los inventarios: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los inventarios.");
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
                _logger.LogInformation($"Obteniendo inventario con ID {id}.");
                var inventory = await _repository.GetByIdAsync(id);

                if (inventory == null)
                {
                    return NotFound("Inventario no encontrado.");
                }

                var inventoryDto = new InventorioDto
                {
                    IdInventory = inventory.IdInventory,
                    IdProduct = inventory.IdProduct,
                    Quantity = inventory.Quantity,
                    DateReceived = inventory.DateReceived,
                    ModifiedDate = inventory.ModifiedDate
                };

                return Ok(inventoryDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el inventario con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el inventario.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] InventarioCreateDto inventoryDto)
        {
            if (inventoryDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del inventario son inválidos.");
            }

            try
            {
                var inventory = new Inventario
                {
                    IdProduct = inventoryDto.IdProduct,
                    Quantity = inventoryDto.Quantity,
                    DateReceived = inventoryDto.DateReceived,
                    ModifiedDate = DateTime.Now
                };

                var createdId = await _repository.CreateAsync(inventory);
                if (createdId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdId }, inventory);
                }

                return BadRequest("No se pudo crear el inventario.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear inventario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el inventario.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] InventarioUpdateDto inventoryDto)
        {
            if (inventoryDto == null || id != inventoryDto.IdInventory || !ModelState.IsValid)
            {
                return BadRequest("Los datos del inventario son inválidos o el ID no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando inventario con ID {id}.");
                var existingInventory = await _repository.GetByIdAsync(id);

                if (existingInventory == null)
                {
                    return NotFound("Inventario no encontrado.");
                }

                existingInventory.IdProduct = inventoryDto.IdProduct;
                existingInventory.Quantity = inventoryDto.Quantity;
                existingInventory.DateReceived = inventoryDto.DateReceived;
                existingInventory.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingInventory);
                if (updated)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el inventario.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar inventario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el inventario.");
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
                _logger.LogInformation($"Eliminando inventario con ID {id}.");
                var deleted = await _repository.DeleteAsync(id);

                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Inventario no encontrado.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar inventario con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el inventario.");
            }
        }
    }
}
