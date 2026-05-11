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
    public class StreetServiceDal : IStreetDal
    {
        DB_Context context;

        public StreetServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Street entity)
        {
            context.Streets.Add(entity);
            await context.SaveChangesAsync();
            return entity.StreetId;
        }

        public Task<List<Street>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Street> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Street> GetByNameAsync(string name)
        {
                return await context.Streets.FirstOrDefaultAsync(s => s.StreetName == name);
        }
    }
}
