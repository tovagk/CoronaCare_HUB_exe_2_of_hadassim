using AutoMapper;
using BL.Bl_API;
using BL.BLApi;
using BL.DTO_Models;
using Dal.Dal_API;
using Dal.Dal_Implementens;
using Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL.BLIMplementens
{
    
    public class CovidDetailsBl : ICovidDatailsBl
    {
        private readonly ICovidDetailDal covidDetailDal;
        private readonly IMapper mapper;
        private readonly IEmployeeDal employeeDal;
        private readonly IVaccineManufacturerDal vaccineManufacturerDal;

        public CovidDetailsBl(ICovidDetailDal covidDetailDal, IMapper mapper, IEmployeeDal employeeDal, IVaccineManufacturerDal vaccineManufacturerDal)
        {
            this.covidDetailDal = covidDetailDal;
            this.employeeDal = employeeDal;
            this.mapper = mapper;
            this.vaccineManufacturerDal = vaccineManufacturerDal;
        }

        /// <summary>
        /// Creates a new Covid detail record if it doesn't already exist.
        /// </summary>
        /// <param name="entity">The CovidDetailDTO object containing the details to be created.</param>
        /// <returns>The ID of the created Covid detail record.</returns>
        public async Task<int> CreateAsync(CovidDetailDTO entity)
        {
            // Check if CovidDetail for the employee already exists
            Employee employee = await employeeDal.GetByIdNumberAsync(entity.EmployeeNumberId);
            CovidDetail existingCovidDetail = await covidDetailDal.GetByIdAsync(employee.EmployeeId);

            if (existingCovidDetail != null)
            {
                return employee.EmployeeId;
            }

            // Check if Manufacturer exists, if not, create it
            VaccineManufacturer vaccineManufacturer = await vaccineManufacturerDal.GetByNameAsync(entity.VaccineManufacturerName);

            int vaccineManufacturerId;
            if (vaccineManufacturer == null)
            {
                vaccineManufacturer = new VaccineManufacturer { ManufacturerName = entity.VaccineManufacturerName };
                vaccineManufacturerId = await vaccineManufacturerDal.CreateAsync(vaccineManufacturer);
            }
            else
            {
                vaccineManufacturerId = vaccineManufacturer.ManufacturerId;
            }

            CovidDetail covidDetail = mapper.Map<CovidDetail>(entity);

            covidDetail.EmployeeId = employee.EmployeeId;

            covidDetail.VaccineManufacturerId = vaccineManufacturerId;

            await covidDetailDal.CreateAsync(covidDetail);

            return covidDetail.EmployeeId;
        }

        /// <summary>
        /// Retrieves all Covid detail records.
        /// </summary>
        /// <returns>A list of CovidDetailDTO objects representing the retrieved Covid detail records.</returns>
        public async Task<List<CovidDetailDTO>> GetAllAsync()
        {
            var covidDetails = await covidDetailDal.GetAllAsync();
            var covidDetailDTOs = mapper.Map<List<CovidDetailDTO>>(covidDetails);
            return covidDetailDTOs;
        }

        /// <summary>
        /// Retrieves a Covid detail record by its ID.
        /// </summary>
        /// <param name="id">The ID of the Covid detail record to retrieve.</param>
        /// <returns>The CovidDetailDTO object representing the retrieved Covid detail record.</returns>
        public async Task<CovidDetailDTO> GetByIdAsync(int id)
        {
            // Fetch the CovidDetail entity with the specified ID from the DAL layer
            var covidDetail = await covidDetailDal.GetByIdAsync(id);

            // Map the CovidDetail entity to a CovidDetailDTO
            var covidDetailDTO = mapper.Map<CovidDetailDTO>(covidDetail);

            return covidDetailDTO;
        }

        /// <summary>
        /// Retrieves a Covid detail record by the employee's ID.
        /// </summary>
        /// <param name="id">The ID of the employee associated with the Covid detail record.</param>
        /// <returns>The CovidDetailDTO object representing the retrieved Covid detail record.</returns>
        public async Task<CovidDetailDTO> GetByNumberIdAsync(int id)
        {
            CovidDetail covidDetail = await covidDetailDal.GetByIdAsync(id);

            CovidDetailDTO covidDetailDTO = mapper.Map<CovidDetailDTO>(covidDetail);

            return covidDetailDTO;
        }

        
    }
}
