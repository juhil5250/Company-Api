using AutoMapper;
using CompanyApi.Context;
using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using EmployeeApi.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAddressController : ControllerBase
    {
        private readonly IEmployeeAddressService _employeeAddressService;

        public EmployeeAddressController(IEmployeeAddressService employeeAddressService)
        {
            _employeeAddressService = employeeAddressService;
        }

        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeAddressDTO>>> GetAddress()
        {
            return Ok(await _employeeAddressService.GetEmployeeAddress());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<EmployeeAddressDTO>> getAddressbyid(int id)
        {
            return Ok(await _employeeAddressService.GetEmployeeAddressById(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddNewAddress(AddEmployeeAddressDTO employeeAddress)
        {
            return Ok(await _employeeAddressService.AddEmployeeAddress(employeeAddress));
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateAddress(int id, AddEmployeeAddressDTO employeeAddress)
        {
            
            await _employeeAddressService.UpdateEmployeeAddress(id, employeeAddress); 

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _employeeAddressService.DeleteEmployeeAddress(id);

            return NoContent();
        }
    }
}
