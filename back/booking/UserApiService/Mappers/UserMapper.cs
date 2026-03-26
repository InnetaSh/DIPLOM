using UserApiService.Models;
using UserContracts;
using UserContracts.Enums;

namespace UserApiService.Mappers
{
    public static class UserMapper
    {
        public static User MapToModel(  UserRequest request)
        {

            return new User
            {
                Username = request.Username,
                Lastname = request.Lastname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                BirthDate = request.BirthDate,
                CountryId = request.CountryId,
                Discount = request.Discount,
                IsBlocked = request.IsBlocked,
                RoleName = Enum.TryParse<UserRole>(request.RoleName, true, out var role)
                    ? role
                    : UserRole.Client
            };
        }

        public static UserResponse MapToResponse( User model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new UserResponse
            {
                id = model.id,
                Username = model.Username ?? string.Empty,
                Lastname = model.Lastname ?? string.Empty,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                CountryId = model.CountryId,
                Discount = model.Discount,
                RoleName = model.RoleName.ToString(),
                IsBlocked = model.IsBlocked,
            };
        }
    }
}
