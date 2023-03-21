using CompanyApi.DTO;
using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_BAL.Services.IServices
{
    public interface IEmployeeAddressService
    {
        Task<List<EmployeeAddressDTO>> GetEmployeeAddress();
        Task<EmployeeAddressDTO> GetEmployeeAddressById(int id);
        Task<EmployeeAddress> AddEmployeeAddress(AddEmployeeAddressDTO employeeAddress);
        Task<EmployeeAddress> UpdateEmployeeAddress(int id, AddEmployeeAddressDTO employeeAddress);
        Task<EmployeeAddress> DeleteEmployeeAddress(int id);
    }
}
