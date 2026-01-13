namespace InvestmentCalculator.Models
{
    internal class AssetData
    {
        internal string? Ticker { get; init; }
        internal decimal EndPrice { get; init; }
        internal decimal Price10YearsAgoFromEndDate { get; init; }
        internal decimal Price9YearsAgoFromEndDate { get; init; }
        internal decimal Price8YearsAgoFromEndDate { get; init; }
        internal decimal Price7YearsAgoFromEndDate { get; init; }
        internal decimal Price6YearsAgoFromEndDate { get; init; }
        internal decimal Price5YearsAgoFromEndDate { get; init; }
        internal decimal Price4YearsAgoFromEndDate { get; init; }
        internal decimal Price3YearsAgoFromEndDate { get; init; }
        internal decimal Price2YearsAgoFromEndDate { get; init; }
        internal decimal Price1YearAgoFromEndDate { get; init; }
        
        // Not common data points
        internal decimal StartPriceFromBirth { get; init; }
        internal double YearsFromBirthToEndDate { get; init; }
    }
}
