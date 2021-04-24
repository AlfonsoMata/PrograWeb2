using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class UsuarioDestacadosCore
    {
        FrostArtDBContext dbContext;
        public UsuarioDestacadosCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }




        public void CreateUsuarioDestacado(UsuarioDestacados destacado)
        {
            try
            {
                bool validDestacado = ValidateDestacado(destacado.IdUsuario, destacado.IdPublicacion);

                if (validDestacado)
                {
                    dbContext.Add(destacado);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateDestacado(int idusuario, int idpublicacion)
        {
            try
            {
                bool existDestacado = dbContext.UsuarioDestacados.Any(destacado => destacado.IdUsuario == idusuario && destacado.IdPublicacion == idpublicacion);
                if (existDestacado)
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

        public void BorrarUsuarioDestacado(int idusuario, int idpublicacion)
        {
            try
            {
                UsuarioDestacados destacados = dbContext.UsuarioDestacados.FirstOrDefault(x => x.IdUsuario == idusuario && x.IdPublicacion == idpublicacion);

                dbContext.Remove(destacados);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
