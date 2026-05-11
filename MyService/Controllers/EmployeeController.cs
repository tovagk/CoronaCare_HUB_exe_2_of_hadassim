using BL.Bl_API;
using BL.DTO_Models;
using Dal.Dal_API;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBl _employeeBl;
        private readonly ICovidDatailsBl _covidDatailesBl;

        public EmployeeController(IEmployeeBl employeeBl, ICovidDatailsBl covidDatailesBl)
        {
            _employeeBl = employeeBl ?? throw new ArgumentNullException(nameof(employeeBl));
            _covidDatailesBl = covidDatailesBl ?? throw new ArgumentNullException(nameof(covidDatailesBl));
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDTO employeeDTO)
        {
            int employeeId = await _employeeBl.CreateAsync(employeeDTO);
            return Ok(employeeId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<EmployeeDTO> employees = await _employeeBl.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetById(int employeeId)
        {
            EmployeeDTO employeeDTO = await _employeeBl.GetByIdAsync(employeeId);
            if (employeeDTO == null)
            {
                return NotFound();
            }
            return Ok(employeeDTO);
        }

        [HttpGet("GetByNumberIdEmployee/{idNumber}")]
        public async Task<IActionResult> GetByNumberIdEmployee(string idNumber)
        {
            try
            {
                // Get employeeDTO by idNumber
                EmployeeDTO employeeDTO = await _employeeBl.GetByNumberIdAsync(idNumber);
                if (employeeDTO == null)
                {
                    return NotFound();
                }

                // Get covid details for the employeeDTO
                CovidDetailDTO covidDetailDTO = await _covidDatailesBl.GetByIdAsync(employeeDTO.EmployeeId);

                // Combine employeeDTO and covid detail data
                var result = new
                {
                    Employee = employeeDTO,
                    CovidDetail = covidDetailDTO
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
