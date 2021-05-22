using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Models.ViewModels
{
    public class LikesVM
    {
    }

    public class LikesPublicacion
    {
        public int Likes { get; set; }
        public int IdPublicacion { get; set; }
    }
    public class LikesUsuario
    {
        public int Likes { get; set; }
        public int IdUsuario { get; set; }
    }

}
