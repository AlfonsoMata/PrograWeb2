using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Comentarios
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }
        [ForeignKey("IdPublicacion")]
        public virtual Publicaciones Publicaciones { get; set; }

    }
}
