using InvestmentCalculator.ViewModels.Utilities;

namespace InvestmentCalculator.ViewModels.StockViewModels
{
    internal class QQQViewModel : CAGRViewModel
    {
        // TODO all the data are placeholder data, which are costco's.
        private const double PriceAt2025Dec19th = 855.62;

        private const double PriceAt2020Dec21st = 364.58;
        private const double PriceAt2021Dec20th = 550.37;
        private const double PriceAt2022Dec19th = 462.65;
        private const double PriceAt2023Dec18th = 671.60;
        private const double PriceAt2024Dec16th = 954.07;

        internal QQQViewModel() : base(
            PriceAt2025Dec19th,
            0,
            0,
            0,
            0,
            0,
            PriceAt2020Dec21st,
            PriceAt2021Dec20th,
            PriceAt2022Dec19th,
            PriceAt2023Dec18th,
            PriceAt2024Dec16th,
            0,
            0,
            false,
            true)
        { }
    }
}
