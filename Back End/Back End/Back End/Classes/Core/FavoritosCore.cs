using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class FavoritosCore
    {
        FrostArtDBContext dbContext;
        public FavoritosCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreateFavorito(Favoritos favorito)
        {
            try
            {
                bool validFavorito = ValidateFavorito(favorito.IdUsuario, favorito.IdPublicacion);

                if (validFavorito)
                {
                    dbContext.Add(favorito);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateFavorito(int idusuario, int idpublicacion)
        {
            try
            {
                bool existFavorito = dbContext.Favoritos.Any(favorito => favorito.IdUsuario == idusuario && favorito.IdPublicacion == idpublicacion);
                if (existFavorito)
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

        public void EliminarFavorito(int idusuario, int idpublicacion)
        {
            try
            {
                Favoritos favorito = dbContext.Favoritos.FirstOrDefault(x => x.IdUsuario == idusuario && x.IdPublicacion == idpublicacion);

                dbContext.Remove(favorito);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
