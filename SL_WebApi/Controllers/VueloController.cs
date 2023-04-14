using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class VueloController : ApiController
    {
        // GET: Vuelo
        [HttpGet]
        [Route("api/Vuelo/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Vuelo.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("api/Vuelo/GetByFecha/{FechaInicio,FechaFin}")]
        public IHttpActionResult GetByFecha(string FechaInicio,string FechaFin)
        {
            ML.Vuelo vuelo = new ML.Vuelo();
            vuelo.FechaInicio = FechaInicio;
            vuelo.FechaFin = FechaFin;
            ML.Result result = BL.Vuelo.GetByFecha(vuelo);
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