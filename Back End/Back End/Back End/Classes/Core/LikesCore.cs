using Back_End.Models;
using Back_End.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class LikesCore
    {
        FrostArtDBContext dbContext;
        public LikesCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public void CreateLike(Likes like)
        {
            try
            {
                bool validLike = ValidateLike(like.IdUsuario,like.IdPublicacion);

                if (validLike)
                {
                    dbContext.Add(like);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateLike(int idusuario, int idpublicacion)
        {
            try
            {
                bool existUsuario = dbContext.Likes.Any(like => like.IdUsuario == idusuario && like.IdPublicacion == idpublicacion);
                if (existUsuario)
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

        public void EliminarLike(int idusuario, int idpublicacion)
        {
            try
            {
                Likes like = dbContext.Likes.FirstOrDefault(x => x.IdUsuario == idusuario && x.IdPublicacion == idpublicacion);

                dbContext.Remove(like);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Likes> GetLikes(int idpublicacion)
        {
            var likes = (
                from l in dbContext.Likes
                where l.IdPublicacion == idpublicacion
                select l
                ).ToList();
            return likes;
        }


        public List<LikesPublicacion> GetPublicacionesMasLikes()
        {
            var likes = (
                from l in dbContext.Likes
                group l by l.IdPublicacion into grp
                orderby grp.Count() descending, grp.Key descending
                select new LikesPublicacion
                {
                    IdPublicacion = grp.Key,
                    Likes = grp.Count()
                }
                ).ToList();
            return likes;
        }


        public List<LikesUsuario> GetLikesUsuario(int idusuario)
        {
            var likes = (
                from l in dbContext.Likes
                join p in dbContext.Publicaciones on l.IdPublicacion equals p.Id
                group p by p.IdUsuario into grp
                orderby grp.Count() descending, grp.Key descending
                where grp.Key == idusuario
                select new LikesUsuario
                {
                    IdUsuario = grp.Key,
                    Likes = grp.Count()
                }
                ).ToList();
            return likes;
        }


    }
}
