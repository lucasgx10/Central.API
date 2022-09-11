using Central.Data;
using Central.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Central.Controllers
{
    [ApiController]
    public class UsuarioController: ControllerBase
    {
        [HttpGet]
        [Route("Usuario")]
        public IActionResult Get([FromServices] AppDataContext context)
        {
            return Ok(context.Usuario.ToList());
        }

        [HttpGet]
        [Route("Usuario/{id:Guid}")]
        public IActionResult GetId([FromRoute] Guid id, [FromServices] AppDataContext context)
        {
            var _usuario = context.Usuario.FirstOrDefault(x => x.Id == id);
            if (_usuario == null)
            {
                return NotFound();
            }

            return Ok(_usuario);
        }


        [HttpPost]
        [Route("Usuario")]
        public IActionResult Post([FromBody] Usuario usuario,[FromServices] AppDataContext context)
        {
            context.Usuario.Add(usuario);
            context.SaveChanges();
            return Ok(usuario);
        }

        [HttpPut]
        [Route("Usuario/{id:Guid}")]
        public IActionResult Put([FromRoute] Guid id,[FromBody] Usuario usuario,[FromServices] AppDataContext context)
        {
            var _usuario = context.Usuario.FirstOrDefault(x => x.Id == id);
            if (_usuario == null)
            {
                return NotFound();

            }
            _usuario.Nome = usuario.Nome;
            _usuario.Email = usuario.Email;
            _usuario.Ativo = usuario.Ativo;
            context.Usuario.Update(_usuario);
            context.SaveChanges();
            return Ok(_usuario);
            
        }
         
        [HttpDelete]
        [Route("Usuario/{id:Guid}")]

        public IActionResult Delete([FromRoute] Guid id,[FromServices]AppDataContext context)
        {
            var _usuario = context.Usuario.FirstOrDefault(x => x.Id == id);
            if (_usuario == null)
            {
                return NotFound();
            }

            context.Usuario.Remove(_usuario);
            context.SaveChanges();

            return NoContent();
          
        }

    }
}
