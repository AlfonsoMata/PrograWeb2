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
    public class UsuariosController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public UsuariosController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/usuarios/get
        [HttpGet]
        public IEnumerable<Usuarios> GetAll()
        {
            List<Usuarios> usuarios = dbContext.Usuarios.ToList();

            return usuarios;
        }



        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public IEnumerable<Usuarios> LogIn(string nombre, string contra)
        {
            /*List<Usuarios> usuarios = dbContext.Usuarios.
                Where(Usuarios=>Usuarios.Nombre == nombre && Usuarios1=>Usuarios1.Contra == comntra).ToList()*/
            try
            {

                UsuariosCore usuarioCore = new UsuariosCore(dbContext);
                return usuarioCore.LogIn(nombre, contra);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody]Usuarios usuario)
        {
            try
            {

                UsuariosCore usuarioCore = new UsuariosCore(dbContext);
                usuarioCore.Create(usuario);
                return Ok("Usuario Agregado");

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]

        public IActionResult ActualizarUsuario([FromBody]Usuarios usuario,[FromRoute] int id)
        {
            try
            {
                UsuariosCore usuarioCore = new UsuariosCore(dbContext);
                usuarioCore.ActualizaUsuario(usuario, id);
                return Ok("Usuario actualizado con exito");
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        //ESTE NO SE USA
        [HttpDelete]

        public IActionResult BorrarUsuario([FromQuery] int id)
        {
            try
            {
                UsuariosCore usuarioCore = new UsuariosCore(dbContext);
                usuarioCore.EliminarUsuario(id);
                return Ok("Usuario eliminado con exito");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        /*
        [HttpGet("{id}")]
        public IActionResult GetUsuario([FromRoute] int id)
        {
            UsuariosCore usuarioCore = new UsuariosCore(dbContext);
            UsuarioVM response = usuarioCore.GetUsuario(id);
            return Ok(response); ;
        }

       */

        [HttpGet("{id}")]
        public IActionResult GetUsuarioPerfil([FromRoute] int id)
        {
            UsuariosCore usuarioCore = new UsuariosCore(dbContext);
            UsuarioPerfilVM response = usuarioCore.GetUsuarioPerfil(id);
            return Ok(response); ;
        }


        [HttpGet("{id}")]
        public IActionResult GetUsuarioDestacados([FromRoute] int id)
        {
            UsuariosCore usuarioCore = new UsuariosCore(dbContext);
            List<UsuarioDestacadosVM> response = usuarioCore.GetUsuarioDestacados(id);
            return Ok(response); ;
        }
    }
}
