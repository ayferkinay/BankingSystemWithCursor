using System;

namespace BankingSystem.Domain.Entities
{
    public class IndividualCustomer : Customer
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string IdentityNumber { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public string? MotherName { get; set; }
        public string? FatherName { get; set; }
        public string Gender { get; set; } = default!;
        public string? Occupation { get; set; }
        public decimal MonthlyIncome { get; set; }
        public bool IsRetired { get; set; }
    }
} 