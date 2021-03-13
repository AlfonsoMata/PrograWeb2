using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class PublicacionEtiquetas
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public int IdEtiqueta { get; set; }

        public virtual Publicaciones Publicaciones { get; set; }
        public virtual Etiquetas Etiquetas { get; set; }


    }
}
