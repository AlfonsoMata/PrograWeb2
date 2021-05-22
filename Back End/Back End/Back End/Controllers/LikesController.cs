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
    public class LikesController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public LikesController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult CrearLike([FromBody] Likes like)
        {
            try
            {

                LikesCore likesCore = new LikesCore(dbContext);
                likesCore.CreateLike(like);
                return Ok("Like Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpDelete]

        public IActionResult BorrarLike([FromQuery] int idusuario, int idpublicacion)
        {
            try
            {
                LikesCore likesCore = new LikesCore(dbContext);
                likesCore.EliminarLike(idusuario, idpublicacion);
                return Ok("Like eliminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet("{idpublicacion}")]
        public IEnumerable<Likes> GetLikes(int idpublicacion)
        {

            try
            {
                LikesCore likesCore = new LikesCore(dbContext);
                return likesCore.GetLikes(idpublicacion);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public IEnumerable<LikesPublicacion> GetPublicacionesMasLikes()
        {

            try
            {
                LikesCore likesCore = new LikesCore(dbContext);
                return likesCore.GetPublicacionesMasLikes();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
    }
