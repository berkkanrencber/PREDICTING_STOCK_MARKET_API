using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PREDICTING_STOCK_MARKET_API.Models;

public class StocksContext:IdentityDbContext<AppUser,AppRole,int>{
    
    public StocksContext(DbContextOptions<StocksContext> options): base(options){
        
    }
    public DbSet<Stock> Stock { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //modelBuilder.Entity<Stock>().HasData()
    }
}