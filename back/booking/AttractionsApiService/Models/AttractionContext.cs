using AttractionsApiService.Data.Seed;
using AttractionsApiService.Models;
using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionsApiService.Models
{
    public class AttractionContext : ContextBase<Attraction>
    {

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<AttractionImage> AttractionImages { get; set; }
        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
          
            builder.Entity<Attraction>(entity =>
            {
                entity.ToTable("attractions");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<AttractionImage>(entity =>
            {
                entity.ToTable("attractionimages");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });


            builder.Entity<Attraction>()
                   .HasMany(r => r.Images)
                   .WithOne(i => i.Attraction)
                   .HasForeignKey(i => i.AttractionId)
                   .OnDelete(DeleteBehavior.Cascade);


            // Seed данные
            AttractionsSeed.Seed(builder);


        }
    }
}
