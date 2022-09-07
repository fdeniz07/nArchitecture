namespace RentACar.Application.Features.Models.Profiles
{
    using AutoMapper;
    using Core.Persistence.Paging;
    using Domain.Entities;
    using Dtos;
    using Models;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>().
                ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
