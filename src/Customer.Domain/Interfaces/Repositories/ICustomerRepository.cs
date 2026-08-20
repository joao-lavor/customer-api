using Customer.Domain.Entities;

namespace Customer.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<bool>RegisterCustomer(CustomerEntity entity);
        Task<bool> UpdateCustomer(CustomerEntity entity);
        Task<CustomerEntity> GetCustomerById(Guid id);
        Task<CustomerEntity> GetCustomerByCpf(string cpf);
        Task<IEnumerable<CustomerEntity>> GetCustomers();
        Task<bool> DeleteCustomerById(Guid id);
        Task<bool> ExistsByCpfAsync(string cpf);


    }
}
