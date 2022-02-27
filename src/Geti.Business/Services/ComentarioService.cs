using Geti.Business.Interfaces;
using Geti.Business.Models;
using Geti.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geti.Business.Services
{
    public class ComentarioService : BaseService, IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(
            IComentarioRepository comentarioRepository,
            INotificador notificador
            ) : base(notificador)
        {
            _comentarioRepository = comentarioRepository;
        }
        public async Task Adicionar(Comentario comentario)
        {
            if (!ExecutarValidacao(new ComentarioValidation(), comentario)) return;


            await _comentarioRepository.Adicionar(comentario);
        }

        public async Task Remover(Guid id)
        {
            await _comentarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _comentarioRepository?.Dispose();
        }
    }
}
