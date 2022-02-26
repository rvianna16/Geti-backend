using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Business.Models;

namespace Geti.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Equipamento, EquipamentoViewModel>().ReverseMap();
            CreateMap<Licenca, LicencaViewModel>().ReverseMap();
        }
    }
}
