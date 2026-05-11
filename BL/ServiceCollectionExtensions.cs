//using BL.BLApi;
//using BL.BLImplements;
//using Dal;
//using BL.Profiles;
using BL.Bl_API;
using BL.BLIMplementens;
using BL.Mapper;
using Dal;
using Dal.Dal_API;
using Dal.Dal_Implementens;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{

    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeBl, EmployeeBl>();
            services.AddScoped<ICovidDatailsBl, CovidDetailsBl>();

            services.AddAutoMapper(typeof(EmployeeToEmployeeDTO));
            services.AddAutoMapper(typeof(AddressToAddressDTO));
            services.AddAutoMapper(typeof(CityToCityDTO));
            services.AddAutoMapper(typeof(CovidDetailToCovidDetailDTO));
            services.AddAutoMapper(typeof(StreetToStreetDTO));
            services.AddAutoMapper(typeof (VaccineManufacturerToVaccineManufacturerDTO));
            services.AddRepositories();

        }
    }

}
