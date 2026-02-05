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
            //_ = PolulateStockDataIntoDb("QQQ", 5);
            //_ = PolulateStockDataIntoDb("COST", 5);
            //_ = PolulateStockDataIntoDb("TSLA", 10);
            //_ = PolulateStockDataIntoDb("BRK-B", 10);
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
            var costcoData = GetCostcoData();
            var qqqData = GetQQQData();
            var timer = new Stopwatch();
            timer.Start();
            var allAssetDataFromDb = await GetAllAssetPricesFromDb();
            var brkBData = GetBrkBDataFromDb(allAssetDataFromDb);
            var teslaData = GetTeslaDataFromDb(allAssetDataFromDb);
            timer.Stop();
            Debug.WriteLine($"Time taken to get BRK-B data from DB: {timer.ElapsedMilliseconds} ms");

            var btcData = GetBtcData();
            var dogeData = GetDogeData();

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

        private static AssetData GetQQQData()
        {
            const decimal PriceAt2025Dec19th = 617.05m;
            const decimal PriceAt2024Dec16th = 538.17m;
            const decimal PriceAt2023Dec18th = 407.08m;
            const decimal PriceAt2022Dec19th = 269.75m;
            const decimal PriceAt2021Dec20th = 380.69m;
            const decimal PriceAt2020Dec21st = 308.92m;

            var qqqData = new AssetData
            {
                EndPrice = PriceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = PriceAt2024Dec16th,
                Date1YearAgo = new DateOnly(2024, 12, 16),
                Price2YearsAgoFromEndDate = PriceAt2023Dec18th,
                Date2YearsAgo = new DateOnly(2023, 12, 18),
                Price3YearsAgoFromEndDate = PriceAt2022Dec19th,
                Date3YearsAgo = new DateOnly(2022, 12, 19),
                Price4YearsAgoFromEndDate = PriceAt2021Dec20th,
                Date4YearsAgo = new DateOnly(2021, 12, 20),
                Price5YearsAgoFromEndDate = PriceAt2020Dec21st,
                Date5YearsAgo = new DateOnly(2020, 12, 21)
            };
            return qqqData;
        }

        private static AssetData GetCostcoData()
        {
            const decimal PriceAt2025Dec19th = 855.62m;
            const decimal PriceAt2024Dec16th = 954.07m;
            const decimal PriceAt2023Dec18th = 671.60m;
            const decimal PriceAt2022Dec19th = 462.65m;
            const decimal PriceAt2021Dec20th = 550.37m;
            const decimal PriceAt2020Dec21st = 364.58m;

            var costcoData = new AssetData
            {
                EndPrice = PriceAt2025Dec19th,
                EndDate = new DateOnly(2025, 12, 19),
                Price1YearAgoFromEndDate = PriceAt2024Dec16th,
                Date1YearAgo = new DateOnly(2024, 12, 16),
                Price2YearsAgoFromEndDate = PriceAt2023Dec18th,
                Date2YearsAgo = new DateOnly(2023, 12, 18),
                Price3YearsAgoFromEndDate = PriceAt2022Dec19th,
                Date3YearsAgo = new DateOnly(2022, 12, 19),
                Price4YearsAgoFromEndDate = PriceAt2021Dec20th,
                Date4YearsAgo = new DateOnly(2021, 12, 20),
                Price5YearsAgoFromEndDate = PriceAt2020Dec21st,
                Date5YearsAgo = new DateOnly(2020, 12, 21)
            };
            return costcoData;
        }

        private static AssetData GetBrkBDataFromDb(List<AssetPrice> assetPrices)
        {
            var allPrices = GetPriceRange(assetPrices, "BRK-B", new DateTime(2020, 12, 1),
                new DateTime(2025, 12, 31));

            var priceAt2025Dec19th = FindPrice(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec16th = FindPrice(new DateTime(2024, 12, 16), allPrices);
            var priceAt2023Dec18th = FindPrice(new DateTime(2023, 12, 18), allPrices);
            var priceAt2022Dec19th = FindPrice(new DateTime(2022, 12, 19), allPrices);
            var priceAt2021Dec20th = FindPrice(new DateTime(2021, 12, 20), allPrices);
            var priceAt2020Dec21st = FindPrice(new DateTime(2020, 12, 21), allPrices);

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

            var priceAt2025Dec19th = FindPrice(new DateTime(2025, 12, 19), allPrices);
            var priceAt2024Dec16th = FindPrice(new DateTime(2024, 12, 16), allPrices);
            var priceAt2023Dec18th = FindPrice(new DateTime(2023, 12, 18), allPrices);
            var priceAt2022Dec19th = FindPrice(new DateTime(2022, 12, 19), allPrices);
            var priceAt2021Dec20th = FindPrice(new DateTime(2021, 12, 20), allPrices);
            var priceAt2020Dec21st = FindPrice(new DateTime(2020, 12, 21), allPrices);

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

        private static double FindPrice(DateTime targetDate, List<AssetPrice> assetPrices)
        {
            return assetPrices.FirstOrDefault(p => 
                p.Date.Date == targetDate.Date)?.AdjClose ?? 0;
        }

        private static AssetData GetBtcData()
        {
            const decimal PriceAt2025Mar26th = 86888.01m;

            const decimal PriceAt2009Oct15th = 0.00099m;
            const double YearSpanFromBirthToEndingDate = 15.4757;

            const decimal PriceAt2015Mar28th = 252.74m;
            const decimal PriceAt2016Mar23th = 418.42m;
            const decimal PriceAt2017Mar28th = 1046.07m;
            const decimal PriceAt2018Mar24th = 8612.8m;
            const decimal PriceAt2019Mar29th = 4092.13m;
            const decimal PriceAt2020Mar24th = 6738.71m;
            const decimal PriceAt2021Mar30th = 58930.27m;
            const decimal PriceAt2022Mar27th = 46821.85m;
            const decimal PriceAt2023Mar24th = 27487.33m;
            const decimal PriceAt2024Mar28th = 70744.79m;

            var btcData = new AssetData
            {
                EndPrice = PriceAt2025Mar26th,
                EndDate = new DateOnly(2025, 3, 26),
                BirthDate = new DateOnly(2009, 10, 15),
                StartPriceFromBirth = PriceAt2009Oct15th,
                YearsFromBirthToEndDate = YearSpanFromBirthToEndingDate,
                Price1YearAgoFromEndDate = PriceAt2024Mar28th,
                Date1YearAgo = new DateOnly(2024, 3, 28),
                Price2YearsAgoFromEndDate = PriceAt2023Mar24th,
                Date2YearsAgo = new DateOnly(2023, 3, 24),
                Price3YearsAgoFromEndDate = PriceAt2022Mar27th,
                Date3YearsAgo = new DateOnly(2022, 3, 27),
                Price4YearsAgoFromEndDate = PriceAt2021Mar30th,
                Date4YearsAgo = new DateOnly(2021, 3, 30),
                Price5YearsAgoFromEndDate = PriceAt2020Mar24th,
                Date5YearsAgo = new DateOnly(2020, 3, 24),
                Price6YearsAgoFromEndDate = PriceAt2019Mar29th,
                Date6YearsAgo = new DateOnly(2019, 3, 29),
                Price7YearsAgoFromEndDate = PriceAt2018Mar24th,
                Date7YearsAgo = new DateOnly(2018, 3, 24),
                Price8YearsAgoFromEndDate = PriceAt2017Mar28th,
                Date8YearsAgo = new DateOnly(2017, 3, 28),
                Price9YearsAgoFromEndDate = PriceAt2016Mar23th,
                Date9YearsAgo = new DateOnly(2016, 3, 23),
                Price10YearsAgoFromEndDate = PriceAt2015Mar28th,
                Date10YearsAgo = new DateOnly(2015, 3, 28)
            };

            return btcData;
        }

        private static AssetData GetDogeData()
        {
            // Data points
            const decimal PriceAt2025Mar25th = 0.1901m;
                  
            const decimal PriceAt2013Dec15th = 0.00056m;
            const double YearSpanFromBirthToEndingDate = 11.29;
                  
            const decimal PriceAt2015Mar25th = 0.0001304m;
            const decimal PriceAt2016Mar25th = 0.0002144m;
            const decimal PriceAt2017Mar25th = 0.0002976m;
            const decimal PriceAt2018Mar26th = 0.003275m;
            const decimal PriceAt2019Mar27th = 0.002087m;
            const decimal PriceAt2020Mar27th = 0.001805m;
            const decimal PriceAt2021Mar23th = 0.05352m;
            const decimal PriceAt2022Mar24th = 0.1366m;
            const decimal PriceAt2023Mar26th = 0.07442m;
            const decimal PriceAt2024Mar27th = 0.1903m;

            var dogeData = new AssetData
            {
                EndPrice = PriceAt2025Mar25th,
                EndDate = new DateOnly(2025, 3, 25),
                BirthDate = new DateOnly(2013, 12, 15),
                StartPriceFromBirth = PriceAt2013Dec15th,
                YearsFromBirthToEndDate = YearSpanFromBirthToEndingDate,
                Price1YearAgoFromEndDate = PriceAt2024Mar27th,
                Date1YearAgo = new DateOnly(2024, 3, 27),
                Price2YearsAgoFromEndDate = PriceAt2023Mar26th,
                Date2YearsAgo = new DateOnly(2023, 3, 26),
                Price3YearsAgoFromEndDate = PriceAt2022Mar24th,
                Date3YearsAgo = new DateOnly(2022, 3, 24),
                Price4YearsAgoFromEndDate = PriceAt2021Mar23th,
                Date4YearsAgo = new DateOnly(2021, 3, 23),
                Price5YearsAgoFromEndDate = PriceAt2020Mar27th,
                Date5YearsAgo = new DateOnly(2020, 3, 27),
                Price6YearsAgoFromEndDate = PriceAt2019Mar27th,
                Date6YearsAgo = new DateOnly(2019, 3, 27),
                Price7YearsAgoFromEndDate = PriceAt2018Mar26th,
                Date7YearsAgo = new DateOnly(2018, 3, 26),
                Price8YearsAgoFromEndDate = PriceAt2017Mar25th,
                Date8YearsAgo = new DateOnly(2017, 3, 25),
                Price9YearsAgoFromEndDate = PriceAt2016Mar25th,
                Date9YearsAgo = new DateOnly(2016, 3, 25),
                Price10YearsAgoFromEndDate = PriceAt2015Mar25th,
                Date10YearsAgo = new DateOnly(2015, 3, 25)
            };

            return dogeData;
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
