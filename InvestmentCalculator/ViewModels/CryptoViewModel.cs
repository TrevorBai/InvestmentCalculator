using InvestmentCalculators.Models;
using InvestmentCalculators.Services;
using System.ComponentModel;

namespace InvestmentCalculators.ViewModels
{
    public class CryptoViewModel : INotifyPropertyChanged
    {
        public AssetPerformance? BTC { get; private set; }
        public AssetPerformance? DOGE { get; private set; }

        internal void LoadCryptoPerformance(List<AssetPrice> allAssetDataFromDb, DateTime anchorDate)
        {
            // The "Meaty" calculation logic now lives here
            var btcData = GetBtcDataPartiallyFromDb(allAssetDataFromDb);

            var dogeData = GetDogeDataPartiallyFromDb(allAssetDataFromDb);

            // We calculate and assign locally
            BTC = AssetPerformanceCalculator.Calculate("BTC", "Bitcoin", btcData);

            DOGE = AssetPerformanceCalculator.Calculate("DOGE", "Dogecoin", dogeData);

            OnPropertyChanged(nameof(BTC));
            OnPropertyChanged(nameof(DOGE));
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

        private static List<AssetPrice> GetPriceRange(List<AssetPrice> assetPrices,
    string ticker, DateTime start, DateTime end)
        {
            return [.. assetPrices
                .Where(p => p.Ticker == ticker && p.Date >= start && p.Date <= end)
                .OrderBy(p => p.Date)];
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
