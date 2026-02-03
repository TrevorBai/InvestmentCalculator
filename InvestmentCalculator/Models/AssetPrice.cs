using System.ComponentModel.DataAnnotations;

namespace InvestmentCalculators.Models
{
    internal class AssetPrice
    {
        [Key] // This makes 'Id' the primary key
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string? Ticker { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public double AdjClose { get; set; }

        public double Close { get; set; }
    }
}
