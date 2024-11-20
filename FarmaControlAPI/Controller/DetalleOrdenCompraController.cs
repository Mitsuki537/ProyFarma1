using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.DetalleOrdenCompra;

namespace FarmaControlAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenCompraController : ControllerBase
    {
        private readonly IDetalleOrdenCompraRepository<DetalleOrdenCompra> _repository;
        private readonly ILogger<DetalleOrdenCompraController> _logger;

        public DetalleOrdenCompraController(IDetalleOrdenCompraRepository<DetalleOrdenCompra> repository, ILogger<DetalleOrdenCompraController> logger)
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
                _logger.LogInformation("Obteniendo todos los detalles de órdenes de compra.");
                var detalles = await _repository.GetAllAsync();

                var detalleDtos = detalles.Select(detalle => new DetalleOrdenCompraDto
                {
                    IdPurchaseOrderDetail = detalle.IdPurchaseOrderDetail,
                    IdPurchaseOrder = detalle.IdPurchaseOrder,
                    IdProduct = detalle.IdProduct,
                    Quantity = detalle.Quantity,
                    UnitPrice = detalle.UnitPrice,
                    LineTotal = detalle.LineTotal,
                    ModifiedDate = detalle.ModifiedDate,
                    ReturnDeadline = detalle.ReturnDeadline ?? DateTime.MinValue,
                    OrderNumber = detalle.OrderNumber
                });

                return Ok(detalleDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener detalles de órdenes de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los detalles de órdenes de compra.");
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
                _logger.LogInformation($"Obteniendo detalle de orden de compra con ID {id}.");
                var detalle = await _repository.GetByIdAsync(id);

                if (detalle == null)
                {
                    return NotFound("Detalle de orden de compra no encontrado.");
                }

                var detalleDto = new DetalleOrdenCompraDto
                {
                    IdPurchaseOrderDetail = detalle.IdPurchaseOrderDetail,
                    IdPurchaseOrder = detalle.IdPurchaseOrder,
                    IdProduct = detalle.IdProduct,
                    Quantity = detalle.Quantity,
                    UnitPrice = detalle.UnitPrice,
                    LineTotal = detalle.LineTotal,
                    ModifiedDate = detalle.ModifiedDate,
                    ReturnDeadline = detalle.ReturnDeadline ?? DateTime.MinValue,
                    OrderNumber = detalle.OrderNumber
                };

                return Ok(detalleDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener detalle de orden de compra con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el detalle de la orden de compra.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] DetalleOrdenCompraCreateDto detalleDto)
        {
            if (detalleDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del detalle de la orden de compra son inválidos.");
            }

            try
            {
                var detalle = new DetalleOrdenCompra
                {
                    IdPurchaseOrder = detalleDto.IdPurchaseOrder,
                    IdProduct = detalleDto.IdProduct,
                    Quantity = detalleDto.Quantity,
                    UnitPrice = detalleDto.UnitPrice,
                    ModifiedDate = DateTime.Now,
                    ReturnDeadline = detalleDto.ReturnDeadline,
                    OrderNumber = detalleDto.OrderNumber
                };

                var createdId = await _repository.CreateAsync(detalle);
                if (createdId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdId }, detalle);
                }

                return BadRequest("No se pudo crear el detalle de la orden de compra.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear detalle de orden de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el detalle de la orden de compra.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] DetalleOrdenCompraUpdateDto detalleDto)
        {
            if (detalleDto == null || id != detalleDto.IdPurchaseOrderDetail || !ModelState.IsValid)
            {
                return BadRequest("Los datos del detalle de la orden de compra son inválidos o el ID no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando detalle de orden de compra con ID {id}.");
                var existingDetalle = await _repository.GetByIdAsync(id);

                if (existingDetalle == null)
                {
                    return NotFound("Detalle de orden de compra no encontrado.");
                }

                existingDetalle.IdPurchaseOrder = detalleDto.IdPurchaseOrder;
                existingDetalle.IdProduct = detalleDto.IdProduct;
                existingDetalle.Quantity = detalleDto.Quantity;
                existingDetalle.UnitPrice = detalleDto.UnitPrice;
                existingDetalle.ModifiedDate = DateTime.Now;
                existingDetalle.ReturnDeadline = detalleDto.ReturnDeadline;
                existingDetalle.OrderNumber = detalleDto.OrderNumber;

                var updated = await _repository.UpdateAsync(existingDetalle);
                if (updated)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el detalle de la orden de compra.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar detalle de orden de compra: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el detalle de la orden de compra.");
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
                _logger.LogInformation($"Eliminando detalle de orden de compra con ID {id}.");
                var deleted = await _repository.DeleteAsync(id);

                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Detalle de orden de compra no encontrado.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar detalle de orden de compra con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el detalle de la orden de compra.");
            }
        }
    }
}

