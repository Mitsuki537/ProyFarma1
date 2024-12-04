using FarmaControlAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedModels;
using SharedModels.Dtos.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FarmaControlAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository<Usuario> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUsuarioRepository<Usuario> userRepository, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {  
            _logger.LogInformation("Intentando hacer login para el usuario: {Username}", loginDto.Username);

            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                _logger.LogWarning("Usuario no encontrado: {Username}", loginDto.Username);
                return Unauthorized("Usuario no encontrado.");
            }

            bool isValidPassword = false;
            if (user.PasswordHash.StartsWith("$2a$") || user.PasswordHash.StartsWith("$2b$")) 
            {
             
                isValidPassword = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
            }
            else
            {
                _logger.LogInformation("Contraseña no hasheada, procediendo a hashelarla.");
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(loginDto.Password);
                user.PasswordHash = hashedPassword;

                await _userRepository.UpdateAsync(user); 
                isValidPassword = true;  
            }

            if (!isValidPassword)
            {
                _logger.LogWarning("Contraseña incorrecta para el usuario: {Username}", loginDto.Username);
                return Unauthorized("Contraseña incorrecta.");
            }

            _logger.LogInformation("Login exitoso para el usuario: {Username}", loginDto.Username);
            var token = GenerateJwtToken(user);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
