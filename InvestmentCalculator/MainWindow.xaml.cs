using System.Globalization;
using System.Windows;
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
            PopulateDogecoinAverageAnnualReturnRate6Years();
            PopulateDogecoinAverageAnnualReturnRate5Years();
            PopulateDogecoinAverageAnnualReturnRate4Years();
            PopulateDogecoinAverageAnnualReturnRate3Years();
            PopulateDogecoinAverageAnnualReturnRate2Years();
            PopulateDogecoinAverageAnnualReturnRate1Year();

            // Bitcoin
            PopulateBitcoinAverageAnnualReturnRateFromBirth();
            PopulateBitcoinAverageAnnualReturnRate10Years();
            PopulateBitcoinAverageAnnualReturnRate9Years();
            PopulateBitcoinAverageAnnualReturnRate8Years();
            PopulateBitcoinAverageAnnualReturnRate7Years();
            PopulateBitcoinAverageAnnualReturnRate6Years();
            PopulateBitcoinAverageAnnualReturnRate5Years();
            PopulateBitcoinAverageAnnualReturnRate4Years();
            PopulateBitcoinAverageAnnualReturnRate3Years();
            PopulateBitcoinAverageAnnualReturnRate2Years();
            PopulateBitcoinAverageAnnualReturnRate1Year();

            // Costco
            PopulateCostcoAverageAnnualReturnRate5Years();
            PopulateCostcoAverageAnnualReturnRate4Years();
            PopulateCostcoAverageAnnualReturnRate3Years();
            PopulateCostcoAverageAnnualReturnRate2Years();
            PopulateCostcoAverageAnnualReturnRate1Year();
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
            double dogecoinAverageAnnualReturnRate10Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2015Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate10Years.Content = $"{dogecoinAverageAnnualReturnRate10Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate9Years()
        {
            var dogecoinPriceAt2016Mar25th = 0.0002144;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 9;
            double dogecoinAverageAnnualReturnRate9Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2016Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate9Years.Content = $"{dogecoinAverageAnnualReturnRate9Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate8Years()
        {
            var dogecoinPriceAt2017Mar25th = 0.0002976;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 8;
            double dogecoinAverageAnnualReturnRate8Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2017Mar25th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate8Years.Content = $"{dogecoinAverageAnnualReturnRate8Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate7Years()
        {
            // It's a bull market in year of 2018
            var dogecoinPriceAt2018Mar26th = 0.003275;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 7;
            double dogecoinAverageAnnualReturnRate7Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2018Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate7Years.Content = $"{dogecoinAverageAnnualReturnRate7Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate6Years()
        {
            var dogecoinPriceAt2019Mar27th = 0.002087;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 6;
            double dogecoinAverageAnnualReturnRate6Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2019Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate6Years.Content = $"{dogecoinAverageAnnualReturnRate6Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate5Years()
        {
            var dogecoinPriceAt2020Mar27th = 0.001805;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 5;
            double dogecoinAverageAnnualReturnRate5Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2020Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate5Years.Content = $"{dogecoinAverageAnnualReturnRate5Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate4Years()
        {
            // It's a bull market in year of 2021
            var dogecoinPriceAt2021Mar23th = 0.05352;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 4;
            double dogecoinAverageAnnualReturnRate4Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2021Mar23th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate4Years.Content = $"{dogecoinAverageAnnualReturnRate4Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate3Years()
        {
            // It's a bull market in year of 2022
            var dogecoinPriceAt2022Mar24th = 0.1366;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 3;
            double dogecoinAverageAnnualReturnRate3Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2022Mar24th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate3Years.Content = $"{dogecoinAverageAnnualReturnRate3Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate2Years()
        {
            var dogecoinPriceAt2023Mar26th = 0.07442;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 2;
            double dogecoinAverageAnnualReturnRate2Years = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate2Years.Content = $"{dogecoinAverageAnnualReturnRate2Years * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate1Year()
        {
            // It's a bull market in year of 2024
            var dogecoinPriceAt2023Mar27th = 0.1903;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 1;
            double dogecoinAverageAnnualReturnRate1Year = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate1Year.Content = $"{dogecoinAverageAnnualReturnRate1Year * 100:F2}%";
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
            double bitcoinAverageAnnualReturnRate10Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2015Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate10Years.Content = $"{bitcoinAverageAnnualReturnRate10Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate9Years()
        {
            var bitcoinPriceAt2016Mar23th = 418.42;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 9;
            double bitcoinAverageAnnualReturnRate9Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2016Mar23th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate9Years.Content = 
                $"{bitcoinAverageAnnualReturnRate9Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate8Years()
        {
            var bitcoinPriceAt2017Mar28th = 1046.07;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 8;
            double bitcoinAverageAnnualReturnRate8Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2017Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate8Years.Content =
                $"{bitcoinAverageAnnualReturnRate8Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate7Years()
        {
            // It's a bull market in year of 2018
            var bitcoinPriceAt2018Mar24th = 8612.8;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 7;
            double bitcoinAverageAnnualReturnRate7Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2018Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate7Years.Content =
                $"{bitcoinAverageAnnualReturnRate7Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate6Years()
        {
            var bitcoinPriceAt2019Mar29th = 4092.13;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 6;
            double bitcoinAverageAnnualReturnRate6Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2019Mar29th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate6Years.Content =
                $"{bitcoinAverageAnnualReturnRate6Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate5Years()
        {
            var bitcoinPriceAt2020Mar24th = 6738.71;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 5;
            double bitcoinAverageAnnualReturnRate5Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2020Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate5Years.Content =
                $"{bitcoinAverageAnnualReturnRate5Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate4Years()
        {
            // It's a bull market in year of 2021
            var bitcoinPriceAt2021Mar30th = 58930.27;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 4;
            double bitcoinAverageAnnualReturnRate4Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2021Mar30th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate4Years.Content =
                $"{bitcoinAverageAnnualReturnRate4Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate3Years()
        {
            // It's a bull market in year of 2022
            var bitcoinPriceAt2022Mar27th = 46821.85;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 3;
            double bitcoinAverageAnnualReturnRate3Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2022Mar27th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate3Years.Content =
                $"{bitcoinAverageAnnualReturnRate3Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate2Years()
        {
            var bitcoinPriceAt2023Mar24th = 27487.33;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 2;
            double bitcoinAverageAnnualReturnRate2Years = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2023Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate2Years.Content =
                $"{bitcoinAverageAnnualReturnRate2Years * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate1Year()
        {
            // It's a bull market in year of 2024
            var bitcoinPriceAt2024Mar28th = 70744.79;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 1;
            double bitcoinAverageAnnualReturnRate1Year = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2024Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate1Year.Content =
                $"{bitcoinAverageAnnualReturnRate1Year * 100:F2}%";
        }

        private void PopulateCostcoAverageAnnualReturnRate5Years()
        {
            var costcoPriceAt2020Dec21st = 364.58;
            var costcoPriceAt2025Dec19th = 855.62;
            var yearSpan = 5;
            double costcoAverageAnnualReturnRate5Years = Calculators.CalculateAverageAnualReturnRate(
                costcoPriceAt2020Dec21st, costcoPriceAt2025Dec19th, yearSpan);
            CalculatedCostcoAverageAnnualReturnRate5Years.Content = $"{costcoAverageAnnualReturnRate5Years * 100:F2}%";
        }

        private void PopulateCostcoAverageAnnualReturnRate4Years()
        {
            var costcoPriceAt2021Dec20th = 550.37;
            var costcoPriceAt2025Dec19th = 855.62;
            var yearSpan = 4;
            double costcoAverageAnnualReturnRate4Years = Calculators.CalculateAverageAnualReturnRate(
                costcoPriceAt2021Dec20th, costcoPriceAt2025Dec19th, yearSpan);
            CalculatedCostcoAverageAnnualReturnRate4Years.Content = $"{costcoAverageAnnualReturnRate4Years * 100:F2}%";
        }

        private void PopulateCostcoAverageAnnualReturnRate3Years()
        {
            var costcoPriceAt2022Dec19th = 462.65;
            var costcoPriceAt2025Dec19th = 855.62;
            var yearSpan = 3;
            double costcoAverageAnnualReturnRate3Years = Calculators.CalculateAverageAnualReturnRate(
                costcoPriceAt2022Dec19th, costcoPriceAt2025Dec19th, yearSpan);
            CalculatedCostcoAverageAnnualReturnRate3Years.Content = $"{costcoAverageAnnualReturnRate3Years * 100:F2}%";
        }

        private void PopulateCostcoAverageAnnualReturnRate2Years()
        {
            var costcoPriceAt2023Dec18th = 671.60;
            var costcoPriceAt2025Dec19th = 855.62;
            var yearSpan = 2;
            double costcoAverageAnnualReturnRate2Years = Calculators.CalculateAverageAnualReturnRate(
                costcoPriceAt2023Dec18th, costcoPriceAt2025Dec19th, yearSpan);
            CalculatedCostcoAverageAnnualReturnRate2Years.Content = $"{costcoAverageAnnualReturnRate2Years * 100:F2}%";
        }

        private void PopulateCostcoAverageAnnualReturnRate1Year()
        {
            var costcoPriceAt2024Dec16th = 954.07;
            var costcoPriceAt2025Dec19th = 855.62;
            var yearSpan = 1;
            double costcoAverageAnnualReturnRate1Year = Calculators.CalculateAverageAnualReturnRate(
                costcoPriceAt2024Dec16th, costcoPriceAt2025Dec19th, yearSpan);
            CalculatedCostcoAverageAnnualReturnRate1Year.Content = $"{costcoAverageAnnualReturnRate1Year * 100:F2}%";
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
