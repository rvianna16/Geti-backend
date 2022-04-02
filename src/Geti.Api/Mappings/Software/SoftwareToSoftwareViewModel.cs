using AutoMapper;
using Geti.Api.ViewModels.Software;
using Geti.Business.Models;

namespace Geti.Api.Mappings.SoftwareMap
{
    internal class SoftwareToSoftwareViewModel : Profile
    {
        public SoftwareToSoftwareViewModel()
        {
            CreateMap<Software, SoftwareViewModel>().ReverseMap();
            CreateMap<Software, SoftwareDetalhesViewModel>().ReverseMap();
        }
    }
}
