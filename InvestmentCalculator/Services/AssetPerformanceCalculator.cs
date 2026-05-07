using InvestmentCalculators.Models;

namespace InvestmentCalculators.Services
{
    internal class AssetPerformanceCalculator
    {
        internal static AssetPerformance Calculate(string ticker, string assetName, AssetData data,
            bool excludingDividends = false)
        {
            if (data == null || data.EndPrice <= 0) return new AssetPerformance { Ticker = ticker };

            var result = new AssetPerformance
            {
                Ticker = ticker,
                Name = excludingDividends 
                    ? assetName + " (Excluding Dividends)" 
                    : assetName,
                EndDate = data.EndDate,
                BirthDate = data.BirthDate,
                Date10YearsAgo = data.Date10YearsAgo,
                Date9YearsAgo = data.Date9YearsAgo,
                Date8YearsAgo = data.Date8YearsAgo,
                Date7YearsAgo = data.Date7YearsAgo,
                Date6YearsAgo = data.Date6YearsAgo,
                Date5YearsAgo = data.Date5YearsAgo,
                Date4YearsAgo = data.Date4YearsAgo,
                Date3YearsAgo = data.Date3YearsAgo,
                Date2YearsAgo = data.Date2YearsAgo,
                Date1YearAgo = data.Date1YearAgo,
                CAGR1Year = CalculateAverageAnualReturnRate(data.Price1YearAgoFromEndDate, data.EndPrice, 1),
                CAGR2Years = CalculateAverageAnualReturnRate(data.Price2YearsAgoFromEndDate, data.EndPrice, 2),
                CAGR3Years = CalculateAverageAnualReturnRate(data.Price3YearsAgoFromEndDate, data.EndPrice, 3),
                CAGR4Years = CalculateAverageAnualReturnRate(data.Price4YearsAgoFromEndDate, data.EndPrice, 4),
                CAGR5Years = CalculateAverageAnualReturnRate(data.Price5YearsAgoFromEndDate, data.EndPrice, 5),
                CAGR6Years = CalculateAverageAnualReturnRate(data.Price6YearsAgoFromEndDate, data.EndPrice, 6),
                CAGR7Years = CalculateAverageAnualReturnRate(data.Price7YearsAgoFromEndDate, data.EndPrice, 7),
                CAGR8Years = CalculateAverageAnualReturnRate(data.Price8YearsAgoFromEndDate, data.EndPrice, 8),
                CAGR9Years = CalculateAverageAnualReturnRate(data.Price9YearsAgoFromEndDate, data.EndPrice, 9),
                CAGR10Years = CalculateAverageAnualReturnRate(data.Price10YearsAgoFromEndDate, data.EndPrice, 10),
                CAGRFromBirth = CalculateAverageAnualReturnRate(data.StartPriceFromBirth, data.EndPrice, data.YearsFromBirthToEndDate)
            };
            return result;
        }

        private static decimal CalculateAverageAnualReturnRate(decimal startValue,
            decimal endValue, double yearSpan)
        {
            if (startValue is 0 || yearSpan <= 0) return 0m;
            double totalGrowthFactor = (double)(endValue / startValue);
            double compoundAnnualGrowthRate = Math.Pow(totalGrowthFactor, 1 / yearSpan) - 1;
            return (decimal)compoundAnnualGrowthRate;
        }

        internal static AssetPerformance CalculateStockPerformanceUsingAverageRollingCAGR(string ticker,
            string assetName, List<AssetPrice> tenYearStockPrices, bool excludingDividends = false)
        {
            var result = new AssetPerformance
            {
                Ticker = ticker,
                Name = excludingDividends
                    ? assetName + " (Excluding Dividends)"
                    : assetName,
                CAGR1Year = (decimal)CalculateAverageRollingCAGR(tenYearStockPrices, 1),
                CAGR2Years = (decimal)CalculateAverageRollingCAGR(tenYearStockPrices, 2),
                CAGR3Years = (decimal)CalculateAverageRollingCAGR(tenYearStockPrices, 3),
                CAGR4Years = (decimal)CalculateAverageRollingCAGR(tenYearStockPrices, 4),
                CAGR5Years = (decimal)CalculateAverageRollingCAGR(tenYearStockPrices, 5)
            };
            return result;
        }

        /// <summary>
        /// The date of the first price is very important. It determines how many "windows" we can
        /// sample from the list.
        /// </summary>
        /// <param name="prices">All the asset price data retrieved from db.</param>
        /// <param name="years">How many years of CAGR you want to calc.</param>
        /// <returns></returns>
        private static double CalculateAverageRollingCAGR(List<AssetPrice> prices, int years)
        {
            List<double> allCagrs = [];

            // We only loop through dates that actually have an 'anchor' x years prior
            DateTime earliestPossibleEnd = prices[0].Date.AddYears(years);

            // We start from the first date that actually has a full 'years' of history behind it
            var validEndDates = prices.Where(p => p.Date >= earliestPossibleEnd).ToList();

            if (!validEndDates.Any()) return 0;

            foreach (var endPoint in validEndDates)
            {
                // 1. Calculate the exact target start date (e.g., Today minus 5 years)
                DateTime targetStartDate = endPoint.Date.AddYears(-years);

                // 2. Find the actual price closest to that date in your list
                // (This handles weekends/holidays accurately)
                var startPoint = prices
                    .Where(p => p.Date <= targetStartDate)
                    .OrderByDescending(p => p.Date)
                    .FirstOrDefault();

                if (startPoint != null && startPoint.Close > 0)
                {
                    double startPrice = startPoint.Close;
                    double endPrice = endPoint.Close;

                    // 3. Calculate CAGR using the exact years requested
                    double cagr = Math.Pow(endPrice / startPrice, 1.0 / years) - 1;
                    allCagrs.Add(cagr);
                }
            }

            return allCagrs.Count != 0 ? allCagrs.Average() : 0;
        }
    }
}
