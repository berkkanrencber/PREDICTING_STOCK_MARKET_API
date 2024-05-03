using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PREDICTING_STOCK_MARKET_API.Models;

public class StocksContext:IdentityDbContext<AppUser,AppRole,int>{
    
    public StocksContext(DbContextOptions<StocksContext> options): base(options){
        
    }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Sentiment6Month> Sentiment6Month {get; set; }
    public DbSet<Sentiment3Month> Sentiment3Month {get; set; }
    public DbSet<Sentiment1Month> Sentiment1Month {get; set; }
    public DbSet<Sentiment1Week> Sentiment1Week {get; set; }
    public DbSet<Prediction6Month> Prediction6Month {get; set; }
    public DbSet<Prediction3Month> Prediction3Month {get; set; }
    public DbSet<Prediction1Month> Prediction1Month {get; set; }
    public DbSet<Prediction1Week> Prediction1Week {get; set; }






    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Stock>().HasData()

        modelBuilder.Entity<Sentiment6Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF6E432");

            entity.Property(e => e.StockName).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.StockGeneralSentiment).HasColumnType("varchar(512)").HasColumnName("StockGeneralSentiment");
            entity.Property(e => e.StockRetweetSentiment).HasColumnType("varchar(512)").HasColumnName("StockRetweetSentiment");
            entity.Property(e => e.StockReplySentiment).HasColumnType("varchar(512)").HasColumnName("StockReplySentiment");
            entity.Property(e => e.StockLikeSentiment).HasColumnType("varchar(512)").HasColumnName("StockLikeSentiment");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");

        });

        modelBuilder.Entity<Sentiment3Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF6E455");

            entity.Property(e => e.StockName).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.StockGeneralSentiment).HasColumnType("varchar(512)").HasColumnName("StockGeneralSentiment");
            entity.Property(e => e.StockRetweetSentiment).HasColumnType("varchar(512)").HasColumnName("StockRetweetSentiment");
            entity.Property(e => e.StockReplySentiment).HasColumnType("varchar(512)").HasColumnName("StockReplySentiment");
            entity.Property(e => e.StockLikeSentiment).HasColumnType("varchar(512)").HasColumnName("StockLikeSentiment");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");

        });

        modelBuilder.Entity<Sentiment1Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF6E437");

            entity.Property(e => e.StockName).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.StockGeneralSentiment).HasColumnType("varchar(512)").HasColumnName("StockGeneralSentiment");
            entity.Property(e => e.StockRetweetSentiment).HasColumnType("varchar(512)").HasColumnName("StockRetweetSentiment");
            entity.Property(e => e.StockReplySentiment).HasColumnType("varchar(512)").HasColumnName("StockReplySentiment");
            entity.Property(e => e.StockLikeSentiment).HasColumnType("varchar(512)").HasColumnName("StockLikeSentiment");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");

        });

        modelBuilder.Entity<Sentiment1Week>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF65537");

            entity.Property(e => e.StockName).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.StockGeneralSentiment).HasColumnType("varchar(512)").HasColumnName("StockGeneralSentiment");
            entity.Property(e => e.StockRetweetSentiment).HasColumnType("varchar(512)").HasColumnName("StockRetweetSentiment");
            entity.Property(e => e.StockReplySentiment).HasColumnType("varchar(512)").HasColumnName("StockReplySentiment");
            entity.Property(e => e.StockLikeSentiment).HasColumnType("varchar(512)").HasColumnName("StockLikeSentiment");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");

        });

        modelBuilder.Entity<Prediction6Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF65555");

            entity.Property(e => e.StockNameAndPrice).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.RF).HasColumnType("varchar(512)").HasColumnName("RF");
            entity.Property(e => e.LSTM).HasColumnType("varchar(512)").HasColumnName("LSTM");
            entity.Property(e => e.Prophet).HasColumnType("varchar(512)").HasColumnName("Prophet");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");
            entity.Property(e => e.SelectPrice).HasColumnType("varchar(512)").HasColumnName("SelectPrice");

        });

        modelBuilder.Entity<Prediction3Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C26FF63755");

            entity.Property(e => e.StockNameAndPrice).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.RF).HasColumnType("varchar(512)").HasColumnName("RF");
            entity.Property(e => e.LSTM).HasColumnType("varchar(512)").HasColumnName("LSTM");
            entity.Property(e => e.Prophet).HasColumnType("varchar(512)").HasColumnName("Prophet");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");
            entity.Property(e => e.SelectPrice).HasColumnType("varchar(512)").HasColumnName("SelectPrice");

        });


        modelBuilder.Entity<Prediction1Month>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A9C265563755");

            entity.Property(e => e.StockNameAndPrice).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.RF).HasColumnType("varchar(512)").HasColumnName("RF");
            entity.Property(e => e.LSTM).HasColumnType("varchar(512)").HasColumnName("LSTM");
            entity.Property(e => e.Prophet).HasColumnType("varchar(512)").HasColumnName("Prophet");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");
            entity.Property(e => e.SelectPrice).HasColumnType("varchar(512)").HasColumnName("SelectPrice");

        });


        modelBuilder.Entity<Prediction1Week>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__Sentimen__2C83A95565563755");

            entity.Property(e => e.StockNameAndPrice).HasColumnType("varchar(512)").HasColumnName("StockName");
            entity.Property(e => e.RF).HasColumnType("varchar(512)").HasColumnName("RF");
            entity.Property(e => e.LSTM).HasColumnType("varchar(512)").HasColumnName("LSTM");
            entity.Property(e => e.Prophet).HasColumnType("varchar(512)").HasColumnName("Prophet");
            entity.Property(e => e.StockResultSentiment).HasColumnType("varchar(512)").HasColumnName("StockResultSentiment");
            entity.Property(e => e.SelectPrice).HasColumnType("varchar(512)").HasColumnName("SelectPrice");

        });

        base.OnModelCreating(modelBuilder);
    }
}