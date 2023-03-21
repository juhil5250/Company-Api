using AutoMapper;
using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using CompanyApi_DAL.Interface;
using EmployeeApi.Model;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CompanyApi_BAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepositery _departmentRepositery;
        private readonly ILogger<DepartmentService> _logger;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepositery departmentRepositery, ILogger<DepartmentService> logger, IMapper mapper)
        {
            _departmentRepositery = departmentRepositery;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<DepartmentDTO>> GetDepartment()
        {
            var department = await _departmentRepositery.GetDepartments();

            if (department == null)
            {
                _logger.LogError("Department NotFound");
                return null;
            }

            var result = _mapper.Map<List<DepartmentDTO>>(department);

            _logger.LogInformation("Information Got Successfully");
            return result;
        }

        public async Task<DepartmentDTO> GetDepartmentById(int id)
        {
            var department = await _departmentRepositery.GetDepartmentById(id);

            if (department == null)
            {
                _logger.LogError("Department NotFound");
                return null;
            }

            var result = _mapper.Map<DepartmentDTO>(department);

            _logger.LogInformation("Information Got Successfully");
            return result;
        }

        public async Task<Department> AddDepartment(DepartmentDTO department)
        {
            var result = await _departmentRepositery.AddDepartment(_mapper.Map<Department>(department));

            await _departmentRepositery.saveAsync();

            _logger.LogInformation("Department Added Successfully");
            return result;
        }

        public async Task<Department> UpdateDepartment(int id, UpdateDepartmentDTO department)
        {
            var departmentExist = await _departmentRepositery.GetDepartmentById(id);

            var result = await _departmentRepositery.UpdateDepartment(_mapper.Map<Department>(department));

            try
            {
                _departmentRepositery.saveAsync();
            }
            catch (DBConcurrencyException)
            {
                if (departmentExist == null)
                {
                    _logger.LogError("Department NotFound");
                    return null;
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Department Update Successfully");
            return result;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            var department = await _departmentRepositery.GetDepartmentById(id);

            if (department == null)
            {
                _logger.LogError("Department NotFound");
                return null;
            }

            await _departmentRepositery.DeleteDepartment(id);

            await _departmentRepositery.saveAsync();


            _logger.LogInformation("Department Deleted");
            return department;
        }
    }
}
