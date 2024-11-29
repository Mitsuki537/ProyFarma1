using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.OrdenCompra;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase 
    {
        private readonly IOrdenCompraRepository<OrdenCompra> _repository;
        private readonly ILogger<OrdenCompraController> _logger;

        public OrdenCompraController(IOrdenCompraRepository<OrdenCompra> repository, ILogger<OrdenCompraController> logger)
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
                _logger.LogInformation("Obteniendo todas las órdenes de compra");
                var orders = await _repository.GetAllAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las órdenes de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las órdenes de compra");
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
                _logger.LogInformation($"Obteniendo orden de compra con ID {id}");
                var order = await _repository.GetByIdAsync(id);

                if (order == null)
                {
                    return NotFound("Orden de compra no encontrada");
                }

                return Ok(order);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la orden de compra con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la orden de compra");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] OrdenCompraCreateDto orderDto)
        {
            if (orderDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos de la orden de compra son inválidos");
            }

            try
            {
                var order = new OrdenCompra
                {
                    IdSupplier = orderDto.IdSupplier,
                    OrderDate = orderDto.OrderDate,
                    Status = orderDto.Status,
                    ModifiedDate = DateTime.Now,
                    OrderNumber = orderDto.OrderNumber
                };

                var createdOrderId = await _repository.CreateAsync(order);
                if (createdOrderId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdOrderId }, order);
                }

                return BadRequest("No se pudo crear la orden de compra");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la orden de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la orden de compra");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenCompraUpdateDto orderDto)
        {
            if (orderDto == null || id != orderDto.IdPurchaseOrder || !ModelState.IsValid)
            {
                return BadRequest("Los datos de la orden de compra son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando orden de compra con ID {id}");

                var existingOrder = await _repository.GetByIdAsync(id);
                if (existingOrder == null)
                {
                    _logger.LogWarning($"Orden de compra con ID {id} no encontrada.");
                    return NotFound("Orden de compra no encontrada.");
                }

                existingOrder.IdSupplier = orderDto.IdSupplier;
                existingOrder.OrderDate = orderDto.OrderDate;
                existingOrder.Status = orderDto.Status;
                existingOrder.ModifiedDate = DateTime.Now;
                existingOrder.OrderNumber = orderDto.OrderNumber;

                var updated = await _repository.UpdateAsync(existingOrder);
                if (updated)
                {
                    _logger.LogInformation($"Orden de compra con ID {id} actualizada correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar la orden de compra.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la orden de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la orden de compra");
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
                var order = await _repository.GetByIdAsync(id);
                if (order == null)
                {
                    return NotFound("Orden de compra no encontrada");
                }

                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo eliminar la orden de compra");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la orden de compra con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la orden de compra");
            }
        }
    }
}
