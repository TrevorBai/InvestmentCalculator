using InvestmentCalculators;
using System.ComponentModel;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class CryptoViewModel : INotifyPropertyChanged
    {
        private BTCViewModel? _btcViewModel;

        public BTCViewModel BTCViewModel
        {
            get => _btcViewModel!;
            set
            {
                _btcViewModel = value;
                OnPropertyChanged(nameof(BTCViewModel));   // or [ObservableProperty] with toolkit
            }
        }

        // Dogecoin
        public string? DogecoinCAGRFromBirth { get; private set; }
        public string? DogecoinCAGR10Years { get; private set; }
        public string? DogecoinCAGR9Years { get; private set; }
        public string? DogecoinCAGR8Years { get; private set; }
        public string? DogecoinCAGR7Years { get; private set; }
        public string? DogecoinCAGR6Years { get; private set; }
        public string? DogecoinCAGR5Years { get; private set; }
        public string? DogecoinCAGR4Years { get; private set; }
        public string? DogecoinCAGR3Years { get; private set; }
        public string? DogecoinCAGR2Years { get; private set; }
        public string? DogecoinCAGR1Year { get; private set; }

        public CryptoViewModel()
        {
            BTCViewModel = new BTCViewModel();
            LoadCryptoData();
        }

        private void LoadCryptoData()
        {
            DogecoinCAGRFromBirth = GetDogecoinCAGRFromBirth();
            DogecoinCAGR10Years = GetDogecoinCAGR10Years();
            DogecoinCAGR9Years = GetDogecoinCAGR9Years();
            DogecoinCAGR8Years = GetDogecoinCAGR8Years();
            DogecoinCAGR7Years = GetDogecoinCAGR7Years();
            DogecoinCAGR6Years = GetDogecoinCAGR6Years();
            DogecoinCAGR5Years = GetDogecoinCAGR5Years();
            DogecoinCAGR4Years = GetDogecoinCAGR4Years();
            DogecoinCAGR3Years = GetDogecoinCAGR3Years();
            DogecoinCAGR2Years = GetDogecoinCAGR2Years();
            DogecoinCAGR1Year = GetDogecoinCAGR1Year();

            // Raise change notifications (or use SetProperty if using toolkit)
            OnPropertyChanged(nameof(DogecoinCAGRFromBirth));
            OnPropertyChanged(nameof(DogecoinCAGR10Years));
            OnPropertyChanged(nameof(DogecoinCAGR9Years));
            OnPropertyChanged(nameof(DogecoinCAGR8Years));
            OnPropertyChanged(nameof(DogecoinCAGR7Years));
            OnPropertyChanged(nameof(DogecoinCAGR6Years));
            OnPropertyChanged(nameof(DogecoinCAGR5Years));
            OnPropertyChanged(nameof(DogecoinCAGR4Years));
            OnPropertyChanged(nameof(DogecoinCAGR3Years));
            OnPropertyChanged(nameof(DogecoinCAGR2Years));
            OnPropertyChanged(nameof(DogecoinCAGR1Year));
        }

        private static string GetDogecoinCAGRFromBirth()
        {
            var dogecoinPriceAt2013Dec15th = 0.00056;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 11.29;
            double dogecoinCAGRFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2013Dec15th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGRFromBirth * 100:F2}%";
        }

        private static string GetDogecoinCAGR10Years()
        {
            var dogecoinPriceAt2015Mar25th = 0.0001304;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 10;
            double dogecoinCAGR10Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2015Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR10Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR9Years()
        {
            var dogecoinPriceAt2016Mar25th = 0.0002144;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 9;
            double dogecoinCAGR9Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2016Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR9Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR8Years()
        {
            var dogecoinPriceAt2017Mar25th = 0.0002976;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 8;
            double dogecoinCAGR8Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2017Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR8Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR7Years()
        {
            // It's a bull market in year of 2018
            var dogecoinPriceAt2018Mar26th = 0.003275;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 7;
            double dogecoinCAGR7Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2018Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR7Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR6Years()
        {
            var dogecoinPriceAt2019Mar27th = 0.002087;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 6;
            double dogecoinCAGR6Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2019Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR6Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR5Years()
        {
            var dogecoinPriceAt2020Mar27th = 0.001805;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 5;
            double dogecoinCAGR5Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2020Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR5Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR4Years()
        {
            // It's a bull market in year of 2021
            var dogecoinPriceAt2021Mar23th = 0.05352;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 4;
            double dogecoinCAGR4Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2021Mar23th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR4Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR3Years()
        {
            // It's a bull market in year of 2022
            var dogecoinPriceAt2022Mar24th = 0.1366;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 3;
            double dogecoinCAGR3Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2022Mar24th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR3Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR2Years()
        {
            var dogecoinPriceAt2023Mar26th = 0.07442;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 2;
            double dogecoinCAGR2Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR2Years * 100:F2}%";
        }

        private static string GetDogecoinCAGR1Year()
        {
            // It's a bull market in year of 2024
            var dogecoinPriceAt2023Mar27th = 0.1903;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 1;
            double dogecoinCAGR1Year = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            return $"{dogecoinCAGR1Year * 100:F2}%";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
