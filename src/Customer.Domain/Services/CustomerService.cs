using Customer.Domain.Entities;
using Customer.Domain.EnumExtensions;
using Customer.Domain.Enums;
using Customer.Domain.Interfaces.Repositories;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Shared;
using Customer.Domain.Validators;
using System.Net.Http.Headers;

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
            var existCustomer = await _repository.ExistsByCpfAsync(customer.CPF);

            if (existCustomer)
                return new DefaultResult(false, CustomerEnum.CustomerRegistration_DuplicateCustomer.GetDescription(), "");

            var validation = new RegisterCustomerValidation();
            var resultValidation = validation.Validate(customer);

            if (!resultValidation.IsValid)
                return new DefaultResult(false, resultValidation.Errors.First().ErrorMessage, "");

            var result = await _repository.RegisterCustomer(customer);

            if (result)
                return new DefaultResult(true, CustomerEnum.CustomerRegistration_Successful.GetDescription(), customer.Id.ToString());

            return new DefaultResult(false, CustomerEnum.CustomerRegistration_Failed.GetDescription(), "");
        }

        public async Task<DefaultResult> UpdateCustomer(CustomerEntity customer)
        {
            var existCustomer = await _repository.GetCustomerById(customer.Id);

            if (existCustomer == null)
                return new DefaultResult(false, CustomerEnum.Customer_NotFound.GetDescription(), "");

            var customerByCpf = await _repository.GetCustomerByCpf(customer.CPF);

            if(customerByCpf != null && customerByCpf.Id != customer.Id)
                return new DefaultResult(false, CustomerEnum.CustomerUpdate_CPF_AlreadyRegistered.GetDescription(), "");

            var validation = new UpdateCustomerValidation();
            var resultValidation = validation.Validate(customer);

            if (!resultValidation.IsValid)
                return new DefaultResult(false, resultValidation.Errors.First().ErrorMessage, "");

            var result = await _repository.UpdateCustomer(customer);

            if (result)
                return new DefaultResult(true, CustomerEnum.CustomerUpdate_Successful.GetDescription(), customer.Id.ToString());

            return new DefaultResult(false, CustomerEnum.CustomerUpdate_Failed.GetDescription(), "");
        }

        public async Task<DefaultResult> DeleteCustomer(Guid Id)
        {
            var customerAlreadyRegistered = await _repository.GetCustomerById(Id);

            if (customerAlreadyRegistered == null)
                return new DefaultResult(false, CustomerEnum.Customer_NotFound.GetDescription(), "");

            var result = await _repository.DeleteCustomerById(Id);

            if (!result)
                return new DefaultResult(false, CustomerEnum.CustomerDelete_Failed.GetDescription(), Id.ToString());

            return new DefaultResult(true, CustomerEnum.CustomerDelete_Sucessful.GetDescription(), Id.ToString());
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync()
        {
            return await _repository.GetCustomers();
        }
    }
}
