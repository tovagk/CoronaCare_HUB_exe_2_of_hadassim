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

    public class CovidDetailToCovidDetailDTO : Profile
    {
        public CovidDetailToCovidDetailDTO()
        {
            CreateMap<CovidDetail, CovidDetailDTO>()
                   .ForMember(dest => dest.VaccineManufacturerName, opt => opt.MapFrom(src => src.VaccineManufacturer != null ? src.VaccineManufacturer.ManufacturerName : null))
                   .ReverseMap();
        }
    }
}
