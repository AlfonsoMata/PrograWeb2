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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuarioDestacadosController : ControllerBase
    {

        FrostArtDBContext dbContext;

        public UsuarioDestacadosController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateUsuarioDestacado([FromBody] UsuarioDestacados destacados)
        {
            try
            {

                UsuarioDestacadosCore destacadosCore = new UsuarioDestacadosCore(dbContext);
                destacadosCore.CreateUsuarioDestacado(destacados);
                return Ok("Destacado Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


   
        [HttpDelete]

        public IActionResult BorrarUsuarioDestacado([FromQuery] int idusuario, int idpublicacion)
        {
            try
            {
                UsuarioDestacadosCore destacadosCore = new UsuarioDestacadosCore(dbContext);
                destacadosCore.BorrarUsuarioDestacado(idusuario, idpublicacion);
                return Ok("Destacado eliminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
