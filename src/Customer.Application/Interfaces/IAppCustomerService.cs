using Customer.Application.DTOs;

namespace Customer.Application.Interfaces
{
    public interface IAppCustomerService
    {
        Task<BaseResponse> RegisterCustomerAsync(RegisterCustomerDTO dto);
        Task<BaseResponse> UpdateCustomerAsync(UpdateCustomerDTO dto);
        Task<BaseResponse> DeleteCustomerAsync(Guid id);
        Task<BaseResponse> GetCustomerByIdAsync(Guid id);
        Task<BaseResponse> GetCustomersAsync();


    }
}
