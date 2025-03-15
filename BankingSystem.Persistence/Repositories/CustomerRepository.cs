using BankingSystem.Application.Services.Repositories;
using BankingSystem.Core.Repositories;
using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.Contexts;

namespace BankingSystem.Persistence.Repositories
{
    public class CustomerRepository : EfRepositoryBase<Customer, Guid, BankingDbContext>, ICustomerRepository
    {
        public CustomerRepository(BankingDbContext context) : base(context)
        {
        }
    }
} 