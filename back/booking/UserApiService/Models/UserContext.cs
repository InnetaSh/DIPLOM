using Globals.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace UserApiService.Models
{
    public class UserContext : ContextBase<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Owner>("Owner")
                .HasValue<Admin>("Admin");
        }
    }
}
