using Back_End.Classes.Core;
using Back_End.Models;
using Back_End.Models.ViewModels;
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
                return Ok("Publicacion Deshabilitada con exito");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPublicacionUsuario([FromRoute] int id)
        {
            PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
            List<PublicacionUsuarioPreviewVM> response = publicacionesCore.GetPublicacionUsuario(id);
            return Ok(response); ;
        }

        [HttpPost]
        public IActionResult CrearPublicacion([FromBody] Publicaciones publicacion)
        {
            try
            {

                PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
                publicacionesCore.CreatePublicacion(publicacion);
                return Ok("Publicacion Agregada");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpPut("{id}")]

        public IActionResult ActualizarPublicacion([FromBody] Publicaciones publicacion, [FromRoute] int id)
        {
            try
            {
                PublicacionesCore publicacionCore = new PublicacionesCore(dbContext);
                publicacionCore.ActualizaPublicacion(publicacion, id);
                return Ok("Publicacion actualizada con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetPublicacionEtiqueta([FromRoute] int id)
        {
            PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
            List<PublicacionUsuarioPreviewVM> response = publicacionesCore.GetPublicacionEtiqueta(id);
            return Ok(response); ;
        }


        [HttpGet("{id}")]
        public IActionResult GetPublicacionTema([FromRoute] int id)
        {
            PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
            List<PublicacionUsuarioPreviewVM> response = publicacionesCore.GetPublicacionTema(id);
            return Ok(response); ;
        }


        [HttpGet("{id}")]
        public IActionResult GetPublicacionId([FromRoute] int id)
        {
            PublicacionesCore publicacionesCore = new PublicacionesCore(dbContext);
            List<PublicacionUsuarioPreviewVM> response = publicacionesCore.GetPublicacionId(id);
            return Ok(response); ;
        }


    }
}
