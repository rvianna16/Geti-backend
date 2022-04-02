using AutoMapper;
using Geti.Api.ViewModels.Colaborador;
using Geti.Business.Models;

namespace Geti.Api.Mappings.ColaboradorMap
{
    internal class ColaboradorToColaboradorEquipamentosViewModel : Profile
    {
        public ColaboradorToColaboradorEquipamentosViewModel()
        {
            CreateMap<Colaborador, ColaboradorEquipamentosViewModel>().ReverseMap();
        }
    }
}
