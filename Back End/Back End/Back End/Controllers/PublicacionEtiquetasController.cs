using Back_End.Classes.Core;
using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Back_End.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PublicacionEtiquetasController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public PublicacionEtiquetasController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CrearPublicacionEtiqueta([FromBody] PublicacionEtiquetas publicacionetiqueta)
        {
            try
            {

                PublicacionEtiquetasCore publicacionesEtiquetasCore = new PublicacionEtiquetasCore(dbContext);
                string response = publicacionesEtiquetasCore.CreatePublicacionEtiqueta(publicacionetiqueta);
                return Ok(response); //trae el id de la publicacion creada

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }



        [HttpDelete]
        public IActionResult BorrarPublicacionEtiqueta(int id)
        {
            try
            {
                PublicacionEtiquetasCore publicacionEtiquetasCore = new PublicacionEtiquetasCore(dbContext);
                publicacionEtiquetasCore.EliminarPublicacionEtiqueta(id);
                return Ok("Etiqueta de la publicacion eliminada con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPublicacionPublicacionEtiquetas([FromRoute] int id)
        {
            PublicacionEtiquetasCore publicacionesCore = new PublicacionEtiquetasCore(dbContext);
            List<PublicacionEtiquetas> response = publicacionesCore.GetPublicacionPublicacionEtiquetas(id);
            return Ok(response); ;
        }

    }
}
