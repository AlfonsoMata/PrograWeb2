using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Likes
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public int IdUsuario { get; set; }

        public virtual Publicaciones Publicaciones { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
