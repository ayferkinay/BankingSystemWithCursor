using BankingSystem.Core.Repositories;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Services.Repositories
{
    public interface ICorporateCustomerRepository : IAsyncRepository<CorporateCustomer, Guid>
    {
    }
} 