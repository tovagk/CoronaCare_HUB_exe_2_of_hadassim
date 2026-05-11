using Dal.Dal_API;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Dal_Implementens
{
    public class EmployeeServiceDal : IEmployeeDal
    {
        DB_Context context;

        public EmployeeServiceDal(DB_Context context)
        {
            this.context = context;
        }
        public async Task<int> CreateAsync(Employee entity)
        {
            context.Employees.Add(entity);
            await context.SaveChangesAsync();
            return entity.EmployeeId;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await context.Set<Employee>()
                .Include(e => e.Address) // Include related Address entity
                    .ThenInclude(a => a.Street) // Include related Street entity within Address
                        .ThenInclude(s => s.City) // Include related City entity within Street
                .Include(e => e.CovidDetail) // Include related CovidDetail entity
                    .ThenInclude(cd => cd.VaccineManufacturer) // Include related VaccineManufacturer entity within CovidDetail
                .ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await context.Employees
                .Include(e => e.Address)
                    .ThenInclude(a => a.Street)
                        .ThenInclude(s => s.City)
                .Include(e => e.CovidDetail)
                    .ThenInclude(cd => cd.VaccineManufacturer)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }

        public Task<Employee> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetByIdNumberAsync(string IdNumber)
        {
            return await context.Employees.FirstOrDefaultAsync(s => s.Idnumber == IdNumber);
        }

        public async Task<Employee> GetByEmployeeNumberIdAsync(string IdNumber)
        {
            return await context.Employees.FirstOrDefaultAsync(e => e.Idnumber == IdNumber);
        }
    }
}
