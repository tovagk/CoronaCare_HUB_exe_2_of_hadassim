using Dal.Dal_API;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Dal_Implementens
{
    public class VaccineManufacturerServiceDal : IVaccineManufacturerDal
    {
        DB_Context context;

        public VaccineManufacturerServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(VaccineManufacturer entity)
        {
            context.VaccineManufacturers.Add(entity);
            await context.SaveChangesAsync();
            return entity.ManufacturerId;
        }

        public Task<List<VaccineManufacturer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VaccineManufacturer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VaccineManufacturer> GetByNameAsync(string name)
        {
            return await context.VaccineManufacturers.FirstOrDefaultAsync(m => m.ManufacturerName == name);
        }
    }
}
