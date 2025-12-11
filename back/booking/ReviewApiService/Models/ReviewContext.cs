using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace ReviewApiService.Models
{
    public class ReviewContext : ContextBase<Review>
    {
        public DbSet<Review> Reviews { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews"); 
                entity.HasKey(e => e.id); 
                entity.Property(e => e.id).HasColumnName("id"); 
            });
        }
    }
}
