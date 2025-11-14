using UserApiService.Models;
using Globals.Abstractions;
using Microsoft.AspNetCore.Identity.Data;

namespace UserApiService.Services.Interfaces
{
    public interface IPasswordHasher 
    {
        void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
        bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}
