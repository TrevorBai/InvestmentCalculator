using System.ComponentModel;

namespace InvestmentCalculator.ViewModels.StockViewModels
{
    internal class StockViewModel : INotifyPropertyChanged
    {
        private QQQViewModel? _qqqViewModel;

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
            QQQViewModel = new QQQViewModel();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
