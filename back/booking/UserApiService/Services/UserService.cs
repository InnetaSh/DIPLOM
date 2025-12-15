using Globals.Sevices;
using UserApiService.Models;
using UserApiService.Services.Interfaces;

namespace UserApiService.Services
{
    public class UserService : ServiceBase<User, UserContext>, IUserService
    {
        public async Task<bool> AddOrderToUser(int userId, int orderId, params string[] includeProperties)
        {
            using var db = new UserContext();
            var user = db.Users.FirstOrDefault(x => x.id == userId);
            if (user != null)
            {
                user.OrdersIdList.Add(orderId);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
