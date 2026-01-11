using OxyPlot;
using OxyPlot.Annotations;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Series;

namespace InvestmentCalculator.ViewModels.CryptoViewModels
{
    internal class CryptoPlotModel(PlotModel cryptoPlotModel)
    {
        private readonly PlotModel _cryptoPlotModel = cryptoPlotModel;

        internal void AddMoreEntitiesToPlot()
        {
            AddLegendToCryptoPlotModel();
            AddDateXAxisToCryptoPlotModel();
            AddDummyYAxisToCryptoPlotModel();
            AddVerticalBarsAndAnnotationsToCryptoPlotModel();
            AddRangeAnnotationsToCryptoPlotModel();
        }

        private void AddLegendToCryptoPlotModel()
        {
            // Add a Legend to the PlotModel
            var legend = new Legend
            {
                LegendPosition = LegendPosition.TopRight, // Set position
                LegendOrientation = LegendOrientation.Horizontal,
                LegendFont = "Arial",
                LegendFontSize = 12,
                IsLegendVisible = true,
                LegendTextColor = OxyColors.White // Set legend text to white
            };

            _cryptoPlotModel.Legends.Add(legend);

            // Create a LineSeries
            var btcSeries = new LineSeries
            {
                Title = "Bitcoin",
                Color = OxyColors.Green,
                MarkerType = MarkerType.Circle
            };
            btcSeries.Points.Add(new DataPoint(0, 10));
            btcSeries.Points.Add(new DataPoint(1, 10));
            btcSeries.Points.Add(new DataPoint(2, 10));

            // Add series to PlotModel
            _cryptoPlotModel.Series.Add(btcSeries);

            var dogecoinSeries = new LineSeries
            {
                Title = "Dogecoin",
                Color = OxyColors.Blue,
                MarkerType = MarkerType.Square
            };
            dogecoinSeries.Points.Add(new DataPoint(0, 5));
            dogecoinSeries.Points.Add(new DataPoint(1, 5));
            dogecoinSeries.Points.Add(new DataPoint(2, 5));

            // Add series to PlotModel
            _cryptoPlotModel.Series.Add(dogecoinSeries);
        }

        private void AddDateXAxisToCryptoPlotModel()
        {
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
            _cryptoPlotModel.Axes.Add(dateAxis);
        }

        private void AddDummyYAxisToCryptoPlotModel()
        {
            // Y-Axis: Hidden (dummy axis for bars)
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                IsAxisVisible = false, // No Y-axis
                Minimum = 0,
                Maximum = 1.5 // Enough for bars and annotations
            };
            _cryptoPlotModel.Axes.Add(yAxis);
        }

        private void AddVerticalBarsAndAnnotationsToCryptoPlotModel()
        {
            // Bitcoin
            AddBitcoinBirthDateVerticalBarAndAnnotation();
            AddFirstBitcoinHalvingDateVerticalBarAndAnnotation();
            AddSecondBitcoinHalvingDateVerticalBarAndAnnotation();
            AddThirdBitcoinHalvingDateVerticalBarAndAnnotation();
            AddForthBitcoinHalvingDateVerticalBarAndAnnotation();
            AddFifthBitcoinHalvingDateVerticalBarAndAnnotation();

            // Dogecoin
            AddDogecoinBirthDateVerticalBarAndAnnotation();

            AddTodaysDateVerticalBarAndAnnotation();
        }

        private void AddBitcoinBirthDateVerticalBarAndAnnotation()
        {
            var firstBitcoinHalvingDate = new DateTime(2009, 10, 15);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Yellow };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(firstBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(firstBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 0.7,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var firstBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc birth date",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(firstBitcoinHalvingDate), 0.75),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(firstBitcoinHalvingDateAnnotation);
        }

        private void AddFirstBitcoinHalvingDateVerticalBarAndAnnotation()
        {
            var bitcoinBirthDate = new DateTime(2012, 11, 18);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Green };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(bitcoinBirthDate),
                X1 = DateTimeAxis.ToDouble(bitcoinBirthDate),
                Y0 = 0,
                Y1 = 1,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var firstBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 1st halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(bitcoinBirthDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(firstBitcoinHalvingDateAnnotation);
        }

        private void AddSecondBitcoinHalvingDateVerticalBarAndAnnotation()
        {
            var secondBitcoinHalvingDate = new DateTime(2016, 7, 9);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Green };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(secondBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(secondBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var secondBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 2nd halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(secondBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(secondBitcoinHalvingDateAnnotation);
        }

        private void AddThirdBitcoinHalvingDateVerticalBarAndAnnotation()
        {
            var thirdBitcoinHalvingDate = new DateTime(2020, 5, 11);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Green };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(thirdBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(thirdBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var thirdBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 3rd halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(thirdBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(thirdBitcoinHalvingDateAnnotation);
        }

        private void AddForthBitcoinHalvingDateVerticalBarAndAnnotation()
        {
            var forthBitcoinHalvingDate = new DateTime(2024, 4, 19);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Green };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(forthBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(forthBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var forthBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 4th halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(forthBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(forthBitcoinHalvingDateAnnotation);
        }

        private void AddFifthBitcoinHalvingDateVerticalBarAndAnnotation()
        {
            var fifthBitcoinHalvingDate = new DateTime(2028, 4, 17);
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Red };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(fifthBitcoinHalvingDate),
                X1 = DateTimeAxis.ToDouble(fifthBitcoinHalvingDate),
                Y0 = 0,
                Y1 = 1,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var forthBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Btc 5th halving",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(fifthBitcoinHalvingDate), 1.05),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(forthBitcoinHalvingDateAnnotation);
        }

        private void AddDogecoinBirthDateVerticalBarAndAnnotation()
        {
            var dogecoinBirthDate = new DateTime(2013, 12, 15); //2013Dec15th
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.BlueViolet };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(dogecoinBirthDate),
                X1 = DateTimeAxis.ToDouble(dogecoinBirthDate),
                Y0 = 0,
                Y1 = 0.7,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var dogecoinBirthDateAnnotation = new TextAnnotation
            {
                Text = "Dogecoin birth date",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(dogecoinBirthDate), 0.75),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(dogecoinBirthDateAnnotation);
        }

        private void AddTodaysDateVerticalBarAndAnnotation()
        {
            var barSeries = new RectangleBarSeries { StrokeColor = OxyColors.Blue };
            barSeries.Items.Add(new RectangleBarItem
            {
                X0 = DateTimeAxis.ToDouble(DateTime.Today),
                X1 = DateTimeAxis.ToDouble(DateTime.Today),
                Y0 = 0,
                Y1 = 0.7,
            });
            _cryptoPlotModel.Series.Add(barSeries);

            var forthBitcoinHalvingDateAnnotation = new TextAnnotation
            {
                Text = "Current date",
                TextPosition = new DataPoint(DateTimeAxis.ToDouble(DateTime.Today), 0.75),
                TextColor = OxyColors.White,
                Stroke = OxyColors.Transparent,
                FontSize = 12,
                TextHorizontalAlignment = OxyPlot.HorizontalAlignment.Center
            };
            _cryptoPlotModel.Annotations.Add(forthBitcoinHalvingDateAnnotation);
        }

        private void AddRangeAnnotationsToCryptoPlotModel()
        {
            AddBitcoinBullRunRangeAnnotationsToCryptoPlotModel();
            AddDogecoinBullRunRangeAnnotationsToCryptoPlotModel();
        }

        private void AddBitcoinBullRunRangeAnnotationsToCryptoPlotModel()
        {
            var btcBullRunRangeAnnotation1 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2011, 4, 17)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2011, 10, 19)),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(btcBullRunRangeAnnotation1);

            var btcBullRunRangeAnnotation2 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2013, 2, 24)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2015, 1, 19)),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(btcBullRunRangeAnnotation2);

            var btcBullRunRangeAnnotation3 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2017, 3, 23)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2018, 12, 8)),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(btcBullRunRangeAnnotation3);

            var btcBullRunRangeAnnotation4 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2019, 3, 26)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2022, 6, 18)),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(btcBullRunRangeAnnotation4);

            var btcBullRunRangeAnnotation5 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2023, 1, 5)),
                MaximumX = DateTimeAxis.ToDouble(DateTime.Now),
                MinimumY = 0,
                MaximumY = 1.5,
                Fill = OxyColor.FromAColor(100, OxyColors.Green), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(btcBullRunRangeAnnotation5);
        }

        private void AddDogecoinBullRunRangeAnnotationsToCryptoPlotModel()
        {
            // Dogecoin
            var dogeBullRunRangeAnnotation1 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2017, 5, 1)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2017, 9, 20)),
                MinimumY = 0,
                MaximumY = 1.4,
                Fill = OxyColor.FromAColor(100, OxyColors.Blue), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(dogeBullRunRangeAnnotation1);

            var dogeBullRunRangeAnnotation2 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2017, 11, 11)),
                MaximumX = DateTimeAxis.ToDouble(new DateTime(2018, 2, 5)),
                MinimumY = 0,
                MaximumY = 1.4,
                Fill = OxyColor.FromAColor(100, OxyColors.Blue), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(dogeBullRunRangeAnnotation2);

            var dogeBullRunRangeAnnotation3 = new RectangleAnnotation
            {
                MinimumX = DateTimeAxis.ToDouble(new DateTime(2020, 12, 31)),
                MaximumX = DateTimeAxis.ToDouble(DateTime.Today),
                MinimumY = 0,
                MaximumY = 1.4,
                Fill = OxyColor.FromAColor(100, OxyColors.Blue), // Semi-transparent green
                Stroke = OxyColors.White,
                StrokeThickness = 1
            };
            _cryptoPlotModel.Annotations.Add(dogeBullRunRangeAnnotation3);
        }

    }
}
