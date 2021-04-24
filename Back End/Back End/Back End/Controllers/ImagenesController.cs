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
    public class ImagenesController : ControllerBase
    {
        private FrostArtDBContext dbContext;

        [HttpPost]
        public IActionResult SubirImagen([FromBody] Imagenes imagen)
        {
            try
            {

                ImagenesCore imagenesCore = new ImagenesCore(dbContext);
                // imagenesCore.Create(usuario);
                return Ok("Imagen Agregada");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        //ESTE NO SE USA
        [HttpDelete]

        public IActionResult BorrarImagen([FromQuery] int id)
        {
            try
            {
                ImagenesCore imagenesCore = new ImagenesCore(dbContext);
               // imagenesCore.EliminarUsuario(id);
                return Ok("Imagen eliminada con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }




        [HttpGet("{id}")]
        public IActionResult GetImagenPublicacion([FromRoute] int id)
        {
            ImagenesCore imagenesCore = new ImagenesCore(dbContext);
            // List<PublicacionUsuarioPreviewVM> response = publicacionesCore.GetPublicacionEtiqueta(id);
            //return Ok(response); 
            return Ok();
        }

    }
}
