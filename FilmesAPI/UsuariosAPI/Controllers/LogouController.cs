using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LogouController : ControllerBase
    {
        private LogoutService _logoutService;

        public LogouController(LogoutService logoutService )
        {
            _logoutService = logoutService;
        }

        [HttpPost]
        public IActionResult DeslogaUsuario()
        {
            Result result = _logoutService.DeslogaUsuario();
            if (result.IsFailed)
            {
                return Unauthorized(result.Errors);
            }
            return Ok(result.Successes);
        }

    }
}
