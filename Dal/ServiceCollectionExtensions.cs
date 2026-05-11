//using Dal.DalApi;
//using Dal.DalImplements;
//using Dal.DO;
using Dal.Dal_API;
using Dal.Dal_Implementens;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeDal, EmployeeServiceDal>();
            services.AddScoped<IAddressDal, AddressServiceDal>();
            services.AddScoped<ICityDal, CityServiceDal>();
            services.AddScoped<IStreetDal, StreetServiceDal>();
            services.AddScoped<ICovidDetailDal, CovidDetailServiceDal>();
            services.AddScoped<IVaccineManufacturerDal, VaccineManufacturerServiceDal>();



            //get the connection string from configuration...
            //calculate relative connection string...
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Owner\\תיכנות הכל\\תרגיל בית הדסים 4\\CoronaCare_HUb_exe_2\\db\\Database1.mdf\";Integrated Security=True;Connect Timeout=30";
                services.AddDbContext<DB_Context>(options => options.UseSqlServer(connString));
        }
    }
}
