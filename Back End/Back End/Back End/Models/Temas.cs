using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Temas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual Publicaciones Publicaciones { get; set; }
    }
}
