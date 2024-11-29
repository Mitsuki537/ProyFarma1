using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.DetalleOrdenVenta;

namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleOrdenVentaController : ControllerBase
    {
        private readonly IDetalleOrdenVentaRepository<DetalleOrdenVenta> _repository;
        private readonly ILogger<DetalleOrdenVentaController> _logger;

        public DetalleOrdenVentaController(IDetalleOrdenVentaRepository<DetalleOrdenVenta> repository, ILogger<DetalleOrdenVentaController> logger)
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
                _logger.LogInformation("Obteniendo todos los detalles de las órdenes de venta");
                var orderDetails = await _repository.GetAllAsync();

                var orderDetailDtos = orderDetails.Select(detail => new DetalleOrdenVentaDto
                {
                    IdSalesOrderDetail = detail.IdSalesOrderDetail,
                    IdSalesOrder = detail.IdSalesOrder,
                    IdProduct = detail.IdProduct,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.UnitPrice,
                    Discount = detail.Discount,
                    LineTotal = detail.LineTotal,
                    ModifiedDate = detail.ModifiedDate,
                    OrderNumber = detail.OrderNumber
                });

                return Ok(orderDetailDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener detalles de la orden de venta: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los detalles de la orden de venta");
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
                _logger.LogInformation($"Obteniendo detalle de la orden de venta con ID {id}");
                var orderDetail = await _repository.GetByIdAsync(id);

                if (orderDetail == null)
                {
                    return NotFound("Detalle de la orden de venta no encontrado");
                }

                var orderDetailDto = new DetalleOrdenVentaDto
                {
                    IdSalesOrderDetail = orderDetail.IdSalesOrderDetail,
                    IdSalesOrder = orderDetail.IdSalesOrder,
                    IdProduct = orderDetail.IdProduct,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.UnitPrice,
                    Discount = orderDetail.Discount,
                    LineTotal = orderDetail.LineTotal,
                    ModifiedDate = orderDetail.ModifiedDate,
                    OrderNumber = orderDetail.OrderNumber
                };

                return Ok(orderDetailDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener detalle de la orden de venta con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el detalle de la orden de venta");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] DetalleOrdenVentaCreateDto orderDetailDto)
        {
            if (orderDetailDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del detalle de la orden de venta son inválidos");
            }

            try
            {
                var orderDetail = new DetalleOrdenVenta
                {
                    IdSalesOrder = orderDetailDto.IdSalesOrder,
                    IdProduct = orderDetailDto.IdProduct,
                    Quantity = orderDetailDto.Quantity,
                    UnitPrice = orderDetailDto.UnitPrice,
                    Discount = orderDetailDto.Discount,
                    OrderNumber= orderDetailDto.OrderNumber
                };

                var createdOrderDetailId = await _repository.CreateAsync(orderDetail);
                if (createdOrderDetailId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdOrderDetailId }, orderDetail);
                }

                return BadRequest("No se pudo crear el detalle de la orden de venta");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el detalle de la orden de venta: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el detalle de la orden de venta");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] DetalleOrdenVentaUpdateDto orderDetailDto)
        {
            if (orderDetailDto == null || id != orderDetailDto.IdSalesOrderDetail || !ModelState.IsValid)
            {
                return BadRequest("Los datos del detalle de la orden de venta son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando detalle de la orden de venta con ID {id}");

                var existingOrderDetail = await _repository.GetByIdAsync(id);
                if (existingOrderDetail == null)
                {
                    _logger.LogWarning($"Detalle de la orden de venta con ID {id} no encontrado.");
                    return NotFound("Detalle de la orden de venta no encontrado.");
                }

                existingOrderDetail.IdSalesOrder = orderDetailDto.IdSalesOrder;
                existingOrderDetail.IdProduct = orderDetailDto.IdProduct;
                existingOrderDetail.Quantity = orderDetailDto.Quantity;
                existingOrderDetail.UnitPrice = orderDetailDto.UnitPrice;
                existingOrderDetail.Discount = orderDetailDto.Discount;
                existingOrderDetail.OrderNumber = orderDetailDto.OrderNumber;

                var updated = await _repository.UpdateAsync(existingOrderDetail);
                if (updated)
                {
                    _logger.LogInformation($"Detalle de la orden de venta con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el detalle de la orden de venta.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el detalle de la orden de venta: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el detalle de la orden de venta");
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
                _logger.LogInformation($"Eliminando detalle de la orden de venta con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Detalle de la orden de venta no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar detalle de la orden de venta con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el detalle de la orden de venta");
            }
        }
    }
}
