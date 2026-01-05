using InvestmentCalculators;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class DogeViewModel
    {
        public string? CAGRFromBirth { get; private set; }
        public string? CAGR10Years { get; private set; }
        public string? CAGR9Years { get; private set; }
        public string? CAGR8Years { get; private set; }
        public string? CAGR7Years { get; private set; }
        public string? CAGR6Years { get; private set; }
        public string? CAGR5Years { get; private set; }
        public string? CAGR4Years { get; private set; }
        public string? CAGR3Years { get; private set; }
        public string? CAGR2Years { get; private set; }
        public string? CAGR1Year { get; private set; }

        // Data points
        private const double DogecoinPriceAt2025Mar25th = 0.1901;

        private const double DogecoinPriceAt2013Dec15th = 0.00056;
        private const double YearSpanFromBirthToEndingDate = 11.29;

        private const double DogecoinPriceAt2015Mar25th = 0.0001304;
        private const double DogecoinPriceAt2016Mar25th = 0.0002144;
        private const double DogecoinPriceAt2017Mar25th = 0.0002976;
        private const double DogecoinPriceAt2018Mar26th = 0.003275;
        private const double DogecoinPriceAt2019Mar27th = 0.002087;
        private const double DogecoinPriceAt2020Mar27th = 0.001805;
        private const double DogecoinPriceAt2021Mar23th = 0.05352;
        private const double DogecoinPriceAt2022Mar24th = 0.1366;
        private const double DogecoinPriceAt2023Mar26th = 0.07442;
        private const double DogecoinPriceAt2023Mar27th = 0.1903;

        public DogeViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            CAGRFromBirth = GetCAGRFromBirth();
            CAGR10Years = GetCAGR10Years();
            CAGR9Years = GetCAGR9Years();
            CAGR8Years = GetCAGR8Years();
            CAGR7Years = GetCAGR7Years();
            CAGR6Years = GetCAGR6Years();
            CAGR5Years = GetCAGR5Years();
            CAGR4Years = GetCAGR4Years();
            CAGR3Years = GetCAGR3Years();
            CAGR2Years = GetCAGR2Years();
            CAGR1Year = GetCAGR1Year();
        }

        private static string GetCAGRFromBirth()
        {
            double dogecoinCAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2013Dec15th, DogecoinPriceAt2025Mar25th, YearSpanFromBirthToEndingDate);
            return $"{dogecoinCAGRFromBirth * 100:F2}%";
        }

        private static string GetCAGR10Years()
        {
            const int YearSpan = 10;
            double dogecoinCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2015Mar25th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR10Years * 100:F2}%";
        }

        private static string GetCAGR9Years()
        {
            const int YearSpan = 9;
            double dogecoinCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2016Mar25th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR9Years * 100:F2}%";
        }

        private static string GetCAGR8Years()
        {
            const int YearSpan = 8;
            double dogecoinCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2017Mar25th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR8Years * 100:F2}%";
        }

        private static string GetCAGR7Years()
        {
            // It's a bull market in year of 2018
            const int YearSpan = 7;
            double dogecoinCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2018Mar26th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR7Years * 100:F2}%";
        }

        private static string GetCAGR6Years()
        {
            const int YearSpan = 6;
            double dogecoinCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2019Mar27th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR6Years * 100:F2}%";
        }

        private static string GetCAGR5Years()
        {
            const int YearSpan = 5;
            double dogecoinCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2020Mar27th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR5Years * 100:F2}%";
        }

        private static string GetCAGR4Years()
        {
            // It's a bull market in year of 2021
            const int YearSpan = 4;
            double dogecoinCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2021Mar23th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR4Years * 100:F2}%";
        }

        private static string GetCAGR3Years()
        {
            // It's a bull market in year of 2022
            const int YearSpan = 3;
            double dogecoinCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2022Mar24th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR3Years * 100:F2}%";
        }

        private static string GetCAGR2Years()
        {
            const int YearSpan = 2;
            double dogecoinCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2023Mar26th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR2Years * 100:F2}%";
        }

        private static string GetCAGR1Year()
        {
            // It's a bull market in year of 2024
            const int YearSpan = 1;
            double dogecoinCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                DogecoinPriceAt2023Mar27th, DogecoinPriceAt2025Mar25th, YearSpan);
            return $"{dogecoinCAGR1Year * 100:F2}%";
        }


    }
}
