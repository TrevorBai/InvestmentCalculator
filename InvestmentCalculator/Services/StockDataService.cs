using InvestmentCalculators.Data;
using InvestmentCalculators.Models;
using Microsoft.EntityFrameworkCore;
using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Enums;

namespace InvestmentCalculators.Services
{
    /// <summary>
    /// "Traffic controller".
    /// </summary>
    internal class StockDataService
    {
        internal async Task<List<StockPrice>> GetHistoricalDataAsync(string ticker, int yearsBack)
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            var startDate = DateTime.Now.AddYears(-yearsBack);

            // 1. Check SQLite first
            var localData = await db.StockPrices
                .Where(p => p.Ticker == ticker && p.Date >= startDate)
                .OrderBy(p => p.Date)
                .ToListAsync();

            // If we have data adn it's up to date (within 24 hours), use it!
            if (localData.Any() && localData.Max(p => p.Date) >= DateTime.Now.AddDays(-1)) 
            {
                return localData;       
            }

            // 2. If no data, fetch from Yahoo
            var yahooClient = new YahooClient();
            var history = await yahooClient.GetHistoricalDataAsync(ticker, DataFrequency.Daily,
                startDate, DateTime.Now);

            // 3. Convert Yahoo data to our SQLite model
            var newPrices = history.Select(h => new StockPrice
                {
                    Ticker = ticker,
                    Date = h.Date,
                    AdjClose = h.AdjustedClose
                }).ToList();

            // 4. Save to SQLite (Avoiding duplicates)
            // Note: In a production app, you'd check for duplicates more carefully,
            // but for a 5-year chunk, clearing and re-saving is a simple start.
            var existing = db.StockPrices.Where(p => p.Ticker == ticker).ToList();
            db.StockPrices.RemoveRange(existing);

            db.StockPrices.AddRange(newPrices);
            await db.SaveChangesAsync();

            return newPrices;
        }






    }
}
