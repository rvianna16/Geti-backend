using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Business.Models;

namespace Geti.Api.Mappings.LicencaMap
{
    internal class LicencaToLicencaDetalhesViewModel : Profile
    {
        public LicencaToLicencaDetalhesViewModel()
        {
            CreateMap<Licenca, LicencaDetalhesViewModel>()
                .ForMember(dest => dest.Disponivel, act => act.MapFrom(src => src.Quantidade - src.Equipamentos.Count))
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));
        }
    }
}
