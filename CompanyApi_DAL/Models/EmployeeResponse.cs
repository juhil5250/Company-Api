using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_DAL.Models
{
    public class EmployeeResponse
    {
        public List<Employee> employees { get; set; } = new List<Employee>();

        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
