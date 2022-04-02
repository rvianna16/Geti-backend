using AutoMapper;
using Geti.Api.ViewModels.Equipamento;
using Geti.Business.Models;

namespace Geti.Api.Mappings.EquipamentoMap
{
    internal class EquipamentoLicencaToEquipamentoLicencaBasicoViewModel : Profile
    {
        public EquipamentoLicencaToEquipamentoLicencaBasicoViewModel()
        {
            CreateMap<EquipamentoLicenca, EquipamentoLicencaBasicoViewModel>()
               .ForMember(dest => dest.Patrimonio, act => act.MapFrom(src => src.Equipamento.Patrimonio))
               .ForMember(dest => dest.TipoEquipamento, act => act.MapFrom(src => src.Equipamento.TipoEquipamento))
               .ForMember(dest => dest.StatusEquipamento, act => act.MapFrom(src => src.Equipamento.StatusEquipamento));
        }
    }
}
