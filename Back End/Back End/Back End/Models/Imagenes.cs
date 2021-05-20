using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Imagenes
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public string Imagen { get; set; }

        public virtual Publicaciones Publicaciones { get; set; }
    }
}
