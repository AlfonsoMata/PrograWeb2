using Back_End.Models;
using Back_End.Models.ViewModels;
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
                Usuarios usuario = dbContext.Usuarios.FirstOrDefault(x => x.Id == id);

                dbContext.Remove(usuario);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
        public UsuarioVM GetUsuario(int id)
        {
            try
            {
                //consultar
                //unir
                var consulta = (from us in dbContext.Usuarios
                                join ss in dbContext.usuariosSeguidos on us.Id equals ss.IdUsuario
                                where us.Id == id
                                select new
                                {
                                    Id = us.Id,
                                    CompleteName = $"{us.Nombre} {us.Id}",
                                    SSName = ss.Name,
                                    SSCredits = ss.Credits
                                }).ToList();

                var agrupador = consulta.GroupBy(x => (x.Id, x.CompleteName));

                //estructurar
                UsuarioVM estructura = agrupador.Select(x => new UsuarioVM
                {
                    CompleteName = x.Key.CompleteName,
                    Subjects = x.Select(y => new SubjectViewModel
                    {
                        Name = y.SSName,
                        Credits = y.SSCredits
                    }).ToList()
                }).First();

                return estructura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        */

        public UsuarioPerfilVM GetUsuarioPerfil(int id)
        {
            try
            {
                //consultar
                //unir
                var consulta = (from us in dbContext.Usuarios
                                join ss in dbContext.usuariosSeguidos on us.Id equals ss.IdUsuario
                                join aaa in dbContext.Usuarios on ss.IdUsuarioSeguido equals aaa.Id
                                   where us.Id == id
                                select new
                                {
                                    Id = us.Id,
                                    Nombre = us.Nombre,
                                    Descripcion = us.Descripcion,
                                    FotoPerfil = us.FotoPerfil,
                                    IdUsuarioSeguido = ss.IdUsuarioSeguido,
                                    SeguidoNombre = aaa.Nombre,
                                    SeguidoFoto = aaa.FotoPerfil
                                }).ToList();

                var agrupador = consulta.GroupBy(x => (x.Id, x.Nombre, x.Descripcion,x.FotoPerfil));

                //estructurar
                UsuarioPerfilVM estructura = agrupador.Select(x => new UsuarioPerfilVM
                {
                    Id = x.Key.Id,
                    Nombre = x.Key.Nombre,
                    Descripcion = x.Key.Descripcion,
                    FotoPerfil = x.Key.FotoPerfil,
                    Seguidos = x.Select(y => new UsuariosSeguidosVM
                    {
                        Id = y.IdUsuarioSeguido,
                        Nombre = y.SeguidoNombre,
                        FotoPerfil = y.FotoPerfil
                    }).ToList()
                }).First();

                return estructura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<UsuarioDestacadosVM> GetUsuarioDestacados(int id)
        {
            List<UsuarioDestacadosVM> destacados = (
                from ud in dbContext.UsuarioDestacados
                join u in dbContext.Usuarios on ud.IdUsuario equals u.Id
                join p in dbContext.Publicaciones on ud.IdPublicacion equals p.Id
                where u.Id == id
                select new UsuarioDestacadosVM
                {
                    Idpublicacion = ud.IdPublicacion,
                    IndiceOrden = ud.IndiceOrden,
                    Titulo = p.Titulo,
                    Fecha = p.Fecha,
                    Activo = p.Activo
                }
                ).ToList();
            return destacados;
        }


        public List<UsuarioFavoritosVM> GetUsuarioFavoritos(int id)
        {
            List<UsuarioFavoritosVM> destacados = (
                from f in dbContext.Favoritos
                join u in dbContext.Usuarios on f.IdUsuario equals u.Id
                join p in dbContext.Publicaciones on f.IdPublicacion equals p.Id
                where u.Id == id && p.Activo == true
                select new UsuarioFavoritosVM
                {
                    IdUsuario = u.Id,
                    Idpublicacion = f.IdPublicacion,
                    Titulo = p.Titulo,
                    Fecha = p.Fecha,
                    Activo = p.Activo
                }
                ).ToList();
            return destacados;
        }
    }
    
}
