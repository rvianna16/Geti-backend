using AutoMapper;
using Geti.Api.ViewModels.Licenca;
using Geti.Business.Models;

namespace Geti.Api.Mappings.LicencaMap
{
    internal class LicencaToLicencaEquipamentoBasicoViewModel : Profile
    {
        public LicencaToLicencaEquipamentoBasicoViewModel()
        {
            CreateMap<Licenca, LicencaEquipamentoBasicoViewModel>()
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));
        }
    }
}
