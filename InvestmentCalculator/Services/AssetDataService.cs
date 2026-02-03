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
    internal class AssetDataService
    {
        internal async Task<List<AssetPrice>> GetHistoricalDataAsyncAndSaveInDb(string ticker, int yearsBack)
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            var startDate = DateTime.Now.AddYears(-yearsBack);

            // 1. Check SQLite first
            var localData = await db.AssetPrices
                .Where(p => p.Ticker == ticker && p.Date >= startDate)
                .OrderBy(p => p.Date)
                .ToListAsync();

            // If we have data adn it's up to date (within 24 hours), use it!
            if (localData.Any() && localData.Max(p => p.Date) >= DateTime.Now.AddDays(-1))
            {
                return localData;
            }

            IEnumerable<HistoricalChartInfo> history = await FetchAssetDataFromYahooFinanceAsync(ticker, startDate);

            var newAssetPricesFromYahooFinanceAPI = GetConvertedStockPricesFromFetchedData(ticker, history);

            await PopulateDbWithNewFetchedAssetData(ticker, db, newAssetPricesFromYahooFinanceAPI);

            return newAssetPricesFromYahooFinanceAPI;
        }

        private static async Task<IEnumerable<HistoricalChartInfo>> FetchAssetDataFromYahooFinanceAsync(
            string ticker, DateTime startDate)
        {
            var yahooClient = new YahooClient();
            var history = await yahooClient.GetHistoricalDataAsync(ticker, DataFrequency.Daily,
                startDate, DateTime.Now);
            return history;
        }

        private static List<AssetPrice> GetConvertedStockPricesFromFetchedData(string ticker, IEnumerable<HistoricalChartInfo> history)
        {
            // 3. Convert Yahoo data to our SQLite model
            return [.. history.Select(h => new AssetPrice
            {
                Ticker = ticker,
                Date = h.Date,
                AdjClose = h.AdjustedClose,
                Close = h.Close
            })];
        }

        private static async Task PopulateDbWithNewFetchedAssetData(string ticker, AppDbContext db, List<AssetPrice> newAssetPricesFromYahooFinanceAPI)
        {
            // 4. Save to SQLite (Avoiding duplicates)
            // Note: In a production app, you'd check for duplicates more carefully,
            // but for a 5-year chunk, clearing and re-saving is a simple start.
            var existingAssetDataFromDb = db.AssetPrices.Where(p => p.Ticker == ticker).ToList();
            db.AssetPrices.RemoveRange(existingAssetDataFromDb);
            db.AssetPrices.AddRange(newAssetPricesFromYahooFinanceAPI);
            await db.SaveChangesAsync();
        }


    }
}
