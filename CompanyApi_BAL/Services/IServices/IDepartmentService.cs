using CompanyApi.DTO;
using EmployeeApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApi_BAL.Services.IServices
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetDepartment();
        Task<DepartmentDTO> GetDepartmentById(int id);
        Task<Department> AddDepartment(DepartmentDTO department);
        Task<Department> UpdateDepartment(int id, UpdateDepartmentDTO department);
        Task<Department> DeleteDepartment(int id);
    }
}
