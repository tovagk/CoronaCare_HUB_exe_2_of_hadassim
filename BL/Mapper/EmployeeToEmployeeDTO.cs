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
    public class EmployeeToEmployeeDTO : Profile
    {

        public EmployeeToEmployeeDTO()
        {

            CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Address != null && src.Address.Street != null && src.Address.Street.City != null ? src.Address.Street.City.CityName : null))
            .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Address != null && src.Address.Street != null ? src.Address.Street.StreetName : null))
            .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.Address != null ? src.Address.StreetNumber : null))
            .ReverseMap();
        }
    }
}
