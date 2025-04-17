using System.Windows;
using System.Globalization;
using System.Windows.Data;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Annotations;

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
        public PlotModel PlotModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded; // Hook up the Loaded event

            DataContext = this;

            // Create the plot model
            PlotModel = new PlotModel
            {
                Title = "Bitcoin/Dogecoin Timelines",
                TitleColor = OxyColors.White,
                Background = OxyColors.Black,
                PlotAreaBackground = OxyColors.Black,
                PlotAreaBorderColor = OxyColors.White,
                PlotAreaBorderThickness = new OxyThickness(0), // Clean look
            };

            // X-Axis: Dates
            var startDate = new DateTime(2009, 10, 15);
            var endDate = new DateTime(2025, 04, 16);
            var dateAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = DateTimeAxis.ToDouble(startDate),
                Maximum = DateTimeAxis.ToDouble(endDate),
                StringFormat = "yyyy-MMM-dd",
                TextColor = OxyColors.White,
                Title = "Date",
                TitleColor = OxyColors.White,
                TicklineColor = OxyColors.White,
                //MajorGridlineStyle = LineStyle.Solid,
                //MajorGridlineColor = OxyColor.FromAColor(100, OxyColors.White),
                //MinorGridlineStyle = LineStyle.None,
                IsAxisVisible = true,
                MajorStep = 365, // One year (in days)
                MinorStep = 30,  // One month
                IntervalLength = 8000 // Adjust label spacing for readability
            };
            PlotModel.Axes.Add(dateAxis);

            // Y-Axis: Hidden (dummy axis for bars)
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                IsAxisVisible = false, // No Y-axis
                Minimum = 0,
                Maximum = 1.5 // Enough for bars and annotations
            };
            PlotModel.Axes.Add(yAxis);

            // Vertical Bars for Critical Dates
            var barSeries = new RectangleBarSeries
            {
                FillColor = OxyColors.Blue,
                StrokeColor = OxyColors.White,
                StrokeThickness = 1
            };

            var firstBitcoinHalvingDate = new DateTime(2012, 11, 18);
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(firstBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(firstBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1
            });

            var secondBitcoinHalvingDate = new DateTime(2016, 7, 9);
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(secondBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(secondBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1
            });

            var thirdBitcoinHalvingDate = new DateTime(2020, 5, 11);
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(thirdBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(thirdBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1
            });

            var forthBitcoinHalvingDate = new DateTime(2024, 4, 19);
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(forthBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(forthBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1
            });

            PlotModel.Series.Add(barSeries);

            // Shaded Range: April 1 to April 30, 2025
            var rangeAnnotation = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2025, 4, 1)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2025, 4, 30)),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            PlotModel.Annotations.Add(rangeAnnotation);

            var firstBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 1st halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(firstBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            PlotModel.Annotations.Add(firstBitcoinHalvingDateAnnotation);

            var secondBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 2nd halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(secondBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            PlotModel.Annotations.Add(secondBitcoinHalvingDateAnnotation);

            var thirdBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 3rd halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(thirdBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            PlotModel.Annotations.Add(thirdBitcoinHalvingDateAnnotation);

            var forthBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 4th halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(forthBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            PlotModel.Annotations.Add(forthBitcoinHalvingDateAnnotation);

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

        private void PopulateDogecoinAverageAnnualReturnRate6Years()
        {
            var dogecoinPriceAt2019Mar27th = 0.002087;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 6;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2019Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate6Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate5Years()
        {
            var dogecoinPriceAt2020Mar27th = 0.001805;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 5;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2020Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate5Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate4Years()
        {
            // It's a bull market in year of 2021
            var dogecoinPriceAt2021Mar23th = 0.05352;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 4;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2021Mar23th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate4Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate3Years()
        {
            // It's a bull market in year of 2022
            var dogecoinPriceAt2022Mar24th = 0.1366;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 3;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2022Mar24th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate3Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate2Years()
        {
            var dogecoinPriceAt2023Mar26th = 0.07442;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 2;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar26th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate2Years.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateDogecoinAverageAnnualReturnRate1Year()
        {
            // It's a bull market in year of 2024
            var dogecoinPriceAt2023Mar27th = 0.1903;
            var dogecoinPriceAt2025Mar25th = 0.1901;
            var yearSpan = 1;
            double dogecoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                dogecoinPriceAt2023Mar27th, dogecoinPriceAt2025Mar25th, yearSpan);
            CalculatedDogecoinAverageAnnualReturnRate1Year.Content = $"{dogecoinAverageAnnualReturnRateFromBirth * 100:F2}%";
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
            // It's a bull market in year of 2018
            var bitcoinPriceAt2018Mar24th = 8612.8;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 7;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2018Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate7Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate6Years()
        {
            var bitcoinPriceAt2019Mar29th = 4092.13;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 6;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2019Mar29th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate6Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate5Years()
        {
            var bitcoinPriceAt2020Mar24th = 6738.71;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 5;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2020Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate5Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate4Years()
        {
            // It's a bull market in year of 2021
            var bitcoinPriceAt2021Mar30th = 58930.27;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 4;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2021Mar30th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate4Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate3Years()
        {
            // It's a bull market in year of 2022
            var bitcoinPriceAt2022Mar27th = 46821.85;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 3;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2022Mar27th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate3Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate2Years()
        {
            var bitcoinPriceAt2023Mar24th = 27487.33;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 2;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2023Mar24th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate2Years.Content =
                $"{bitcoinAverageAnnualReturnRateFromBirth * 100:F2}%";
        }

        private void PopulateBitcoinAverageAnnualReturnRate1Year()
        {
            // It's a bull market in year of 2024
            var bitcoinPriceAt2024Mar28th = 70744.79;
            var bitcoinPriceAt2025Mar26th = 86888.01;
            var yearSpan = 1;
            double bitcoinAverageAnnualReturnRateFromBirth = Calculators.CalculateAverageAnualReturnRate(
                bitcoinPriceAt2024Mar28th, bitcoinPriceAt2025Mar26th, yearSpan);
            CalculatedBitcoinAverageAnnualReturnRate1Year.Content =
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
