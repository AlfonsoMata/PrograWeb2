using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Publicaciones
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdTema { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }
        [ForeignKey("IdTema")]
        public virtual Temas Temas { get; set; }

        public virtual ICollection<PublicacionEtiquetas> PublicacionEtiquetas { get; set; }

        public virtual ICollection<Likes> Likes { get; set; }

        public virtual ICollection<Favoritos> Favoritos { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }

        public virtual ICollection<UsuarioDestacados> UsuarioDestacados { get; set; }

        public virtual ICollection<Imagenes> Imagenes { get; set; }
    }
}
