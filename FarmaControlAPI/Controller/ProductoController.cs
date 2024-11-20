using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.Producto;

namespace FarmaControlAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository<Producto> _repository;
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(IProductoRepository<Producto> repository, ILogger<ProductoController> logger)
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
                _logger.LogInformation("Obteniendo todos los productos");
                var products = await _repository.GetAllAsync();

                var productDtos = products.Select(product => new ProductoDto
                {
                    IdProduct = product.IdProduct,
                    ProductName = product.ProductName,
                    IdSupplier = product.IdSupplier,
                    IdCategory = product.IdCategory,
                    UnitPrice = product.UnitPrice,
                    ReorderLevel = product.ReorderLevel,
                    LoteNumber = product.LoteNumber,
                    ManufactureDate = product.ManufactureDate,
                    ModifiedDate = product.ModifiedDate
                });

                return Ok(productDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener productos: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener los productos");
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
                _logger.LogInformation($"Obteniendo producto con ID {id}");
                var product = await _repository.GetByIdAsync(id);

                if (product == null)
                {
                    return NotFound("Producto no encontrado");
                }

                var productDto = new ProductoDto
                {
                    IdProduct = product.IdProduct,
                    ProductName = product.ProductName,
                    IdSupplier = product.IdSupplier,
                    IdCategory = product.IdCategory,
                    UnitPrice = product.UnitPrice,
                    ReorderLevel = product.ReorderLevel,
                    LoteNumber = product.LoteNumber,
                    ManufactureDate = product.ManufactureDate,
                    ModifiedDate = product.ModifiedDate
                };

                return Ok(productDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener producto con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener el producto");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ProductoCreateDto productDto)
        {
            if (productDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos del producto son inválidos");
            }

            try
            {
                var product = new Producto
                {
                    ProductName = productDto.ProductName,
                    IdSupplier = productDto.IdSupplier,
                    IdCategory = productDto.IdCategory,
                    UnitPrice = productDto.UnitPrice,
                    ReorderLevel = productDto.ReorderLevel,
                    LoteNumber = productDto.LoteNumber,
                    ManufactureDate = productDto.ManufactureDate,
                    ModifiedDate = DateTime.Now
                };

                var createdProductId = await _repository.CreateAsync(product);
                if (createdProductId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdProductId }, product);
                }

                return BadRequest("No se pudo crear el producto");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear producto: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear el producto");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] ProductoUpdateDto productDto)
        {
            if (productDto == null || id != productDto.IdProduct || !ModelState.IsValid)
            {
                return BadRequest("Los datos del producto son inválidos o el ID no coincide");
            }

            try
            {
                _logger.LogInformation($"Actualizando producto con ID {id}");

                var existingProduct = await _repository.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    _logger.LogWarning($"Producto con ID {id} no encontrado.");
                    return NotFound("Producto no encontrado.");
                }

                existingProduct.ProductName = productDto.ProductName;
                existingProduct.IdSupplier = productDto.IdSupplier;
                existingProduct.IdCategory = productDto.IdCategory;
                existingProduct.UnitPrice = productDto.UnitPrice;
                existingProduct.ReorderLevel = productDto.ReorderLevel;
                existingProduct.LoteNumber = productDto.LoteNumber;
                existingProduct.ManufactureDate = productDto.ManufactureDate;
                existingProduct.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingProduct);
                if (updated)
                {
                    _logger.LogInformation($"Producto con ID {id} actualizado correctamente.");
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar el producto.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar producto: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar el producto");
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
                _logger.LogInformation($"Eliminando producto con ID {id}");
                var deleted = await _repository.DeleteAsync(id);
                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Producto no encontrado");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar producto con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar el producto");
            }
        }
    }
}

