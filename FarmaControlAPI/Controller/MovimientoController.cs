using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.MovimientoInventario;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IInventorioMovimientoRepository<Movimiento> _repository;
        private readonly ILogger<MovimientoController> _logger;

        public MovimientoController(IInventorioMovimientoRepository<Movimiento> repository, ILogger<MovimientoController> logger)
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
                _logger.LogInformation("Obteniendo todos los movimientos de inventario");
                var movimientos = await _repository.GetAllAsync();

                var movimientoDtos = movimientos.Select(movimiento => new MovimientoInventarioDto
                {
                    IdMovement = movimiento.IdMovement,
                    IdInventory = movimiento.IdInventory,
                    MovementType = movimiento.MovementType,
                    Quantity = movimiento.Quantity,
                    MovementDate = movimiento.MovementDate
                });

                return Ok(movimientoDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los movimientos de inventario: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los movimientos");
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
                _logger.LogInformation($"Obteniendo movimiento con ID {id}");
                var movimiento = await _repository.GetByIdAsync(id);

                if (movimiento == null)
                {
                    return NotFound("Movimiento no encontrado");
                }

                var movimientoDto = new MovimientoInventarioDto
                {
                    IdMovement = movimiento.IdMovement,
                    IdInventory = movimiento.IdInventory,
                    MovementType = movimiento.MovementType,
                    Quantity = movimiento.Quantity,
                    ModifiedDate = movimiento.ModifiedDate
                };

                return Ok(movimientoDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener movimiento con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el movimiento");
            }
        }
    }
}

