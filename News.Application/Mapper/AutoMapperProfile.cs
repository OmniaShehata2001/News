using AutoMapper;
using News.Dtos;
using News.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() 
       {
            CreateMap<news, NewsDto>().ReverseMap();
            CreateMap<NewsDto, news>()
                            .ForMember(dest => dest.NewsImage, opt => opt.MapFrom(src => src.NewsImageString))
                            .ReverseMap()
                            .ForMember(dest => dest.NewsImage, opt => opt.Ignore())
                            .ForMember(dest => dest.NewsImageString, opt => opt.MapFrom(src => src.NewsImage));
        }
    }
}
