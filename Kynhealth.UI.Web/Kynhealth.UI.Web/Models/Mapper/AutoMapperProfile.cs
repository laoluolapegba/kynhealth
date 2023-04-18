using AutoMapper;
using Kynhealth.Entities;

namespace Kynhealth.UI.Web.Models.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Organization, OrganizationViewModel>()
                .ForMember(l => l.LocalGovtname, o => o.MapFrom(src => src.Lga.LgaName))
                .ForMember(l => l.StateName, o => o.MapFrom(src => src.State.StateName))
                .ForMember(l => l.CountryName, o => o.MapFrom(src => src.Country.CountryName));
        }
    }
}
