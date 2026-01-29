using InvestmentCalculators.Data;
using InvestmentCalculators.Models;
using Microsoft.EntityFrameworkCore;
using OoplesFinance.YahooFinanceAPI;
using OoplesFinance.YahooFinanceAPI.Enums;
using OoplesFinance.YahooFinanceAPI.Models;

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

            IEnumerable<HistoricalChartInfo> history = await FetchStockDataFromYahooFinanceAsync(ticker, startDate);

            var newStockPricesFromYahooFinanceAPI = GetConvertedStockPricesFromFetchedData(ticker, history);

            await PopulateDbWithNewFetchedStockData(ticker, db, newStockPricesFromYahooFinanceAPI);

            return newStockPricesFromYahooFinanceAPI;
        }

        private static async Task<IEnumerable<HistoricalChartInfo>> FetchStockDataFromYahooFinanceAsync(
            string ticker, DateTime startDate)
        {
            var yahooClient = new YahooClient();
            var history = await yahooClient.GetHistoricalDataAsync(ticker, DataFrequency.Daily,
                startDate, DateTime.Now);
            return history;
        }

        private static List<StockPrice> GetConvertedStockPricesFromFetchedData(string ticker, IEnumerable<HistoricalChartInfo> history)
        {
            // 3. Convert Yahoo data to our SQLite model
            return history.Select(h => new StockPrice
            {
                Ticker = ticker,
                Date = h.Date,
                AdjClose = h.AdjustedClose
            }).ToList();
        }

        private static async Task PopulateDbWithNewFetchedStockData(string ticker, AppDbContext db, List<StockPrice> newStockPricesFromYahooFinanceAPI)
        {
            // 4. Save to SQLite (Avoiding duplicates)
            // Note: In a production app, you'd check for duplicates more carefully,
            // but for a 5-year chunk, clearing and re-saving is a simple start.
            var existingStockDataFromDb = db.StockPrices.Where(p => p.Ticker == ticker).ToList();
            db.StockPrices.RemoveRange(existingStockDataFromDb);
            db.StockPrices.AddRange(newStockPricesFromYahooFinanceAPI);
            await db.SaveChangesAsync();
        }


    }
}
