using Dal.Dal_API;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Dal_Implementens
{
    public class CovidDetailServiceDal : ICovidDetailDal
    {
        DB_Context context;

        public CovidDetailServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(CovidDetail entity)
        {
            context.CovidDetails.Add(entity);
            await context.SaveChangesAsync();
            return entity.EmployeeId;
        }

        public async Task<List<CovidDetail>> GetAllAsync()
        {
            return await context.CovidDetails
                            .Include(cd => cd.Employee)
                                .ThenInclude(emp => emp.Address)
                            .Include(cd => cd.VaccineManufacturer)
                            .ToListAsync();
        }

        public async Task<CovidDetail> GetByIdAsync(int id)
        {
            return await context.Set<CovidDetail>().FindAsync(id);
        }

        public Task<CovidDetail> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
