using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class PublicacionesCore
    {
        FrostArtDBContext dbContext;
        public PublicacionesCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void DesabilitarPublicacion(int id)
        {
            try
            {
                Publicaciones publicacion = dbContext.Publicaciones.FirstOrDefault(x => x.Id == id && x.Activo);
                if(publicacion != null)
                {
                    publicacion.Activo = false;
                    dbContext.Update(publicacion);
                    dbContext.SaveChanges();
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
