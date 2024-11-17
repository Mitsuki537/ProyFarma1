using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.MovimientoInventario;

namespace FarmaControlAPI.Controller
{
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
                    MovementDate = movimiento.MovementDate,
                    ReferenceID = movimiento.ReferenceID,
                    ModifiedDate = movimiento.ModifiedDate
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
                    MovementDate = movimiento.MovementDate,
                    ReferenceID = movimiento.ReferenceID,
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] MovimientoCreateDto movimientoDto)
        {
            if (movimientoDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del movimiento son inválidos");
            }

            try
            {
                var movimiento = new Movimiento
                {
                    IdInventory = movimientoDto.IdInventory,
                    MovementType = movimientoDto.MovementType,
                    Quantity = movimientoDto.Quantity,
                    MovementDate = movimientoDto.MovementDate,
                    ReferenceID = movimientoDto.ReferenceID,
                    ModifiedDate = DateTime.Now
                };

                var createdMovimientoId = await _repository.CreateAsync(movimiento);
                if (createdMovimientoId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdMovimientoId }, movimiento);
                }

                return BadRequest("No se pudo crear el movimiento");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear movimiento: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el movimiento");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] MovimientoUpdateDto movimientoDto)
        {
            if (movimientoDto == null || id != movimientoDto.IdMovement || !ModelState.IsValid)
            {
                return BadRequest("Los datos del movimiento son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando movimiento con ID {id}");

                var existingMovimiento = await _repository.GetByIdAsync(id);
                if (existingMovimiento == null)
                {
                    _logger.LogWarning($"Movimiento con ID {id} no encontrado.");
                    return NotFound("Movimiento no encontrado.");
                }

                existingMovimiento.IdInventory = movimientoDto.IdInventory;
                existingMovimiento.MovementType = movimientoDto.MovementType;
                existingMovimiento.Quantity = movimientoDto.Quantity;
                existingMovimiento.MovementDate = movimientoDto.MovementDate;
                existingMovimiento.ReferenceID = movimientoDto.ReferenceID;
                existingMovimiento.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingMovimiento);
                if (updated)
                {
                    _logger.LogInformation($"Movimiento con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el movimiento.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar movimiento: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el movimiento");
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
                _logger.LogInformation($"Eliminando movimiento con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Movimiento no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar movimiento con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el movimiento");
            }
        }
    }
}

