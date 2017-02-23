using Microsoft.EntityFrameworkCore;
using Trade.Infra.Contract.Models.Entities;

namespace Trade.Infra.EF
{
    public class TradeDbContext : DbContext
    {
        public TradeDbContext(DbContextOptions<TradeDbContext> options) : base(options)
        {
        }

        public DbSet<YahooVolumeIncreaseRateDate> YahooVolumeIncreaseRateDates { get; set; }
        public DbSet<YahooVolumeIncreaseRate> YahooVolumeIncreaseRates { get; set; }
        public DbSet<YahooPriceIncreaseRateDate> YahooPriceIncreaseRateDates { get; set; }
        public DbSet<YahooPriceIncreaseRate> YahooPriceIncreaseRates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YahooVolumeIncreaseRateDate>()
                .ToTable("YahooVolumeIncreaseRateDate")
                .HasKey(x => new { x.Date });

            modelBuilder.Entity<YahooVolumeIncreaseRate>()
                .ToTable("YahooVolumeIncreaseRate")
                .HasKey(x => new {x.Date, x.Ranking});

            modelBuilder.Entity<YahooPriceIncreaseRateDate>()
                .ToTable("YahooPriceIncreaseRateDate")
                .HasKey(x => new { x.Date });

            modelBuilder.Entity<YahooPriceIncreaseRate>()
                .ToTable("YahooPriceIncreaseRate")
                .HasKey(x => new { x.Date, x.Ranking });
        }
    }
}
