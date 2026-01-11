using InvestmentCalculator.ViewModels.CryptoViewModels;
using InvestmentCalculator.ViewModels.StockViewModels;
using OxyPlot;
using System.ComponentModel;

namespace InvestmentCalculator.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
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
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

//public class ReturnRatePeriod : INotifyPropertyChanged
//{
//    //public event PropertyChangedEventHandler? PropertyChanged;
//}
