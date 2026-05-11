using BL.Bl_API;
using BL.BLIMplementens;
using BL.DTO_Models;
using Dal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyService.Controllers
{
    public class CovidDtailesController : ProjectBaseController
    {
        ICovidDatailsBl covidDetailBl;
        public CovidDtailesController(ICovidDatailsBl covidDetailBl)
        {
            this.covidDetailBl = covidDetailBl;
        }

        [HttpPost]
        public async Task<int> Create(CovidDetailDTO covidDetailDTO)
        {
            return await covidDetailBl.CreateAsync(covidDetailDTO);
        }

        [HttpGet]
        public async Task<List<CovidDetailDTO>> GetAll()
        {
            return await covidDetailBl.GetAllAsync();
        }

        [HttpGet("{employeeId}")]
        public async Task<CovidDetailDTO> GetById(int employeeId)
        {
            return await covidDetailBl.GetByIdAsync(employeeId);
        }
    }
}
