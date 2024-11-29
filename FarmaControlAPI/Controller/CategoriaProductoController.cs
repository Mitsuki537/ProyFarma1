using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.Dtos.CategoriaProducto;


namespace FarmaControlAPI.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaProductoController : ControllerBase
    {
        private readonly ICategoriaProductoRepository<CategoriaProducto> _repository;
        private readonly ILogger<CategoriaProductoController> _logger;

        public CategoriaProductoController(ICategoriaProductoRepository<CategoriaProducto> repository, ILogger<CategoriaProductoController> logger)
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
                _logger.LogInformation("Obteniendo todas las categorías de producto.");
                var categorias = await _repository.GetAllAsync();

                var categoriaDtos = categorias.Select(categoria => new CategoriaProductoDto
                {
                    IdCategory = categoria.IdCategory,
                    IdParentCategory = categoria.IdParentCategory,
                    CategoryName = categoria.CategoryName,
                    ModifiedDate = categoria.ModifiedDate
                });

                return Ok(categoriaDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las categorías de producto: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las categorías de producto.");
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
                _logger.LogInformation($"Obteniendo categoría de producto con ID {id}.");
                var categoria = await _repository.GetByIdAsync(id);

                if (categoria == null)
                {
                    return NotFound("Categoría de producto no encontrada.");
                }

                var categoriaDto = new CategoriaProductoDto
                {
                    IdCategory = categoria.IdCategory,
                    IdParentCategory = categoria.IdParentCategory,
                    CategoryName = categoria.CategoryName,
                    ModifiedDate = categoria.ModifiedDate
                };

                return Ok(categoriaDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la categoría de producto con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener la categoría de producto.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CategoriaProductoCreateDto categoriaDto)
        {
            if (categoriaDto == null || !ModelState.IsValid)
            {
                return BadRequest("Los datos de la categoría de producto son inválidos.");
            }

            try
            {
                var categoria = new CategoriaProducto
                {
                    IdParentCategory = categoriaDto.IdParentCategory,
                    CategoryName = categoriaDto.CategoryName,
                    ModifiedDate = DateTime.Now
                };

                var createdId = await _repository.CreateAsync(categoria);
                if (createdId > 0)
                {
                    return CreatedAtAction(nameof(GetById), new { id = createdId }, categoria);
                }

                return BadRequest("No se pudo crear la categoría de producto.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear categoría de producto: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la categoría de producto.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] CategoriaProductoUpdateDto categoriaDto)
        {
            if (categoriaDto == null || id != categoriaDto.IdCategory || !ModelState.IsValid)
            {
                return BadRequest("Los datos de la categoría de producto son inválidos o el ID no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando categoría de producto con ID {id}.");
                var existingCategoria = await _repository.GetByIdAsync(id);

                if (existingCategoria == null)
                {
                    return NotFound("Categoría de producto no encontrada.");
                }

                existingCategoria.IdParentCategory = categoriaDto.IdParentCategory;
                existingCategoria.CategoryName = categoriaDto.CategoryName;
                existingCategoria.ModifiedDate = DateTime.Now;

                var updated = await _repository.UpdateAsync(existingCategoria);
                if (updated)
                {
                    return NoContent();
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo actualizar la categoría de producto.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar categoría de producto: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al actualizar la categoría de producto.");
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
                _logger.LogInformation($"Eliminando categoría de producto con ID {id}.");
                var deleted = await _repository.DeleteAsync(id);

                if (deleted)
                {
                    return NoContent();
                }

                return NotFound("Categoría de producto no encontrada.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar categoría de producto con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al eliminar la categoría de producto.");
            }
        }
    }
}

