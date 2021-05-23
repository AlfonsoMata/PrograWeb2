using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class PublicacionEtiquetasCore
    {
        FrostArtDBContext dbContext;
        public PublicacionEtiquetasCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string CreatePublicacionEtiqueta(PublicacionEtiquetas publicacionEtiquetas)
        {
            try
            {
                bool validPubli = ValidateNotNullPublicacionEtiqueta(publicacionEtiquetas);

                if (validPubli)
                {
                    dbContext.Add(publicacionEtiquetas);
                    dbContext.SaveChanges();
                    return publicacionEtiquetas.Id.ToString();
                }
                return "Null";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool ValidateNotNullPublicacionEtiqueta(PublicacionEtiquetas publicacionEtiquetas)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacionEtiquetas.IdEtiqueta.ToString()) || string.IsNullOrEmpty(publicacionEtiquetas.IdPublicacion.ToString()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public void EliminarPublicacionEtiqueta(int id)
        {
            try
            {
                PublicacionEtiquetas publicacionEtiquetas = dbContext.PublicacionEtiquetas.FirstOrDefault(x => x.Id == id);

                dbContext.Remove(publicacionEtiquetas);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<PublicacionEtiquetas> GetPublicacionPublicacionEtiquetas(int idpublicacion)
        {
            var publicaciones = (
                from p in dbContext.PublicacionEtiquetas
                where p.IdPublicacion == idpublicacion
                select new PublicacionEtiquetas
                {
                    Id = p.Id,
                    IdEtiqueta = p.IdEtiqueta,
                    IdPublicacion = p.IdPublicacion
                }
                ).ToList();
            return publicaciones;
        }
    }
}
