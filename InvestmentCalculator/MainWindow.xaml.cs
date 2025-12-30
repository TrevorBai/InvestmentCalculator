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
            // Bitcoin
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

        // Bitcoin section
        // ------------------------

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
