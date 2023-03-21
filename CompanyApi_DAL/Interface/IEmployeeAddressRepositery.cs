using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_DAL.Interface
{
    public interface IEmployeeAddressRepositery
    {
        Task<List<EmployeeAddress>> GetEmployeeAddress();
        Task<EmployeeAddress> GetEmployeeAddressById(int id);
        Task<EmployeeAddress> AddEmployeeAddress(EmployeeAddress employeeAddress);
        Task<EmployeeAddress> UpdateEmployeeAddress(EmployeeAddress employeeAddress);
        Task<EmployeeAddress> DeleteEmployeeAddress(int id);

        Task SaveAsync();
    }
}
