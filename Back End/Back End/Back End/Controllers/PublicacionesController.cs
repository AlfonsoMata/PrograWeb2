using Back_End.Classes.Core;
using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacionesController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public PublicacionesController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpDelete("{id}")]
        public IActionResult DesabilitarPublicaciones(int id)
        {
            try
            {
                PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
                publicacionesCore.DesabilitarPublicacion(id);
                return Ok("Usuario actualizado con exito");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
