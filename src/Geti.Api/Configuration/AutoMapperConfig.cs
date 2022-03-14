using AutoMapper;
using Geti.Api.Controllers;
using Geti.Api.ViewModels;
using Geti.Api.ViewModels.Colaborador;
using Geti.Api.ViewModels.Equipamento;
using Geti.Api.ViewModels.Licenca;
using Geti.Api.ViewModels.Software;
using Geti.Business.Models;
using System.Linq;

namespace Geti.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            /// <summary>
            /// Colaborador
            /// </summary>
            CreateMap<Colaborador, ColaboradorViewModel>().ReverseMap();
            CreateMap<Colaborador, ColaboradorEquipamentosViewModel>().ReverseMap();

            /// <summary>
            /// Licenca
            /// </summary>
            CreateMap<Licenca, LicencaViewModel>()
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));

            CreateMap<Licenca, LicencaDetalhesViewModel>()
                .ForMember(dest => dest.Disponivel, act => act.MapFrom(src => src.Quantidade - src.Equipamentos.Count()))
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));

            CreateMap<Licenca, LicencaEquipamentoBasicoViewModel>()
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Software.Nome));

            /// <summary>
            /// Software
            /// </summary>
            CreateMap<Software, SoftwareViewModel>().ReverseMap();
            CreateMap<Software, SoftwareDetalhesViewModel>().ReverseMap();

            /// <summary>
            /// Comentario
            /// </summary>
            CreateMap<Comentario, ComentarioViewModel>().ReverseMap();

            /// <summary>
            /// Equipamento
            /// </summary>
            CreateMap<EquipamentoViewModel, Equipamento>();
            CreateMap<Equipamento, EquipamentoViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));

            CreateMap<Equipamento, EquipamentoLicencaBasicoViewModel>().ReverseMap();

            CreateMap<EquipamentoLicenca, EquipamentoDetalhesViewModel>().ReverseMap();

            CreateMap<EquipamentoLicenca, LicencaEquipamentoBasicoViewModel>()
                .ForMember(dest => dest.Nome, act => act.MapFrom(src => src.Licenca.Nome))
                .ForMember(dest => dest.Chave, act => act.MapFrom(src => src.Licenca.Chave))
                .ForMember(dest => dest.Software, act => act.MapFrom(src => src.Licenca.Software.Nome));                

            CreateMap<Equipamento, EquipamentoDetalhesViewModel>()
                .ForMember(dest => dest.NomeColaborador, act => act.MapFrom(src => src.Colaborador.Nome));

            CreateMap<AddEquipamentoLicencaViewModel, EquipamentoLicenca>().ReverseMap();           

            CreateMap<EquipamentoLicenca, EquipamentoLicencaBasicoViewModel>()
               .ForMember(dest => dest.Patrimonio, act => act.MapFrom(src => src.Equipamento.Patrimonio))
               .ForMember(dest => dest.TipoEquipamento, act => act.MapFrom(src => src.Equipamento.TipoEquipamento));                          

        }
    }
}
