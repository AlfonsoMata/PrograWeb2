using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contra { get; set; }
        public string Email { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public Byte[] FotoPerfil { get; set; }

        public virtual ICollection<Publicaciones> Publicaciones { get; set; }
        public virtual ICollection<Likes> Likes { get; set; }

        public virtual ICollection<Favoritos> Favoritos { get; set; }

        public virtual ICollection<UsuariosSeguidos> UsuariosSeguidos { get; set; }
        public virtual ICollection<Comentarios> Comentarios { get; set; }

        public virtual ICollection<UsuarioDestacados> UsuarioDestacado { get; set; }
    }

    
}
