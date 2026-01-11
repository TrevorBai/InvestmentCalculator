using InvestmentCalculator.ViewModels.Utilities;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class BTCViewModel : CAGRViewModel
    {
        private const double PriceAt2025Mar26th = 86888.01;

        private const double PriceAt2009Oct15th = 0.00099;
        private const double YearSpanFromBirthToEndingDate = 15.4757;

        private const double PriceAt2015Mar28th = 252.74;
        private const double PriceAt2016Mar23th = 418.42;
        private const double PriceAt2017Mar28th = 1046.07;
        private const double PriceAt2018Mar24th = 8612.8;
        private const double PriceAt2019Mar29th = 4092.13;
        private const double PriceAt2020Mar24th = 6738.71;
        private const double PriceAt2021Mar30th = 58930.27;
        private const double PriceAt2022Mar27th = 46821.85;
        private const double PriceAt2023Mar24th = 27487.33;
        private const double PriceAt2024Mar28th = 70744.79;

        public BTCViewModel() : base(
            PriceAt2025Mar26th,
            PriceAt2015Mar28th,
            PriceAt2016Mar23th,
            PriceAt2017Mar28th,
            PriceAt2018Mar24th,
            PriceAt2019Mar29th,
            PriceAt2020Mar24th,
            PriceAt2021Mar30th,
            PriceAt2022Mar27th,
            PriceAt2023Mar24th,
            PriceAt2024Mar28th,
            PriceAt2009Oct15th,
            YearSpanFromBirthToEndingDate,
            true,
            false) { }



    }
}
