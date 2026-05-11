using AutoMapper;
using BL.DTO_Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mapper
{
    public class StreetToStreetDTO : Profile
    {
        public StreetToStreetDTO()
        {
            CreateMap<Street, StreetDTO>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.CityName : null));
        }
    }
}
