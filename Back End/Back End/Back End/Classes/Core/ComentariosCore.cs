using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class ComentariosCore
    {

        FrostArtDBContext dbContext;
        public ComentariosCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public void CreateComentario(Comentarios comentario)
        {
            try
            {
                bool validComent = ValidateNotNullComentario(comentario);

                if (validComent)
                {
                    dbContext.Add(comentario);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateNotNullComentario(Comentarios comentario)
        {
            try
            {
                if (string.IsNullOrEmpty(comentario.IdUsuario.ToString()) || string.IsNullOrEmpty(comentario.IdPublicacion.ToString()) || string.IsNullOrEmpty(comentario.Texto) || string.IsNullOrEmpty(comentario.Fecha.ToString()) || string.IsNullOrEmpty(comentario.Activo.ToString()))
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

        public void DesabilitarComentario(int id)
        {
            try
            {
                Comentarios comentario = dbContext.Comentarios.FirstOrDefault(x => x.Id == id && x.Activo);
                if (comentario != null)
                {
                    comentario.Activo = false;
                    dbContext.Update(comentario);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Comentarios> GetComentariosPublicacion(int idpubli)
        {
            var comentarios = (
                from c in dbContext.Comentarios
                where c.IdPublicacion == idpubli && c.Activo == true
                select c
                ).ToList();
            return comentarios;
        }


    }
}
