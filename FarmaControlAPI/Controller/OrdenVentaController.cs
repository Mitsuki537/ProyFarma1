using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.OrdenVenta;

namespace FarmaControlAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenVentaController : ControllerBase
    {
        private readonly IOrdenVentaRepository<OrdenVenta> _repository;
        private readonly ILogger<OrdenVentaController> _logger;

        public OrdenVentaController(IOrdenVentaRepository<OrdenVenta> repository, ILogger<OrdenVentaController> logger)
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
                _logger.LogInformation("Obteniendo todas las órdenes de ventas");
                var salesOrders = await _repository.GetAllAsync();

                var salesOrderDtos = salesOrders.Select(order => new OrdenVentaDto
                {
                    IdSalesOrder = order.IdSalesOrder,
                    IdCustomer = order.IdCustomer,
                    IdEmployee = order.IdEmployee,
                    OrderDate = order.OrderDate,
                    ModifiedDate = order.ModifiedDate
                });

                return Ok(salesOrderDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener órdenes de ventas: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las órdenes de ventas");
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
                _logger.LogInformation($"Obteniendo orden de ventas con ID {id}");
                var salesOrder = await _repository.GetByIdAsync(id);

                if (salesOrder == null)
                {
                    _logger.LogWarning($"Orden de ventas con ID {id} no encontrada.");
                    return NotFound("Orden de ventas no encontrada.");
                }

                var salesOrderDto = new OrdenVentaDto
                {
                    IdSalesOrder = salesOrder.IdSalesOrder,
                    IdCustomer = salesOrder.IdCustomer,
                    IdEmployee = salesOrder.IdEmployee,
                    OrderDate = salesOrder.OrderDate,
                    ModifiedDate = salesOrder.ModifiedDate
                };

                return Ok(salesOrderDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener orden de ventas con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la orden de ventas");
            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] OrdenVentaCreateDto salesOrderDto)
        {
            if (salesOrderDto == null || !ModelState.IsValid)
            {
                _logger.LogWarning("Datos inválidos para crear una orden de ventas.");
                return BadRequest("Los datos de la orden de ventas son inválidos.");
            }

            try
            {
                _logger.LogInformation("Creando una nueva orden de ventas");

                var salesOrder = new OrdenVenta
                {
                    IdCustomer = salesOrderDto.IdCustomer,
                    IdEmployee = salesOrderDto.IdEmployee,
                    OrderDate = salesOrderDto.OrderDate,
                    ModifiedDate = DateTime.Now
                };

                var createdSalesOrderId = await _repository.CreateAsync(salesOrder);

                return CreatedAtAction(nameof(GetById), new { id = createdSalesOrderId }, salesOrder);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear la orden de ventas: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la orden de ventas");
            }
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] OrdenVentaUpdateDto salesOrderDto)
        {
            if (salesOrderDto == null || id != salesOrderDto.IdSalesOrder || !ModelState.IsValid)
            {
                _logger.LogWarning("Datos inválidos para actualizar la orden de ventas.");
                return BadRequest("Los datos de la orden de ventas son inválidos o el ID no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando orden de ventas con ID {id}");

                var existingSalesOrder = await _repository.GetByIdAsync(id);

                if (existingSalesOrder == null)
                {
                    _logger.LogWarning($"Orden de ventas con ID {id} no encontrada.");
                    return NotFound("Orden de ventas no encontrada.");
                }

                existingSalesOrder.IdCustomer = salesOrderDto.IdCustomer;
                existingSalesOrder.IdEmployee = salesOrderDto.IdEmployee;
                existingSalesOrder.OrderDate = salesOrderDto.OrderDate;
                existingSalesOrder.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingSalesOrder);

                if (updated)
                {
                    _logger.LogInformation($"Orden de ventas con ID {id} actualizada correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar la orden de ventas.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar la orden de ventas: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la orden de ventas");
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
                _logger.LogInformation($"Eliminando orden de ventas con ID {id}");

                var deleted = await _repository.DeleteAsync(id);

                if (deleted)
                {
                    _logger.LogInformation($"Orden de ventas con ID {id} eliminada correctamente.");
                    return NoContent();
                }

                _logger.LogWarning($"Orden de ventas con ID {id} no encontrada.");
                return NotFound("Orden de ventas no encontrada.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la orden de ventas con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la orden de ventas");
            }
        }
    }
}
