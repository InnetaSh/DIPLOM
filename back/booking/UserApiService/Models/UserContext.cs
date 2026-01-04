using Globals.Models;
using Microsoft.EntityFrameworkCore;
using UserApiService.Data.Seed;
using UserApiService.Models;

public class UserContext : ContextBase<User>
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<SuperAdmin> SuperAdmins { get; set; }

    // Заказы владельцев
    public DbSet<OwnerOfferLink> OwnerOfferLinks { get; set; }

    // Заказы клиентов
    public DbSet<ClientOrderLink> ClientOrderLinks { get; set; }

    public DbSet<HistoryOfferLink> HistoryOfferLinks { get; set; }

    protected override void ModelBuilderConfigure(ModelBuilder builder)
    {
        AdminSeed.Seed(builder);

        // Конфигурация User и наследников
        builder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");

            entity.HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Client>("Client")
                .HasValue<Owner>("Owner")
                .HasValue<Admin>("Admin")
                .HasValue<SuperAdmin>("SuperAdmin");
        });

        // OwnerOffer
        builder.Entity<OwnerOfferLink>(entity =>
        {
            entity.ToTable("owner_offer_links");
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Owner)
                .WithMany(o => o.OwnerOfferLinks)
                .HasForeignKey(x => x.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(x => new { x.OwnerId, x.OfferId })
                .IsUnique();
        });
       
        // ClientOrder
        builder.Entity<ClientOrderLink>(entity =>
        {
            entity.ToTable("client_order_links");
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Client)
                .WithMany(c => c.ClientOrderLinks)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(x => new { x.ClientId, x.OrderId })
                .IsUnique(); // защита от дубликатов
        });

        // Client-HistoryOffer
        builder.Entity<HistoryOfferLink>(entity =>
        {
            entity.ToTable("history_offer_links");
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Client)
                .WithMany(o => o.HistoryOfferLinks)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(x => new { x.ClientId, x.OfferId })
                .IsUnique();
        });
    }
}
