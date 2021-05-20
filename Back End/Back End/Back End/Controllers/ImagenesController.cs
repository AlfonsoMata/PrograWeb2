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
        public ImagenesController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult SubirImagen([FromBody] Imagenes imagen)
        {
            try
            {

                ImagenesCore imagenesCore = new ImagenesCore(dbContext);
                 imagenesCore.SubirImagen(imagen);
                return Ok("Imagen Agregada");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        //ESTE NO SE USA
        [HttpDelete]

        public IActionResult BorrarImagen(int id)
        {
            try
            {
                ImagenesCore imagenesCore = new ImagenesCore(dbContext);
                imagenesCore.EliminarImagen(id);
                return Ok("Imagen eliminada con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }




        [HttpGet("{id}")]
        public IActionResult GetImagenPublicacion( int id)
        {
            ImagenesCore imagenesCore = new ImagenesCore(dbContext);
             List<Imagenes> response = imagenesCore.GetImagenes(id);
            return Ok(response); 
            //return Ok();
        }

    }
}
