using AutoMapper;
using Business.Dto;
using Domain.Entities;
using Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ApplicationAutoMapperProfile:Profile
    {
        public ApplicationAutoMapperProfile()
        {
            this.CreateMap<CategoryDto, Category>().ReverseMap();
            this.CreateMap<NewsDto, News>().ReverseMap();
            this.CreateMap<ApplicationUser, UserDto>().ReverseMap();
        }
    }
}
