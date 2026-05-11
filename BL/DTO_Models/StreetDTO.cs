using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTO_Models
{
    public class StreetDTO
    {
        public int StreetId { get; set; }
        public string? StreetName { get; set; }
        public int? CityId { get; set; }
        public string? CityName { get; set; } 
    }
}
