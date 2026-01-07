using InvestmentCalculator.ViewModels.Utilities;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class DogeViewModel : CAGRCalculator
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
        private const double DogecoinPriceAt2024Mar27th = 0.1903;

        public DogeViewModel() : base(
            DogecoinPriceAt2025Mar25th,
            DogecoinPriceAt2015Mar25th,
            DogecoinPriceAt2016Mar25th,
            DogecoinPriceAt2017Mar25th,
            DogecoinPriceAt2018Mar26th,
            DogecoinPriceAt2019Mar27th,
            DogecoinPriceAt2020Mar27th,
            DogecoinPriceAt2021Mar23th,
            DogecoinPriceAt2022Mar24th,
            DogecoinPriceAt2023Mar26th,
            DogecoinPriceAt2024Mar27th,
            DogecoinPriceAt2013Dec15th,
            YearSpanFromBirthToEndingDate)
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

    }
}
