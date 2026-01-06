using InvestmentCalculators;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class BTCViewModel
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

        private const double BtcPriceAt2025Mar26th = 86888.01;

        private const double BitcoinPriceAt2009Oct15th = 0.00099;
        private const double YearSpanFromBirthToEndingDate = 15.4757;

        private const double BitcoinPriceAt2015Mar28th = 252.74;
        private const double BitcoinPriceAt2016Mar23th = 418.42;
        private const double BitcoinPriceAt2017Mar28th = 1046.07;
        private const double BitcoinPriceAt2018Mar24th = 8612.8;
        private const double BitcoinPriceAt2019Mar29th = 4092.13;
        private const double BitcoinPriceAt2020Mar24th = 6738.71;
        private const double BitcoinPriceAt2021Mar30th = 58930.27;
        private const double BitcoinPriceAt2022Mar27th = 46821.85;
        private const double BitcoinPriceAt2023Mar24th = 27487.33;
        private const double BitcoinPriceAt2024Mar28th = 70744.79;


        public BTCViewModel()
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
            double btcCAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2009Oct15th, BtcPriceAt2025Mar26th, YearSpanFromBirthToEndingDate);
            return $"{btcCAGRFromBirth * 100:F2}%";
        }

        private static string GetCAGR10Years()
        {
            const int YearSpan = 10;
            double btcCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2015Mar28th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR10Years * 100:F2}%";
        }

        private static string GetCAGR9Years()
        {
            const int YearSpan = 9;
            double btcCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2016Mar23th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR9Years * 100:F2}%";
        }

        private static string GetCAGR8Years()
        {
            const int YearSpan = 8;
            double btcCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2017Mar28th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR8Years * 100:F2}%";
        }

        private static string GetCAGR7Years()
        {
            // It's a bull market in year of 2018
            const int YearSpan = 7;
            double btcCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2018Mar24th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR7Years * 100:F2}%";
        }

        private static string GetCAGR6Years()
        {
            const int YearSpan = 6;
            double btcCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2019Mar29th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR6Years * 100:F2}%";
        }

        private static string GetCAGR5Years()
        {
            const int YearSpan = 5;
            double btcCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2020Mar24th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR5Years * 100:F2}%";
        }

        private static string GetCAGR4Years()
        {
            // It's a bull market in year of 2021
            const int YearSpan = 4;
            double btcCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2021Mar30th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR4Years * 100:F2}%";
        }

        private static string GetCAGR3Years()
        {
            // It's a bull market in year of 2022
            const int YearSpan = 3;
            double btcCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2022Mar27th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR3Years * 100:F2}%";
        }

        private static string GetCAGR2Years()
        {
            const int YearSpan = 2;
            double btcCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2023Mar24th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR2Years * 100:F2}%";
        }

        private static string GetCAGR1Year()
        {
            // It's a bull market in year of 2024
            const int YearSpan = 1;
            double btcCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                BitcoinPriceAt2024Mar28th, BtcPriceAt2025Mar26th, YearSpan);
            return $"{btcCAGR1Year * 100:F2}%";
        }

    }
}
