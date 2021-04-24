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
    public class TemasController : ControllerBase
    {
        FrostArtDBContext dbContext;

        public TemasController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/usuarios/get
        [HttpGet]
        public IEnumerable<Temas> GetAll()
        {
            List<Temas> temas = dbContext.Temas.ToList();

            return temas;
        }
    }
}
