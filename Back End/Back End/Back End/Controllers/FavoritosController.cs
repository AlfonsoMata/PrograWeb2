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
    public class FavoritosController : ControllerBase
    {

        FrostArtDBContext dbContext;

        public FavoritosController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CrearFavorito([FromBody] Favoritos favoritos)
        {
            try
            {

                FavoritosCore favoritosCore = new FavoritosCore(dbContext);
                favoritosCore.CreateFavorito(favoritos);
                return Ok("Favorito Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        
        [HttpDelete]

        public IActionResult BorrarFavorito([FromQuery] int idusuario, int idpublicacion)
        {
            try
            {
                FavoritosCore favoritosCore = new FavoritosCore(dbContext);
                favoritosCore.EliminarFavorito(idusuario, idpublicacion);
                return Ok("Favorito eliminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

    }
}
