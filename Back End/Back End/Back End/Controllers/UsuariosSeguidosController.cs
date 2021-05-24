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
    public class UsuariosSeguidosController : ControllerBase
    {

        FrostArtDBContext dbContext;

        public UsuariosSeguidosController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult CreateUsuarioSeguido([FromBody] UsuariosSeguidos seguidos)
        {
            try
            {

                UsuariosSeguidosCore destacadosCore = new UsuariosSeguidosCore(dbContext);
                destacadosCore.CreateUsuarioSeguido(seguidos);
                return Ok("Seguido Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }



        [HttpDelete]

        public IActionResult BorrarUsuarioSeguido([FromQuery] int idusuario, int idusuarioseguido)
        {
            try
            {
                UsuariosSeguidosCore seguidosCore = new UsuariosSeguidosCore(dbContext);
                seguidosCore.BorrarUsuarioSeguido(idusuario, idusuarioseguido);
                return Ok("Seguido eliminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet]
        public IEnumerable<UsuarioSeguidoresVM> GetSeguidoresUsuario(int idusuario)
        {

            try
            {
                UsuariosSeguidosCore usuariosSeguidosCore = new UsuariosSeguidosCore(dbContext);
                return usuariosSeguidosCore.GetSeguidoresUsuario(idusuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
