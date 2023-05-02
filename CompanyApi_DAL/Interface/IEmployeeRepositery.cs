using CompanyApi.DTO;
using CompanyApi_DAL.Models;
using EmployeeApi.Model;

namespace CompanyApi.Interface
{
    public interface IEmployeeRepositery
    {
        Task<EmployeeResponse> GetEmployees(int page, float pageResult);
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);

        Task SaveAsync();
    }
}
