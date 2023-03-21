using AutoMapper;
using CompanyApi.Context;
using CompanyApi.DTO;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly ILogger<TeamsController> _logger;
        private readonly IMapper _mapper;
        public TeamsController(CompanyContext context, ILogger<TeamsController> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamDTO>>> GetTeam()
        {
            if (_context.Team == null)
            {
                _logger.LogError("No Team in Database");
                return NotFound();
            }
            _logger.LogInformation("Information Get Successfully");
            var team = await _context.Team.Include(t => t.Employees).ToListAsync();
            var res = _mapper.Map<List<TeamDTO>>(team);

            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDTO>> GetTeam(int id)
        {
            if (_context.Team == null)
            {
                _logger.LogError("No Team in Database");
                return NotFound();
            }

            var team = await _context.Team.Where(t => t.TeamId == id).Include(t => t.Employees).FirstOrDefaultAsync();
            var res = _mapper.Map<TeamDTO>(team);

            if (team == null)
            {
                _logger.LogError("Team Id is Not Matched");
                return NotFound();
            }

            _logger.LogInformation("Information Get Successfully");
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(TeamDTO team)
        {
            _context.Team.Add(_mapper.Map<Team>(team));
            await _context.SaveChangesAsync();

            _logger.LogInformation("Information Get Successfully");
            return Ok(team);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, UpdateTeamDTO team)
        {
            if (_context.Team == null)
            {
                _logger.LogError("No Team in Database");
                return BadRequest();
            }

            _context.Entry(_mapper.Map<Team>(team)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    _logger.LogError("Team Id is Not Matched");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation("Team is Update Successfully");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            if (_context.Team == null)
            {
                _logger.LogError("No Team in Database");
                return NotFound();
            }

            var team = await _context.Team.FindAsync(id);
            if (team == null)
            {
                _logger.LogError("Team Id is Not Matched");
                return NotFound();
            }

            _context.Team.Remove(team);
            await _context.SaveChangesAsync();

            _logger.LogDebug("Team Deleted Successfully");
            return NoContent();
        }

        private bool TeamExists(int id)
        {
            return _context.Team.Any(e => e.TeamId == id);
        }
    }
}
