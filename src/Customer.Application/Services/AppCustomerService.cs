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
        public async Task<BaseResponse> RegisterCustomerAsync(RegisterCustomerDTO dto)
        {
            var response = new BaseResponse();
            var entity = new CustomerEntity();
            var data = entity.NewCustomer(dto.Name, dto.LastName, dto.CPF, dto.BirthDate);
            var result = await _customerDomainService.RegisterCustomer(data);

            if (result.Sucess)
            {
                response = new BaseResponse { Data = result, Success = result.Sucess };
                response.Notifications = null;
            }
            else
                response.AddNotification(result.Mensagem);
            return response;
        }

        public async Task<BaseResponse> UpdateCustomerAsync(UpdateCustomerDTO dto)
        {
            var response = new BaseResponse();
            var entity = new CustomerEntity();
            var data = entity.UpdateCustomer(dto.Id, dto.Name, dto.LastName, dto.CPF, dto.BirthDate, dto.Active);
            var result = await _customerDomainService.UpdateCustomer(data);

            if (result.Sucess)
            {
                response = new BaseResponse { Data = result, Success = result.Sucess };
                response.Notifications = null;
            }
            else
                response.AddNotification(result.Mensagem);
            return response;
        }

        public async Task<BaseResponse> DeleteCustomerAsync(Guid id)
        {
            var response = new BaseResponse();
            var result = await _customerDomainService.DeleteCustomer(id);

            if (result.Sucess)
            {
                response = new BaseResponse { Data = result, Success = result.Sucess };
                response.Notifications = null;
            }
            else
                response.AddNotification(result.Mensagem);
            return response;
        }

        public async Task<BaseResponse> GetCustomerByIdAsync(Guid id)
        {
            var response = new BaseResponse();
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

            if (result != null)
            {
                response = new BaseResponse { Data = data, Success = true };
                response.Notifications = null;
            }
            else 
            {
                response.Notifications = null;
            }

            return response;
        }

        public async Task<BaseResponse> GetCustomersAsync()
        {
            var response = new BaseResponse();
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

            if (result != null)
            {
                response = new BaseResponse { Data = data, Success = true };
                response.Notifications = null;
            }
            else
            {
                response.Notifications = null;
            }

            return response;
        }


    }
}
