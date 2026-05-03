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
        // Child ViewModels
        public StockViewModel Stocks { get; } = new();
        public CryptoViewModel Cryptos { get; } = new();

        // Cryptos
        public AssetPerformance? BTC => Cryptos.BTC;
        public AssetPerformance? DOGE => Cryptos.DOGE;

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
            //_ = PolulateAssetDataIntoDb("VOO", 10);
            //_ = PolulateAssetDataIntoDb("QQQ", 10);
            //_ = PolulateAssetDataIntoDb("DIA", 10);

            //_ = PolulateAssetDataIntoDb("COST", 10);
            //_ = PolulateAssetDataIntoDb("TSLA", 10);
            //_ = PolulateAssetDataIntoDb("BRK-B", 10);
            //_ = PolulateAssetDataIntoDb("NVDA", 10);
            //_ = PolulateAssetDataIntoDb("AVGO", 10);
            //_ = PolulateAssetDataIntoDb("GOOG", 10);

            //_ = PolulateAssetDataIntoDb("BTC-USD", 12);
            //_ = PolulateAssetDataIntoDb("DOGE-USD", 12);
        }

        private async void LoadData()
        {
            var timer = new Stopwatch();
            timer.Start();
            var allAssetDataFromDb = await GetAllAssetPricesFromDb();
            timer.Stop();
            Debug.WriteLine($"Time taken to get asset data from DB: {timer.ElapsedMilliseconds} ms");

            var anchorDate = new DateTime(2025, 12, 19);
            // 2. Delegate the "Meaty" parts to the children
            Stocks.LoadStockPerformance(allAssetDataFromDb, anchorDate);
            Cryptos.LoadCryptoPerformance(allAssetDataFromDb, anchorDate);
        }

        private static async Task<List<AssetPrice>> GetAllAssetPricesFromDb()
        {
            using var db = new AppDbContext();
            return await db.AssetPrices.AsNoTracking().ToListAsync();
        }

        public async Task PolulateAssetDataIntoDb(string ticker, int yearsBack)
        {
            var service = new AssetDataService();
            await service.GetHistoricalDataAsyncAndSaveInDb(ticker, yearsBack);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

