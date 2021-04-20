using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back_End.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public UsuariosController( FrostArtDBContext dbContext)
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

        
    }
}
