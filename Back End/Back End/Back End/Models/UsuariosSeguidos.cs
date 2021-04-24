using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class UsuariosSeguidos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioSeguido { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuarios Usuarios { get; set; }
        [ForeignKey("IdUsuarioSeguido")]
        public virtual Usuarios Usuarios2{ get; set; }
    }
}
