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


        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<District>().ToTable("districts");
            builder.Entity<Region>().ToTable("regions");
            builder.Entity<City>().ToTable("cities");
            builder.Entity<Country>().ToTable("countries");



            LocationSeed.Seed(builder);

            
        }
    }
}
