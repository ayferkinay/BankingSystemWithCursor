using BankingSystem.Application.Services.Repositories;
using BankingSystem.Core.Repositories;
using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.Contexts;

namespace BankingSystem.Persistence.Repositories
{
    public class CorporateCustomerRepository : EfRepositoryBase<CorporateCustomer, Guid, BankingDbContext>, ICorporateCustomerRepository
    {
        public CorporateCustomerRepository(BankingDbContext context) : base(context)
        {
        }
    }
} 