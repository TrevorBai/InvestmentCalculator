namespace InvestmentCalculator.ViewModels.Utilities
{
    internal class CAGRViewModel : CAGRCalculator
    {
        public string? CAGRFromBirth { get; private set; }
        public string? CAGR10Years { get; private set; }
        public string? CAGR9Years { get; private set; }
        public string? CAGR8Years { get; private set; }
        public string? CAGR7Years { get; private set; }
        public string? CAGR6Years { get; private set; }
        public string? CAGR5Years { get; private set; }
        public string? CAGR4Years { get; private set; }
        public string? CAGR3Years { get; private set; }
        public string? CAGR2Years { get; private set; }
        public string? CAGR1Year { get; private set; }

        protected CAGRViewModel(double endValue, double value10YearsAgoFromEndDate, double value9YearsAgoFromEndDate, double value8YearsAgoFromEndDate, double value7YearsAgoFromEndDate, double value6YearsAgoFromEndDate, double value5YearsAgoFromEndDate, double value4YearsAgoFromEndDate, double value3YearsAgoFromEndDate, double value2YearsAgoFromEndDate, double value1YearAgoFromEndDate, double startValueFromBirth, double yearsFromBirthToEndDate,
            bool calc10YearsAndFromBirthCAGRs, bool cald5YearsCAGRs) : 
            base(endValue, value10YearsAgoFromEndDate, value9YearsAgoFromEndDate, value8YearsAgoFromEndDate, value7YearsAgoFromEndDate, value6YearsAgoFromEndDate, value5YearsAgoFromEndDate, value4YearsAgoFromEndDate, value3YearsAgoFromEndDate, value2YearsAgoFromEndDate, value1YearAgoFromEndDate, startValueFromBirth, yearsFromBirthToEndDate)
        {
            if (calc10YearsAndFromBirthCAGRs) Load10YearsAndFromBirthCAGRsData();
            if (cald5YearsCAGRs) Load5YearsCAGRsData();
        }

        private void Load10YearsAndFromBirthCAGRsData()
        {
            CAGRFromBirth = GetCAGRFromBirth();
            CAGR10Years = GetCAGR10Years();
            CAGR9Years = GetCAGR9Years();
            CAGR8Years = GetCAGR8Years();
            CAGR7Years = GetCAGR7Years();
            CAGR6Years = GetCAGR6Years();
            CAGR5Years = GetCAGR5Years();
            CAGR4Years = GetCAGR4Years();
            CAGR3Years = GetCAGR3Years();
            CAGR2Years = GetCAGR2Years();
            CAGR1Year = GetCAGR1Year();
        }

        private void Load5YearsCAGRsData()
        {
            CAGR5Years = GetCAGR5Years();
            CAGR4Years = GetCAGR4Years();
            CAGR3Years = GetCAGR3Years();
            CAGR2Years = GetCAGR2Years();
            CAGR1Year = GetCAGR1Year();
        }

    }
}
