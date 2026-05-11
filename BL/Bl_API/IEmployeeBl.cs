using BL.BLApi;
using BL.DTO_Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Bl_API
{
    public interface IEmployeeBl :IBl<EmployeeDTO>
    {
        Task<EmployeeDTO> GetByNumberIdAsync(string idNumber);

    }
}
