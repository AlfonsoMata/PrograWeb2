using Back_End.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class UsuariosCore
    {
        FrostArtDBContext dbContext;
        public UsuariosCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Usuarios> LogIn(string nombre, string contra)
        {
            var usuarios = (
                from u in dbContext.Usuarios
                where u.Nombre == nombre && u.Contra == contra
                select u
                ).ToList();
            return usuarios;
        }
        public void Create(Usuarios usuario)
        {
            try
            {
                bool validUser = ValidateNotNull(usuario);

                if (validUser)
                {
                    dbContext.Add(usuario);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateNotNull(Usuarios usuarios)
        {
            try
            {
                if (string.IsNullOrEmpty(usuarios.Nombre) || string.IsNullOrEmpty(usuarios.Contra) || string.IsNullOrEmpty(usuarios.Email))
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

        public void ActualizaUsuario(Usuarios usuario, int id)
        {
            try
            {
                bool validUser = ValidateNotNull(usuario);

                if (validUser)
                {
                    bool existUsuario = dbContext.Usuarios.Any(usuario => usuario.Id == id);
                    if(existUsuario)
                    {
                        usuario.Id = id;

                        dbContext.Update(usuario);
                        dbContext.SaveChanges();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                Usuarios usuario = dbContext.Usuarios.Include(x=> x.Publicaciones).Include(x=> x.Likes)
                    .Include(x => x.Favoritos).Include(x => x.UsuariosSeguidos).Include(x => x.Comentarios).Include(x => x.UsuarioDestacado).FirstOrDefault(x => x.Id == id);

                dbContext.Remove(usuario);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
