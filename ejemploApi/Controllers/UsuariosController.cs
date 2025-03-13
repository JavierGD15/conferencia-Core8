using ejemploApi.Domain.Model;
using ejemploApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace ejemploApi.Controllers
{
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;

        public UsuariosController(IUsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }


        [HttpGet("api/usuarios")]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            return await _usuariosService.GetUsuarios();
        }
    }
}
