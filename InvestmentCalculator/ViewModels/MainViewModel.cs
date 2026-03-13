using InvestmentCalculators.Data;
using InvestmentCalculators.Models;
using InvestmentCalculators.Services;
using Microsoft.EntityFrameworkCore;
using OxyPlot;
using System.ComponentModel;
using System.Diagnostics;

namespace InvestmentCalculators.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly Dictionary<string, AssetPerformance> _assetPerformanceDict = [];

        private AssetPerformance? GetByTicker(string ticker)
        {
            _assetPerformanceDict.TryGetValue(ticker, out var performance);
            return performance;
        }

        // Cryptos
        public AssetPerformance? BTC => GetByTicker("BTC");
        public AssetPerformance? DOGE => GetByTicker("DOGE");

        // Stocks
        public AssetPerformance? QQQ => GetByTicker("QQQ");
        public AssetPerformance? Costco => GetByTicker("COST");
        public AssetPerformance? Tesla => GetByTicker("TSLA");
        public AssetPerformance? BrkB => GetByTicker("BRK-B");





        private PlotModel? _cryptoPlotModel;

        public PlotModel CryptoPlotModel
        {
            get => _cryptoPlotModel!;
            set
            {
                _cryptoPlotModel = value;
                OnPropertyChanged(nameof(CryptoPlotModel));   // or [ObservableProperty] with toolkit
            }
        }

        public MainViewModel()
        {
            CryptoPlotModel = new PlotModel
            {
                Title = "Bitcoin/Dogecoin Timelines",
                TitleColor = OxyColors.White,
                Background = OxyColors.Black,
                PlotAreaBackground = OxyColors.Black,
                PlotAreaBorderColor = OxyColors.White,
                PlotAreaBorderThickness = new OxyThickness(0), // Clean look
            };
            new CryptoPlotModel(CryptoPlotModel).AddMoreEntitiesToPlot();

            LoadData();

            // Should run only once
            //_ = PolulateStockDataIntoDb("QQQ", 10);
            //_ = PolulateStockDataIntoDb("COST", 10);
            //_ = PolulateStockDataIntoDb("TSLA", 10);
            //_ = PolulateStockDataIntoDb("BRK-B", 10);
            //_ = PolulateStockDataIntoDb("DOGE-USD", 12);
            //_ = PolulateStockDataIntoDb("BTC-USD", 12);
        }

        public async Task PolulateStockDataIntoDb(string ticker, int yearsBack)
        {
            var service = new AssetDataService();
            await service.GetHistoricalDataAsyncAndSaveInDb(ticker, yearsBack);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadData()
        {
            var timer = new Stopwatch();
            timer.Start();
            var allAssetDataFromDb = await GetAllAssetPricesFromDb();
            var qqqData = GetQQQDataFromDb(allAssetDataFromDb);
            var costcoData = GetCostcoDataFromDb(allAssetDataFromDb);
            var brkBData = GetBrkBDataFromDb(allAssetDataFromDb);
            var teslaData = GetTeslaDataFromDb(allAssetDataFromDb);
            var dogeData = GetDogeDataPartiallyFromDb(allAssetDataFromDb);
            var btcData = GetBtcDataPartiallyFromDb(allAssetDataFromDb);
            timer.Stop();
            Debug.WriteLine($"Time taken to get asset data from DB: {timer.ElapsedMilliseconds} ms");


            var costcoPerformance = AssetPerformanceCalculator.Calculate("COST", "Costco", costcoData, true);
            var qqqPerformance = AssetPerformanceCalculator.Calculate("QQQ", "QQQ", qqqData, true);
            var teslaPerformance = AssetPerformanceCalculator.Calculate("TSLA", "Tesla", teslaData);
            var brkBPerformance = AssetPerformanceCalculator.Calculate("BRK-B", "Brk-B", brkBData);


            var btcPerformance = AssetPerformanceCalculator.Calculate("BTC", "Bitcoin", btcData);
            var dogePerformance = AssetPerformanceCalculator.Calculate("DOGE", "Dogecoin", dogeData);

            _assetPerformanceDict.Add(costcoPerformance.Ticker!, costcoPerformance);
            _assetPerformanceDict.Add(qqqPerformance.Ticker!, qqqPerformance);
            _assetPerformanceDict.Add(teslaPerformance.Ticker!, teslaPerformance);
            _assetPerformanceDict.Add(brkBPerformance.Ticker!, brkBPerformance);
            _assetPerformanceDict.Add(btcPerformance.Ticker!, btcPerformance);
            _assetPerformanceDict.Add(dogePerformance.Ticker!, dogePerformance);
        }

        private static AssetData GetQQQDataFromDb(List<AssetPrice> assetPrices)
        {
            var allPrices = GetPriceRange(assetPrices, "QQQ", new DateTime(2020, 12, 1),
                new DateTime(2025, 12, 31));

            var priceAt2025Dec19th = FindPriceByClose(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec16th = FindPriceByClose(new DateTime(2024, 12, 16), allPrices);
            var priceAt2023Dec18th = FindPriceByClose(new DateTime(2023, 12, 18), allPrices);
            var priceAt2022Dec19th = FindPriceByClose(new DateTime(2022, 12, 19), allPrices);
            var priceAt2021Dec20th = FindPriceByClose(new DateTime(2021, 12, 20), allPrices);
            var priceAt2020Dec21st = FindPriceByClose(new DateTime(2020, 12, 21), allPrices);

            var qqqData = new AssetData
            {
                EndPrice = (decimal)priceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = (decimal)priceAt2024Dec16th,
                Date1YearAgo = new DateOnly(2024, 12, 16),
                Price2YearsAgoFromEndDate = (decimal)priceAt2023Dec18th,
                Date2YearsAgo = new DateOnly(2023, 12, 18),
                Price3YearsAgoFromEndDate = (decimal)priceAt2022Dec19th,
                Date3YearsAgo = new DateOnly(2022, 12, 19),
                Price4YearsAgoFromEndDate = (decimal)priceAt2021Dec20th,
                Date4YearsAgo = new DateOnly(2021, 12, 20),
                Price5YearsAgoFromEndDate = (decimal)priceAt2020Dec21st,
                Date5YearsAgo = new DateOnly(2020, 12, 21)
            };
            return qqqData;
        }

        private static AssetData GetCostcoDataFromDb(List<AssetPrice> assetPrices)
        {
            var allPrices = GetPriceRange(assetPrices, "COST", new DateTime(2020, 12, 1),
                new DateTime(2025, 12, 31));

            var priceAt2025Dec19th = FindPriceByClose(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec20th = FindPriceByClose(new DateTime(2024, 12, 20), allPrices);
            var priceAt2023Dec22nd = FindPriceByClose(new DateTime(2023, 12, 22), allPrices);
            var priceAt2022Dec23rd = FindPriceByClose(new DateTime(2022, 12, 23), allPrices);
            var priceAt2021Dec23rd = FindPriceByClose(new DateTime(2021, 12, 23), allPrices);
            var priceAt2020Dec24th = FindPriceByClose(new DateTime(2020, 12, 24), allPrices);

            var costcoData = new AssetData
            {
                EndPrice = (decimal)priceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = (decimal)priceAt2024Dec20th,
                Date1YearAgo = new DateOnly(2024, 12, 20),
                Price2YearsAgoFromEndDate = (decimal)priceAt2023Dec22nd,
                Date2YearsAgo = new DateOnly(2023, 12, 22),
                Price3YearsAgoFromEndDate = (decimal)priceAt2022Dec23rd,
                Date3YearsAgo = new DateOnly(2022, 12, 23),
                Price4YearsAgoFromEndDate = (decimal)priceAt2021Dec23rd,
                Date4YearsAgo = new DateOnly(2021, 12, 23),
                Price5YearsAgoFromEndDate = (decimal)priceAt2020Dec24th,
                Date5YearsAgo = new DateOnly(2020, 12, 24)
            };
            return costcoData;
        }

        private static AssetData GetBrkBDataFromDb(List<AssetPrice> assetPrices)
        {
            var allPrices = GetPriceRange(assetPrices, "BRK-B", new DateTime(2020, 12, 1),
                new DateTime(2025, 12, 31));

            var priceAt2025Dec19th = FindPriceByAdjClose(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec16th = FindPriceByAdjClose(new DateTime(2024, 12, 16), allPrices);
            var priceAt2023Dec18th = FindPriceByAdjClose(new DateTime(2023, 12, 18), allPrices);
            var priceAt2022Dec19th = FindPriceByAdjClose(new DateTime(2022, 12, 19), allPrices);
            var priceAt2021Dec20th = FindPriceByAdjClose(new DateTime(2021, 12, 20), allPrices);
            var priceAt2020Dec21st = FindPriceByAdjClose(new DateTime(2020, 12, 21), allPrices);

            var brkBData = new AssetData
            {
                EndPrice = (decimal)priceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = (decimal)priceAt2024Dec16th,
                Date1YearAgo = new DateOnly(2024, 12, 16),
                Price2YearsAgoFromEndDate = (decimal)priceAt2023Dec18th,
                Date2YearsAgo = new DateOnly(2023, 12, 18),
                Price3YearsAgoFromEndDate = (decimal)priceAt2022Dec19th,
                Date3YearsAgo = new DateOnly(2022, 12, 19),
                Price4YearsAgoFromEndDate = (decimal)priceAt2021Dec20th,
                Date4YearsAgo = new DateOnly(2021, 12, 20),
                Price5YearsAgoFromEndDate = (decimal)priceAt2020Dec21st,
                Date5YearsAgo = new DateOnly(2020, 12, 21)
            };
            return brkBData;
        }

        private static AssetData GetTeslaDataFromDb(List<AssetPrice> assetPrices)
        {
            var allPrices = GetPriceRange(assetPrices, "TSLA", new DateTime(2020, 12, 1),
                new DateTime(2025, 12, 31));

            var priceAt2025Dec19th = FindPriceByAdjClose(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec16th = FindPriceByAdjClose(new DateTime(2024, 12, 16), allPrices);
            var priceAt2023Dec18th = FindPriceByAdjClose(new DateTime(2023, 12, 18), allPrices);
            var priceAt2022Dec19th = FindPriceByAdjClose(new DateTime(2022, 12, 19), allPrices);
            var priceAt2021Dec20th = FindPriceByAdjClose(new DateTime(2021, 12, 20), allPrices);
            var priceAt2020Dec21st = FindPriceByAdjClose(new DateTime(2020, 12, 21), allPrices);

            var teslaData = new AssetData
            {
                EndPrice = (decimal)priceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = (decimal)priceAt2024Dec16th,
                Date1YearAgo = new DateOnly(2024, 12, 16),
                Price2YearsAgoFromEndDate = (decimal)priceAt2023Dec18th,
                Date2YearsAgo = new DateOnly(2023, 12, 18),
                Price3YearsAgoFromEndDate = (decimal)priceAt2022Dec19th,
                Date3YearsAgo = new DateOnly(2022, 12, 19),
                Price4YearsAgoFromEndDate = (decimal)priceAt2021Dec20th,
                Date4YearsAgo = new DateOnly(2021, 12, 20),
                Price5YearsAgoFromEndDate = (decimal)priceAt2020Dec21st,
                Date5YearsAgo = new DateOnly(2020, 12, 21)
            };
            return teslaData;
        }

        /// <summary>
        /// Some of the doge data are too old, yahoo-finance doesn't even track them.
        /// In fact, any data prior to Nov-09-2017 were not there.
        /// </summary>
        /// <returns></returns>
        private static AssetData GetDogeDataPartiallyFromDb(List<AssetPrice> assetPrices)
        {
            // These data can't be retrieved from db since yahoo finance doesn't have them
            const decimal PriceAt2013Dec15th = 0.00056m;
            const double YearSpanFromBirthToEndingDate = 11.29;

            const decimal PriceAt2015Mar25th = 0.0001304m;
            const decimal PriceAt2016Mar25th = 0.0002144m;
            const decimal PriceAt2017Mar25th = 0.0002976m;

            var allPrices = GetPriceRange(assetPrices, "DOGE-USD", new DateTime(2018, 3, 1),
                new DateTime(2025, 3, 31));

            var endingDate = new DateTime(2025, 3, 25);
            var date1YearAgo = endingDate.AddYears(-1);
            var date2YearsAgo = endingDate.AddYears(-2);
            var date3YearsAgo = endingDate.AddYears(-3);
            var date4YearsAgo = endingDate.AddYears(-4);
            var date5YearsAgo = endingDate.AddYears(-5);
            var date6YearsAgo = endingDate.AddYears(-6);
            var date7YearsAgo = endingDate.AddYears(-7);
            var date8YearsAgo = endingDate.AddYears(-8);
            var date9YearsAgo = endingDate.AddYears(-9);
            var date10YearsAgo = endingDate.AddYears(-10);

            var priceAt2025Mar25th = FindPriceByClose(endingDate, allPrices);
            var priceAt2024Mar27th = FindPriceByClose(date1YearAgo, allPrices);
            var priceAt2023Mar26th = FindPriceByClose(date2YearsAgo, allPrices);
            var priceAt2022Mar24th = FindPriceByClose(date3YearsAgo, allPrices);
            var priceAt2021Mar23rd = FindPriceByClose(date4YearsAgo, allPrices);
            var priceAt2020Mar27th = FindPriceByClose(date5YearsAgo, allPrices);
            var priceAt2019Mar27th = FindPriceByClose(date6YearsAgo, allPrices);
            var priceAt2018Mar26th = FindPriceByClose(date7YearsAgo, allPrices);

            var dogeData = new AssetData
            {
                EndPrice = (decimal)priceAt2025Mar25th,
                EndDate = DateOnly.FromDateTime(endingDate),
                BirthDate = new DateOnly(2013, 12, 15),
                StartPriceFromBirth = PriceAt2013Dec15th,
                YearsFromBirthToEndDate = YearSpanFromBirthToEndingDate,
                Price1YearAgoFromEndDate = (decimal)priceAt2024Mar27th,
                Date1YearAgo = DateOnly.FromDateTime(date1YearAgo),
                Price2YearsAgoFromEndDate = (decimal)priceAt2023Mar26th,
                Date2YearsAgo = DateOnly.FromDateTime(date2YearsAgo),
                Price3YearsAgoFromEndDate = (decimal)priceAt2022Mar24th,
                Date3YearsAgo = DateOnly.FromDateTime(date3YearsAgo),
                Price4YearsAgoFromEndDate = (decimal)priceAt2021Mar23rd,
                Date4YearsAgo = DateOnly.FromDateTime(date4YearsAgo),
                Price5YearsAgoFromEndDate = (decimal)priceAt2020Mar27th,
                Date5YearsAgo = DateOnly.FromDateTime(date5YearsAgo),
                Price6YearsAgoFromEndDate = (decimal)priceAt2019Mar27th,
                Date6YearsAgo = DateOnly.FromDateTime(date6YearsAgo),
                Price7YearsAgoFromEndDate = (decimal)priceAt2018Mar26th,
                Date7YearsAgo = DateOnly.FromDateTime(date7YearsAgo),
                Price8YearsAgoFromEndDate = PriceAt2017Mar25th,
                Date8YearsAgo = DateOnly.FromDateTime(date8YearsAgo),
                Price9YearsAgoFromEndDate = PriceAt2016Mar25th,
                Date9YearsAgo = DateOnly.FromDateTime(date9YearsAgo),
                Price10YearsAgoFromEndDate = PriceAt2015Mar25th,
                Date10YearsAgo = DateOnly.FromDateTime(date10YearsAgo)
            };

            return dogeData;
        }

        /// <summary>
        /// Any btc data prior to Sept-17-2014 were not in yahoo finance.
        /// </summary>
        /// <returns></returns>
        private static AssetData GetBtcDataPartiallyFromDb(List<AssetPrice> assetPrices)
        {
            const decimal PriceAt2009Oct15th = 0.00099m;
            const double YearSpanFromBirthToEndingDate = 15.4757;

            var allPrices = GetPriceRange(assetPrices, "BTC-USD", new DateTime(2015, 3, 1),
                new DateTime(2025, 3, 31));

            var endingDate = new DateTime(2025, 3, 26);
            var date1YearAgo = endingDate.AddYears(-1);
            var date2YearsAgo = endingDate.AddYears(-2);
            var date3YearsAgo = endingDate.AddYears(-3);
            var date4YearsAgo = endingDate.AddYears(-4);
            var date5YearsAgo = endingDate.AddYears(-5);
            var date6YearsAgo = endingDate.AddYears(-6);
            var date7YearsAgo = endingDate.AddYears(-7);
            var date8YearsAgo = endingDate.AddYears(-8);
            var date9YearsAgo = endingDate.AddYears(-9);
            var date10YearsAgo = endingDate.AddYears(-10);

            var priceAtEndingDate = FindPriceByClose(endingDate, allPrices);
            var priceAt1YearAgo = FindPriceByClose(date1YearAgo, allPrices);
            var priceAt2YearsAgo = FindPriceByClose(date2YearsAgo, allPrices);
            var priceAt3YearsAgo = FindPriceByClose(date3YearsAgo, allPrices);
            var priceAt4YearsAgo = FindPriceByClose(date4YearsAgo, allPrices);
            var priceAt5YearsAgo = FindPriceByClose(date5YearsAgo, allPrices);
            var priceAt6YearsAgo = FindPriceByClose(date6YearsAgo, allPrices);
            var priceAt7YearsAgo = FindPriceByClose(date7YearsAgo, allPrices);
            var priceAt8YearsAgo = FindPriceByClose(date8YearsAgo, allPrices);
            var priceAt9YearsAgo = FindPriceByClose(date9YearsAgo, allPrices);
            var priceAt10YearsAgo = FindPriceByClose(date10YearsAgo, allPrices);

            var btcData = new AssetData
            {
                EndPrice = (decimal)priceAtEndingDate,
                EndDate = DateOnly.FromDateTime(endingDate),
                BirthDate = new DateOnly(2009, 10, 15),
                StartPriceFromBirth = PriceAt2009Oct15th,
                YearsFromBirthToEndDate = YearSpanFromBirthToEndingDate,
                Price1YearAgoFromEndDate = (decimal)priceAt1YearAgo,
                Date1YearAgo = DateOnly.FromDateTime(date1YearAgo),
                Price2YearsAgoFromEndDate = (decimal)priceAt2YearsAgo,
                Date2YearsAgo = DateOnly.FromDateTime(date2YearsAgo),
                Price3YearsAgoFromEndDate = (decimal)priceAt3YearsAgo,
                Date3YearsAgo = DateOnly.FromDateTime(date3YearsAgo),
                Price4YearsAgoFromEndDate = (decimal)priceAt4YearsAgo,
                Date4YearsAgo = DateOnly.FromDateTime(date4YearsAgo),
                Price5YearsAgoFromEndDate = (decimal)priceAt5YearsAgo,
                Date5YearsAgo = DateOnly.FromDateTime(date5YearsAgo),
                Price6YearsAgoFromEndDate = (decimal)priceAt6YearsAgo,
                Date6YearsAgo = DateOnly.FromDateTime(date6YearsAgo),
                Price7YearsAgoFromEndDate = (decimal)priceAt7YearsAgo,
                Date7YearsAgo = DateOnly.FromDateTime(date7YearsAgo),
                Price8YearsAgoFromEndDate = (decimal)priceAt8YearsAgo,
                Date8YearsAgo = DateOnly.FromDateTime(date8YearsAgo),
                Price9YearsAgoFromEndDate = (decimal)priceAt9YearsAgo,
                Date9YearsAgo = DateOnly.FromDateTime(date9YearsAgo),
                Price10YearsAgoFromEndDate = (decimal)priceAt10YearsAgo,
                Date10YearsAgo = DateOnly.FromDateTime(date10YearsAgo)
            };

            return btcData;
        }

        /// <summary>
        /// If can't find the price on that specific date, find the most recent price
        /// before that date.
        /// </summary>
        private static double FindPriceByClose(DateTime targetDate, List<AssetPrice> assetPrices)
        {
            var lastAvailable = assetPrices
                .Where(p => p.Date.Date <= targetDate.Date) // Only look at today or earlier
                .OrderByDescending(p => p.Date)            // Get the most recent one
                .FirstOrDefault();
            return lastAvailable?.Close ?? 0;
        }

        /// <summary>
        /// If can't find the price on that specific date, find the most recent price
        /// before that date.
        /// </summary>
        private static double FindPriceByAdjClose(DateTime targetDate, List<AssetPrice> assetPrices)
        {
            var lastAvailable = assetPrices
                .Where(p => p.Date.Date <= targetDate.Date)
                .OrderByDescending(p => p.Date)            
                .FirstOrDefault();
            return lastAvailable?.AdjClose ?? 0;
        }

        private static List<AssetPrice> GetPriceRange(List<AssetPrice> assetPrices,
            string ticker, DateTime start, DateTime end)
        {
            return [.. assetPrices
                .Where(p => p.Ticker == ticker && p.Date >= start && p.Date <= end)
                .OrderBy(p => p.Date)];
        }

        private static async Task<List<AssetPrice>> GetAllAssetPricesFromDb()
        {
            using var db = new AppDbContext();
            return await db.AssetPrices.AsNoTracking().ToListAsync();
        }




    }
}

//public class ReturnRatePeriod : INotifyPropertyChanged
//{
//    //public event PropertyChangedEventHandler? PropertyChanged;
//}
