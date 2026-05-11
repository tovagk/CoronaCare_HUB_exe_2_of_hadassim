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
    public class AddressToAddressDTO : Profile
    {
        public AddressToAddressDTO()
        {
            CreateMap<Address, AddressDTO>()
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.Street != null ? src.Street.StreetName : null))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.Street != null && src.Street.City != null ? src.Street.City.CityName : null));

        }
    }
 }
