using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Equipamento;
using Geti.Business.Models;

namespace Geti.Api.Mappings.EquipamentoMap
{
    internal class EquipamentoToEquipamentoViewModel : Profile
    {
        public EquipamentoToEquipamentoViewModel()
        {
            CreateMap<Equipamento, EquipamentoViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));

            CreateMap<Equipamento, EquipamentoDetalhesViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));

            CreateMap<EquipamentoViewModel, Equipamento>();
            CreateMap<Equipamento, EquipamentoLicencaBasicoViewModel>().ReverseMap();
            CreateMap<AddEquipamentoLicencaViewModel, EquipamentoLicenca>().ReverseMap();
            CreateMap<EquipamentoLicenca, EquipamentoDetalhesViewModel>().ReverseMap();
        }
    }
}
