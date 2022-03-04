using AutoMapper;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Colaborador;
using Geti.Api.ViewModels.Equipamento;
using Geti.Business.Models;

namespace Geti.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorEquipamentosViewModel>().ReverseMap();

            CreateMap<Licenca, LicencaViewModel>().ReverseMap();

            CreateMap<Comentario, ComentarioViewModel>().ReverseMap();

            CreateMap<EquipamentoViewModel, Equipamento>();
            CreateMap<Equipamento, EquipamentoViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));

            CreateMap<EquipamentoDetalhesViewModel, Equipamento>().ReverseMap();
            CreateMap<Equipamento, EquipamentoDetalhesViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));
        }
    }
}
