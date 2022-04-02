using AutoMapper;
using Geti.Api.Data;
using Geti.Api.ViewModels.Usuario;

namespace Geti.Api.Mappings.User
{
    internal class UserBascioViewModelToApplicationUser : Profile
    {
        public UserBascioViewModelToApplicationUser()
        {
            CreateMap<UserBasicoViewModel, ApplicationUser>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, act => act.MapFrom(src => src.Id)).ReverseMap();
        }
    }
}
