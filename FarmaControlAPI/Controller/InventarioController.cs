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
    }
}
