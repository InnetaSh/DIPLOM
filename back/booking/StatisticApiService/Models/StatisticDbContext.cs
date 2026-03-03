using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace StatisticApiService.Models
{
    public class StatisticDbContext : ContextBase<PopularEntity>
    {
        public DbSet<PopularEntity> PopularEntities { get; set; }
        public DbSet<EntityStatEvent> EntityStatEvents { get; set; }
        //public DbSet<EntityStatsAggregate> EntityStatsAggregates { get; set; }
        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<PopularEntity>(entity =>
            {
                entity.ToTable("popularEntity");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            builder.Entity<EntityStatEvent>(entity =>
            {
                entity.ToTable("entityStatEvent");
                entity.HasKey(e => e.id);
                entity.Property(e => e.id).HasColumnName("id");
            });

            //builder.Entity<EntityStatsAggregate>(entity =>
            //{
            //    entity.ToTable("entityStatsAggregate");
            //    entity.HasKey(e => e.id);
            //    entity.Property(e => e.id).HasColumnName("id");
            //});
        }
    }
}
