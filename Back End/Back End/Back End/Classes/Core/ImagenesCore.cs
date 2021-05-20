using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class ImagenesCore
    {
        FrostArtDBContext dbContext;
        public ImagenesCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void SubirImagen(Imagenes imagen)
        {
            try
            {
                    dbContext.Add(imagen);
                    dbContext.SaveChanges();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarImagen(int id)
        {
            try
            {
                Imagenes imagen = dbContext.Imagenes.FirstOrDefault(x => x.Id == id);

                dbContext.Remove(imagen);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Imagenes> GetImagenes(int idpublicacion)
        {
            var imagenes = (
                from i in dbContext.Imagenes
                where i.IdPublicacion == idpublicacion
                select i
                ).ToList();
            return imagenes;
        }
    }
}
