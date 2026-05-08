using InvestmentCalculators.Models;
using InvestmentCalculators.Services;
using System.ComponentModel;

namespace InvestmentCalculators.ViewModels
{
    public class StockViewModel : INotifyPropertyChanged
    {
        // Etfs
        public AssetPerformance? VOO { get; private set; }
        public AssetPerformance? QQQ { get; private set; }
        public AssetPerformance? DIA { get; private set; }

        // Individual stocks
        public AssetPerformance? Costco { get; private set; }
        public AssetPerformance? Tesla { get; private set; }
        public AssetPerformance? BrkB { get; private set; }
        public AssetPerformance? Nvidia { get; private set; }
        public AssetPerformance? Broadcom { get; private set; }
        public AssetPerformance? Alphabet { get; private set; }

        internal void LoadStockPerformance(List<AssetPrice> allAssetDataFromDb, DateTime anchorDate)
        {
            // We calculate and assign locally

            // Etfs
            var vooPrices = allAssetDataFromDb.Where(p => p.Ticker == "VOO").OrderBy(p => p.Date).ToList();
            VOO = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR("VOO",
                "S&P 500", vooPrices, true);

            var qqqPrices = allAssetDataFromDb.Where(p => p.Ticker == "QQQ").OrderBy(p => p.Date).ToList();
            QQQ = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR("QQQ",
                "Nasdaq-100", qqqPrices, true);

            var diaPrices = allAssetDataFromDb.Where(p => p.Ticker == "DIA").OrderBy(p => p.Date).ToList();
            DIA = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR("DIA",
                "Dow Jones", diaPrices, true);

            // Individual stocks
            var costcoPrices = allAssetDataFromDb.Where(p => p.Ticker == "COST").OrderBy(p => p.Date).ToList();
            Costco = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR("COST", "Costco", costcoPrices, true);

            var teslaPrices = allAssetDataFromDb.Where(p => p.Ticker == "TSLA").OrderBy(p => p.Date).ToList();
            Tesla = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR("TSLA", "Tesla", teslaPrices);

            var brkBPrices = allAssetDataFromDb.Where(p => p.Ticker == "BRK-B").OrderBy(p => p.Date).ToList();
            BrkB = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR(
                "BRK-B", "Brk-B", brkBPrices);

            var nvidiaPrices = allAssetDataFromDb.Where(p => p.Ticker == "NVDA").OrderBy(p => p.Date).ToList();
            Nvidia = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR(
                "NVDA", "Nvidia", nvidiaPrices, true);

            var broadcomPrices = allAssetDataFromDb.Where(p => p.Ticker == "AVGO").OrderBy(p => p.Date).ToList();
            Broadcom = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR(
                "AVGO", "Broadcom", broadcomPrices, true);    
            
            var alphabetPrices = allAssetDataFromDb.Where(p => p.Ticker == "GOOG").OrderBy(p => p.Date).ToList();
            Alphabet = AssetPerformanceCalculator.CalculateStockPerformanceUsingAverageRollingCAGR(
                "GOOG", "Alphabet", alphabetPrices, true);

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
