using InvestmentCalculator.Models;

namespace InvestmentCalculator.Services
{
    internal class AssetPerformanceCalculator
    {
        internal static AssetPerformance Calculate(string ticker, AssetData data)
        {
            if (data == null || data.EndPrice <= 0) return new AssetPerformance { Ticker = ticker };

            // Prepare object initializer for all possible properties
            var result = new AssetPerformance
            {
                Ticker = ticker,
                CAGR1Year = CalculateAverageAnualReturnRate(data.Price1YearAgoFromEndDate, data.EndPrice, 1),
                CAGR2Years = CalculateAverageAnualReturnRate(data.Price2YearsAgoFromEndDate, data.EndPrice, 2),
                CAGR3Years = CalculateAverageAnualReturnRate(data.Price3YearsAgoFromEndDate, data.EndPrice, 3),
                CAGR4Years = CalculateAverageAnualReturnRate(data.Price4YearsAgoFromEndDate, data.EndPrice, 4),
                CAGR5Years = CalculateAverageAnualReturnRate(data.Price5YearsAgoFromEndDate, data.EndPrice, 5)
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
