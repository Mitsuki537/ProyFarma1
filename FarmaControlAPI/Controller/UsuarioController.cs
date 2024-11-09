using Microsoft.AspNetCore.Components;

namespace FarmaControlAPI.Controller
{
    using AutoMapper;
    using FarmaControlAPI.Https.Responses;
    using FarmaControlAPI.Repository;
    using FarmaControlAPI.Services;
    using Microsoft.AspNetCore.Mvc;
    using SharedModels;
    using SharedModels.Dtos.Usuario;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(Repository<Usuario> usarioRepository, IMapper mapper)
        {
            _usuarioService = new UsuarioService(usarioRepository, mapper);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<UsuarioDto>>>> GetAllUsers()
        {
            var response = await _usuarioService.GetAll();

            return response.SendResponse(this);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UsuarioDto>>> GetUserById(int id)
        {

            var response = await _usuarioService.GetById(id);

            return response.SendResponse(this);

        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UsuarioDto>>> CreateUser(UsuarioCreateDto createDto)
        {
            var response = await _usuarioService.CreateUser(createDto, this);

            return response.SendResponse(this);
        }
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UsuarioDto>>> UpdateUser(int id, UsuarioUpdateDto updateDto)
        {
            var response = await _usuarioService.Update(id, updateDto);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UsuarioDto>>> DeleteUser(int id)
        {
            var response = await _usuarioService.Delete(id);

            return response.SendResponse(this);
        }
    }
}
