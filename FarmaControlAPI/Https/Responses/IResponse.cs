using Microsoft.AspNetCore.Mvc;

namespace FarmaControlAPI.Https.Responses
{
    public interface IResponse
    {
        public ObjectResult SendResponse(ControllerBase controller);

    }
}
