using InvestmentCalculators.Models;
using InvestmentCalculators.Services;
using System.ComponentModel;

namespace InvestmentCalculators.ViewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        public AssetPerformance? Costco { get; private set; }

        internal void LoadStockPerformance(List<AssetPrice> allPrices, DateTime anchorDate)
        {
            // The "Meaty" calculation logic now lives here
            var costcoData = Get5YrsAssetDataFromDb(allPrices, "COST", anchorDate);

            // We calculate and assign locally
            Costco = AssetPerformanceCalculator.Calculate("COST", "Costco", costcoData, true);

            OnPropertyChanged(nameof(Costco));
        }

        private static AssetData Get5YrsAssetDataFromDb(List<AssetPrice> assetPrices,
            string assetTicker, DateTime anchorEndingDate, bool byAdjustedClose = false)
        {
            var startRangeDate = new DateTime(anchorEndingDate.Year - 5, anchorEndingDate.Month, 1);
            var endRangeDate = new DateTime(anchorEndingDate.Year, anchorEndingDate.Month, 1)
                .AddMonths(1).AddDays(-1);

            var allPrices = GetPriceRange(assetPrices, assetTicker, startRangeDate, endRangeDate);

            var date1YearAgo = anchorEndingDate.AddYears(-1);
            var date2YearsAgo = anchorEndingDate.AddYears(-2);
            var date3YearsAgo = anchorEndingDate.AddYears(-3);
            var date4YearsAgo = anchorEndingDate.AddYears(-4);
            var date5YearsAgo = anchorEndingDate.AddYears(-5);

            var priceAtEndingDate = byAdjustedClose
                ? FindPriceByAdjClose(anchorEndingDate, allPrices)
                : FindPriceByClose(anchorEndingDate, allPrices);
            var priceAt1YearAgo = byAdjustedClose
                ? FindPriceByAdjClose(date1YearAgo, allPrices)
                : FindPriceByClose(date1YearAgo, allPrices);
            var priceAt2YearsAgo = byAdjustedClose
                ? FindPriceByAdjClose(date2YearsAgo, allPrices)
                : FindPriceByClose(date2YearsAgo, allPrices);
            var priceAt3YearsAgo = byAdjustedClose
                ? FindPriceByAdjClose(date3YearsAgo, allPrices)
                : FindPriceByClose(date3YearsAgo, allPrices);
            var priceAt4YearsAgo = byAdjustedClose
                ? FindPriceByAdjClose(date4YearsAgo, allPrices)
                : FindPriceByClose(date4YearsAgo, allPrices);
            var priceAt5YearsAgo = byAdjustedClose
                ? FindPriceByAdjClose(date5YearsAgo, allPrices)
                : FindPriceByClose(date5YearsAgo, allPrices);

            var assetData = new AssetData
            {
                EndPrice = (decimal)priceAtEndingDate,
                EndDate = DateOnly.FromDateTime(anchorEndingDate),
                Price1YearAgoFromEndDate = (decimal)priceAt1YearAgo,
                Date1YearAgo = DateOnly.FromDateTime(date1YearAgo),
                Price2YearsAgoFromEndDate = (decimal)priceAt2YearsAgo,
                Date2YearsAgo = DateOnly.FromDateTime(date2YearsAgo),
                Price3YearsAgoFromEndDate = (decimal)priceAt3YearsAgo,
                Date3YearsAgo = DateOnly.FromDateTime(date3YearsAgo),
                Price4YearsAgoFromEndDate = (decimal)priceAt4YearsAgo,
                Date4YearsAgo = DateOnly.FromDateTime(date4YearsAgo),
                Price5YearsAgoFromEndDate = (decimal)priceAt5YearsAgo,
                Date5YearsAgo = DateOnly.FromDateTime(date5YearsAgo)
            };
            return assetData;
        }

        private static List<AssetPrice> GetPriceRange(List<AssetPrice> assetPrices,
            string ticker, DateTime start, DateTime end)
        {
            return [.. assetPrices
                .Where(p => p.Ticker == ticker && p.Date >= start && p.Date <= end)
                .OrderBy(p => p.Date)];
        }

        /// <summary>
        /// If can't find the price on that specific date, find the most recent price
        /// before that date.
        /// </summary>
        private static double FindPriceByAdjClose(DateTime targetDate, List<AssetPrice> assetPrices)
        {
            var lastAvailable = assetPrices
                .Where(p => p.Date.Date <= targetDate.Date)
                .OrderByDescending(p => p.Date)
                .FirstOrDefault();
            return lastAvailable?.AdjClose ?? 0;
        }

        /// <summary>
        /// If can't find the price on that specific date, find the most recent price
        /// before that date.
        /// </summary>
        private static double FindPriceByClose(DateTime targetDate, List<AssetPrice> assetPrices)
        {
            var lastAvailable = assetPrices
                .Where(p => p.Date.Date <= targetDate.Date) // Only look at today or earlier
                .OrderByDescending(p => p.Date)            // Get the most recent one
                .FirstOrDefault();
            return lastAvailable?.Close ?? 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
