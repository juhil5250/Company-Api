using AutoMapper;
using CompanyApi.Context;
using CompanyApi.DTO;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CompanyApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly CompanyContext _DbContext;
        private readonly ILogger<ProjectController> _logger;
        private readonly IMapper _mapper;

        public ProjectController(CompanyContext DbContext, ILogger<ProjectController> logger, IMapper mapper)
        {
            _DbContext = DbContext;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDTO>>> GetProject()
        {
            if (_DbContext.Projects == null)
            {
                _logger.LogError("No Project in Database");
                return NotFound();
            }

            _logger.LogInformation("Information Get Successfully");
            var project = await _DbContext.Projects.Include(p => p.employeeProjects).ToListAsync();
            var proj = _mapper.Map<List<ProjectDTO>>(project);

            return Ok(proj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            if (_DbContext.Projects == null)
            {
                _logger.LogError("No Project in Database");
                return NotFound();
            }

            var Project = await _DbContext.Projects.Where(p => p.ProjectId == id).Include(p => p.employeeProjects).FirstOrDefaultAsync();
            var proj = _mapper.Map<ProjectDTO>(Project);

            if (Project == null)
            {
                _logger.LogError("Project id is Not Matched");
                return NotFound();
            }

            _logger.LogInformation("Information Get Successfully");
            return Ok(proj);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject(ProjectDTO project)
        {
            _DbContext.Projects.Add(_mapper.Map<Project>(project));

            await _DbContext.SaveChangesAsync();

            _logger.LogInformation("Project Add Successfully");
            return Ok(project);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(int id, UpdateProjectDTO project)
        {
            if (project.ProjectId != id)
            {
                _logger.LogError("No Project in Database");
                return BadRequest();
            }

            _DbContext.Entry(_mapper.Map<Project>(project)).State = EntityState.Modified;

            try
            {
                await _DbContext.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ProjectExist(id))
                {
                    _logger.LogError("Project id is Not Matched");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            _logger.LogInformation("Project Update Successfully");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (_DbContext.Projects == null)
            {
                _logger.LogError("No Project in Database");
                return NotFound();
            }

            var project = await _DbContext.Projects.FindAsync(id);
            if(project == null)
            {
                _logger.LogError("Project id is Not Matched");
                return NotFound();
            }

            _DbContext.Projects.Remove(project);
            await _DbContext.SaveChangesAsync();

            _logger.LogInformation("Project Deleted Successfully");
            return NoContent();
        }

        private bool ProjectExist(int id)
        {
            return (_DbContext.Projects?.Any(p => p.ProjectId == id)).GetValueOrDefault();
        }

    }
}
