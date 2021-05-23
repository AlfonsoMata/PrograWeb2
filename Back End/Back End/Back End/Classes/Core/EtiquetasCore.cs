﻿using Back_End.Models;
using Back_End.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Back_End.Classes.Core
{
    public class EtiquetasCore
    {
        FrostArtDBContext dbContext;
        public EtiquetasCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public string CreateEtiqueta(Etiquetas etiqueta)
        {
            try
            {
                bool validEtiqueta = ValidateNotNullEtiqueta(etiqueta);

                if (validEtiqueta)
                {
                    dbContext.Add(etiqueta);
                    dbContext.SaveChanges();
                    return etiqueta.Id.ToString();
                }
                return "Null";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidateNotNullEtiqueta(Etiquetas etiqueta)
        {
            try
            {
               // bool existUsuario = dbContext.Usuarios.Any(usuario => usuario.Id == id);
                if (string.IsNullOrEmpty(etiqueta.Nombre)|| dbContext.Etiquetas.Any(a => a.Nombre == etiqueta.Nombre))
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
