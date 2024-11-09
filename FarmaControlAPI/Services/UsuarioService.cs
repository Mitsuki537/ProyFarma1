using AutoMapper;
using FarmaControlAPI.Https.Responses;
using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedModels;
using SharedModels.Dtos.Usuario;

namespace FarmaControlAPI.Services
{
    using BCrypt.Net;
    public class UsuarioService
    {
        private readonly Repository<Usuario> _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(Repository<Usuario> usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        //Crear usario
        public async Task<Response<UsuarioDto>> CreateUser(UsuarioCreateDto usuarioCreate, ControllerBase controller)
        {

            if (usuarioCreate == null)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Debes ingresar los datos solicitados"
                };
            }

            try
            {
                if (await _usuarioRepository.ExistsAsync(u => u.Username == usuarioCreate.Username))
                {
                    return new Response<UsuarioDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Ya existe un usuario con ese nombre"
                    };
                }

                if (!controller.ModelState.IsValid)
                {
                    return new Response<UsuarioDto>
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Invalid user model"
                    };
                }

                var newUsuario = _mapper.Map<Usuario>(usuarioCreate);

                newUsuario.PasswordHash = BCrypt.HashPassword(newUsuario.PasswordHash);

                await _usuarioRepository.CreateAsync(newUsuario);

                return new Response<UsuarioDto>
                {
                    Data = _mapper.Map<UsuarioDto>(newUsuario),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Usuario creado con exito"
                };
            }
            catch (Exception ex)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Algo salio mal"
                };
            }
        }

        //Obtener usuario por id
        public async Task<Response<UsuarioDto>> GetById(int id)
        {
            if (id <= 0)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe ser un numero"
                };
            }

            try
            {
                var usuario = await _usuarioRepository.GetById(id);
                if (usuario == null)
                {
                    return new Response<UsuarioDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "Usuario no encontrado"
                    };
                }
                return new Response<UsuarioDto>
                {
                    Data = _mapper.Map<UsuarioDto>(usuario),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Usuario encontrado con exito"
                };
            }
            catch (Exception e)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Algo salio mal"
                };
            }
        }
        //Obtener todos los usuarios
        public async Task<Response<List<UsuarioDto>>> GetAll()
        {
            try
            {
                var users = await _usuarioRepository.GetAllAsync();

                return new Response<List<UsuarioDto>>
                {
                    Data = _mapper.Map<List<UsuarioDto>>(users),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Usuarios obtenidos con exito"
                };
            }
            catch (Exception e)
            {
                return new Response<List<UsuarioDto>>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Algo salio mal obteniedo los usuarios"
                };
            }
        }
        //Actualizar usuario por id
        public async Task<Response<UsuarioDto>> Update(
           int id,
           UsuarioUpdateDto updateDto
        )
        {
            if (id <= 0)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id debe ser mayor a cero"
                };
            }

            try
            {
                var usuario = await _usuarioRepository.GetById(id);

                if (usuario == null)
                {
                    return new Response<UsuarioDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No hay usuarios con ese id"
                    };
                }
                usuario.Username = updateDto.Username;
                usuario.Role = updateDto.Role;
                if (!string.IsNullOrEmpty(updateDto.PasswordHash))
                {
                    usuario.PasswordHash = BCrypt.HashPassword(updateDto.PasswordHash);
                }
                _mapper.Map(updateDto, usuario);

                using (var transaction = await _usuarioRepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _usuarioRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new Response<UsuarioDto>
                        {
                            Data = _mapper.Map<UsuarioDto>(usuario),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "Usuario actualizado con exito"
                        };
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!await _usuarioRepository.ExistsAsync(u => u.IdUser == id))
                        {
                            return new Response<UsuarioDto>
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "No existe usuario con ese id"
                            };
                        }

                        return new Response<UsuarioDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Algo salio mal actualizando el usuario"
                        };
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();

                        return new Response<UsuarioDto>
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Algo salio mal actualizando el usuario" + e.Message
                        };
                    }
                }
            }
            catch (Exception e)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Algo salio mal actulizando el usuario"
                };
            }
        }
        // Eliminar usuario por id
        public async Task<Response<UsuarioDto>> Delete(int id)
        {
            if (id <= 0)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "El id tiene que ser un numero positivo"
                };
            }

            try
            {
                var usuario = await _usuarioRepository.GetById(id);

                if (usuario == null)
                {
                    return new Response<UsuarioDto>
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "No existe usuario con ese id"
                    };
                }

                await _usuarioRepository.DeleteAsync(usuario);

                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Usuario eliminado con exito"
                };
            }
            catch (Exception e)
            {
                return new Response<UsuarioDto>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Algo salio mal eliminando el usuario"
                };
            }
        }

    }
}
