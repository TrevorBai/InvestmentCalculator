using InvestmentCalculator.ViewModels.Utilities;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class DogeViewModel : CAGRViewModel
    {
        // Data points
        private const double PriceAt2025Mar25th = 0.1901;

        private const double PriceAt2013Dec15th = 0.00056;
        private const double YearSpanFromBirthToEndingDate = 11.29;

        private const double PriceAt2015Mar25th = 0.0001304;
        private const double PriceAt2016Mar25th = 0.0002144;
        private const double PriceAt2017Mar25th = 0.0002976;
        private const double PriceAt2018Mar26th = 0.003275;
        private const double PriceAt2019Mar27th = 0.002087;
        private const double PriceAt2020Mar27th = 0.001805;
        private const double PriceAt2021Mar23th = 0.05352;
        private const double PriceAt2022Mar24th = 0.1366;
        private const double PriceAt2023Mar26th = 0.07442;
        private const double PriceAt2024Mar27th = 0.1903;

        internal DogeViewModel() : base(
            PriceAt2025Mar25th,
            PriceAt2015Mar25th,
            PriceAt2016Mar25th,
            PriceAt2017Mar25th,
            PriceAt2018Mar26th,
            PriceAt2019Mar27th,
            PriceAt2020Mar27th,
            PriceAt2021Mar23th,
            PriceAt2022Mar24th,
            PriceAt2023Mar26th,
            PriceAt2024Mar27th,
            PriceAt2013Dec15th,
            YearSpanFromBirthToEndingDate,
            true,
            false) { }


    }
}
