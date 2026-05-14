namespace InvestmentCalculators.Models
{
    public class AssetPerformance
    {
        public string? Ticker { get; init; }
        public string? Name { get; init; }
        public DateOnly? EndDate { get; init; }
        public decimal? CAGRFromBirth { get; init; }
        public DateOnly? BirthDate { get; init; }
        public decimal? CAGR10Years { get; init; }
        public DateOnly? Date10YearsAgo { get; init; }
        public decimal? CAGR9Years { get; init; }
        public DateOnly? Date9YearsAgo { get; init; }
        public decimal? CAGR8Years { get; init; }
        public DateOnly? Date8YearsAgo { get; init; }
        public decimal? CAGR7Years { get; init; }
        public DateOnly? Date7YearsAgo { get; init; }
        public decimal? CAGR6Years { get; init; }
        public DateOnly? Date6YearsAgo { get; init; }
        public decimal? CAGR5Years { get; init; }
        public DateOnly? Date5YearsAgo { get; init; }
        public decimal? CAGR4Years { get; init; }
        public DateOnly? Date4YearsAgo { get; init; }
        public decimal? CAGR3Years { get; init; }
        public DateOnly? Date3YearsAgo { get; init; }
        public decimal? CAGR2Years { get; init; }
        public DateOnly? Date2YearsAgo { get; init; }
        public decimal? CAGR1Year { get; init; }
        public DateOnly? Date1YearAgo { get; init; }
    }

    public class StockPerformance
    {
        public string? Ticker { get; init; }
        public string? Name { get; init; }
        public double? AverageRollingCAGR5YearsWindow { get; init; }
        public double? AverageRollingCAGR4YearsWindow { get; init; }
        public double? AverageRollingCAGR3YearsWindow { get; init; }
        public double? AverageRollingCAGR2YearsWindow { get; init; }
        public double? AverageRollingCAGR1YearWindow { get; init; }
        public double? NegativeCAGRPercentage5YearsWindow { get; init; }
        public double? NegativeCAGRPercentage4YearsWindow { get; init; }
        public double? NegativeCAGRPercentage3YearsWindow { get; init; }
        public double? NegativeCAGRPercentage2YearsWindow { get; init; }
        public double? NegativeCAGRPercentage1YearWindow { get; init; }
        public double? MedianRollingCAGR5YearsWindow { get; init; }
        public double? MedianRollingCAGR4YearsWindow { get; init; }
        public double? MedianRollingCAGR3YearsWindow { get; init; }
        public double? MedianRollingCAGR2YearsWindow { get; init; }
        public double? MedianRollingCAGR1YearWindow { get; init; }
        public double? WorstCaseRollingCAGR5YearsWindow { get; init; }
        public double? WorstCaseRollingCAGR4YearsWindow { get; init; }
        public double? WorstCaseRollingCAGR3YearsWindow { get; init; }
        public double? WorstCaseRollingCAGR2YearsWindow { get; init; }
        public double? WorstCaseRollingCAGR1YearWindow { get; init; }
    }



}
