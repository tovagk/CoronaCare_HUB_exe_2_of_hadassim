using AutoMapper;
using BL.Bl_API;
using BL.DTO_Models;
using Dal.Dal_API;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.BLIMplementens
{
    /// <summary>
    /// Implementation of the IEmployeeBl interface to handle employee operations.
    /// </summary>
    public class EmployeeBl : IEmployeeBl
    {
        private readonly IEmployeeDal employeeDal;
        private readonly IMapper mapper;
        private readonly IAddressDal addressDal;
        private readonly ICityDal cityDal;
        private readonly IStreetDal streetDal;
        private readonly ICovidDatailsBl covidDatailesBl;

        public EmployeeBl(IEmployeeDal employeeDal, IMapper mapper, ICityDal cityDal, IStreetDal streetDal, IAddressDal addressDal, ICovidDatailsBl covidDatailesBl)
        {
            this.employeeDal = employeeDal;
            this.mapper = mapper;
            this.cityDal = cityDal;
            this.streetDal = streetDal;
            this.addressDal = addressDal;
            this.covidDatailesBl = covidDatailesBl;
        }

        /// <summary>
        /// Creates a new employee record with associated address and Covid details.
        /// </summary>
        /// <param name="entity">The EmployeeDTO object containing the details to be created.</param>
        /// <returns>The ID of the created employee record.</returns>
        public async Task<int> CreateAsync(EmployeeDTO entity)
        {
            // Check if Employee exists
            Employee existingEmployee = await employeeDal.GetByEmployeeNumberIdAsync(entity.Idnumber);

            if (existingEmployee != null)
            {
                return existingEmployee.EmployeeId;
            }

            // Check if City exists, if not, create it
            City city = await cityDal.GetByNameAsync(entity.CityName);
            int cityId;
            if (city == null)
            {
                city = new City { CityName = entity.CityName };
                cityId = await cityDal.CreateAsync(city);
            }
            else
            {
                cityId = city.CityId;
            }

            // Check if Street exists, if not, create it
            Street street = await streetDal.GetByNameAsync(entity.StreetName);
            int streetId;
            if (street == null)
            {
                // Street doesn't exist, create it
                street = new Street { StreetName = entity.StreetName, CityId = cityId }; // Assuming street requires cityId
                streetId = await streetDal.CreateAsync(street);
            }
            else
            {
                streetId = street.StreetId;
            }

            // Create Address
            Address address = new Address { StreetId = streetId, StreetNumber = entity.StreetNumber };
            int addressId = await addressDal.CreateAsync(address);

            // Create Employee
            Employee employee = mapper.Map<Employee>(entity);
            employee.AddressId = addressId;
            await employeeDal.CreateAsync(employee);

            // Create CovidDetail
            CovidDetailDTO covidDetailDTO = entity.CovidDetail;
            await covidDatailesBl.CreateAsync(covidDetailDTO);

            return employee.EmployeeId;
        }

        /// <summary>
        /// Retrieves all employee records with associated Covid details.
        /// </summary>
        /// <returns>A list of EmployeeDTO objects representing the retrieved employee records.</returns>
        public async Task<List<EmployeeDTO>> GetAllAsync()
        {
            var employees = await employeeDal.GetAllAsync();
            var employeeDTOs = mapper.Map<List<EmployeeDTO>>(employees);

            // Now, for each EmployeeDTO, fetch its CovidDetailDTO
            foreach (var employeeDTO in employeeDTOs)
            {
                // Get CovidDetailDTO for the current employee
                employeeDTO.CovidDetail = await covidDatailesBl.GetByIdAsync(employeeDTO.EmployeeId);
            }

            return employeeDTOs;
        }

        /// <summary>
        /// Retrieves an employee record by its ID.
        /// </summary>
        /// <param name="id">The ID of the employee record to retrieve.</param>
        /// <returns>The EmployeeDTO object representing the retrieved employee record.</returns>
        public async Task<EmployeeDTO> GetByIdAsync(int id)
        {
            Employee employee = await employeeDal.GetByIdAsync(id);

            if (employee == null)
                return null;

            EmployeeDTO employeeDTO = mapper.Map<EmployeeDTO>(employee);
            return employeeDTO;
        }

        /// <summary>
        /// Retrieves an employee record by its unique identification number.
        /// </summary>
        /// <param name="idNumber">The unique identification number of the employee.</param>
        /// <returns>The EmployeeDTO object representing the retrieved employee record.</returns>
        public async Task<EmployeeDTO> GetByNumberIdAsync(string idNumber)
        {
            Employee employee = await employeeDal.GetByIdNumberAsync(idNumber);
            if (employee == null)
            {
                return null;
            }
            EmployeeDTO employeeDTO = mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;
        }

    }
}
