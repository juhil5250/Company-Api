using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CompanyApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string? Email { get; set; }
    }
}
