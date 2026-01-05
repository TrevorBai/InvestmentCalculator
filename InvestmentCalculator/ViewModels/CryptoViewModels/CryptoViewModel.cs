using System.ComponentModel;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class CryptoViewModel : INotifyPropertyChanged
    {
        private BTCViewModel? _btcViewModel;
        private DogeViewModel? _dogeViewModel;

        public BTCViewModel BTCViewModel
        {
            get => _btcViewModel!;
            set
            {
                _btcViewModel = value;
                OnPropertyChanged(nameof(BTCViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public DogeViewModel DogeViewModel
        {
            get => _dogeViewModel!;
            set
            {
                _dogeViewModel = value;
                OnPropertyChanged(nameof(DogeViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        public CryptoViewModel()
        {
            BTCViewModel = new BTCViewModel();
            DogeViewModel = new DogeViewModel();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
