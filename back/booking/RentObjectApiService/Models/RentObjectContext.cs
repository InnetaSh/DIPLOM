using Globals.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace RentObjectApiService.Models
{
    public class RentObjectContext : ContextBase<RentObj>
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ParamsCategory> ParamsCategories { get; set; }
        public DbSet<RentObj> RentObjects { get; set; }
        public DbSet<RentObjParam> RentObjParamsString { get; set; }

 

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<CityRequest>().ToTable("Cities");
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<RentObj>().ToTable("RentObjects");
        }
    }

}
