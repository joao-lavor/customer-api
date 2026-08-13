using Customer.Application.DTOs;

namespace Customer.Application.Interfaces
{
    public interface IAppCustomerService
    {
        Task<string> RegisterCustomerAsync(RegisterCustomerDTO dto);
        Task<string> UpdateCustomerAsync(UpdateCustomerDTO dto);
        Task<string> DeleteCustomerAsync(Guid id);
        Task<CustomerResponseDTO> GetCustomerByIdAsync(Guid id);


    }
}
