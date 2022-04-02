using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Business.Models;

namespace Geti.Api.Mappings.ColaboradorMap
{
    internal class ColaboradorToColaboradorViewModel : Profile
    {
        public ColaboradorToColaboradorViewModel()
        {
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
        }
    }
}
