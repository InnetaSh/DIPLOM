using Microsoft.EntityFrameworkCore;
using UserApiService.Models;
using UserApiService.Models.Enums;


namespace UserApiService.Data.Seed
{
    public static class AdminSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // super password is SuperAdmin123!
            modelBuilder.Entity<User>().HasData(new User
               {
                   id = 1,
                   Username = "superadmin",
                   Email = "super@system.local",
                   PasswordSalt = Convert.FromBase64String("V8wvqBbePjDdjC3iI5L4FYThnxnJKv59NCUZ+uSkC9v3hpuX8kFFZKQETn3TqG8mhBfWZB+HqKavNqCpxZBlxA=="),
                   PasswordHash = Convert.FromBase64String("Qb/7CDMxTQqtY2cT31K8K8EQwGLcJhqTfHtzz/4DYfV5mTRhBwfanma6Yjmjcbl4vw7hLipArjC7N3rPx4EoXw=="),
                   Token = "",
                   RoleName = UserRole.SuperAdmin
               });

             
        }
    }
}
