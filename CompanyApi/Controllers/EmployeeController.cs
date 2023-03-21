using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using EmployeeApi.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [EnableQuery(PageSize = 10)]
        [HttpGet]
        public async Task<ActionResult<List<EmployeeDto>>> GetEmployee()
        {
            return Ok(await _employeeServices.GetEmployee());
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            return Ok(await _employeeServices.GetEmployeeById(id));
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] EmployeeDto employee)
        {
            return Ok(await _employeeServices.AddEmployee(employee));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDTO employee)
        {
            await _employeeServices.UpdateEmployee(id, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeServices.DeleteEmployee(id);

            return NoContent();
        }
    }
}
