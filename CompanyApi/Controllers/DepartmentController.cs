using CompanyApi.DTO;
using CompanyApi_BAL.Services.IServices;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartment()
        {
            return Ok(await _departmentService.GetDepartment());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<DepartmentDTO>> GetDepartmentByid(int id)
        {
            return Ok(await _departmentService.GetDepartmentById(id));
        }


        [HttpPost]

        public async Task<ActionResult> AddDepartment(DepartmentDTO department)
        {
            _departmentService.AddDepartment(department);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDTO department)
        {
            await _departmentService.UpdateDepartment(id, department);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _departmentService.DeleteDepartment(id);

            return NoContent();
        }
    }
}
