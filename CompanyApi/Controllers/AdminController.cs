using CompanyApi.Context;
using CompanyApi.DTO;
using CompanyApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IConfiguration _Configuration;
        private readonly CompanyContext _DbContext;
        private readonly ILogger<AdminController> _Logger;

        public static User user = new User();

        public AdminController(IConfiguration configuration, CompanyContext dbContext, ILogger<AdminController> logger)
        {
            _Configuration = configuration;
            _DbContext = dbContext;
            _Logger = logger;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<User>> Register(UserDTO Request)

        {
            if (_DbContext.Users.Any(x => x.UserName == Request.UserName))
            {
                _Logger.LogError("User Already Exists in Database");
                return BadRequest("user already register");
            }

            CreatePasswordHash(Request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = Request.UserName;
            user.Email = Request.Email;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _DbContext.Users.Add(user);
            _DbContext.SaveChanges();

            _Logger.LogInformation("User Added successfully");
            return Ok("User Added Successfully");
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(string userName, string password)
        {
            var UserExist = _DbContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (UserExist == null)
            {
                _Logger.LogError("username is Not Matched");
                return BadRequest("incorrect userName");
            }

            if (!VerifyPassword(password, UserExist.PasswordHash, UserExist.PasswordSalt))
            {
                _Logger.LogError("password is Not Mathched");
                return BadRequest("incorrect password");
            }

            var token = CreateToken(UserExist);
            _Logger.LogInformation("Login Successfull");
            return Ok(token);
        }

        private void CreatePasswordHash(string Password, out byte[] PasswordHash, out byte[] PasswordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
