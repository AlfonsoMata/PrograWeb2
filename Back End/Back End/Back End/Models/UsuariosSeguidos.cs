using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class UsuariosSeguidos
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdUsuarioSeguido { get; set; }

        public virtual Usuarios Usuarios { get; set; }
        public virtual Usuarios Usuarios2{ get; set; }
    }
}
