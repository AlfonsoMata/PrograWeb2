using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models
{
    public class Etiquetas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PublicacionEtiquetas> PublicacionEtiquetas { get; set; }
    }
}

