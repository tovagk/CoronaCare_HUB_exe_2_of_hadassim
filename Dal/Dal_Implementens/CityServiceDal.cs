using Dal.Dal_API;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Dal_Implementens
{
    public class CityServiceDal : ICityDal
    {
        DB_Context context;

        public CityServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(City entity)
        {
            context.Cities.Add(entity);
            await context.SaveChangesAsync();
            return entity.CityId;
        }

        public Task<List<City>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetByNameAsync(string name)
        {
            return await context.Cities.FirstOrDefaultAsync(c => c.CityName == name);
        }
    }
}
