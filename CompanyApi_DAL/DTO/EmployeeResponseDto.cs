using CompanyApi.DTO;
using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_DAL.DTO
{
    public class EmployeeResponseDto
    {
        public List<EmployeeDto> employees { get; set; } = new List<EmployeeDto>();

        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
