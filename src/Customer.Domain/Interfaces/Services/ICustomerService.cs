
using Customer.Domain.Entities;

namespace Customer.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<CustomerEntity> GetCustomerById(Guid Id);
        Task<string> RegisterCustomer(CustomerEntity customer);
        Task<string> UpdateCustomer(CustomerEntity customer);
        Task<string> DeleteCustomer(Guid Id);

    }
}
