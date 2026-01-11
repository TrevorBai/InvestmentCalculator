using InvestmentCalculator.ViewModels.Utilities;

namespace InvestmentCalculator.ViewModels.StockViewModels
{
    internal class QQQViewModel : CAGRViewModel
    {
        // TODO all the data are placeholder data.
        private const double PriceAt2025Dec19th = 0;

        private const double PriceAt2020Dec21st = 0;
        private const double PriceAt2021Dec20th = 0;
        private const double PriceAt2022Dec19th = 0;
        private const double PriceAt2023Dec18th = 0;
        private const double PriceAt2024Dec16th = 0;

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
