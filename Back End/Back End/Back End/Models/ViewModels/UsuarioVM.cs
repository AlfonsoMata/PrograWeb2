using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models.ViewModels
{
    public class UsuarioVM
    {
        public string CompleteName { get; set; }
        public List<SubjectViewModel> Subjects { get; set; }
    }

 

    public class SubjectViewModel
    {
        public string Name { get; set; }
        public int Credits { get; set; }
    }


    public class UsuarioPerfilVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Byte[] FotoPerfil { get; set; }
        public List<UsuariosSeguidosVM> Seguidos { get; set; }
    }

    public class UsuariosSeguidosVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Byte[] FotoPerfil { get; set; }
    }


    public class UsuarioDestacadosVM
    {
        public int Id { get; set; }
        public int Idpublicacion { get; set; }
        public int IndiceOrden { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activo {get;set; }
    }

    public class UsuarioFavoritosVM
    {
        public int IdUsuario { get; set; } 
        public int Idpublicacion { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Activo { get; set; }
    }

}
