using System.ComponentModel;

namespace InvestmentCalculator.ViewModels.StockViewModels
{
    internal class StockViewModel : INotifyPropertyChanged
    {
        private CostcoViewModel? _costcoViewModel;
        private QQQViewModel? _qqqViewModel;

        public CostcoViewModel CostcoViewModel
        {
            get => _costcoViewModel!;
            set
            {
                _costcoViewModel = value;
                OnPropertyChanged(nameof(CostcoViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public QQQViewModel QQQViewModel
        {
            get => _qqqViewModel!;
            set
            {
                _qqqViewModel = value;
                OnPropertyChanged(nameof(QQQViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public StockViewModel()
        {
            CostcoViewModel = new CostcoViewModel();
            QQQViewModel = new QQQViewModel();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
