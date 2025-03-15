using BankingSystem.Application.Services.Repositories;
using BankingSystem.Core.Repositories;
using BankingSystem.Domain.Entities;
using BankingSystem.Persistence.Contexts;

namespace BankingSystem.Persistence.Repositories
{
    public class IndividualCustomerRepository : EfRepositoryBase<IndividualCustomer, Guid, BankingDbContext>, IIndividualCustomerRepository
    {
        public IndividualCustomerRepository(BankingDbContext context) : base(context)
        {
        }
    }
} 