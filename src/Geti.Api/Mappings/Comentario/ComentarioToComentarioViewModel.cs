using AutoMapper;
using Geti.Api.ViewModels.Equipamento;
using Geti.Business.Models;

namespace Geti.Api.Mappings.ComentarioMap
{
    internal class ComentarioToComentarioViewModel : Profile
    {
        public ComentarioToComentarioViewModel()
        {
            CreateMap<Comentario, ComentarioViewModel>().ReverseMap();
        }
    }
}
