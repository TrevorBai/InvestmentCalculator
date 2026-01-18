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
}
