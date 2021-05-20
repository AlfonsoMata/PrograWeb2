using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models.ViewModels
{
    public class PublicacionVM
    {
    }

    public class PublicacionUsuarioPreviewVM
    {
        public int IdPublicacion { get; set; }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string FotoPerfil { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int IdTema { get; set; }
        public string NombreTema { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activo { get; set; }
        public List<PublicacionEtiquetasVM> Etiquetas { get; set; }
        
    }

    public class PublicacionEtiquetasVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }



    public class PublicacionComentariosVM
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdPublicacion { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
    }
}
