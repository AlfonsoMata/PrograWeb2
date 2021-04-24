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
    public class ComentariosController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public ComentariosController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult CreateComentario([FromBody] Comentarios comentario)
        {
            try
            {

                ComentariosCore comentariosCore = new ComentariosCore(dbContext);
                comentariosCore.CreateComentario(comentario);
                return Ok("Comentario Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }




        [HttpDelete("{id}")]
        public IActionResult DesabilitarComentario(int id)
        {
            try
            {
                ComentariosCore comentariosCore = new ComentariosCore(dbContext);
                comentariosCore.DesabilitarComentario(id);
                return Ok("Comentario Deshabilitado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public IEnumerable<Comentarios> GetComentariosPublicacion(int id)
        {
         
            try
            {

                ComentariosCore comentariosCore = new ComentariosCore(dbContext);
                return comentariosCore.GetComentariosPublicacion(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
