using Globals.Models;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Data.Seeds;
using OfferApiService.Models.RentObject;

namespace OfferApiService.Models
{
    public class OfferContext : ContextBase<Offer>
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<BookedDate> BookedDates { get; set; }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<ParamsCategory> ParamsCategories { get; set; }
        public DbSet<ParamItem> ParamItems { get; set; }
        public DbSet<RentObj> RentObjects { get; set; }
        public DbSet<RentObjParamValue> RentObjParamValues { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Offer>().ToTable("Offers");
            builder.Entity<BookedDate>().ToTable("BookedDates");
            builder.Entity<City>().ToTable("Cities");
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<RentObj>().ToTable("RentObjects");
            builder.Entity<ParamsCategory>().ToTable("ParamsCategories");
            builder.Entity<ParamItem>().ToTable("ParamItems");
            builder.Entity<RentObjParamValue>().ToTable("RentObjParamValues");

            
            ParamsSeed.Seed(builder);

            
            builder.Entity<ParamsCategory>()
                .HasMany(c => c.Items)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ParamItem>()
                .HasMany(i => i.RentObjValues)
                .WithOne(v => v.ParamItem)
                .HasForeignKey(v => v.ParamItemId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RentObj>()
                .HasMany(r => r.ParamValues)
                .WithOne(v => v.RentObj)
                .HasForeignKey(v => v.RentObjId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
