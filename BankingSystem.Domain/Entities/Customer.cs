

namespace BankingSystem.Domain.Entities
{
    public abstract class Customer : Entity<Guid>
    {
        public string CustomerNumber { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Address { get; set; } = default!;
        public bool IsActive { get; set; } = true;
        public decimal TotalAssets { get; set; }
        public decimal TotalLiabilities { get; set; }
        public string? Notes { get; set; }
    }
} 