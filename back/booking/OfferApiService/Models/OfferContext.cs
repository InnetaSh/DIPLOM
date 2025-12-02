using Globals.Models;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Data.Seed;
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

        public DbSet<RentObjImage> RentObjImages { get; set; }
        public DbSet<RentObject.RentObject> RentObjects { get; set; }
        public DbSet<RentObjParamValue> RentObjParamValues { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Offer>().ToTable("offers");
            builder.Entity<BookedDate>().ToTable("bookeddates");
            builder.Entity<City>().ToTable("cities");
            builder.Entity<Country>().ToTable("countries");
            builder.Entity<RentObject.RentObject>().ToTable("rentobjects");
            builder.Entity<ParamsCategory>().ToTable("paramscategories");
            builder.Entity<ParamItem>().ToTable("paramitems");
            builder.Entity<RentObjParamValue>().ToTable("rentobjparamvalues");
            builder.Entity<RentObjImage>().ToTable("rentobjimages");


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

            builder.Entity<RentObject.RentObject>()
                .HasMany(r => r.ParamValues)
                .WithOne(v => v.RentObj)
                .HasForeignKey(v => v.RentObjId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
