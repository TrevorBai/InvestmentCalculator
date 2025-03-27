namespace InvestmentCalculators
{
    internal static class Calculators
    {
        internal static double CalculateAverageAnualReturnRate(double beginningValue,
            double endingValue, double yearSpan)
        {
            var totalGrowthFactor = endingValue / beginningValue;
            var compoundAnnualGrowthRate = Math.Pow(totalGrowthFactor, 1 / yearSpan) - 1;
            return compoundAnnualGrowthRate;
        }





    }
}
