using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Repositories;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Shared;
using System.Net.WebSockets;

namespace Customer.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomerEntity> GetCustomerById(Guid Id)
        {
            return await _repository.GetCustomerById(Id);
        }

        public async Task<DefaultResult> RegisterCustomer(CustomerEntity customer)
        {
            bool CustomerAlreadyExists = false;

            if (CustomerAlreadyExists)
                return new DefaultResult(false, "Cliente ja cadastrado!", "");

            if (string.IsNullOrEmpty(customer.Name))

                return new DefaultResult(false, "É necessário informar o nome do cliente", "");


            if (string.IsNullOrEmpty(customer.CPF))

                return new DefaultResult(false, "É necessário informar um CPF válido", "");

            var result = await _repository.RegisterCustomer(customer);

            if (result)
                return new DefaultResult(true, "Cliente cadastrado com sucesso!", customer.Id.ToString());

            return new DefaultResult(false, "Erro ao cadastrar o cliente!", "");
        }

        public async Task<DefaultResult> UpdateCustomer(CustomerEntity customer)
        {
            bool CustomerAlreadyExists = false;

            if (CustomerAlreadyExists)
                return new DefaultResult(false, "Cliente Inválido ou Inexistente!", "");

            if (string.IsNullOrEmpty(customer.Name))
                return new DefaultResult(false, "É necessário informar o nome do cliente!", "");

            if (string.IsNullOrEmpty(customer.CPF))
                return new DefaultResult(false, "É necessário informar um CPF válido!", "");

            var result = await _repository.UpdateCustomer(customer);

            if (result)
                return new DefaultResult(true, "Cliente atualizado com sucesso!", customer.Id.ToString());

            return new DefaultResult(false, "Erro ao atualizar Cliente!","");
        }

        public async Task<DefaultResult> DeleteCustomer(Guid Id)
        {
            bool CustomerExists = true;

            if (!CustomerExists)
                return new DefaultResult(false, "Cliente Inválido ou Inexistente!", "");
                
            var result = await _repository.DeleteCustomerById(Id);

            if (!result)
                return new DefaultResult(false, "Falha ao excluir cliente!", Id.ToString());

            return new DefaultResult(true, "Cliente excluido com sucesso!", Id.ToString());
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync() 
        {
            return await _repository.GetCustomers();
        }
    }
}
