using InvestmentCalculators;

namespace InvestmentCalculator.ViewModels.Utilities
{
    internal class CAGRCalculator(double endValue, double value10YearsAgoFromEndDate,
        double value9YearsAgoFromEndDate, double value8YearsAgoFromEndDate,
        double value7YearsAgoFromEndDate, double value6YearsAgoFromEndDate,
        double value5YearsAgoFromEndDate, double value4YearsAgoFromEndDate,
        double value3YearsAgoFromEndDate, double value2YearsAgoFromEndDate,
        double value1YearAgoFromEndDate, double startValueFromBirth,
        double yearsFromBirthToEndDate)
    {
        private readonly double _endValue = endValue;
        
        private readonly double _value10YearsAgoFromEndDate = value10YearsAgoFromEndDate;
        private readonly double _value9YearsAgoFromEndDate = value9YearsAgoFromEndDate;
        private readonly double _value8YearsAgoFromEndDate = value8YearsAgoFromEndDate;
        private readonly double _value7YearsAgoFromEndDate = value7YearsAgoFromEndDate;
        private readonly double _value6YearsAgoFromEndDate = value6YearsAgoFromEndDate;
        private readonly double _value5YearsAgoFromEndDate = value5YearsAgoFromEndDate;
        private readonly double _value4YearsAgoFromEndDate = value4YearsAgoFromEndDate;
        private readonly double _value3YearsAgoFromEndDate = value3YearsAgoFromEndDate;
        private readonly double _value2YearsAgoFromEndDate = value2YearsAgoFromEndDate;
        private readonly double _value1YearAgoFromEndDate = value1YearAgoFromEndDate;

        // Not common data points
        private readonly double _startValueFromBirth = startValueFromBirth;
        private readonly double _yearsFromBirthToEndDate = yearsFromBirthToEndDate;

        protected string GetCAGRFromBirth()
        {
            if (_startValueFromBirth.Equals(0) ||
                _yearsFromBirthToEndDate.Equals(0)) return string.Empty;
            double CAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                _startValueFromBirth, _endValue, _yearsFromBirthToEndDate);
            return $"{CAGRFromBirth * 100:F2}%";
        }

        protected string GetCAGR10Years()
        {
            const int YearSpan = 10;
            double btcCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                _value10YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR10Years * 100:F2}%";
        }

        protected string GetCAGR9Years()
        {
            const int YearSpan = 9;
            double btcCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                _value9YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR9Years * 100:F2}%";
        }

        protected string GetCAGR8Years()
        {
            const int YearSpan = 8;
            double btcCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                _value8YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR8Years * 100:F2}%";
        }

        protected string GetCAGR7Years()
        {
            // It's a bull market in year of 2018
            const int YearSpan = 7;
            double btcCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                _value7YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR7Years * 100:F2}%";
        }

        protected string GetCAGR6Years()
        {
            const int YearSpan = 6;
            double btcCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                _value6YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR6Years * 100:F2}%";
        }

        protected string GetCAGR5Years()
        {
            const int YearSpan = 5;
            double btcCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                _value5YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR5Years * 100:F2}%";
        }

        protected string GetCAGR4Years()
        {
            // It's a bull market in year of 2021
            const int YearSpan = 4;
            double btcCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                _value4YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR4Years * 100:F2}%";
        }

        protected string GetCAGR3Years()
        {
            // It's a bull market in year of 2022
            const int YearSpan = 3;
            double btcCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                _value3YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR3Years * 100:F2}%";
        }

        protected string GetCAGR2Years()
        {
            const int YearSpan = 2;
            double btcCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                _value2YearsAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR2Years * 100:F2}%";
        }

        protected string GetCAGR1Year()
        {
            // It's a bull market in year of 2024
            const int YearSpan = 1;
            double btcCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                _value1YearAgoFromEndDate, _endValue, YearSpan);
            return $"{btcCAGR1Year * 100:F2}%";
        }


    }
}
