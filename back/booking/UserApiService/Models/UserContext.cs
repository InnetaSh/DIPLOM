using Globals.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UserApiService.Data.Seed;

namespace UserApiService.Models
{
    public class UserContext : ContextBase<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SuperAdmin> SuperAdmins { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {

            AdminSeed.Seed(builder);

            builder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Owner>("Owner")
                .HasValue<Admin>("Admin")
                .HasValue<SuperAdmin>("SuperAdmin");
        }
    }
}
