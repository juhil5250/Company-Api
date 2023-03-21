using AutoMapper;
using CompanyApi.DTO;
using CompanyApi.Interface;
using CompanyApi_BAL.Services.IServices;
using EmployeeApi.Model;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CompanyApi_BAL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepositery _employeeRepositery;
        private readonly ILogger<EmployeeServices> _logger;

        public EmployeeServices(IEmployeeRepositery employeeRepositery, IMapper mapper, ILogger<EmployeeServices> logger)
        {
            _employeeRepositery = employeeRepositery;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<EmployeeDto>> GetEmployee()
        {
            var employee = await _employeeRepositery.GetEmployees();

            if (employee == null)
            {
                _logger.LogError("Employee NotFound...");
                return null;
            }

            var result = _mapper.Map<List<EmployeeDto>>(employee);

            _logger.LogInformation("information Get Successfully");
            return result;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _employeeRepositery.GetEmployeeById(id);

            if (employee == null)
            {
                _logger.LogError("Employee NotFound");
                return null;
            }

            var result = _mapper.Map<EmployeeDto>(employee);

            _logger.LogInformation("information Get Successfully");
            return result;
        }

        public async Task<Employee> AddEmployee(EmployeeDto employee)
        {
            var result = await _employeeRepositery.AddEmployee(_mapper.Map<Employee>(employee));

            await _employeeRepositery.SaveAsync();

            _logger.LogInformation("Employee Add Successfully");
            return result;
        }

        public async Task<Employee> UpdateEmployee(int id, UpdateEmployeeDTO employee)
        {
            var employeeExist = await _employeeRepositery.GetEmployeeById(id);

            
            var result = await _employeeRepositery.UpdateEmployee(_mapper.Map<Employee>(employee));

            try
            {
                await _employeeRepositery.SaveAsync();
            }
            catch (DBConcurrencyException)
            {
                if (employeeExist == null)
                {
                    _logger.LogError("Employee Not exist in Database");
                    return null;
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Employee Update Successfully");
            return result;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await _employeeRepositery.DeleteEmployee(id);

            await _employeeRepositery.SaveAsync();

            _logger.LogInformation("Employee Deleted Successfully");
            return employee;
        }
    }
}
