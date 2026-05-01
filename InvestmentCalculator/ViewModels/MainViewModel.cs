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

        // Child ViewModels
        public StockViewModel Stocks { get; } = new();
        public CryptoViewModel Cryptos { get; } = new();

        private AssetPerformance? GetByTicker(string ticker)
        {
            _assetPerformanceDict.TryGetValue(ticker, out var performance);
            return performance;
        }

        // Cryptos
        public AssetPerformance? BTC => Cryptos.BTC;
        public AssetPerformance? DOGE => GetByTicker("DOGE");

        // Etfs
        public AssetPerformance? VOO => Stocks.VOO;
        public AssetPerformance? QQQ => Stocks.QQQ;
        public AssetPerformance? DIA => Stocks.DIA;

        // Individual stocks
        public AssetPerformance? Costco => Stocks.Costco;
        public AssetPerformance? Tesla => Stocks.Tesla;
        public AssetPerformance? BrkB => Stocks.BrkB;
        public AssetPerformance? Nvidia => Stocks.Nvidia;
        public AssetPerformance? Broadcom => Stocks.Broadcom;
        public AssetPerformance? Alphabet => Stocks.Alphabet;


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
            Cryptos.LoadCryptoPerformance(allAssetDataFromDb, anchorDate);

            var dogeData = GetDogeDataPartiallyFromDb(allAssetDataFromDb);

            timer.Stop();
            Debug.WriteLine($"Time taken to get asset data from DB: {timer.ElapsedMilliseconds} ms");

            // Cryptos
            var dogePerformance = AssetPerformanceCalculator.Calculate("DOGE", "Dogecoin", 
                dogeData);

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

