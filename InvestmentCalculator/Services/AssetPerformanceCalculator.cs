using InvestmentCalculators.Models;

namespace InvestmentCalculators.Services
{
    internal class AssetPerformanceCalculator
    {
        internal static AssetPerformance CalculateCryptoPerformance(string ticker, string assetName,
            AssetData data, bool excludingDividends = false)
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

        internal static StockPerformance CalculateStockPerformance(string ticker, string assetName,
            List<AssetPrice> tenYearStockPricesInOrder, bool excludingDividends = false)
        {
            var allCagrsInOrder1YearWindow = GetAllCAGRsInOrder(tenYearStockPricesInOrder, 1);
            var allCagrsInOrder2YearsWindow = GetAllCAGRsInOrder(tenYearStockPricesInOrder, 2);
            var allCagrsInOrder3YearsWindow = GetAllCAGRsInOrder(tenYearStockPricesInOrder, 3);
            var allCagrsInOrder4YearsWindow = GetAllCAGRsInOrder(tenYearStockPricesInOrder, 4);
            var allCagrsInOrder5YearsWindow = GetAllCAGRsInOrder(tenYearStockPricesInOrder, 5);

            // After getting all the cagrs, we can calc a lot of different metrics from them.
            var result = new StockPerformance
            {
                Ticker = ticker,
                Name = excludingDividends
                    ? assetName + " (Excluding Dividends)"
                    : assetName,
                AverageRollingCAGR1YearWindow = CalculateAverageRollingCAGR
                    (allCagrsInOrder1YearWindow),
                AverageRollingCAGR2YearsWindow = CalculateAverageRollingCAGR
                    (allCagrsInOrder2YearsWindow),
                AverageRollingCAGR3YearsWindow = CalculateAverageRollingCAGR
                    (allCagrsInOrder3YearsWindow),
                AverageRollingCAGR4YearsWindow = CalculateAverageRollingCAGR
                    (allCagrsInOrder4YearsWindow),
                AverageRollingCAGR5YearsWindow = CalculateAverageRollingCAGR
                    (allCagrsInOrder5YearsWindow),
                NegativeCAGRPercentage1YearWindow = CalculateNegativeCAGRPercentage
                    (allCagrsInOrder1YearWindow),
                NegativeCAGRPercentage2YearsWindow = CalculateNegativeCAGRPercentage
                    (allCagrsInOrder2YearsWindow),
                NegativeCAGRPercentage3YearsWindow = CalculateNegativeCAGRPercentage
                    (allCagrsInOrder3YearsWindow),
                NegativeCAGRPercentage4YearsWindow = CalculateNegativeCAGRPercentage
                    (allCagrsInOrder4YearsWindow),
                NegativeCAGRPercentage5YearsWindow = CalculateNegativeCAGRPercentage
                    (allCagrsInOrder5YearsWindow),
                MedianRollingCAGR1YearWindow = CalculateMedianRollingCAGR(
                    allCagrsInOrder1YearWindow),
                MedianRollingCAGR2YearsWindow = CalculateMedianRollingCAGR(
                    allCagrsInOrder2YearsWindow),
                MedianRollingCAGR3YearsWindow = CalculateMedianRollingCAGR(
                    allCagrsInOrder3YearsWindow),
                MedianRollingCAGR4YearsWindow = CalculateMedianRollingCAGR(
                    allCagrsInOrder4YearsWindow),
                MedianRollingCAGR5YearsWindow = CalculateMedianRollingCAGR(
                    allCagrsInOrder5YearsWindow)
            };
            return result;
        }

        /// <summary>
        /// The date of the first price is very important. It determines how many "windows" we can
        /// sample from the list.
        /// </summary>
        /// <param name="pricesInOrder">All the asset price data retrieved from db in order.</param>
        /// <param name="years">How many years of CAGR you want to calc.</param>
        private static List<double> GetAllCAGRsInOrder(List<AssetPrice> pricesInOrder, int years)
        {
            List<double> allCagrsInOrder = [];

            // We only loop through dates that actually have an 'anchor' x years prior
            DateTime earliestPossibleEnd = pricesInOrder[0].Date.AddYears(years);

            // We start from the first date that actually has a full 'years' of history behind it
            var validEndDatesInOrder = pricesInOrder.Where(p => p.Date >= earliestPossibleEnd).ToList();

            if (validEndDatesInOrder.Count == 0) return [];

            foreach (var endPoint in validEndDatesInOrder)
            {
                // 1. Calculate the exact target start date (e.g., Today minus 5 years)
                DateTime targetStartDate = endPoint.Date.AddYears(-years);

                // 2. Find the actual price closest to that date in your list
                // (This handles weekends/holidays accurately)
                var startPoint = pricesInOrder
                    .Where(p => p.Date <= targetStartDate)
                    .OrderByDescending(p => p.Date)
                    .FirstOrDefault();

                if (startPoint != null && startPoint.Close > 0)
                {
                    double startPrice = startPoint.Close;
                    double endPrice = endPoint.Close;

                    // 3. Calculate CAGR using the exact years requested
                    double cagr = CalculateAverageAnualReturnRate(startPrice, endPrice, years);
                    allCagrsInOrder.Add(cagr);
                }
            }

            return allCagrsInOrder;
        }

        private static double CalculateAverageAnualReturnRate(double startValue,
            double endValue, double yearSpan)
        {
            if (startValue is 0 || yearSpan <= 0) return 0;
            double totalGrowthFactor = endValue / startValue;
            double compoundAnnualGrowthRate = Math.Pow(totalGrowthFactor, 1 / yearSpan) - 1;
            return compoundAnnualGrowthRate;
        }

        private static double CalculateAverageRollingCAGR(List<double> allCagrsInOrder)
        {
            return allCagrsInOrder.Count != 0 ? allCagrsInOrder.Average() : 0;
        }

        /// <summary>
        /// The less nagative CAGR percentage, the better the stock is in general.
        /// </summary>
        /// <param name="allCagrsInOrder"></param>
        /// <returns></returns>
        private static double CalculateNegativeCAGRPercentage(List<double> allCagrsInOrder)
        {
            var totalCount = allCagrsInOrder.Count;
            var negativeCAGRCount = allCagrsInOrder.Count(cagr => cagr < 0);
            // Have to coarse one int into a double so the division would be double division
            var negativeCAGRPercentage = (double)negativeCAGRCount / totalCount;
            return negativeCAGRPercentage;
        }

        private static double CalculateMedianRollingCAGR(List<double> allCagrsInOrder)
        {
            if (allCagrsInOrder.Count == 0) return 0;
            var sortedCAGRs = allCagrsInOrder.OrderBy(cagr => cagr).ToList();
            int midIndex = sortedCAGRs.Count / 2;
            if (sortedCAGRs.Count % 2 == 0)
            {
                // Even count, take the average of the two middle values
                return (sortedCAGRs[midIndex - 1] + sortedCAGRs[midIndex]) / 2;
            }
            else
            {
                // Odd count, take the middle value
                return sortedCAGRs[midIndex];
            }
        }


    }
}
