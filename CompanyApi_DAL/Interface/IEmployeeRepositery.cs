using CompanyApi.DTO;
using EmployeeApi.Model;

namespace CompanyApi.Interface
{
    public interface IEmployeeRepositery
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> DeleteEmployee(int id);

        Task SaveAsync();
    }
}
