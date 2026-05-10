using InvestmentCalculators.Models;
using InvestmentCalculators.Services;
using System.ComponentModel;

namespace InvestmentCalculators.ViewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        // Etfs
        public StockPerformance? VOO { get; private set; }
        public StockPerformance? QQQ { get; private set; }
        public StockPerformance? DIA { get; private set; }

        // Individual stocks
        public StockPerformance? Costco { get; private set; }
        public StockPerformance? Tesla { get; private set; }
        public StockPerformance? BrkB { get; private set; }
        public StockPerformance? Nvidia { get; private set; }
        public StockPerformance? Broadcom { get; private set; }
        public StockPerformance? Alphabet { get; private set; }

        internal void LoadStockPerformance(List<AssetPrice> allAssetDataFromDb)
        {
            // Etfs
            var vooPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "VOO").OrderBy(p => p.Date).ToList();
            VOO = AssetPerformanceCalculator.CalculateStockPerformance("VOO",
                "S&P 500", vooPricesInOrder, true);

            var qqqPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "QQQ").OrderBy(p => p.Date).ToList();
            QQQ = AssetPerformanceCalculator.CalculateStockPerformance("QQQ",
                "Nasdaq-100", qqqPricesInOrder, true);

            var diaPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "DIA").OrderBy(p => p.Date).ToList();
            DIA = AssetPerformanceCalculator.CalculateStockPerformance("DIA",
                "Dow Jones", diaPricesInOrder, true);

            // Individual stocks
            var costcoPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "COST").OrderBy(p => p.Date).ToList();
            Costco = AssetPerformanceCalculator.CalculateStockPerformance("COST", "Costco", costcoPricesInOrder, true);

            var teslaPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "TSLA").OrderBy(p => p.Date).ToList();
            Tesla = AssetPerformanceCalculator.CalculateStockPerformance("TSLA", "Tesla", teslaPricesInOrder);

            var brkBPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "BRK-B").OrderBy(p => p.Date).ToList();
            BrkB = AssetPerformanceCalculator.CalculateStockPerformance(
                "BRK-B", "Brk-B", brkBPricesInOrder);

            var nvidiaPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "NVDA").OrderBy(p => p.Date).ToList();
            Nvidia = AssetPerformanceCalculator.CalculateStockPerformance(
                "NVDA", "Nvidia", nvidiaPricesInOrder, true);

            var broadcomPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "AVGO").OrderBy(p => p.Date).ToList();
            Broadcom = AssetPerformanceCalculator.CalculateStockPerformance(
                "AVGO", "Broadcom", broadcomPricesInOrder, true);
            
            var alphabetPricesInOrder = allAssetDataFromDb.Where(p => p.Ticker == "GOOG").OrderBy(p => p.Date).ToList();
            Alphabet = AssetPerformanceCalculator.CalculateStockPerformance(
                "GOOG", "Alphabet", alphabetPricesInOrder, true);

            OnPropertyChanged(nameof(VOO));
            OnPropertyChanged(nameof(QQQ));
            OnPropertyChanged(nameof(DIA));

            OnPropertyChanged(nameof(Costco));
            OnPropertyChanged(nameof(Tesla));
            OnPropertyChanged(nameof(BrkB));
            OnPropertyChanged(nameof(Nvidia));
            OnPropertyChanged(nameof(Broadcom));
            OnPropertyChanged(nameof(Alphabet));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
