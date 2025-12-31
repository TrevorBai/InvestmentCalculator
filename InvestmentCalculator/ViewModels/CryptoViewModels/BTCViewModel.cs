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
            var bitcoinPriceAt2009Oct15th = 0.00099;
            var yearSpan = 15.4757;
            double btcCAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2009Oct15th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGRFromBirth * 100:F2}%";
        }

        private static string GetCAGR10Years()
        {
            var bitcoinPriceAt2015Mar28th = 252.74;
            var yearSpan = 10;
            double btcCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2015Mar28th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR10Years * 100:F2}%";
        }

        private static string GetCAGR9Years()
        {
            var bitcoinPriceAt2016Mar23th = 418.42;
            var yearSpan = 9;
            double btcCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2016Mar23th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR9Years * 100:F2}%";
        }

        private static string GetCAGR8Years()
        {
            var bitcoinPriceAt2017Mar28th = 1046.07;
            var yearSpan = 8;
            double btcCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2017Mar28th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR8Years * 100:F2}%";
        }

        private static string GetCAGR7Years()
        {
            // It's a bull market in year of 2018
            var bitcoinPriceAt2018Mar24th = 8612.8;
            var yearSpan = 7;
            double btcCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2018Mar24th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR7Years * 100:F2}%";
        }

        private static string GetCAGR6Years()
        {
            var bitcoinPriceAt2019Mar29th = 4092.13;
            var yearSpan = 6;
            double btcCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2019Mar29th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR6Years * 100:F2}%";
        }

        private static string GetCAGR5Years()
        {
            var bitcoinPriceAt2020Mar24th = 6738.71;
            var yearSpan = 5;
            double btcCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2020Mar24th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR5Years * 100:F2}%";
        }

        private static string GetCAGR4Years()
        {
            // It's a bull market in year of 2021
            var bitcoinPriceAt2021Mar30th = 58930.27;
            var yearSpan = 4;
            double btcCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2021Mar30th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR4Years * 100:F2}%";
        }

        private static string GetCAGR3Years()
        {
            // It's a bull market in year of 2022
            var bitcoinPriceAt2022Mar27th = 46821.85;
            var yearSpan = 3;
            double btcCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2022Mar27th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR3Years * 100:F2}%";
        }

        private static string GetCAGR2Years()
        {
            var bitcoinPriceAt2023Mar24th = 27487.33;
            var yearSpan = 2;
            double btcCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2023Mar24th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR2Years * 100:F2}%";
        }

        private static string GetCAGR1Year()
        {
            // It's a bull market in year of 2024
            var bitcoinPriceAt2024Mar28th = 70744.79;
            var yearSpan = 1;
            double btcCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2024Mar28th, BtcPriceAt2025Mar26th, yearSpan);
            return $"{btcCAGR1Year * 100:F2}%";
        }

    }
}
