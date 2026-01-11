namespace InvestmentCalculators
{
    internal static class Calculators
    {
        internal static double CalculateAverageAnualReturnRate(double beginningValue,
            double endingValue, double yearSpan)
        {
            if (beginningValue is 0) return 0;
            var totalGrowthFactor = endingValue / beginningValue;
            var compoundAnnualGrowthRate = Math.Pow(totalGrowthFactor, 1 / yearSpan) - 1;
            return compoundAnnualGrowthRate;
        }





    }
}
