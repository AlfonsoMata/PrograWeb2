using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class UsuariosSeguidosCore
    {
        FrostArtDBContext dbContext;
        public UsuariosSeguidosCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreateUsuarioSeguido(UsuariosSeguidos seguido)
        {
            try
            {
                bool validSeguido = ValidateSeguido(seguido.IdUsuario, seguido.IdUsuarioSeguido);

                if (validSeguido)
                {
                    dbContext.Add(seguido);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateSeguido(int idusuario, int idusuarioseguido)
        {
            try
            {
                bool existseguido = dbContext.usuariosSeguidos.Any(seguido => seguido.IdUsuario == idusuario && seguido.IdUsuarioSeguido == idusuarioseguido);
                if (existseguido)
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

        public void BorrarUsuarioSeguido(int idusuario, int idusuarioseguido)
        {
            try
            {
                UsuariosSeguidos seguidos = dbContext.usuariosSeguidos.FirstOrDefault(x => x.IdUsuario == idusuario && x.IdUsuarioSeguido == idusuarioseguido);

                dbContext.Remove(seguidos);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
