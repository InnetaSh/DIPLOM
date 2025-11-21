using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace OrderApiService.Models
{
    public class OrderContext : ContextBase<Order>
    {
        public DbSet<Order> Orders { get; set; }


        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Order>().ToTable("Orders");
        }
    }
}
