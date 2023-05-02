using CompanyApi.DTO;
using CompanyApi_DAL.DTO;
using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_BAL.Services.IServices
{
    public interface IEmployeeServices
    {
        Task<EmployeeResponseDto> GetEmployee(int page, float pageResult);
        Task<EmployeeDto> GetEmployeeById(int id);
        Task<Employee> AddEmployee(EmployeeDto employee);
        Task<Employee> UpdateEmployee(int id, UpdateEmployeeDTO employee);
        Task<Employee> DeleteEmployee(int id);
    }
}
