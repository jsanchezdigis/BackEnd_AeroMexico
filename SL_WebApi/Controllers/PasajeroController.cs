using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class PasajeroController : ApiController
    {
        // POST: Pasajero
        [HttpPost]
        [Route("api/Pasajero/Add")]
        public IHttpActionResult Post([FromBody] ML.Pasajero pasajero)
        {

            ML.Result result = BL.Pasajero.Add(pasajero);

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