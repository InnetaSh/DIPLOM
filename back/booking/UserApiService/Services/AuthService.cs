using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserApiService.Models;
//using UserApiService.Models.Enums;
using UserApiService.Services.Interfaces;
using UserContracts;
using UserContracts.Enums;
//using UserApiService.View;

namespace UserApiService.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserContext _context;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AuthService> _logger;
        public AuthService(
          UserContext context,
          ITokenService tokenService,
          IPasswordHasher passwordHasher,
          ILogger<AuthService> logger)
        {
            _context = context;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public async Task<LoginResponse> GoogleLoginAsync(string email, string name)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                user = new Client
                {
                    Email = email,
                    Username = name,
                    RoleName = UserRole.Client
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }

            var token = _tokenService.GenerateJwtToken(user);

            return new LoginResponse
            {
                Username = user.Username,
                Token = token,
                RoleName = user.RoleName.ToString()
            };
        }


        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var normalizedPhone = NormalizePhone(request.Login);
            _logger.LogInformation("Login attempt for {Login}", request.Login);

            var user = await _context.Users
                 .AsNoTracking()
                 .FirstOrDefaultAsync(u =>
                     u.Email == request.Login ||
                     u.PhoneNumber == normalizedPhone);

            if (user == null ||
            !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                _logger.LogWarning("Failed login attempt for {Login}", request.Login);
                throw new UnauthorizedAccessException("Invalid login or password");
            }

            var token = _tokenService.GenerateJwtToken(user);
            _logger.LogInformation("User {UserId} logged in", user.id);

            return new LoginResponse
            {
                Username = user.Username,
                Token = token,
                RoleName = user.RoleName.ToString()
            };
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            _logger.LogInformation("Registration attempt for email {Email}", request.Email);

            if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            {
                _logger.LogWarning("Registration failed: Email {Email} already exists", request.Email);
                throw new Exception("Email already exists");
            }


            var normalizedPhone = NormalizePhone(request.PhoneNumber);

            _passwordHasher.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

            var role = Enum.TryParse<UserRole>(request.RoleName, true, out var parsedRole)
                ? parsedRole
                : UserRole.Client;

            User newUser = role switch
            {
                UserRole.Client => new Client(),
                UserRole.Owner => new Owner(),
                UserRole.Admin => new Admin(),
                UserRole.SuperAdmin => new SuperAdmin(),
                _ => new User()
            };

            newUser.Username = request.Username;
            newUser.BirthDate = request.BirthDate;
            newUser.PasswordHash = hash;
            newUser.PasswordSalt = salt;
            newUser.Email = request.Email;
            newUser.PhoneNumber = normalizedPhone;
            newUser.CountryId = request.CountryId;
            newUser.RoleName = role;

            var token = _tokenService.GenerateJwtToken(newUser);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            _logger.LogInformation(
               "User registered successfully. UserId: {UserId}, Email: {Email}, Role: {Role}",
               newUser.id,
               newUser.Email,
               newUser.RoleName
           );


            return new RegisterResponse
            {
                Username = newUser.Username,
                Token = token,
                RoleName = newUser.RoleName.ToString()
            };
        }


        public async Task<bool> DeleteUserAsync(int id)
        {
            _logger.LogInformation("Attempt to delete user with id {UserId}", id);

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                _logger.LogWarning("Delete failed. User with id {UserId} not found", id);
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            _logger.LogInformation("User with id {UserId} deleted successfully", id);

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


        private string NormalizePhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return phone;

            return new string(phone.Where(char.IsDigit).ToArray());
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
