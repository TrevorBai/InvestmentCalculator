using InvestmentCalculators.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculators.Data
{
    /// <summary>
    /// Gateway to the application's database.
    /// </summary>
    internal class AppDbContext : DbContext
    {
        public DbSet<StockPrice> StockPrices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This will create a file named 'StockHistory.db' in your project's bin folder
            optionsBuilder.UseSqlite("Data Source=StockHistory.db");
        }





    }
}
