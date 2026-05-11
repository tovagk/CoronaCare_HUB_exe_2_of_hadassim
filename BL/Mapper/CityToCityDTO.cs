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
    public class CityToCityDTO : Profile
    {
        public CityToCityDTO()
        {
            CreateMap<City, CityDTO>();
        }
    }
}
