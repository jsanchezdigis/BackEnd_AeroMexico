using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ReservacionController : ApiController
    {
        // POST: Reservacion
        [HttpPost]
        [Route("api/Reservacion/Add")]
        public IHttpActionResult Post([FromBody] ML.Reservacion reservacion)
        {

            ML.Result result = BL.Reservacion.Add(reservacion);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}