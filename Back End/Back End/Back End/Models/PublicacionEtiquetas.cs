using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class PublicacionEtiquetas
    {
        public int Id { get; set; }
        public int IdPublicacion { get; set; }
        public int IdEtiqueta { get; set; }
        [ForeignKey("IdPublicacion")]
        public virtual Publicaciones Publicaciones { get; set; }
        [ForeignKey("IdEtiqueta")]
        public virtual Etiquetas Etiquetas { get; set; }


    }
}
