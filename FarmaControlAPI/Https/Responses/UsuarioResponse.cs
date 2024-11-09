using SharedModels.Dtos.Usuario;
namespace FarmaControlAPI.Https.Responses
{
    public class UsuarioResponse:ApiResponse
    {
        public UsuarioDto? User { get; set; }
    }
}
