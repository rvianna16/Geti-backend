using AutoMapper;
using Geti.Api.ViewModels.Licenca;
using Geti.Business.Models;

namespace Geti.Api.Mappings.EquipamentoMap
{
    internal class EquipamentoLicencaToLicencaEquipamentoBasicoViewModel : Profile
    {
        public EquipamentoLicencaToLicencaEquipamentoBasicoViewModel()
        {
            CreateMap<EquipamentoLicenca, LicencaEquipamentoBasicoViewModel>()
                .ForMember(dest => dest.Nome, act => act.MapFrom(src => src.Licenca.Nome))
                .ForMember(dest => dest.Chave, act => act.MapFrom(src => src.Licenca.Chave))
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Licenca.Software.Nome));
        }
    }
}
