using Back_End.Models;
using Back_End.Models.ViewModels;
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

        public List<PublicacionUsuarioPreviewVM> GetPublicacionUsuarioPreview(int id)
        {
            try
            {
                //consultar
                //unir
                var consulta = (from p in dbContext.Publicaciones
                                join u in dbContext.Usuarios on p.IdUsuario equals u.Id
                                join t in dbContext.Temas on p.IdTema equals t.Id
                                join pe in dbContext.PublicacionEtiquetas on p.Id equals pe.IdPublicacion
                                join ee in dbContext.Etiquetas on pe.IdEtiqueta equals ee.Id
                                where u.Id == id && p.Activo == true
                                select new
                                {
                                    IdPublicacion = p.Id,
                                    IdUsuario = u.Id,
                                    NombreUsuario = u.Nombre,
                                    FotoPerfil = u.FotoPerfil,
                                    Titulo = p.Titulo,
                                    Descripcion = p.Descripcion,
                                    IdTema = t.Id,
                                    NombreTema = t.Nombre,
                                    Fecha = p.Fecha,
                                    Activo = p.Activo,
                                    IdEtiqueta = ee.Id,
                                    EtiquetaNombre = ee.Nombre
                                }).ToList();

                var agrupador = consulta.GroupBy(x => (x.IdPublicacion, x.IdUsuario, x.NombreUsuario, x.FotoPerfil, x.Titulo, x.Descripcion, x.IdTema, x.NombreTema, x.Fecha, x.Activo));

                //estructurar
                List<PublicacionUsuarioPreviewVM> estructura = agrupador.Select(x => new PublicacionUsuarioPreviewVM
                {
                    IdPublicacion = x.Key.IdPublicacion,
                    IdUsuario = x.Key.IdUsuario,
                    NombreUsuario = x.Key.NombreUsuario,
                    FotoPerfil = x.Key.FotoPerfil,
                    Titulo = x.Key.Titulo,
                    Descripcion = x.Key.Descripcion,
                    IdTema = x.Key.IdTema,
                    NombreTema = x.Key.NombreTema,
                    Fecha = x.Key.Fecha,
                    Activo = x.Key.Activo,
                    Etiquetas = x.Select(y => new PublicacionEtiquetasVM
                    {
                        Id = y.IdEtiqueta,
                        Nombre = y.EtiquetaNombre
                    }).ToList()
                }).ToList();

                return estructura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CreatePublicacion(Publicaciones publicacion)
        {
            try
            {
                bool validPubli = ValidateNotNullPublicacion(publicacion);

                if (validPubli)
                {
                    dbContext.Add(publicacion);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateNotNullPublicacion(Publicaciones publicacion)
        {
            try
            {
                if (string.IsNullOrEmpty(publicacion.IdUsuario.ToString()) || string.IsNullOrEmpty(publicacion.Titulo) || string.IsNullOrEmpty(publicacion.IdTema.ToString()) || string.IsNullOrEmpty(publicacion.Fecha.ToString()) || string.IsNullOrEmpty(publicacion.Activo.ToString()))
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
    }
}
