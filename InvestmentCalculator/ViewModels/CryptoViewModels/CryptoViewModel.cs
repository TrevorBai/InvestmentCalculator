using System.ComponentModel;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class CryptoViewModel : INotifyPropertyChanged
    {
        private DogeViewModel? _dogeViewModel;

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
            DogeViewModel = new DogeViewModel();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
