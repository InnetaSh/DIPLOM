using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderApiService.Models
{
    public class OrderContext : ContextBase<Order>
    {
        public DbSet<Order> Orders { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Order>(entity =>
            {
                entity.ToTable("orders"); 
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
        }
    }
}
