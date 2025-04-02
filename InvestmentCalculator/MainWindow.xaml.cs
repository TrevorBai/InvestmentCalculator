using System.Windows;
using System.Globalization;
using System.Windows.Data;

namespace InvestmentCalculators
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded; // Hook up the Loaded event
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Dogecoin
            PopulateDogecoinAverageAnnualReturnRateFromBirth();
            PopulateDogecoinAverageAnnualReturnRate10Years();
            PopulateDogecoinAverageAnnualReturnRate9Years();
            PopulateDogecoinAverageAnnualReturnRate8Years();
            PopulateDogecoinAverageAnnualReturnRate7Years();

            // Bitcoin
            PopulateBitcoinAverageAnnualReturnRateFromBirth();
            PopulateBitcoinAverageAnnualReturnRate10Years();
            PopulateBitcoinAverageAnnualReturnRate9Years();
            PopulateBitcoinAverageAnnualReturnRate8Years();
            PopulateBitcoinAverageAnnualReturnRate7Years();
        }

        private void PopulateDogecoinAverageAnnualReturnRateFromBirth()
        {
            var dogecoinPriceAt2013Dec15th = 0.00056;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 11.29;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2013Dec15th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRateFromBirth.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate10Years()
        {
            var dogecoinPriceAt2015Mar25th = 0.0001304;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 10;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2015Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate10Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate9Years()
        {
            var dogecoinPriceAt2016Mar25th = 0.0002144;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 9;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2016Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate9Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate8Years()
        {
            var dogecoinPriceAt2017Mar25th = 0.0002976;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 8;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2017Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate8Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate7Years()
        {
            // It's a bull market in year of 2018
            var dogecoinPriceAt2018Mar26th = 0.003275;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 7;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2018Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate7Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        // Bitcoin section
        // ------------------------

        private void PopulateBitcoinAverageAnnualReturnRateFromBirth()
        {
            var bitcoinPriceAt2009Oct15th = 0.00099;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 15.4757;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2009Oct15th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRateFromBirth.Content = $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate10Years()
        {
            var bitcoinPriceAt2015Mar28th = 252.74;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 10;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2015Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate10Years.Content = $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate9Years()
        {
            var bitcoinPriceAt2016Mar23th = 418.42;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 9;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2016Mar23th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate9Years.Content = 
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate8Years()
        {
            var bitcoinPriceAt2017Mar28th = 1046.07;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 8;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2017Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate8Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate7Years()
        {
            var bitcoinPriceAt2018Mar24th = 8612.8;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 7;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2018Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate7Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }




        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Parse inputs
                double principal = double.Parse(PrincipalTextBox.Text);
                double rate = double.Parse(RateTextBox.Text) / 100; // Convert % to decimal
                double time = double.Parse(TimeTextBox.Text);
                double futureValue;

                if (CompoundCheckBox.IsChecked == true)
                {
                    int frequency = int.Parse(FrequencyTextBox.Text);
                    // Compound interest: A = P(1 + r/n)^(nt)
                    futureValue = principal * Math.Pow(1 + rate / frequency, frequency * time);
                }
                else
                {
                    // Simple interest: A = P(1 + rt)
                    futureValue = principal * (1 + rate * time);
                }

                ResultLabel.Content = $"Future Value: ${futureValue:F2}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }


}
