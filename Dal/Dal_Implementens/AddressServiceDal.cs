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
    public class AddressServiceDal : IAddressDal
    {
        DB_Context context;

        public AddressServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Address entity)
        {
            context.Addresses.Add(entity);
            await context.SaveChangesAsync();
            return entity.AddressId;         
        }

        public Task<List<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
