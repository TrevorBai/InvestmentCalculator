using InvestmentCalculator.Models;
using InvestmentCalculator.Services;
using InvestmentCalculator.ViewModels.CryptoViewModels;
using InvestmentCalculator.ViewModels.StockViewModels;
using OxyPlot;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace InvestmentCalculator.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<AssetPerformance> AssetPerformances { get; } = [];

        private PlotModel? _cryptoPlotModel;
        private CryptoViewModel? _cryptoViewModel;
        private StockViewModel? _stockViewModel;

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

        public StockViewModel StockViewModel
        {
            get => _stockViewModel!;
            set
            {
                _stockViewModel = value;
                OnPropertyChanged(nameof(StockViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public MainViewModel()
        {
            CryptoViewModel = new CryptoViewModel();
            StockViewModel = new StockViewModel();
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

            var performance = AssetPerformanceCalculator.Calculate("Costco", costcoData);
            AssetPerformances.Add(performance);

        } 


    }
}

//public class ReturnRatePeriod : INotifyPropertyChanged
//{
//    //public event PropertyChangedEventHandler? PropertyChanged;
//}
