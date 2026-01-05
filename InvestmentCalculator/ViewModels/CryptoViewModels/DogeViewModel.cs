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

        private const double DogecoinPriceAt2025Mar25th = 0.1901;

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
            var dogecoinPriceAt2013Dec15th = 0.00056;
            var yearSpan = 11.29;
            double dogecoinCAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2013Dec15th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGRFromBirth * 100:F2}%";
        }

        private static string GetCAGR10Years()
        {
            var dogecoinPriceAt2015Mar25th = 0.0001304;
            var yearSpan = 10;
            double dogecoinCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2015Mar25th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR10Years * 100:F2}%";
        }

        private static string GetCAGR9Years()
        {
            var dogecoinPriceAt2016Mar25th = 0.0002144;
            var yearSpan = 9;
            double dogecoinCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2016Mar25th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR9Years * 100:F2}%";
        }

        private static string GetCAGR8Years()
        {
            var dogecoinPriceAt2017Mar25th = 0.0002976;
            var yearSpan = 8;
            double dogecoinCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2017Mar25th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR8Years * 100:F2}%";
        }

        private static string GetCAGR7Years()
        {
            // It's a bull market in year of 2018
            var dogecoinPriceAt2018Mar26th = 0.003275;
            var yearSpan = 7;
            double dogecoinCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2018Mar26th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR7Years * 100:F2}%";
        }

        private static string GetCAGR6Years()
        {
            var dogecoinPriceAt2019Mar27th = 0.002087;
            var yearSpan = 6;
            double dogecoinCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2019Mar27th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR6Years * 100:F2}%";
        }

        private static string GetCAGR5Years()
        {
            var dogecoinPriceAt2020Mar27th = 0.001805;
            var yearSpan = 5;
            double dogecoinCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2020Mar27th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR5Years * 100:F2}%";
        }

        private static string GetCAGR4Years()
        {
            // It's a bull market in year of 2021
            var dogecoinPriceAt2021Mar23th = 0.05352;
            var yearSpan = 4;
            double dogecoinCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2021Mar23th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR4Years * 100:F2}%";
        }

        private static string GetCAGR3Years()
        {
            // It's a bull market in year of 2022
            var dogecoinPriceAt2022Mar24th = 0.1366;
            var yearSpan = 3;
            double dogecoinCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2022Mar24th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR3Years * 100:F2}%";
        }

        private static string GetCAGR2Years()
        {
            var dogecoinPriceAt2023Mar26th = 0.07442;
            var yearSpan = 2;
            double dogecoinCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar26th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR2Years * 100:F2}%";
        }

        private static string GetCAGR1Year()
        {
            // It's a bull market in year of 2024
            var dogecoinPriceAt2023Mar27th = 0.1903;
            var yearSpan = 1;
            double dogecoinCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar27th, DogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR1Year * 100:F2}%";
        }


    }
}
