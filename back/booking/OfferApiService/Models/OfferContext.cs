using Globals.Models;
using Microsoft.EntityFrameworkCore;

namespace OfferApiService.Models
{
    public class OfferContext : ContextBase<Offer>
    {
        public DbSet<Offer> Offers { get; set; }
        public DbSet<BookedDate> BookedDates { get; set; }


        protected override void ModelBuilderConfigure(ModelBuilder builder)
        {
            builder.Entity<Offer>().ToTable("Offers");
            builder.Entity<BookedDate>().ToTable("BookedDates");
        }
    }
}
