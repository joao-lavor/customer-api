using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Services;

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

        public async Task<string> RegisterCustomer(CustomerEntity customer)
        {
            bool CustomerAlreadyExists = false;

            CustomerAlreadyExists = true;

            if(CustomerAlreadyExists)
                return "Cliente já cadastrado!";

            if (string.IsNullOrEmpty(customer.Name))
                return "É necessário informar o nome do cliente!";

            if (string.IsNullOrEmpty(customer.CPF))
                return "É necessário informar um CPF válido!";

            return "Cliente cadastrado com sucesso!";
        }

        public async Task<string> UpdateCustomer(CustomerEntity customer)
        {
            bool CustomerAlreadyExists = false;

            CustomerAlreadyExists = true;

            if (CustomerAlreadyExists)
                return "Cliente Inválido ou Inexistente!";

            if (string.IsNullOrEmpty(customer.Name))
                return "É necessário informar o nome do cliente!";

            if (string.IsNullOrEmpty(customer.CPF))
                return "É necessário informar um CPF válido!";

            return "Cliente atualizado com sucesso!";
        }

        public async Task<string> DeleteCustomer(Guid Id)
        {
            bool CustomerExists = false;

            CustomerExists = false;

            if (!CustomerExists)
                return "Cliente Inexistente ou Inválido!";
            return "Cliente excluido com sucesso!";
        }

    }
}
