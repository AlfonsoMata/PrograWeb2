using Back_End.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Back_End.Classes.Core
{
    public class TemasCore
    {
        FrostArtDBContext dbContext;
        public TemasCore(FrostArtDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
