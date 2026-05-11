using Dal.DalApi;
using Dal.Models;
using System.Threading.Tasks;

namespace Dal.Dal_API
{
    public interface IEmployeeDal : IDal<Employee>
    {
        Task<Employee> GetByIdNumberAsync(string IdNumber);

        Task<Employee> GetByEmployeeNumberIdAsync(string IdNumber);
    }
}
