﻿using System.Windows;
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
            // Perform complex calculation here
            double dogecoinAverageAnualReturnRateFromBorn = CalculateDogecoinAverageAnualReturnRateFromBorn();
            CalculatedDogecoinAverageAnualReturnRate.Content = $"{dogecoinAverageAnualReturnRateFromBorn * 100:F2}%";
        }

        private static double CalculateDogecoinAverageAnualReturnRateFromBorn()
        {
            var dogecoinPriceAt2013Dec15th = 0.00056;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 11.29;

            var totalGrowthFactor = dogecoinPriceAt2025Mar25th / dogecoinPriceAt2013Dec15th;

            // Use Math.Pow instead of ^ for exponentiation
            var compoundAnnualGrowthRate = Math.Pow(totalGrowthFactor, 1 / yearSpan) - 1;
            return compoundAnnualGrowthRate;
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
