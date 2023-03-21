using AutoMapper;
using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using CompanyApi_DAL.Interface;
using EmployeeApi.Model;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CompanyApi_BAL.Services
{
    public class EmployeeAddressService : IEmployeeAddressService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeAddressService> _logger;
        private readonly IEmployeeAddressRepositery _employeeAddressRepositery;
        public EmployeeAddressService(IMapper mapper, ILogger<EmployeeAddressService> logger, IEmployeeAddressRepositery employeeAddressRepositery)
        {
            _employeeAddressRepositery = employeeAddressRepositery;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<EmployeeAddress> AddEmployeeAddress(AddEmployeeAddressDTO employeeAddress)
        {
            var empAdd = await _employeeAddressRepositery.AddEmployeeAddress(_mapper.Map<EmployeeAddress>(employeeAddress));

            await _employeeAddressRepositery.SaveAsync();

            _logger.LogInformation("information Got Successfully");
            return empAdd;
        }

        public async Task<EmployeeAddress> DeleteEmployeeAddress(int id)
        {
            var empAdd = await _employeeAddressRepositery.GetEmployeeAddressById(id);

            if (empAdd == null)
            {
                _logger.LogError("Employee Not Available");
                return null;
            }

            await _employeeAddressRepositery.DeleteEmployeeAddress(id);

            await _employeeAddressRepositery.SaveAsync();

            _logger.LogInformation("Address Deleted Successfully");
            return empAdd;
        }

        public async Task<List<EmployeeAddressDTO>> GetEmployeeAddress()
        {
            var empAdd = await _employeeAddressRepositery.GetEmployeeAddress();

            if (empAdd == null)
            {
                _logger.LogError("Employee Not Available");
                return null;
            }

            var result = _mapper.Map<List<EmployeeAddressDTO>>(empAdd);

            _logger.LogInformation("information Got Successfully");
            return result;
        }

        public async Task<EmployeeAddressDTO> GetEmployeeAddressById(int id)
        {
            var empAdd = await _employeeAddressRepositery.GetEmployeeAddressById(id);

            if (empAdd == null)
            {
                _logger.LogError("Employee Not Available");
                return null;
            }

            var result = _mapper.Map<EmployeeAddressDTO>(empAdd);

            _logger.LogInformation("information Got Successfully");
            return result;
        }

        public async Task<EmployeeAddress> UpdateEmployeeAddress(int id, AddEmployeeAddressDTO employeeAddress)
        {
            var empAddExist = await _employeeAddressRepositery.GetEmployeeAddressById(id);

            await _employeeAddressRepositery.UpdateEmployeeAddress(_mapper.Map<EmployeeAddress>(employeeAddress));

            try
            {
                await _employeeAddressRepositery.SaveAsync();
            }
            catch (DBConcurrencyException)
            {
                if (empAddExist == null)
                {
                    _logger.LogError("Employee Not Available");
                    return null;
                }
                else
                {
                    throw;
                }
            }

            await _employeeAddressRepositery.SaveAsync();

            _logger.LogInformation("Address Updated Successfully");
            return empAddExist;
        }

    }
}
