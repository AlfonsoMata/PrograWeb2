﻿using System;
using System.Collections.Generic;
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
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }

        public virtual Usuarios Usuarios { get; set; }
        public virtual Temas Temas { get; set; }

        public virtual ICollection<PublicacionEtiquetas> PublicacionEtiquetas { get; set; }

        public virtual ICollection<Likes> Likes { get; set; }

        public virtual ICollection<Favoritos> Favoritos { get; set; }

        public virtual ICollection<Comentarios> Comentarios { get; set; }
    }
}
