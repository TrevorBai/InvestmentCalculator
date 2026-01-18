using InvestmentCalculator.Models;

namespace InvestmentCalculator.Services
{
    internal class AssetPerformanceCalculator
    {
        internal static AssetPerformance Calculate(string ticker, string assetName, AssetData data)
        {
            if (data == null || data.EndPrice <= 0) return new AssetPerformance { Ticker = ticker };

            var result = new AssetPerformance
            {
                Ticker = ticker,
                Name = assetName,
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
    }
}
