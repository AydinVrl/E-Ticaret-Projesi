using AutoMapper;
using FinalProject.Entities.DTOs;
using FinalProject.Entities.Models;

namespace FinalProject.WebApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
            CreateMap<ProductDTO, Product>().ReverseMap();
        }
    }
}
