using Globals.Models;
using Microsoft.EntityFrameworkCore;
using TranslationApiService.Data.Seed;
using TranslationApiService.Models.Location;
using TranslationApiService.Models.Offer;
using TranslationApiService.Models.Review;

namespace TranslationApiService.Models
{
    public class TranslationContext : ContextBase<Language>
    {
        public DbSet<OfferTranslation> OffersTranslation { get; set; }

        public DbSet<CityTranslation> CitiesTranslation { get; set; }
        public DbSet<CountryTranslation> CountriesTranslation { get; set; }
        public DbSet<RegionTranslation> RegionsTranslation { get; set; }
        public DbSet<DistrictTranslation> DistrictsTranslation { get; set; }

        public DbSet<ParamsCategoryTranslation> ParamsCategoriesTranslation { get; set; }
        public DbSet<ParamItemTranslation> ParamItemsTranslation { get; set; }

        public DbSet<ReviewTranslation> ReviewTranslation { get; set; }
        public DbSet<Language> Languages { get; set; }

        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<OfferTranslation>(entity =>
            {
                entity.ToTable("offertranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<CityTranslation>(entity =>
            {
                entity.ToTable("citiestranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<CountryTranslation>(entity =>
            {
                entity.ToTable("countrytranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<RegionTranslation>(entity =>
            {
                entity.ToTable("regionstranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<DistrictTranslation>(entity =>
            {
                entity.ToTable("districtstranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<ParamsCategoryTranslation>(entity =>
            {
                entity.ToTable("paramscategoriestranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<ParamItemTranslation>(entity =>
            {
                entity.ToTable("paramitemstranslation");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });



            LanguageSeed.Seed(builder);

           
        }
    }
}
