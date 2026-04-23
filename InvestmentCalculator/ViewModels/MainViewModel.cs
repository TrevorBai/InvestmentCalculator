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

        // Child ViewModel
        public StockViewModel Stocks { get; } = new();

        private AssetPerformance? GetByTicker(string ticker)
        {
            _assetPerformanceDict.TryGetValue(ticker, out var performance);
            return performance;
        }

        // Cryptos
        public AssetPerformance? BTC => GetByTicker("BTC");
        public AssetPerformance? DOGE => GetByTicker("DOGE");

        // Stocks
        // Etfs
        public AssetPerformance? VOO => GetByTicker("VOO");
        public AssetPerformance? QQQ => GetByTicker("QQQ");
        public AssetPerformance? DIA => GetByTicker("DIA");

        // Individual stocks

        // The Costco property now simply redirects to the child ViewModel
        // This maintains compatibility if your XAML already points to "Costco"
        // Though ideally, you'd update XAML to "Stocks.Costco"
        public AssetPerformance? Costco => Stocks.Costco;
        public AssetPerformance? Tesla => Stocks.Tesla;
        public AssetPerformance? BrkB => Stocks.BrkB;
        public AssetPerformance? Nvidia => Stocks.Nvidia;


        public AssetPerformance? Broadcom => GetByTicker("AVGO");
        public AssetPerformance? Alphabet => GetByTicker("GOOG");

        


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
            //_ = PolulateStockDataIntoDb("VOO", 10);
            //_ = PolulateStockDataIntoDb("QQQ", 10);
            //_ = PolulateStockDataIntoDb("DIA", 10);

            //_ = PolulateStockDataIntoDb("COST", 10);
            //_ = PolulateStockDataIntoDb("TSLA", 10);
            //_ = PolulateStockDataIntoDb("BRK-B", 10);
            //_ = PolulateStockDataIntoDb("NVDA", 10);
            //_ = PolulateStockDataIntoDb("AVGO", 10);
            //_ = PolulateStockDataIntoDb("GOOG", 10);

            //_ = PolulateStockDataIntoDb("BTC-USD", 12);
            //_ = PolulateStockDataIntoDb("DOGE-USD", 12);
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

            var anchorDate = new DateTime(2025, 12, 19);

            // 2. Delegate the "Meaty" parts to the children
            Stocks.LoadStockPerformance(allAssetDataFromDb, anchorDate);

            // Etfs
            var vooData = Get5YrsAssetDataFromDb(allAssetDataFromDb, "VOO",
                new DateTime(2025, 12, 19));
            var qqqData = Get5YrsAssetDataFromDb(allAssetDataFromDb, "QQQ",
                new DateTime(2025, 12, 19));
            var diaData = Get5YrsAssetDataFromDb(allAssetDataFromDb, "DIA",
                new DateTime(2025, 12, 19));

            // Stocks          
            var broadcomData = Get5YrsAssetDataFromDb(allAssetDataFromDb, "AVGO",
                new DateTime(2025, 12, 19));
            var alphabetData = Get5YrsAssetDataFromDb(allAssetDataFromDb, "GOOG",
                new DateTime(2025, 12, 19));

            var dogeData = GetDogeDataPartiallyFromDb(allAssetDataFromDb);
            var btcData = GetBtcDataPartiallyFromDb(allAssetDataFromDb);
            timer.Stop();
            Debug.WriteLine($"Time taken to get asset data from DB: {timer.ElapsedMilliseconds} ms");

            // Etfs
            var vooPerformance = AssetPerformanceCalculator.Calculate("VOO", "S&P 500", vooData, true);
            var qqqPerformance = AssetPerformanceCalculator.Calculate("QQQ", "Nasdaq-100", qqqData,
                true);
            var diaPerformance = AssetPerformanceCalculator.Calculate("DIA", "Dow Jones", diaData,
                true);

            // Individual stocks
            var broadcomPerformance = AssetPerformanceCalculator.Calculate("AVGO", "Broadcom", broadcomData, true);
            var alphabetPerformance = AssetPerformanceCalculator.Calculate("GOOG", "Alphabet", alphabetData, true);

            // Cryptos
            var btcPerformance = AssetPerformanceCalculator.Calculate("BTC", "Bitcoin", btcData);
            var dogePerformance = AssetPerformanceCalculator.Calculate("DOGE", "Dogecoin", 
                dogeData);

            _assetPerformanceDict.Add(vooPerformance.Ticker!, vooPerformance);
            _assetPerformanceDict.Add(qqqPerformance.Ticker!, qqqPerformance);
            _assetPerformanceDict.Add(diaPerformance.Ticker!, diaPerformance);

            _assetPerformanceDict.Add(broadcomPerformance.Ticker!, broadcomPerformance);
            _assetPerformanceDict.Add(alphabetPerformance.Ticker!, alphabetPerformance);

            _assetPerformanceDict.Add(btcPerformance.Ticker!, btcPerformance);
            _assetPerformanceDict.Add(dogePerformance.Ticker!, dogePerformance);
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

            var priceAtEndingDate = FindPriceByClose(endingDate, allPrices);
            var priceAt1YearAgo = FindPriceByClose(date1YearAgo, allPrices);
            var priceAt2YearsAgo = FindPriceByClose(date2YearsAgo, allPrices);
            var priceAt3YearsAgo = FindPriceByClose(date3YearsAgo, allPrices);
            var priceAt4YearsAgo = FindPriceByClose(date4YearsAgo, allPrices);
            var priceAt5YearsAgo = FindPriceByClose(date5YearsAgo, allPrices);
            var priceAt6YearsAgo = FindPriceByClose(date6YearsAgo, allPrices);
            var priceAt7YearsAgo = FindPriceByClose(date7YearsAgo, allPrices);

            var dogeData = new AssetData
            {
                EndPrice = (decimal)priceAtEndingDate,
                EndDate = DateOnly.FromDateTime(endingDate),
                BirthDate = new DateOnly(2013, 12, 15),
                StartPriceFromBirth = PriceAt2013Dec15th,
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


        private static AssetData Get5YrsAssetDataFromDb(List<AssetPrice> assetPrices,
            string assetTicker, DateTime anchorEndingDate, bool byAdjustedClose = false)
        {
            var startRangeDate = new DateTime(anchorEndingDate.Year - 5, anchorEndingDate.Month, 1);
            var endRangeDate = new DateTime(anchorEndingDate.Year, anchorEndingDate.Month, 1)
                .AddMonths(1).AddDays(-1);

            var allPrices = GetPriceRange(assetPrices, assetTicker, startRangeDate, endRangeDate);

            var date1YearAgo = anchorEndingDate.AddYears(-1);
            var date2YearsAgo = anchorEndingDate.AddYears(-2);
            var date3YearsAgo = anchorEndingDate.AddYears(-3);
            var date4YearsAgo = anchorEndingDate.AddYears(-4);
            var date5YearsAgo = anchorEndingDate.AddYears(-5);

            var priceAtEndingDate = byAdjustedClose 
                ? FindPriceByAdjClose(anchorEndingDate, allPrices)
                : FindPriceByClose(anchorEndingDate, allPrices);
            var priceAt1YearAgo = byAdjustedClose 
                ? FindPriceByAdjClose(date1YearAgo, allPrices)
                : FindPriceByClose(date1YearAgo, allPrices);
            var priceAt2YearsAgo = byAdjustedClose 
                ? FindPriceByAdjClose(date2YearsAgo, allPrices) 
                : FindPriceByClose(date2YearsAgo, allPrices);
            var priceAt3YearsAgo = byAdjustedClose 
                ? FindPriceByAdjClose(date3YearsAgo, allPrices) 
                : FindPriceByClose(date3YearsAgo, allPrices);
            var priceAt4YearsAgo = byAdjustedClose 
                ? FindPriceByAdjClose(date4YearsAgo, allPrices) 
                : FindPriceByClose(date4YearsAgo, allPrices);
            var priceAt5YearsAgo = byAdjustedClose 
                ? FindPriceByAdjClose(date5YearsAgo, allPrices) 
                : FindPriceByClose(date5YearsAgo, allPrices);

            var assetData = new AssetData
            {
                EndPrice = (decimal)priceAtEndingDate,
                EndDate = DateOnly.FromDateTime(anchorEndingDate),
                Price1YearAgoFromEndDate = (decimal)priceAt1YearAgo,
                Date1YearAgo = DateOnly.FromDateTime(date1YearAgo),
                Price2YearsAgoFromEndDate = (decimal)priceAt2YearsAgo,
                Date2YearsAgo = DateOnly.FromDateTime(date2YearsAgo),
                Price3YearsAgoFromEndDate = (decimal)priceAt3YearsAgo,
                Date3YearsAgo = DateOnly.FromDateTime(date3YearsAgo),
                Price4YearsAgoFromEndDate = (decimal)priceAt4YearsAgo,
                Date4YearsAgo = DateOnly.FromDateTime(date4YearsAgo),
                Price5YearsAgoFromEndDate = (decimal)priceAt5YearsAgo,
                Date5YearsAgo = DateOnly.FromDateTime(date5YearsAgo)
            };
            return assetData;
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
