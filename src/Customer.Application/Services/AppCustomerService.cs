using Customer.Application.DTOs;
using Customer.Application.Interfaces;
using Customer.Domain.Entities;
using Customer.Domain.Interfaces.Services;

namespace Customer.Application.Services
{
    public class AppCustomerService : IAppCustomerService
    {
        private readonly ICustomerService _customerDomainService;
        public AppCustomerService(ICustomerService customerDomainService)
        {
            _customerDomainService = customerDomainService;
        }
        public async Task<string> RegisterCustomerAsync(RegisterCustomerDTO dto)
        {
            var entity = new CustomerEntity();
            var data = entity.NewCustomer(dto.Name, dto.LastName, dto.CPF, dto.BirthDate);
            var result = await _customerDomainService.RegisterCustomer(data);
            return result.Mensagem;
        }

        public async Task<string> UpdateCustomerAsync(UpdateCustomerDTO dto)
        {
            var entity = new CustomerEntity();
            var data = entity.UpdateCustomer(dto.Id, dto.Name, dto.LastName, dto.CPF, dto.BirthDate, dto.Active);
            var result = await _customerDomainService.UpdateCustomer(data);
            return result.Mensagem;
        }

        public async Task<string> DeleteCustomerAsync(Guid id)
        {
            var result = await _customerDomainService.DeleteCustomer(id);
            return result.Mensagem;
        }

        public async Task<CustomerResponseDTO> GetCustomerByIdAsync(Guid id)
        {
            var data = new CustomerResponseDTO();
            var result = await _customerDomainService.GetCustomerById(id);
            
            if (result != null)
            {
                data = new CustomerResponseDTO
                {
                    Id = result.Id,
                    CPF = result.CPF,
                    Name = result.Name,
                    LastName = result.LastName,
                    BirthDate = result.BirthDate,
                    Active = result.Active
                };
            }
            return data;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetCustomersAsync()
        {
            var data = new List<CustomerResponseDTO>();

            var result = await _customerDomainService.GetCustomersAsync();

            foreach(var item in result)
            {
               var customer = new CustomerResponseDTO
                {
                    Id = item.Id,
                    CPF = item.CPF,
                    Name = item.Name,
                    LastName = item.LastName,
                    BirthDate = item.BirthDate,
                    Active = item.Active
                };
                data.Add(customer);
            }
            return data;
        }


    }
}
