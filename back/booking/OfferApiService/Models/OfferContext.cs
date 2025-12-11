using Globals.Models;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Data.Seed;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.Models
{
    public class OfferContext : ContextBase<Offer>
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<BookedDate> BookedDates { get; set; }
        public DbSet<ParamsCategory> ParamsCategories { get; set; }
        public DbSet<ParamItem> ParamItems { get; set; }
        public DbSet<RentObjImage> RentObjImages { get; set; }
        public DbSet<RentObject> RentObjects { get; set; }
        public DbSet<RentObjParamValue> RentObjParamValues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Offer>(entity =>
            {
                entity.ToTable("offers");   
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<BookedDate>(entity =>
            {
                entity.ToTable("bookeddates");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<RentObject>(entity =>
            {
                entity.ToTable("rentobjects");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<ParamsCategory>(entity =>
            {
                entity.ToTable("paramscategories");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<ParamItem>(entity =>
            {
                entity.ToTable("paramitems");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<RentObjParamValue>(entity =>
            {
                entity.ToTable("rentobjparamvalues");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });
            builder.Entity<RentObjImage>(entity =>
            {
                entity.ToTable("rentobjimages");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });


            builder.Entity<ParamsCategory>()
                   .HasMany(c => c.Items)
                   .WithOne(i => i.Category)
                   .HasForeignKey(i => i.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RentObject>()
                   .HasMany(r => r.ParamValues)
                   .WithOne(v => v.RentObj)
                   .HasForeignKey(v => v.RentObjId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RentObject>()
                    .HasMany(r => r.Images)
                    .WithOne(i => i.RentObj)
                    .HasForeignKey(i => i.RentObjId)
                    .OnDelete(DeleteBehavior.Cascade);


            ParamsSeed.Seed(builder);
        }

    }
}
