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
    public class EtiquetasController : ControllerBase
    {

        FrostArtDBContext dbContext;

        public EtiquetasController(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CrearEtiqueta([FromBody] Etiquetas etiqueta)
        {
            try
            {

                EtiquetasCore etiquetasCore = new EtiquetasCore(dbContext);
                string response = etiquetasCore.CreateEtiqueta(etiqueta);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        // GET: api/usuarios/get
        [HttpGet]
        public IEnumerable<Etiquetas> GetAll()
        {
            List<Etiquetas> etiquetas = dbContext.Etiquetas.ToList();

            return etiquetas;
        }

    }
}
