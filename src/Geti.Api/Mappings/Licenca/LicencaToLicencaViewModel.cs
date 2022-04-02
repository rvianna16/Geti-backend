using AutoMapper;
using Geti.Api.ViewModels.Licenca;
using Geti.Business.Models;

namespace Geti.Api.Mappings.LicencaMap
{
    internal class LicencaToLicencaViewModel : Profile
    {
        public LicencaToLicencaViewModel()
        {
            CreateMap<Licenca, LicencaViewModel>()
                .ForMember(dest => dest.Disponivel, act => act.MapFrom(src => src.Quantidade - src.Equipamentos.Count))
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));

            CreateMap<LicencaViewModel, Licenca>();
        }
    }
}
