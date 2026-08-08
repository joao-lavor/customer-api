
using Customer.Domain.Entities;
using Customer.Domain.Shared;

namespace Customer.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerEntity> GetCustomerById(Guid Id);
        Task<DefaultResult> RegisterCustomer(CustomerEntity customer);
        Task<DefaultResult> UpdateCustomer(CustomerEntity customer);
        Task<DefaultResult> DeleteCustomer(Guid Id);

    }
}
