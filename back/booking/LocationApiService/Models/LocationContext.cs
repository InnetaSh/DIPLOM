using Globals.Models;
using LocationApiService.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace LocationApiService.Models
{
    public class LocationContext : ContextBase<Country>
    {
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Attraction> Attractions { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            // --- Country ---
            builder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            // --- Region ---
            builder.Entity<Region>(entity =>
            {
                entity.ToTable("regions");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            // --- City ---
            builder.Entity<City>(entity =>
            {
                entity.ToTable("cities");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            // --- District ---
            builder.Entity<District>(entity =>
            {
                entity.ToTable("districts");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<Attraction>(entity =>
            {
                entity.ToTable("attractions");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            // Seed данные
            LocationSeed.Seed(builder);
        }
    }
}
