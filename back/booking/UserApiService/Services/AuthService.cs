using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserApiService.Models;
using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;
using UserApiService.View;

namespace UserApiService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _context = new UserContext();
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
                throw new UnauthorizedAccessException("Неверное имя пользователя или пароль");

            var token = _tokenService.GenerateJwtToken(user);
            user.Token = token;
            await _context.SaveChangesAsync();

            return new LoginResponse
            {
                Username = user.Username,
                Token = token,
                RoleName = user.RoleName.ToString()
            };
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            //var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            //if (existingUser != null)
            //    throw new InvalidOperationException("Пользователь с таким именем уже существует");

            _passwordHasher.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            var role = Enum.TryParse<UserRole>(request.RoleName, true, out var parsedRole)
                ? parsedRole
                : UserRole.Client;

            var newUser = new User
            {
                Username = request.Username,
                PasswordHash = hash,
                PasswordSalt = salt,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                RoleName = role
            };

            var token = _tokenService.GenerateJwtToken(newUser);
            newUser.Token = token;

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new RegisterResponse
            {
                Username = newUser.Username,
                Token = token,
                RoleName = newUser.RoleName.ToString()
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsEntityAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.id == id);
        }

        public async Task<bool> ExistsEntityByNameAsync(string name)
        {
            return await _context.Users.AnyAsync(u => u.Username == name);
        }
        //private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        //{
        //    using var hmac = new HMACSHA512();
        //    salt = hmac.Key;
        //    hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //}

        //private bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    using (var hmac = new HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //        return computedHash.SequenceEqual(storedHash);
        //    }
        //}
    }
}
