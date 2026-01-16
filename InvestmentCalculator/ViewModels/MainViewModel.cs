using InvestmentCalculator.Models;
using InvestmentCalculator.Services;
using InvestmentCalculator.ViewModels.CryptoViewModels;
using OxyPlot;
using System.ComponentModel;

namespace InvestmentCalculator.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, AssetPerformance> _assetPerformanceDict = [];

        private AssetPerformance? GetByTicker(string ticker)
        {
            _assetPerformanceDict.TryGetValue(ticker, out var performance);
            return performance;
        }

        public AssetPerformance? QQQ => GetByTicker("QQQ");
        public AssetPerformance? Costco => GetByTicker("COST");

        private PlotModel? _cryptoPlotModel;
        private CryptoViewModel? _cryptoViewModel;

        public PlotModel CryptoPlotModel
        {
            get => _cryptoPlotModel!;
            set
            {
                _cryptoPlotModel = value;
                OnPropertyChanged(nameof(CryptoPlotModel));   // or [ObservableProperty] with toolkit
            }
        }

        public CryptoViewModel CryptoViewModel
        {
            get => _cryptoViewModel!;
            set
            {
                _cryptoViewModel = value;
                OnPropertyChanged(nameof(CryptoViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public MainViewModel()
        {
            CryptoViewModel = new CryptoViewModel();
            CryptoPlotModel = new PlotModel
            {
                Title = "Bitcoin/Dogecoin Timelines",
                TitleColor = OxyColors.White,
                Background = OxyColors.Black,
                PlotAreaBackground = OxyColors.Black,
                PlotAreaBorderColor = OxyColors.White,
                PlotAreaBorderThickness = new OxyThickness(0), // Clean look
            };
            new CryptoPlotModel(CryptoPlotModel).AddMoreEntitiesToPlot();

            LoadData();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadData()
        {
            var costcoData = GetCostcoData();
            var qqqData = GetQQQData();

            var costcoPerformance = AssetPerformanceCalculator.Calculate("COST", costcoData, 0);
            var qqqPerformance = AssetPerformanceCalculator.Calculate("QQQ", qqqData, 0);

            _assetPerformanceDict.Add(costcoPerformance.Ticker!, costcoPerformance);
            _assetPerformanceDict.Add(qqqPerformance.Ticker!, qqqPerformance);
        }

        private static AssetData GetCostcoData()
        {
            const decimal PriceAt2025Dec19th = 855.62m;
            const decimal PriceAt2020Dec21st = 364.58m;
            const decimal PriceAt2021Dec20th = 550.37m;
            const decimal PriceAt2022Dec19th = 462.65m;
            const decimal PriceAt2023Dec18th = 671.60m;
            const decimal PriceAt2024Dec16th = 954.07m;

            var costcoData = new AssetData
            {
                EndPrice = PriceAt2025Dec19th,
                Price1YearAgoFromEndDate = PriceAt2024Dec16th,
                Price2YearsAgoFromEndDate = PriceAt2023Dec18th,
                Price3YearsAgoFromEndDate = PriceAt2022Dec19th,
                Price4YearsAgoFromEndDate = PriceAt2021Dec20th,
                Price5YearsAgoFromEndDate = PriceAt2020Dec21st
            };
            return costcoData;
        }

        private static AssetData GetQQQData()
        {
            const decimal PriceAt2025Dec19th = 617.05m;
            const decimal PriceAt2020Dec21st = 308.92m;
            const decimal PriceAt2021Dec20th = 380.69m;
            const decimal PriceAt2022Dec19th = 269.75m;
            const decimal PriceAt2023Dec18th = 407.08m;
            const decimal PriceAt2024Dec16th = 538.17m;

            var qqqData = new AssetData
            {
                EndPrice = PriceAt2025Dec19th,
                Price1YearAgoFromEndDate = PriceAt2024Dec16th,
                Price2YearsAgoFromEndDate = PriceAt2023Dec18th,
                Price3YearsAgoFromEndDate = PriceAt2022Dec19th,
                Price4YearsAgoFromEndDate = PriceAt2021Dec20th,
                Price5YearsAgoFromEndDate = PriceAt2020Dec21st
            };
            return qqqData;
        }


    }
}

//public class ReturnRatePeriod : INotifyPropertyChanged
//{
//    //public event PropertyChangedEventHandler? PropertyChanged;
//}
