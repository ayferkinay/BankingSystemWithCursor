namespace BankingSystem.Domain.Entities
{
    public class CorporateCustomer : Customer
    {
        public string CompanyName { get; set; } = default!;
        public string TaxNumber { get; set; } = default!;
        public string TaxOffice { get; set; } = default!;
        public string CompanyType { get; set; } = default!;
        public string? CommercialRegistrationNumber { get; set; }
        public int EmployeeCount { get; set; }
        public decimal AnnualRevenue { get; set; }
        public int YearEstablished { get; set; }
        public string? AuthorizedPersonName { get; set; }
        public string? AuthorizedPersonPosition { get; set; }
        public string? SectorOfActivity { get; set; }
    }
} 