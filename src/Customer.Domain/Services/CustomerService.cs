using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Services;
using Customer.Domain.Shared;

namespace Customer.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        
        public CustomerService()
        {

        }

        public async Task<CustomerEntity> GetCustomerById(Guid Id)
        {
            var result = new CustomerEntity { Id = Guid.NewGuid(), Name = "João", CPF = "12345678955", BirthDate = DateTime.Now, SobreNome = "Lavor" };
            return result;
        }

        public async Task<DefaultResult> RegisterCustomer(CustomerEntity customer)
        {
            DefaultResult result = new DefaultResult();
            
            bool CustomerAlreadyExists = false;

            CustomerAlreadyExists = true;

            if(CustomerAlreadyExists)
                return new DefaultResult(false,"Cliente ja cadastrado!", "");

            if (string.IsNullOrEmpty(customer.Name))

                return new DefaultResult(false, "Cliente ja cadastrado!", "");


            if (string.IsNullOrEmpty(customer.CPF))

                return new DefaultResult(false, "Cliente ja cadastrado!", "");



            return new DefaultResult(true, "Cliente ja cadastrado!", customer.Id.ToString());

        }

        public async Task<DefaultResult> UpdateCustomer(CustomerEntity customer)
        {
            bool CustomerAlreadyExists = false;

            CustomerAlreadyExists = true;

            if (CustomerAlreadyExists)
                return new DefaultResult(false, "Cliente Inválido ou Inexistente!","");

            if (string.IsNullOrEmpty(customer.Name))
                return new DefaultResult(false,"É necessário informar o nome do cliente!","");

            if (string.IsNullOrEmpty(customer.CPF))
                return new DefaultResult(false,"É necessário informar um CPF válido!","");

            return new DefaultResult(true,"Cliente atualizado com sucesso!", customer.Id.ToString());
        }

        public async Task<DefaultResult> DeleteCustomer(Guid Id)
        {
            bool CustomerExists = false;

            CustomerExists = false;

            if (!CustomerExists)
                return new DefaultResult(false, "Cliente Inválido ou Inexistente!", "");
            return new DefaultResult(true,"Cliente excluido com sucesso!",Id.ToString());
        }

    }
}
