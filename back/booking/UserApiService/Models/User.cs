using Globals.Models;
using UserApiService.Models.Enums;
using System.ComponentModel.DataAnnotations;
namespace UserApiService.Models
{
    public class User : EntityBase
    {
        [Required]
        public string? Username { get; set; }
        //[Required]
        //public byte[] PasswordHash { get; set; } = Array.Empty<byte>();

        //[Required]
        //public byte[] PasswordSalt { get; set; } = Array.Empty<byte>();
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string Token { get; set; }
        [Required]
        public  UserRole RoleName { get; set; }

        public DateTime? LastLogin { get; set; }
    }

  
}
