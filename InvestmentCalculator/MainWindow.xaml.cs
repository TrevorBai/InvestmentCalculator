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
            // Costco
            PopulateCostcoAverageAnnualReturnRate5Years();
            PopulateCostcoAverageAnnualReturnRate4Years();
            PopulateCostcoAverageAnnualReturnRate3Years();
            PopulateCostcoAverageAnnualReturnRate2Years();
            PopulateCostcoAverageAnnualReturnRate1Year();
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
