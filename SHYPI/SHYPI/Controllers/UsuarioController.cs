using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SHYPI.Models;

namespace SHYPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios() {
            return Ok();
        }
    }
}
