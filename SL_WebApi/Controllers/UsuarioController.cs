using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        // POST: Usuario
        [HttpPost]
        [Route("api/Usuario/GetByName")]
        public IHttpActionResult Post([FromBody] ML.Usuario usuario)
        {
            string UserName;
            UserName = usuario.UserName;
            ML.Result result = BL.Usuario.GetByName(UserName);
            if (result.Correct)
            {
                //return Ok(result);
                return Content(System.Net.HttpStatusCode.OK, result);
            }
            else
            {
                //return BadRequest(result.ErrorMessage);//Mensaje dentro del JSON
                //return NotFound();//retornar nada
                //return Unauthorized();//solo el codigo de HTML
                return Content(System.Net.HttpStatusCode.Unauthorized,result);
            }
        }
    }
}