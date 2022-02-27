using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Data.Repository
{
    public class ComentarioRepository : Repository<Comentario>, IComentarioRepository
    {
        public ComentarioRepository(GetiDbContext context) : base(context) { }

        public async Task<Comentario> ObterComentario(Guid id)
        {
            return await Db.Comentarios.AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
